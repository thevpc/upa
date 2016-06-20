package net.vpc.upa.impl.persistence;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.*;
import net.vpc.upa.filters.FieldFilter;
import net.vpc.upa.Query;
import net.vpc.upa.persistence.ResultMetaData;

import java.util.*;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/29/12 2:28 AM
 */
public final class DefaultQueryBuilder implements QueryBuilder {

    private boolean updatable;
    private boolean lazyListLoadingEnabled = true;
    private Entity entity;
    private String entityAlias;
    private Expression expression;
    private Order order;
    private FieldFilter fieldFilter;
    private Object id;
    private Key key;
    private Object prototype;
    private Record recordPrototype;
    private Map<String, Object> hints = new HashMap<String, Object>();
    private Query query;
    private LinkedHashMap<String, Object> paramsByName = new LinkedHashMap<String, Object>();
    private LinkedHashMap<Integer, Object> paramsByIndex = new LinkedHashMap<Integer, Object>();

    public DefaultQueryBuilder(Entity entity) {
        this.entity = entity;
    }

    public Entity getEntityType() {
        return entity;
    }

    public QueryBuilder byExpression(String expression) {
        return byExpression(expression == null ? null : new UserExpression(expression));
    }

    public QueryBuilder byExpression(Expression expression) {
        if (this.expression == null) {
            this.expression = expression;
        } else if (expression != null) {
            this.expression = new And(this.expression, expression);
        }
        return this;
    }

    @Override
    public QueryBuilder byExpression(Expression expression,boolean applyAndOp) {
        if(applyAndOp || this.expression == null){
            this.expression = expression;
        }else {
            this.expression = new And(this.expression, expression);
        }
        return this;
    }

    @Override
    public QueryBuilder orderBy(Order order) {
        this.order = order;
        return this;
    }

    @Override
    public QueryBuilder setFieldFilter(FieldFilter fieldFilter) {
        this.fieldFilter = fieldFilter;
        return this;
    }

    @Override
    public QueryBuilder byId(Object id) {
        if (id instanceof Key) {
            byKey((Key) id);
        } else {
            this.id = id;
        }
        return this;
    }

    @Override
    public QueryBuilder byKey(Key key) {
        this.key = key;
        return this;
    }

    @Override
    public QueryBuilder byPrototype(Object prototype) {
        this.prototype = prototype;
        return this;
    }

    @Override
    public QueryBuilder byRecordPrototype(Record prototype) {
        this.recordPrototype = prototype;
        return this;
    }

    @Override
    public Expression getExpression() {
        return expression;
    }

    @Override
    public Order getOrder() {
        return order;
    }

    @Override
    public FieldFilter getFieldFilter() {
        return fieldFilter;
    }

    @Override
    public Object getId() {
        return id;
    }

    @Override
    public Key getKey() {
        return key;
    }

    @Override
    public Object getPrototype() {
        return prototype;
    }

    @Override
    public Record getRecordPrototype() {
        return recordPrototype;
    }

    public String getEntityAlias() {
        return entityAlias;
    }

    public QueryBuilder setEntityAlias(String entityAlias) {
        this.entityAlias = entityAlias;
        return this;
    }

    private Query exec() {
//        if (query == null) {
        String entityName = entity.getName();
        Select s = (new Select()).from(entityName, entityAlias);

        if (getFieldFilter() != null) {
            for (Field field : entity.getFields(getFieldFilter())) {
                if (field != null) {
                    s.field(new Var(field.getName()), field.getName());
                }
            }
        }
        Expression criteria = null;
        if (getId() != null) {
            Expression e = entity.getBuilder().idToExpression(getId(), entityName);
            criteria = criteria == null ? e : new And(criteria, e);
        }
        if (getKey() != null) {
            Expression e = (entity.getBuilder().idToExpression(entity.getBuilder().keyToId(getKey()), entityName));
            criteria = criteria == null ? e : new And(criteria, e);
        }
        if (getPrototype() != null) {
            Expression e = entity.getBuilder().objectToExpression(getPrototype(), true, entityName);
            criteria = criteria == null ? e : new And(criteria, e);
        }
        if (getRecordPrototype() != null) {
            Expression e = (entity.getBuilder().recordToExpression(getRecordPrototype(), entityName));
            criteria = criteria == null ? e : new And(criteria, e);
        }
        if (getExpression() != null) {
            Expression e = getExpression();
            criteria = criteria == null ? e : new And(criteria, e);
        }
        s.setWhere(criteria);
        s.orderBy(getOrder());
        query = entity.createQuery(s);
        for (Map.Entry<String, Object> e : paramsByName.entrySet()) {
            query.setParameter(e.getKey(), e.getValue());
        }
        for (Map.Entry<Integer, Object> e : paramsByIndex.entrySet()) {
            query.setParameter(e.getKey().intValue(), e.getValue());
        }
        query.setUpdatable(this.isUpdatable());
        if (hints != null) {
            for (Map.Entry<String, Object> h : hints.entrySet()) {
                query.setHint(h.getKey(), h.getValue());
            }
        }
//        }
        return query;
    }

    @Override
    public Date getDate() throws UPAException {
        return exec().getDate();
    }

    @Override
    public Boolean getBoolean() throws UPAException {
        return exec().getBoolean();
    }

    @Override
    public String getString() throws UPAException {
        return exec().getString();
    }

