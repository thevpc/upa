package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.NativeField;
import net.vpc.upa.impl.persistence.QueryExecutor;
import net.vpc.upa.impl.uql.BindingId;
import net.vpc.upa.impl.uql.NativeFieldByBindingIdComparator;
import net.vpc.upa.impl.util.*;
import net.vpc.upa.persistence.QueryResult;
import net.vpc.upa.persistence.ResultMetaData;
import net.vpc.upa.types.ManyToOneType;

import java.sql.SQLException;
import java.util.*;

/**
 * Created by vpc on 6/18/16.
 */
public class DefaultObjectQueryResultLazyList<T> extends QueryResultLazyList<T> implements QueryResultParserHelper {
    public static final CacheMap<NamedId, ResultObject> NO_RESULT_CACHE = new NoCacheMap<NamedId, ResultObject>();
    boolean workspace_hasNext=true;
    Map<String, Set<Object>> workspace_missingObjects = new HashMap<>();
    List<LazyResult> workspace_todos = new ArrayList<>();
    LinkedList<T> workspace_available = new LinkedList<>();
    int workspace_missingObjectsCount = 0;
    int workspace_bulkSize = 100;
    boolean workspace_hasTodos = false;
    PersistenceUnit persistenceUnit;
    private boolean updatable;
    private boolean itemAsDocument;
    private ResultMetaData metaData;
    private CacheMap<NamedId, ResultObject> referencesCache;
    private Map<String, Object> hints;
    private ObjectFactory ofactory;
    private ColumnFamily[] columnFamilies;
    private QueryResultItemBuilder resultBuilder;

