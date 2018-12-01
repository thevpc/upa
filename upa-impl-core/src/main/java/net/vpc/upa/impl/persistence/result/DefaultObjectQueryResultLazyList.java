package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.exceptions.IllegalUPAArgumentException;
import net.vpc.upa.impl.DefaultKey;
import net.vpc.upa.impl.DefaultPersistenceUnit;
import net.vpc.upa.impl.UPAImplDefaults;
import net.vpc.upa.impl.UPAImplKeys;
import net.vpc.upa.impl.cache.EntityCollectionCache;
import net.vpc.upa.impl.cache.LRUCacheMap;
import net.vpc.upa.impl.persistence.NativeField;
import net.vpc.upa.impl.persistence.QueryExecutor;
import net.vpc.upa.impl.upql.BindingId;
import net.vpc.upa.impl.upql.NativeFieldByBindingIdComparator;
import net.vpc.upa.impl.util.*;
import net.vpc.upa.persistence.QueryResult;
import net.vpc.upa.persistence.ResultMetaData;

import java.util.*;
import java.util.logging.Logger;

import net.vpc.upa.exceptions.UnexpectedException;

/**
 * Created by vpc on 6/18/16.
 */
public class DefaultObjectQueryResultLazyList<T> extends QueryResultLazyList<T> implements QueryResultParserHelper {
    public static final CacheMap<NamedId, ResultObject> NO_RESULT_CACHE = new NoCacheMap<NamedId, ResultObject>();
    private static final Logger log = Logger.getLogger(DefaultObjectQueryResultLazyList.class.getName());
    boolean workspace_hasNext = true;
    Map<String, Set<Object>> workspace_missingObjects = new HashMap<String, Set<Object>>();
    List<LazyResult> workspace_todos = new LinkedList<>();
    LinkedList<T> workspace_available = new LinkedList<T>();
    int workspace_missingObjectsCount = 0;
    int workspace_bulkSize = UPAImplDefaults.QueryHints_REDUCE_BUFFER_SIZE;
    boolean workspace_hasTodos = false;
    PersistenceUnit persistenceUnit;
    private boolean updatable;
    private boolean itemAsDocument;
    private ResultMetaData metaData;
    private CacheMap<NamedId, ResultObject> referencesCache;
    private Map<String, Object> hints;
    private ObjectFactory ofactory;
    private ResultFieldFamily[] columnFamilies;
    private QueryResultItemBuilder resultBuilder;
    private EntityCollectionCache entityCollectionCache;
    private long rowIndex = -1;

