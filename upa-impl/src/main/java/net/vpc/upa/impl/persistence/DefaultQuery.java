package net.vpc.upa.impl.persistence;

import net.vpc.upa.impl.util.Strings;
import net.vpc.upa.persistence.ExpressionCompilerConfig;
import net.vpc.upa.types.I18NString;
import net.vpc.upa.*;
import net.vpc.upa.exceptions.FindException;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.filters.FieldFilter;
import net.vpc.upa.impl.IdToKeyConverter;
import net.vpc.upa.impl.uql.compiledexpression.*;
import net.vpc.upa.impl.util.ConvertedList;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.Query;
import net.vpc.upa.persistence.QueryResult;
import net.vpc.upa.persistence.ResultMetaData;

import java.sql.SQLException;
import java.util.*;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.filters.Fields;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.impl.uql.CompiledExpressionHelper;
import net.vpc.upa.impl.uql.DecObjectType;
import net.vpc.upa.impl.uql.ExpressionDeclaration;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/19/12 Time: 6:14 PM To change
 * this template use File | Settings | File Templates.
 */
public class DefaultQuery extends AbstractQuery {

    private static final Logger log = Logger.getLogger(DefaultQuery.class.getName());
    private EntityExecutionContext context;
    private Entity defaultEntity;
    private CompiledEntityStatement query;
    private DefaultResultMetaData metadata;
    private QueryResult result;
//    private NativeSQL nativeSQL;
    private DefaultPersistenceStore store;
    private boolean lazyListLoadingEnabled = true;
    private Map<String, Object> hints = new HashMap<String, Object>();
    private static final FieldFilter ID = Fields.regular().and(Fields.byModifiersAllOf(FieldModifier.ID));
    private static final FieldFilter READABLE = Fields.regular().and(
            Fields.byModifiersAnyOf(FieldModifier.SELECT_DEFAULT,
                    FieldModifier.SELECT_COMPILED,
                    FieldModifier.SELECT_LIVE)).andNot(Fields.byAllAccessLevel(AccessLevel.PRIVATE));

    private List<Object> allResults = new ArrayList<Object>();
    private Map<String, NativeSQL> precompiledNativeSQLMap = new HashMap<String, NativeSQL>();
    private DefaultQuery sessionAwareInstance;
    private Map<String, Object> parametersByName ;
    private Map<Integer, Object> parametersByIndex ;

    //needed by asm emit
    protected DefaultQuery() {
    }

    public DefaultQuery(CompiledEntityStatement query, Entity defaultEntity, EntityExecutionContext context) {
        this.context = context;
        this.query = (CompiledEntityStatement) query.copy();
        this.defaultEntity = defaultEntity;
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
        NativeSQL nativeSQL = createNativeSQL(null, null);
        DefaultResultMetaData m = new DefaultResultMetaData();
        m.addField("result", IdentityDataTypeTransform.INT, null);
        this.metadata = m;
        nativeSQL.execute();
        return nativeSQL.getResultCount();
    }

    protected String resolveAliasName() {
        String aliasName = null;
        if (query instanceof CompiledUnion) {
            List<CompiledQueryStatement> queryStatements = ((CompiledUnion) query).getQueryStatements();
            if (queryStatements.isEmpty()) {
                throw new IllegalArgumentException("Empty Union");
            }
            List<ExpressionDeclaration> declarations = queryStatements.get(0).getExportedDeclarations();
            for (ExpressionDeclaration d : declarations) {
                if (d.getReferrerType() == DecObjectType.ENTITY) {
                    aliasName = d.getValidName();
                    break;
                }
            }
        } else { // select
            List<ExpressionDeclaration> declarations = query.getExportedDeclarations();
            for (ExpressionDeclaration d : declarations) {
                if (d.getReferrerType() == DecObjectType.ENTITY) {
                    aliasName = d.getValidName();
                    break;
                }
            }
        }
        return aliasName;
    }