    @Override
    public Number getNumber() throws UPAException {
        return exec().getNumber();
    }

    @Override
    public Object getSingleValue() throws UPAException {
        return exec().getString();
    }

    @Override
    public Object getSingleValue(Object defaultValue) throws UPAException {
        return exec().getSingleValue(defaultValue);
    }

    @Override
    public MultiRecord getMultiRecord() throws UPAException {
        return exec().getMultiRecord();
    }

    @Override
    public Record getRecord() throws UPAException {
        return exec().getRecord();
    }

    @Override
    public <R2> List<R2> getEntityList() throws UPAException {
        Query exec = exec();
        return exec.getEntityList();
    }

    @Override
    public <R> R getEntity() throws UPAException {
        return exec().getEntity();
    }

    @Override
    public <K> List<K> getIdList() throws UPAException {
        return exec().getIdList();
    }

    @Override
    public List<Key> getKeyList() throws UPAException {
        return exec().getKeyList();
    }

    @Override
    public List<MultiRecord> getMultiRecordList() throws UPAException {
        return exec().getMultiRecordList();
    }

    @Override
    public List<Record> getRecordList() throws UPAException {
        return exec().getRecordList();
    }

    @Override
    public ResultMetaData getMetaData() throws UPAException {
        return exec().getMetaData();
    }

    public <T> List<T> getValueList(int index) throws UPAException {
        return exec().getValueList(index);
    }

    @Override
    public <T> Set<T> getValueSet(int index) throws UPAException {
        return exec().getValueSet(index);
    }

    @Override
    public <T> Set<T> getValueSet(String name) throws UPAException {
        return exec().getValueSet(name);
    }

    public <T> List<T> getValueList(String name) throws UPAException {
        return exec().getValueList(name);
    }

    public <T> List<T> getTypeList(Class<T> type, String... fields) throws UPAException {
        return exec().getTypeList(type, fields);
    }

    public <T> Set<T> getTypeSet(Class<T> type, String... fields) throws UPAException {
        return exec().getTypeSet(type, fields);
    }

    public <R> R getSingleEntity() throws UPAException {
        return exec().getSingleEntity();
    }

    public <R> R getSingleEntityOrNull() throws UPAException {
        return exec().getSingleEntityOrNull();
    }

    @Override
    public Query setParameter(String name, Object value) {
        if (query != null) {
            throw new IllegalArgumentException("Query is already executed");
        }
        paramsByName.put(name, value);
        return this;
    }

    public Query setParameters(Map<String, Object> parameters) {
        if (parameters != null) {
            if (query != null) {
                throw new IllegalArgumentException("Query is already executed");
            }
            paramsByName.putAll(parameters);
        }
        return this;
    }

    @Override
    public Query setParameter(int index, Object value) {
        if (query != null) {
            throw new IllegalArgumentException("Query is already executed");
        }
        paramsByIndex.put(index, value);
        return this;
    }

    @Override
    public Query removeParameter(String name) {
        if(paramsByName!=null){
            paramsByName.remove(name);
        }
        return this;
    }

    @Override
    public Query removeParameter(int index) {
        if(paramsByIndex!=null){
            paramsByIndex.remove(index);
        }
        return this;
    }

    public boolean isLazyListLoadingEnabled() {
        return lazyListLoadingEnabled;
    }

    public Query setLazyListLoadingEnabled(boolean lazyLoadingEnabled) {
        this.lazyListLoadingEnabled = lazyLoadingEnabled;
        if (query != null) {
            query.setLazyListLoadingEnabled(lazyListLoadingEnabled);
        }
        return this;
    }

    public boolean isUpdatable() {
        return updatable;
    }

    public void setUpdatable(boolean forUpdate) {
        this.updatable = forUpdate;
        if (query != null) {
            query.setUpdatable(forUpdate);
        }
    }

    public void updateCurrent() {
        if (query == null) {
            throw new IllegalArgumentException("Not yet executed");
        }
        query.updateCurrent();
    }

    public int executeNonQuery() {
        return exec().executeNonQuery();
    }

    public void close() {
        if (query != null) {
            query.close();
        }
    }

    public QueryBuilder byField(String field, Object value) {
        return byExpression(
                new Equals(new Var(new Var(entity.getName()), entity.getField(field).getName()),
                        new Param(entity.getField(field).getName(), value))
        );
    }

    public boolean isEmpty() throws UPAException {
        return exec().isEmpty();
    }

    public Map<String, Object> getHints() {
        if (query != null) {
            return query.getHints();
        }
        return hints;
    }

    public Object getHint(String hintName) {
        if (query != null) {
            return query.getHint(hintName);
        }
        return hints==null?null:hints.get(hintName);
    }

    public Object getHint(String hintName,Object defaultValue) {
        if (query != null) {
            return query.getHint(hintName,defaultValue);
        }
        Object c = hints == null ? null : hints.get(hintName);
        return c==null?defaultValue:c;
    }

    @Override
    public QueryBuilder setHint(String key, Object value) {
        if (query != null) {
            throw new IllegalArgumentException("Query is already executed");
        }
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

    @Override
    public <K> Set<K> getIdSet() throws UPAException {
        return exec().getIdSet();
    }

    @Override
    public Set<Key> getKeySet() throws UPAException {
        return exec().getKeySet();
    }
}