    public DefaultObjectQueryResultLazyList(
            PersistenceUnit pu,
            QueryExecutor queryExecutor,
            boolean itemAsDocument,
            int supportCacheSize,
            boolean updatable,
            QueryResultItemBuilder resultBuilder
    ) throws SQLException {
        super(queryExecutor);
        this.itemAsDocument = itemAsDocument;
        this.resultBuilder = resultBuilder;
        metaData = queryExecutor.getMetaData();
        hints = queryExecutor.getHints();
        if (hints == null) {
            hints = new HashMap<String, Object>();
        } else {
            hints = new HashMap<String, Object>(hints);
        }
        if (supportCacheSize > 0) {
            CacheMap<NamedId, ResultObject> sharedCache = (CacheMap<NamedId, ResultObject>) hints.get("queryCache");
            if (sharedCache == null) {
                sharedCache = new LRUCacheMap<NamedId, ResultObject>(supportCacheSize);
                hints.put("queryCache", sharedCache);
            }
            referencesCache = sharedCache;
        } else {
            referencesCache = NO_RESULT_CACHE;
        }
        LinkedHashMap<BindingId, ColumnFamily> bindingToTypeInfos0 = new LinkedHashMap<BindingId, ColumnFamily>();
        ofactory = pu.getFactory();
        persistenceUnit = pu;
        NativeField[] fields = queryExecutor.getFields();

        //reorder fields by binding so that parent bindings are always seen first!
        SortPreserveIndexIndexedItem[] indexed = UPAUtils.sortPreserveIndex0(fields, NativeFieldByBindingIdComparator.INSTANCE);

        for (int i = 0; i < indexed.length; i++) {
            NativeField nativeField = (NativeField) indexed[i].getItem();
            FieldInfo f = new FieldInfo();
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
            ColumnFamily columnFamily = bindingToTypeInfos0.get(parentBinding);
            if (columnFamily == null) {
                ColumnFamily ancestor = null;
                if ((parentBinding == null || parentBinding.getParent() == null)) {
                    //do nothing
                } else {
                    ancestor = bindingToTypeInfos0.get(parentBinding.getParent());
                    if (ancestor == null) {
                        throw new IllegalArgumentException("Unexpected");
                    }
                }
                if (ancestor != null) {
                    if (ancestor.entity == null) {
                        throw new IllegalArgumentException("Unsupported");
                    } else {
                        Field field = ancestor.entity.getField(parentBinding.getName());
                        if (field.getDataType() instanceof ManyToOneType) {
                            columnFamily = new ColumnFamily(parentBinding, ((ManyToOneType) field.getDataType()).getTargetEntity(), ofactory);
                            columnFamily.documentType = itemAsDocument;
                            bindingToTypeInfos0.put(parentBinding, columnFamily);
                        } else {
                            throw new IllegalArgumentException("Unsupported");
                        }
                    }
                } else {
                    if (f.parentBindingReferrer != null && parentBinding != null) {
                        columnFamily = new ColumnFamily(parentBinding, f.parentBindingReferrer, ofactory);
                        columnFamily.documentType = itemAsDocument;
                        bindingToTypeInfos0.put(parentBinding, columnFamily);
                    } else {
                        columnFamily = new ColumnFamily(parentBinding, ofactory);
                        columnFamily.documentType = itemAsDocument;//n.contains(".") ? relationAsDocument : defaultsToDocument;
                        bindingToTypeInfos0.put(parentBinding, columnFamily);
                    }
                }
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
        columnFamilies = bindingToTypeInfos0.values().toArray(new ColumnFamily[bindingToTypeInfos0.size()]);
        for (ColumnFamily columnFamily : columnFamilies) {
            if (columnFamily.entity != null) {
                Set<String> visitedIds = new HashSet<>();
                Set<String> expectedIds = new HashSet<>();
                List<Field> idFields = columnFamily.entity.getIdFields();
                for (Field field : idFields) {
                    expectedIds.add(field.getName());
                }
                for (Iterator<FieldInfo> iterator = columnFamily.idFields.iterator(); iterator.hasNext(); ) {
                    FieldInfo field = iterator.next();
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
                        throw new IllegalArgumentException("Should never Happen");
                    }
                }
                FieldInfo[] nonOrderedIdFields = columnFamily.idFields.toArray(new FieldInfo[columnFamily.idFields.size()]);

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
                columnFamily.parser = ColumnFamilyParserNoBinding.INSTANCE;
            } else if (columnFamily.entity != null && columnFamily.identifiable) {
                if (columnFamily.partialObject) {
                    if (columnFamily.idFields.size() == 1) {
                        columnFamily.parser = ColumnFamilyParserSingleIdExternalTodoEntity.INSTANCE;
                    } else {
                        columnFamily.parser = ColumnFamilyParserMultiIdExternalTodoEntity.INSTANCE;
                    }
                } else {
                    if (columnFamily.idFields.size() == 1) {
                        columnFamily.parser = ColumnFamilyParserSingleIdEntity.INSTANCE;
                    } else {
                        columnFamily.parser = ColumnFamilyParserMultiIdEntity.INSTANCE;
                    }
                }
            } else if (columnFamily.entity != null && !columnFamily.identifiable) {
                columnFamily.parser = ColumnFamilyParserNoIdEntity.INSTANCE;
            } else {
                throw new IllegalArgumentException("Unsupported binding " + columnFamily.binding);
            }
        }
        for (ColumnFamily columnFamily : columnFamilies) {
            columnFamily.fieldsArray = columnFamily.nonIdFields.toArray(new FieldInfo[columnFamily.nonIdFields.size()]);
        }

        this.updatable = updatable;
    }


    public void addWorkspaceMissingObject(String entity, Object id) {
        Set<Object> list = workspace_missingObjects.get(entity);
        if (list == null) {
            list = new HashSet<>();
            workspace_missingObjects.put(entity,list);
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
        for (Map.Entry<String, Set<Object>> e : workspace_missingObjects.entrySet()) {
            String entityName = e.getKey();
            Entity entity = persistenceUnit.getEntity(entityName);
            EntityBuilder builder = entity.getBuilder();
            Query query = entity.createQueryBuilder().byIdList(new ArrayList<Object>(e.getValue())).setHints(getHints());
            CacheMap<NamedId, ResultObject> referencesCache = getReferencesCache();
            if (itemAsDocument) {
                for (Document o : query.getDocumentList()) {
                    ResultObject resultObject = new ResultObject();
                    Object entityObject = null;
                    Document entityDocument = o;
                    resultObject.entityObject = entityObject;
                    resultObject.entityDocument = entityDocument;
                    resultObject.entityResult = entityDocument;
                    NamedId id = new NamedId(builder.objectToId(o), entityName);
                    if (!referencesCache.containsKey(id)) {
                        referencesCache.put(id, resultObject);
                    }
                }
            } else {
                for (Object o : query.getResultList()) {
                    ResultObject resultObject = new ResultObject();
                    Object entityObject = o;
                    Document entityDocument = builder.objectToDocument(entityObject, true);
                    resultObject.entityObject = entityObject;
                    resultObject.entityDocument = entityDocument;
                    resultObject.entityResult = entityObject;
                    NamedId id = new NamedId(builder.objectToId(o), entityName);
                    if (!referencesCache.containsKey(id)) {
                        referencesCache.put(id, resultObject);
                    }
                }
            }
        }
        workspace_missingObjects.clear();
        for (LazyResult lazyResult : workspace_todos) {
            for (Map.Entry<BindingId, NamedId> t : lazyResult.todos.entrySet()) {
                ResultObject ro = referencesCache.get(t.getValue());
                if (ro == null) {
                    throw new IllegalArgumentException("Problem");
                }
                lazyResult.values.put(t.getKey(), ro.entityResult);
            }
            workspace_available.add((T) this.resultBuilder.createResult(lazyResult.build(), metaData));
        }
        workspace_todos.clear();
        workspace_hasTodos=false;
        workspace_missingObjectsCount = 0;
    }

    @Override
    public boolean checkHasNext() throws UPAException {
        QueryResult result=getQueryResult();
        if (!workspace_available.isEmpty()) {
            return true;
        }
        while (workspace_hasNext) {
            workspace_hasNext = result.hasNext();
            if (workspace_hasNext) {
                LazyResult lazyResult = new LazyResult(result, updatable, metaData);
                for (ColumnFamily columnFamily : columnFamilies) {
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
}
