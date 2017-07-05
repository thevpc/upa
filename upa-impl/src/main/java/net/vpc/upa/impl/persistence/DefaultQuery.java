package net.vpc.upa.impl.persistence;

import net.vpc.upa.expressions.*;
import net.vpc.upa.filters.FieldFilters;
import net.vpc.upa.impl.persistence.result.*;
import net.vpc.upa.impl.uql.util.UQLUtils;
import net.vpc.upa.impl.util.filters.FieldFilters2;
import net.vpc.upa.persistence.*;
import net.vpc.upa.types.I18NString;
import net.vpc.upa.*;
import net.vpc.upa.exceptions.FindException;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.filters.FieldFilter;
import net.vpc.upa.impl.IdToKeyConverter;
import net.vpc.upa.impl.uql.compiledexpression.*;
import net.vpc.upa.impl.util.ConvertedList;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.Query;

import java.sql.SQLException;
import java.util.*;
import java.util.logging.Logger;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/19/12 Time: 6:14 PM To change
 * this template use File | Settings | File Templates.
 */
public class DefaultQuery extends AbstractQuery {

    private static final Logger log = Logger.getLogger(DefaultQuery.class.getName());
    private EntityExecutionContext context;
    //    private Entity defaultEntity;
//    private CompiledEntityStatement cquery;
    private EntityStatement query;
    private QueryResult result;
    //    private QueryExecutor queryExecutor;
    private DefaultPersistenceStore store;
    private boolean lazyListLoadingEnabled = true;
    private Map<String, Object> hints = new HashMap<String, Object>();

    private List<Object> allResults = new ArrayList<Object>();
    private QueryExecutor lastQueryExecutor = null;
    private DefaultQuery sessionAwareInstance;
    private Map<String, Object> parametersByName;
    private Map<Integer, Object> parametersByIndex;

    //needed by asm emit
    protected DefaultQuery() {
    }

//    public DefaultQuery(CompiledEntityStatement query, Entity defaultEntity, EntityExecutionContext context) {
//        this.context = context;
//        this.cquery = (CompiledEntityStatement) query.copy();
//        this.defaultEntity = defaultEntity;
//        store = (DefaultPersistenceStore) context.getPersistenceStore();
//    }

    public DefaultQuery(EntityStatement query, Entity defaultEntity, EntityExecutionContext context) {
        this.query = query;
        if (defaultEntity != null) {
            if (query instanceof Select) {
                Select select = (Select) query;
                if (select.getEntity() == null) {
                    select.from(defaultEntity.getName());
                }
            } else if (query instanceof Insert) {
                if (((Insert) query).getEntity() == null) {
                    ((Insert) query).into(defaultEntity.getName());
                }
            } else if (query instanceof Update) {
                if (((Update) query).getEntity() == null) {
                    ((Update) query).entity(defaultEntity.getName());
                }
            } else if (query instanceof Delete) {
                if (((Delete) query).getEntity() == null) {
                    ((Delete) query).from(defaultEntity.getName());
                }
            }
        }

        this.context = context;
//        this.cquery = (CompiledEntityStatement) query.copy();
//        this.defaultEntity = defaultEntity;
        store = (DefaultPersistenceStore) context.getPersistenceStore();
    }

    public int executeNonQuery() {
        if (!context.getPersistenceUnit().getPersistenceGroup().currentSessionExists()) {
            if (sessionAwareInstance == null) {
                sessionAwareInstance = context.getPersistenceUnit().getPersistenceGroup().getContext().makeSessionAware(this);
            }
            return sessionAwareInstance.executeNonQuery();
        }
        //
        QueryExecutor queryExecutor = createNativeSQL(null);
        return queryExecutor.execute().getResultCount();
    }