    public DefaultObjectQueryResultLazyList(
            PersistenceUnit pu,
            QueryExecutor queryExecutor,
            boolean itemAsDocument,
            boolean updatable,
            QueryResultItemBuilder resultBuilder
    ) {
        super(queryExecutor);
        this.itemAsDocument = itemAsDocument;
        this.entityCollectionCache = ((DefaultPersistenceUnit) pu).getPersistenceUnitCache();
        this.resultBuilder = resultBuilder;
        metaData = queryExecutor.getMetaData();
        hints = queryExecutor.getHints();
        if (hints == null) {
            hints = new HashMap<String, Object>();
        } else {
            hints = new HashMap<String, Object>(hints);
        }
        int supportCacheSize = UPAUtils.convertToInt(hints.get(QueryHints.QUERY_CACHE_SIZE), UPAImplDefaults.QueryHints_CACHE_SIZE);
        if (supportCacheSize < 0) {
            supportCacheSize = UPAImplDefaults.QueryHints_CACHE_SIZE;
        }
        if (supportCacheSize > 0) {
            CacheMap<NamedId, ResultObject> sharedCache = (CacheMap<NamedId, ResultObject>) hints.get(UPAImplKeys.QueryHints_queryCache);
            if (sharedCache == null) {
                sharedCache = new LRUCacheMap<NamedId, ResultObject>(supportCacheSize);
                hints.put(UPAImplKeys.QueryHints_queryCache, sharedCache);
            }
            referencesCache = sharedCache;
        } else {
            referencesCache = NO_RESULT_CACHE;
        }
        LinkedHashMap<BindingId, ResultFieldFamily> bindingToTypeInfos0 = new LinkedHashMap<BindingId, ResultFieldFamily>();
        ofactory = pu.getFactory();
        persistenceUnit = pu;
        NativeField[] fields = queryExecutor.getFields();

        //reorder fields by binding so that parent bindings are always seen first!
        SortPreserveIndexIndexedItem[] indexed = UPAUtils.sortPreserveIndex0(fields, NativeFieldByBindingIdComparator.INSTANCE);

        for (int i = 0; i < indexed.length; i++) {
            NativeField nativeField = (NativeField) indexed[i].getItem();
            ResultFieldParseData f = new ResultFieldParseData();
            f.dbIndex = indexed[i].getIndex();
            f.nativeField = nativeField;
            f.name = nativeField.getName();
            f.binding = nativeField.getBindingId();
            f.field = nativeField.getField();
            f.parentBindingReferrer = nativeField.getParentBindingEntity();

            if (f.parentBindingReferrer == null && f.field != null) {
                //work around!
                f.parentBindingReferrer = f.field.getEntity();
            }

            BindingId parentBinding = f.binding.getParent();
            ResultFieldFamily columnFamily = bindingToTypeInfos0.get(parentBinding);
            if (columnFamily == null) {
                ResultFieldFamily ancestor = null;
                if ((parentBinding == null || parentBinding.getParent() == null)) {
                    //do nothing
                } else {
                    ancestor = bindingToTypeInfos0.get(parentBinding.getParent());
                    if (ancestor == null) {
                        throw new IllegalUPAArgumentException("Unexpected");
                    }
                }
                if (ancestor != null) {
                    if (ancestor.entity == null) {
                        throw new IllegalUPAArgumentException("Unsupported");
                    } else {
                        Field field = ancestor.entity.getField(parentBinding.getName());
                        Relationship manyToOneRelationship = field.getManyToOneRelationship();
                        if (manyToOneRelationship != null) {
                            columnFamily = new ResultFieldFamily(parentBinding, manyToOneRelationship.getTargetEntity(), ofactory);
                            columnFamily.documentType = itemAsDocument;
                            bindingToTypeInfos0.put(parentBinding, columnFamily);
                        } else {
                            throw new IllegalUPAArgumentException("Unsupported");
                        }
                    }
                } else {
                    if (f.parentBindingReferrer != null && parentBinding != null) {
                        columnFamily = new ResultFieldFamily(parentBinding, f.parentBindingReferrer, ofactory);
                        columnFamily.documentType = itemAsDocument;
                        bindingToTypeInfos0.put(parentBinding, columnFamily);
                    } else {
                        columnFamily = new ResultFieldFamily(parentBinding, ofactory);
                        columnFamily.documentType = itemAsDocument;//n.contains(".") ? relationAsDocument : defaultsToDocument;
                        bindingToTypeInfos0.put(parentBinding, columnFamily);
                    }
                }
                columnFamily.preferLoadLater = f.nativeField.isPreferLoadLater();
                columnFamily.partialObject = f.nativeField.isPartialObject();
            }
            f.columnFamily = columnFamily;
            if (f.field != null && f.field.isId()) {
                columnFamily.idFields.add(f);
            } else {
                columnFamily.nonIdFields.add(f);
            }
            columnFamily.fieldsMap.put(f.binding.getName(), f);
        }
        columnFamilies = bindingToTypeInfos0.values().toArray(new ResultFieldFamily[bindingToTypeInfos0.size()]);
        for (ResultFieldFamily columnFamily : columnFamilies) {
            if (columnFamily.entity != null) {
                Set<String> visitedIds = new HashSet<String>();
                Set<String> expectedIds = new HashSet<String>();
                List<Field> idFields = columnFamily.entity.getIdFields();
                for (Field field : idFields) {
                    expectedIds.add(field.getName());
                }
                for (Iterator<ResultFieldParseData> iterator = columnFamily.idFields.iterator(); iterator.hasNext(); ) {
                    ResultFieldParseData field = iterator.next();
                    //id field defined twice, not so reasonable, but may happen
                    //if user defines by him self columns
                    String fieldName = field.field.getName();
                    if (visitedIds.contains(fieldName)) {
                        iterator.remove();
                        columnFamily.nonIdFields.add(field);
                    } else if (expectedIds.contains(fieldName)) {
                        visitedIds.add(fieldName);
                        expectedIds.remove(fieldName);
                    } else {
                        //should never happen
                        throw new IllegalUPAArgumentException("Should never Happen");
                    }
                }
                ResultFieldParseData[] nonOrderedIdFields = columnFamily.idFields.toArray(new ResultFieldParseData[columnFamily.idFields.size()]);

                //now re-order id fields
                for (int i = 0; i < idFields.size(); i++) {
                    for (int j = 0; j < nonOrderedIdFields.length; j++) {
                        if (columnFamily.idFields.get(j).field.getName().equals(idFields.get(i).getName())) {
                            nonOrderedIdFields[i] = columnFamily.idFields.get(j);
                            break;
                        }
                    }
                }

                if (expectedIds.isEmpty() && !columnFamily.idFields.isEmpty()) {
                    columnFamily.identifiable = true;
                }
            }
            if (columnFamily.binding == null) {
                columnFamily.parser = ColumnFamilyParserNoBindingResult.INSTANCE;
            } else if (columnFamily.entity != null && columnFamily.identifiable) {
                if (columnFamily.preferLoadLater) {
                    if (columnFamily.idFields.size() == 1) {
                        columnFamily.parser = ColumnFamilyParserSingleIdExternalTodoEntityResult.INSTANCE;
                    } else {
                        columnFamily.parser = ColumnFamilyParserMultiIdExternalTodoEntityResult.INSTANCE;
                    }
                } else {
                    if (columnFamily.idFields.size() == 1) {
                        columnFamily.parser = ColumnFamilyParserSingleIdEntityResult.INSTANCE;
                    } else {
                        columnFamily.parser = ColumnFamilyParserMultiIdEntityResult.INSTANCE;
                    }
                }
            } else if (columnFamily.entity != null && !columnFamily.identifiable) {
                columnFamily.parser = ColumnFamilyParserNoIdEntityResult.INSTANCE;
            } else {
                throw new IllegalUPAArgumentException("Unsupported binding " + columnFamily.binding);
            }
        }
        for (ResultFieldFamily columnFamily : columnFamilies) {
            columnFamily.fieldsArray = columnFamily.nonIdFields.toArray(new ResultFieldParseData[columnFamily.nonIdFields.size()]);
        }

        this.updatable = updatable;
    }