    @Override
    public <R2> List<R2> getEntityList() throws UPAException {
        if (!context.getPersistenceUnit().getPersistenceGroup().currentSessionExists()) {
            if (sessionAwareInstance == null) {
                sessionAwareInstance = context.getPersistenceUnit().getPersistenceGroup().getContext().makeSessionAware(this);
            }
            return sessionAwareInstance.getEntityList();
        }
        try {
            String aliasName = resolveAliasName();
            NativeSQL nativeSQL = executeQuery("READABLE", READABLE);
            String fetchStrategy=(String) nativeSQL.getHints().get(QueryHints.FETCH_STRATEGY);
            if(Strings.isNullOrEmpty(fetchStrategy)){
                fetchStrategy="join";
            }
            QueryResultLazyList<R2> r=null;
            if("select".equals(fetchStrategy)) {
                r = new SingleEntityQueryResultSelectFetchStrategy<R2>(nativeSQL, aliasName);
            }else if("join".equals(fetchStrategy)){
                r = new SingleEntityQueryResultJoinFetchStrategy<R2>(nativeSQL, aliasName);
            }else {
                log.log(Level.WARNING, "Ignored "+QueryHints.FETCH_STRATEGY+" '"+fetchStrategy+"' possible values are {join,select}");
                r = new SingleEntityQueryResultJoinFetchStrategy<R2>(nativeSQL, aliasName);
            }
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
    public List<MultiRecord> getMultiRecordList() throws UPAException {
        if (!context.getPersistenceUnit().getPersistenceGroup().currentSessionExists()) {
            if (sessionAwareInstance == null) {
                sessionAwareInstance = context.getPersistenceUnit().getPersistenceGroup().getContext().makeSessionAware(this);
            }
            return sessionAwareInstance.getMultiRecordList();
        }
        try {
            NativeSQL nativeSQL = executeQuery("READABLE", READABLE);
            MultiRecordList r = new MultiRecordList(nativeSQL, isUpdatable());
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
            NativeSQL nativeSQL = executeQuery("READABLE", READABLE);
            QueryResult r = null;
            try {
                r = nativeSQL.getQueryResult();
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

    @Override
    public List<Record> getRecordList() throws UPAException {
        if (!context.getPersistenceUnit().getPersistenceGroup().currentSessionExists()) {
            if (sessionAwareInstance == null) {
                sessionAwareInstance = context.getPersistenceUnit().getPersistenceGroup().getContext().makeSessionAware(this);
            }
            return sessionAwareInstance.getRecordList();
        }
        try {
            String aliasName = resolveAliasName();
            NativeSQL nativeSQL = executeQuery("READABLE", READABLE);
            String fetchStrategy=(String) nativeSQL.getHints().get(QueryHints.FETCH_STRATEGY);
            if(Strings.isNullOrEmpty(fetchStrategy)){
                fetchStrategy="join";
            }
            QueryResultLazyList<Record> r=null;
            if("select".equals(fetchStrategy)) {
                r = new RecordQueryResultSelectFetchStrategy(nativeSQL, aliasName);
            }else if("join".equals(fetchStrategy)){
                r = new RecordQueryResultJoinFetchStrategy(nativeSQL, aliasName);
            }else {
                log.log(Level.WARNING, "Ignored "+QueryHints.FETCH_STRATEGY+" '"+fetchStrategy+"' possible values are {join,select}");
                r = new RecordQueryResultJoinFetchStrategy(nativeSQL, aliasName);
            }

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
    public <T> List<T> getValueList(int index) throws UPAException {
        if (!context.getPersistenceUnit().getPersistenceGroup().currentSessionExists()) {
            if (sessionAwareInstance == null) {
                sessionAwareInstance = context.getPersistenceUnit().getPersistenceGroup().getContext().makeSessionAware(this);
            }
            return sessionAwareInstance.getValueList(index);
        }
        try {
            NativeSQL nativeSQL = executeQuery("READABLE", READABLE);
            if (index < 0 || index > nativeSQL.getFields().length) {
                throw new ArrayIndexOutOfBoundsException("Invalid index " + index);
            }
            ValueList<T> r = new ValueList<T>(nativeSQL, index);
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
        HashSet<T> set = new HashSet<T>();
        set.addAll(this.<T>getValueList(index));
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
            NativeSQL nativeSQL = executeQuery("READABLE", READABLE);
            NativeField[] ne = nativeSQL.getFields();
            int index = -1;
            for (int i = 0; i < ne.length; i++) {
                if (name.equals(ne[i].getName())) {
                    index = i;
                    break;
                }
            }
            if (index < 0) {
                throw new NoSuchElementException("Field " + name + " not found");
            }
            ValueList<T> r = new ValueList<T>(nativeSQL, index);
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
            NativeSQL nativeSQL = executeQuery("READABLE", READABLE);
            TypeList<T> r = new TypeList<T>(nativeSQL, type, fields);
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
        set.addAll(getTypeList(type,fields));
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
        ConvertedList<Object, Key> r = new ConvertedList<Object, Key>(getIdList(), new IdToKeyConverter<Object>(defaultEntity));
        allResults.add(r);
        return r;
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
            Entity entity = null;
            if (query instanceof CompiledUnion) {
                List<CompiledQueryStatement> queryStatements = ((CompiledUnion) query).getQueryStatements();
                if (queryStatements.isEmpty()) {
                    throw new IllegalArgumentException("Empty Union");
                }
                List<ExpressionDeclaration> declarations = queryStatements.get(0).getExportedDeclarations();
                for (ExpressionDeclaration d : declarations) {
                    if (d.getReferrerType() == DecObjectType.ENTITY) {
                        entity = context.getPersistenceUnit().getEntity((String) d.getReferrerName());
                        break;
                    }
                }
            } else { // select
                List<ExpressionDeclaration> declarations = query.getExportedDeclarations();
                for (ExpressionDeclaration d : declarations) {
                    if (d.getReferrerType() == DecObjectType.ENTITY) {
                        entity = context.getPersistenceUnit().getEntity((String) d.getReferrerName());
                        break;
                    }
                }
            }

            if (entity == null) {
                entity = getDefaultEntity();
            }
            NativeSQL nativeSQL = executeQuery("ID", ID);
            SingleEntityKeyList<K2> r = new SingleEntityKeyList<K2>(nativeSQL, entity);
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

    public Entity getDefaultEntity() {
        if (defaultEntity == null) {
            throw new IllegalArgumentException("No Default Entity is associated to this Find Query");
        }
        return defaultEntity;
    }

    protected NativeSQL executeQuery(String filteredKey, FieldFilter fieldFilter) {
//        if (result != null) {
//            throw new FindException("QueryAlreadyExecutedException");
//        }
        NativeSQL nativeSQL = createNativeSQL(filteredKey, fieldFilter);
        DefaultResultMetaData m = new DefaultResultMetaData();
        for (NativeField x : nativeSQL.getFields()) {
            m.addField(x.getName(), x.getTypeTransform(), x.getField());
        }
        this.metadata = m;
        nativeSQL.setUpdatable(isUpdatable());
        nativeSQL.execute();
        result = nativeSQL.getQueryResult();
        return nativeSQL;
    }

    protected NativeSQL createNativeSQL(String key, FieldFilter fieldFilter) {
        applyParameters();
        NativeSQL s = precompiledNativeSQLMap.get(key);
        if (s == null) {
            s = store.nativeSQL(query, fieldFilter, context.setHints(getHints()));
            precompiledNativeSQLMap.put(key, s);
        }
        return s;
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
        if(parametersByName ==null){
            parametersByName =new HashMap<String, Object>();
        }
        parametersByName.put(name, value);
        return this;
    }

    @Override
    public Query removeParameter(final String name) {
        if(parametersByName !=null) {
            parametersByName.remove(name);
        }
        return this;
    }

    @Override
    public Query removeParameter(int index) {
        if(parametersByIndex !=null) {
            parametersByIndex.remove(index);
        }
        return this;
    }

    public Query setParameters(Map<String, Object> parameters) {
        if (parameters != null) {
            for (Map.Entry<String, Object> entry : parameters.entrySet()) {
                setParameter(entry.getKey(), entry.getValue());
            }
        }
        return this;
    }


    private Query applyParameters() {
        if (parametersByName != null) {
            for (Map.Entry<String, Object> entry : parametersByName.entrySet()) {
                String name = entry.getKey();
                Object value = entry.getValue();

                List<CompiledParam> params = query.findExpressionsList(new CompiledParamFilter(name));
                if (params.isEmpty()) {
                    throw new IllegalArgumentException("Parameter not found " + name);
                }
                for (CompiledParam p : params) {
                    p.setValue(value);
                    p.setUnspecified(false);
                }
            }
        }
        if(parametersByIndex!=null && !parametersByIndex.isEmpty()) {
            List<CompiledParam> params = query.findExpressionsList(CompiledExpressionHelper.PARAM_FILTER);
            for (Map.Entry<Integer, Object> entry : parametersByIndex.entrySet()) {
                Integer index = entry.getKey();
                Object value = entry.getValue();
                if (params.size() <= index) {
                    throw new IllegalArgumentException("Parameter not found " + index);
                }
                CompiledParam p = params.get(index);
                if (p == null) {
                    throw new IllegalArgumentException("Parameter not found " + index);
                }
                p.setValue(value);
                p.setUnspecified(false);
            }
        }
        return this;
    }

    @Override
    public Query setParameter(int index, Object value) {
        if(parametersByIndex==null){
            parametersByIndex=new HashMap<Integer, Object>();
        }
        parametersByIndex.put(index,value);
        return this;
    }

    @Override
    public ResultMetaData getMetaData() throws UPAException {
        if (metadata == null) {
            DefaultResultMetaData m = new DefaultResultMetaData();
            CompiledEntityStatement query2 = (CompiledEntityStatement) context.getPersistenceUnit().getExpressionManager().compileExpression(query, new ExpressionCompilerConfig().setValidate(true));
            if (query2 instanceof CompiledQueryStatement) {
                final CompiledQueryStatement qs = (CompiledQueryStatement) query2;
                for (int i = 0; i < qs.countFields(); i++) {
                    CompiledQueryField field = qs.getField(i);

                    DefaultCompiledExpression expression = field.getExpression();
                    String validName = field.getName() != null ? field.getName() : expression.toString();
                    if (validName == null) {
                        validName = "#" + i;
                    }
                    Field f = null;
                    if (expression instanceof CompiledVar) {
                        CompiledVar v = (CompiledVar) expression;
                        CompiledVarOrMethod finest = v.getFinest();
                        if (finest != null && finest.getReferrer() instanceof Field) {
                            f = (Field) finest.getReferrer();
                        }
                    }
                    m.addField(validName, expression.getTypeTransform(), f);
                }
            }
            this.metadata = m;
        }
        return metadata;
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
        if(hints!=null) {
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
        return hints==null?null:hints.get(hintName);
    }

    public Object getHint(String hintName,Object defaultValue) {
        Object c = hints == null ? null : hints.get(hintName);
        return c==null?defaultValue:c;
    }

}