    protected CompiledEntityStatement createCompiledEntityStatement() {
        String alias = null;
        String ent = null;
        if (query instanceof Select) {
            Select d = (Select) query;
            String entityAlias = d.getEntityAlias();
            EntityName entityName = (d.getEntity() instanceof EntityName) ? ((EntityName) d.getEntity()) : null;
            if (entityAlias != null) {
                alias = entityAlias;
                ent = entityName == null ? null : entityName.getName();
            } else {
                ent = entityName == null ? null : entityName.getName();
                alias = ent;
            }
        }
        ExpressionCompilerConfig config = new ExpressionCompilerConfig();
        config.setTranslateOnly();
        if (alias != null) {
            config.setThisAlias(alias);
        }
        return (CompiledEntityStatement) context.getPersistenceUnit().getExpressionManager().compileExpression(query, config);
    }

    @Override
    public <R2> List<R2> getEntityList() throws UPAException {
        return getResultList();
    }

    @Override
    public List<MultiDocument> getMultiDocumentList() throws UPAException {
        if (!context.getPersistenceUnit().getPersistenceGroup().currentSessionExists()) {
            if (sessionAwareInstance == null) {
                sessionAwareInstance = context.getPersistenceUnit().getPersistenceGroup().getContext().makeSessionAware(this);
            }
            return sessionAwareInstance.getMultiDocumentList();
        }
        try {
            QueryExecutor queryExecutor = executeQuery(FieldFilters2.READ);
            MultiDocumentList r = new MultiDocumentList(queryExecutor, isUpdatable());
            allResults.add(r);
            if (!isLazyListLoadingEnabled()) {
                //force loading
                r.loadAll();
            }
            return r;
        } catch (Exception e) {
            throw new FindException(e, new I18NString("FindFailed"));
        }
    }

    @Override
    public boolean isEmpty() throws UPAException {
        if (!context.getPersistenceUnit().getPersistenceGroup().currentSessionExists()) {
            if (sessionAwareInstance == null) {
                sessionAwareInstance = context.getPersistenceUnit().getPersistenceGroup().getContext().makeSessionAware(this);
            }
            return sessionAwareInstance.isEmpty();
        }
        try {
            QueryExecutor queryExecutor = executeQuery(FieldFilters2.READ);
            QueryResult r = null;
            try {
                r = queryExecutor.getQueryResult();
                return !r.hasNext();
            } finally {
                if (r != null) {
                    r.close();
                }
            }
        } catch (Exception e) {
            throw new FindException(e, new I18NString("FindFailed"));
        }
    }

    public <T> List<T> getResultList() throws UPAException {
        return getResultList(new ObjectOrArrayQueryResultItemBuilder());
    }

    public <T> Set<T> getResultSet() throws UPAException {
        HashSet<T> set = new HashSet<T>();
        set.addAll(this.<T>getResultList(new ObjectOrArrayQueryResultItemBuilder()));
        return set;
    }

    public <T> List<T> getResultList(QueryResultItemBuilder builder) throws UPAException {
        PersistenceUnit pu = context.getPersistenceUnit();
        if (!pu.getPersistenceGroup().currentSessionExists()) {
            if (sessionAwareInstance == null) {
                sessionAwareInstance = pu.getPersistenceGroup().getContext().makeSessionAware(this);
            }
            return sessionAwareInstance.getResultList(builder);
        }
        try {
            QueryExecutor queryExecutor = executeQuery(FieldFilters2.READ);
            QueryFetchStrategy fetchStrategy = (QueryFetchStrategy) queryExecutor.getHints().get(QueryHints.FETCH_STRATEGY);
            if (fetchStrategy == null) {
                fetchStrategy = QueryFetchStrategy.JOIN;
            }
            boolean itemAsDocument = builder instanceof DocumentQueryResultItemBuilder;
            boolean relationAsDocument = itemAsDocument;//false;
            int supportCache = 10000;
            QueryResultRelationLoader loader = null;
            switch (fetchStrategy) {
                case JOIN: {
                    break;
                }
                case SELECT: {
                    supportCache = 10000;
                    loader = new QueryRelationLoaderSelectObject();
                    break;
                }
            }
            QueryResultLazyList<T> r = new DefaultObjectQueryResultLazyList<T>(
                    pu,
                    queryExecutor,
                    fetchStrategy != QueryFetchStrategy.JOIN,
                    itemAsDocument,
                    relationAsDocument,
                    supportCache,
                    isUpdatable(),
                    loader,
                    builder
            );
            allResults.add(r);
            if (!isLazyListLoadingEnabled()) {
                //force loading
                r.loadAll();
            }
            return r;
        } catch (Exception e) {
            throw new FindException(e, new I18NString("FindFailed"));
        }
    }