    public void addWorkspaceMissingObject(String entity, Object id) {
        Set<Object> list = workspace_missingObjects.get(entity);
        if (list == null) {
            list = new HashSet<Object>();
            workspace_missingObjects.put(entity, list);
        }
        if (list.add(id)) {
            workspace_missingObjectsCount++;
        }
    }

    private void addWorkspaceTodo(LazyResult result) {
        workspace_todos.add(result);
        workspace_hasTodos = true;
    }

    private void reduceWorkspace() {
        if (workspace_missingObjectsCount > 0) {
            EntityCollectionCache c = ((DefaultPersistenceUnit) persistenceUnit).getPersistenceUnitCache();
            CacheMap<NamedId, ResultObject> referencesCache = getReferencesCache();
            while (!workspace_missingObjects.isEmpty()) {
                for (Map.Entry<String, Set<Object>> e : workspace_missingObjects.entrySet()) {
                    String entityName = e.getKey();
                    Entity entity = persistenceUnit.getEntity(entityName);
                    EntityBuilder builder = entity.getBuilder();
                    Set<Object> itemsToReduce = e.getValue();
                    Set<Object> itemsToReduce2 = new HashSet<Object>(itemsToReduce.size());

                    //should remove already loaded objects
                    for (Object o : itemsToReduce) {
                        NamedId id = new NamedId(o, entityName);
                        if (!referencesCache.containsKey(id) && c.findById(entityName, builder.idToKey(o)) == null) {
                            itemsToReduce2.add(o);
                        } else {
//                        System.out.println(">>  Already reduced "+id);
                        }
                    }
                    if (itemsToReduce2.size() > 0) {
                        if (UPAImplDefaults.DEBUG_MODE) {
                            net.vpc.upa.Properties properties = persistenceUnit.getProperties();
                            long oldMaxReduceSize = properties.getLong(UPAImplKeys.System_Perf_ResultList_MaxReduceSize, 0);
                            if (oldMaxReduceSize < itemsToReduce2.size()) {
                                oldMaxReduceSize = itemsToReduce2.size();
                                properties.setLong(UPAImplKeys.System_Perf_ResultList_MaxReduceSize, oldMaxReduceSize);
                            }
                        }
                        int count = loadElementsToCache(referencesCache, entity, itemsToReduce2);
                        if (count != itemsToReduce2.size()) {
                            throw new IllegalUPAArgumentException("Problem");
                        }
                    } else {
                        break;
                    }
                }
                workspace_missingObjects.clear();
                workspace_missingObjectsCount = 0;
                for (Iterator<LazyResult> iterator = workspace_todos.iterator(); iterator.hasNext(); ) {
                    LazyResult lazyResult = iterator.next();
                    for (Iterator<Map.Entry<BindingId, NamedId>> itemTodosIterator = lazyResult.todos.entrySet().iterator(); itemTodosIterator.hasNext(); ) {
                        Map.Entry<BindingId, NamedId> t = itemTodosIterator.next();
                        NamedId value = t.getValue();
                        ResultObject ro = referencesCache.get(value);
                        if (ro == null) {
                            String entityName = (String) value.getName();
                            EntityBuilder eb = persistenceUnit.getEntity(entityName).getBuilder();
                            Key k3 = eb.idToKey(value.getId());
                            Object cachedObj = c.findById(entityName, k3);
                            if (cachedObj != null) {
                                ro = ResultObject.forObject(cachedObj, eb,itemAsDocument);
                                lazyResult.values.put(t.getKey(), ro.entityResult);
                                itemTodosIterator.remove();
                            } else {
                                //this would happen if cache is overloaded
                                //so let me reload this object
                                addWorkspaceMissingObject(entityName, value.getId());
                            }
                        } else {
                            lazyResult.values.put(t.getKey(), ro.entityResult);
                            itemTodosIterator.remove();
                        }
                    }
                }
                for (Iterator<LazyResult> iterator = workspace_todos.iterator(); iterator.hasNext(); ) {
                    LazyResult lazyResult = iterator.next();
                    if (lazyResult.todos.isEmpty()) {
                        workspace_available.add((T) this.resultBuilder.createResult(lazyResult.build(), metaData));
                        iterator.remove();
                    } else {
                        break;
                    }
                }
                workspace_hasTodos = !workspace_todos.isEmpty();
            }
            if (workspace_hasTodos) {
                throw new UnexpectedException("ShouldNoHaveRemainingTodos");
            }
        }
    }