    @Override
    public List<Document> getDocumentList() throws UPAException {
        return getResultList(new DocumentQueryResultItemBuilder());
    }

    @Override
    public <T> List<T> getValueList(int index) throws UPAException {
        if (!context.getPersistenceUnit().getPersistenceGroup().currentSessionExists()) {
            if (sessionAwareInstance == null) {
                sessionAwareInstance = context.getPersistenceUnit().getPersistenceGroup().getContext().makeSessionAware(this);
            }
            return sessionAwareInstance.getValueList(index);
        }
        try {
            QueryExecutor queryExecutor = executeQuery(FieldFilters2.READ);
            if (index < 0 || index > queryExecutor.getMetaData().getResultFields().size()) {
                throw new ArrayIndexOutOfBoundsException("Invalid index " + index);
            }
            ValueList<T> r = new ValueList<T>(queryExecutor, index);
            allResults.add(r);
            if (!isLazyListLoadingEnabled()) {
                //force loading
                r.loadAll();
            }
            return r;
        } catch (Exception e) {
            throw new FindException(e, new I18NString("FindFailed"));
        }
    }

    @Override
    public <T> Set<T> getValueSet(int index) throws UPAException {
        List<T> valueList = this.<T>getValueList(index);
        if (query instanceof Select && (((Select) query).getOrder().size() > 0)) {
            LinkedHashSet<T> set = new LinkedHashSet<T>();
            set.addAll(valueList);
            return set;
        }
        HashSet<T> set = new HashSet<T>();
        set.addAll(valueList);
        return set;
    }

    @Override
    public <T> Set<T> getValueSet(String name) throws UPAException {
        HashSet<T> set = new HashSet<T>();
        set.addAll(this.<T>getValueList(name));
        return set;
    }

    @Override
    public <T> List<T> getValueList(String name) throws UPAException {
        if (!context.getPersistenceUnit().getPersistenceGroup().currentSessionExists()) {
            if (sessionAwareInstance == null) {
                sessionAwareInstance = context.getPersistenceUnit().getPersistenceGroup().getContext().makeSessionAware(this);
            }
            return sessionAwareInstance.getValueList(name);
        }
        try {
            QueryExecutor queryExecutor = executeQuery(FieldFilters2.READ);
            List<ResultField> ne = queryExecutor.getMetaData().getResultFields();
            int index = -1;
            for (int i = 0; i < ne.size(); i++) {
                if (name.equals(ne.get(i).getAlias())) {
                    index = i;
                    break;
                }
            }
            if (index < 0) {
                throw new NoSuchElementException("Field " + name + " not found");
            }
            ValueList<T> r = new ValueList<T>(queryExecutor, index);
            if (!isLazyListLoadingEnabled()) {
                //force loading
                r.loadAll();
            }
            allResults.add(r);
            return r;
        } catch (Exception e) {
            throw new FindException(e, new I18NString("FindFailed"));
        }
    }

    public <T> List<T> getTypeList(Class<T> type, String... fields) throws UPAException {
        if (!context.getPersistenceUnit().getPersistenceGroup().currentSessionExists()) {
            if (sessionAwareInstance == null) {
                sessionAwareInstance = context.getPersistenceUnit().getPersistenceGroup().getContext().makeSessionAware(this);
            }
            return sessionAwareInstance.getTypeList(type, fields);
        }
        try {
            QueryExecutor queryExecutor = executeQuery(FieldFilters2.READ);
            TypeList<T> r = new TypeList<T>(queryExecutor, type, fields);
            allResults.add(r);
            if (!isLazyListLoadingEnabled()) {
                //force loading
                r.loadAll();
            }
            return r;
        } catch (SQLException e) {
            throw new FindException(e, new I18NString("FindFailed"));
        }
    }

    @Override
    public <T> Set<T> getTypeSet(Class<T> type, String... fields) throws UPAException {
        HashSet<T> set = new HashSet<T>();
        set.addAll(getTypeList(type, fields));
        return set;
    }

    @Override
    public List<Key> getKeyList() throws UPAException {
        if (!context.getPersistenceUnit().getPersistenceGroup().currentSessionExists()) {
            if (sessionAwareInstance == null) {
                sessionAwareInstance = context.getPersistenceUnit().getPersistenceGroup().getContext().makeSessionAware(this);
            }
            return sessionAwareInstance.getKeyList();
        }
        if ((query instanceof QueryStatement)) {
            Entity entity = resolveDefaultEntity();
            if (entity != null) {
                ConvertedList<Object, Key> r = new ConvertedList<Object, Key>(getIdList(), new IdToKeyConverter<Object>(entity));
                allResults.add(r);
                return r;
            }
        }
        throw new FindException(new I18NString("InvalidQuery"));
    }

    private Entity resolveDefaultEntity() {
        String[] a = UQLUtils.resolveEntityAndAlias((QueryStatement) query);
        Entity entity = null;
        if (a != null) {
            entity = context.getPersistenceUnit().getEntity(a[0]);
        }
        return entity;
    }

    @Override
    public <K2> List<K2> getIdList() throws UPAException {
        if (!context.getPersistenceUnit().getPersistenceGroup().currentSessionExists()) {
            if (sessionAwareInstance == null) {
                sessionAwareInstance = context.getPersistenceUnit().getPersistenceGroup().getContext().makeSessionAware(this);
            }
            return sessionAwareInstance.getIdList();
        }
        try {
            if ((query instanceof QueryStatement)) {
                Entity entity = resolveDefaultEntity();
                if (entity != null) {
                    QueryExecutor queryExecutor = executeQuery(FieldFilters.id());
                    SingleEntityKeyList<K2> r = new SingleEntityKeyList<K2>(queryExecutor, entity);
                    allResults.add(r);
                    if (!isLazyListLoadingEnabled()) {
                        //force loading
                        r.loadAll();
                    }
                    return r;
                }
            }
        } catch (Exception e) {
            throw new FindException(e, new I18NString("FindFailed"));
        }
        throw new FindException(new I18NString("InvalidQuery"));
    }

    @Override
    public <K> Set<K> getIdSet() throws UPAException {
        HashSet<K> set = new HashSet<K>();
        set.addAll(this.<K>getIdList());
        return set;
    }

    @Override
    public Set<Key> getKeySet() throws UPAException {
        HashSet<Key> set = new HashSet<Key>();
        set.addAll(this.getKeyList());
        return set;
    }

    protected QueryExecutor executeQuery(FieldFilter fieldFilter) {
//        if (result != null) {
//            throw new FindException("QueryAlreadyExecutedException");
//        }
        QueryExecutor queryExecutor = createNativeSQL(fieldFilter);
//        DefaultResultMetaData m = new DefaultResultMetaData();
//        for (NativeField x : queryExecutor.getFields()) {
//            m.addField(x.getName(), x.getTypeTransform(), x.getField());
//        }
//        this.metadata = m;
        queryExecutor.execute();
        result = queryExecutor.getQueryResult();
        return queryExecutor;
    }

    protected QueryExecutor createNativeSQL(FieldFilter fieldFilter) {
//        applyParameters();
        lastQueryExecutor = store.createExecutor(query, parametersByName, parametersByIndex, isUpdatable(), fieldFilter, context.setHints(getHints()));
        EntityStatement statement = lastQueryExecutor.getMetaData().getStatement();
        return lastQueryExecutor;
    }