    private int loadElementsToCache(CacheMap<NamedId, ResultObject> referencesCache, Entity entity, Collection<Object> itemsToReduce2) {
        String entityName = entity.getName();
        EntityBuilder builder = entity.getBuilder();
        QueryBuilder query = entity.createQueryBuilder().byIdList(new ArrayList<Object>(itemsToReduce2)).setHints(getHints());
        int count = 0;
        EntityCollectionCache c = ((DefaultPersistenceUnit) entity.getPersistenceUnit()).getPersistenceUnitCache();
        if (itemAsDocument) {
            for (Document o : query.getDocumentList()) {
                ResultObject resultObject = ResultObject.forDocument(o, builder);
                Object id1 = builder.objectToId(o);
                NamedId id = new NamedId(id1, entityName);
                if (!referencesCache.containsKey(id)) {
                    referencesCache.put(id, resultObject);
                }
                count++;
            }
        } else {
            for (Object o : query.getResultList()) {
                ResultObject resultObject = ResultObject.forObject(o, builder);
                NamedId id = new NamedId(builder.objectToId(o), entityName);
                if (!referencesCache.containsKey(id)) {
                    referencesCache.put(id, resultObject);
                }
                count++;
            }
        }
        return count;
    }

    @Override
    public boolean checkHasNext() throws UPAException {
        if (!workspace_available.isEmpty()) {
            return true;
        }
        while (workspace_hasNext) {
            QueryResult result = getQueryResult();
            workspace_hasNext = result.hasNext();
            if (workspace_hasNext) {
                rowIndex++;
                LazyResult lazyResult = new LazyResult(result, updatable, metaData);
                for (ResultFieldFamily columnFamily : columnFamilies) {
                    lazyResult.types.put(columnFamily.binding, columnFamily);
                    columnFamily.parser.parse(result, columnFamily, lazyResult, this);
                }
                if (lazyResult.incomplete || workspace_hasTodos) {
                    addWorkspaceTodo(lazyResult);
                    if (workspace_missingObjectsCount >= workspace_bulkSize) {
                        reduceWorkspace();
                        return true;
                    }
                } else {
                    workspace_available.add((T) this.resultBuilder.createResult(lazyResult.build(), metaData));
                    return true;
                }
            } else {
                result.close();
                if (workspace_missingObjectsCount > 0) {
                    reduceWorkspace();
                    return true;
                }
            }
        }
        return false;
    }


    public T loadNext() throws UPAException {
        return (T) workspace_available.remove();
    }

    public CacheMap<NamedId, ResultObject> getReferencesCache() {
        return referencesCache;
    }

    public Map<String, Object> getHints() {
        return hints;
    }

    @Override
    public EntityCollectionCache getEntityCollectionCache() {
        return entityCollectionCache;
    }
}