    //        CompiledNamedExpression[] ne = new CompiledNamedExpression[query.countFields()];
//        for (int i = 0; i < ne.length; i++) {
//            CompiledQueryField field = query.getField(i);
//            String validName = field.getName() != null ? field.getName() : field.getExpression().toString();
//            if (validName == null) {
//                validName = "#" + i;
//            }
//            ne[i] = new CompiledNamedExpression(validName, field.getExpression());
//        }
    @Override
    public Query setParameter(final String name, Object value) {
        if (parametersByName == null) {
            parametersByName = new HashMap<String, Object>();
        }
        parametersByName.put(name, value);
        return this;
    }

    @Override
    public Query removeParameter(final String name) {
        if (parametersByName != null) {
            parametersByName.remove(name);
        }
        return this;
    }

    @Override
    public Query removeParameter(int index) {
        if (parametersByIndex != null) {
            parametersByIndex.remove(index);
        }
        return this;
    }


    //
//    private Query applyParameters() {
//        if (parametersByName != null) {
//            for (Map.Entry<String, Object> entry : parametersByName.entrySet()) {
//                String name = entry.getKey();
//                Object value = entry.getValue();
//
//                List<Expression> params = query.findAll(ExpressionFilterFactory.forParam(name));
//                if (params.isEmpty()) {
//                    params=query.findAll(ExpressionFilterFactory.forParam(name));
//                    throw new IllegalArgumentException("Parameter not found " + name);
//                }
//                for (Expression e : params) {
//                    Param p=(Param) e;
//                    p.setValue(value);
//                    p.setUnspecified(false);
//                }
//            }
//        }
//        if(parametersByIndex!=null && !parametersByIndex.isEmpty()) {
//            List<Expression> params = query.findAll(ExpressionFilterFactory.PARAM_FILTER);
//            for (Map.Entry<Integer, Object> entry : parametersByIndex.entrySet()) {
//                Integer index = entry.getKey();
//                Object value = entry.getValue();
//                if (params.size() <= index) {
//                    throw new IllegalArgumentException("Parameter not found " + index);
//                }
//                Param p = (Param) params.get(index);
//                if (p == null) {
//                    throw new IllegalArgumentException("Parameter not found " + index);
//                }
//                p.setValue(value);
//                p.setUnspecified(false);
//            }
//        }
//        return this;
//    }

    @Override
    public Query setParameter(int index, Object value) {
        if (parametersByIndex == null) {
            parametersByIndex = new HashMap<Integer, Object>();
        }
        parametersByIndex.put(index, value);
        return this;
    }

    @Override
    public ResultMetaData getMetaData() throws UPAException {
        if (lastQueryExecutor == null) {
            throw new UPAException("NoQueryExecutedYet");
        }
        return lastQueryExecutor.getMetaData();
    }

    public boolean isLazyListLoadingEnabled() {
        return lazyListLoadingEnabled;
    }

    public Query setLazyListLoadingEnabled(boolean lazyLoadingEnabled) {
        this.lazyListLoadingEnabled = lazyLoadingEnabled;
        return this;
    }

    public void updateCurrent() {
        if (!isUpdatable()) {
            throw new IllegalArgumentException("IsForUpdateMissing");
        }
        result.updateCurrent();
    }

    public void close() {
        for (Object object : allResults) {
            UPAUtils.close(object);
        }
        allResults.clear();
    }

    @Override
    public Query setHint(String key, Object value) {
        if (value == null) {
            hints.remove(key);
        } else {
            hints.put(key, value);
        }
        return this;
    }

    @Override
    public Query setHints(Map<String, Object> hints) {
        if (hints != null) {
            for (Map.Entry<String, Object> e : hints.entrySet()) {
                setHint(e.getKey(), e.getValue());
            }
        }
        return this;
    }

    public Map<String, Object> getHints() {
        return hints;
    }

    public Object getHint(String hintName) {
        return hints == null ? null : hints.get(hintName);
    }

    public Object getHint(String hintName, Object defaultValue) {
        Object c = hints == null ? null : hints.get(hintName);
        return c == null ? defaultValue : c;
    }

}
