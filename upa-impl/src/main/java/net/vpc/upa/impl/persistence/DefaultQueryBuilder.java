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
public final class DefaultQueryBuilder extends AbstractQuery implements QueryBuilder {

    private boolean lazyListLoadingEnabled = true;
    private Entity entity;
    private String entityAlias;
    private Expression expression;
    private Order order;
    private int top;
    private FieldFilter fieldFilter;
    private Object id;
    private Key key;
    private Object prototype;
    private Document documentPrototype;
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
    public QueryBuilder byDocumentPrototype(Document prototype) {
        this.documentPrototype = prototype;
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

    public Document getDocumentPrototype() {
        return documentPrototype;
    }

    public String getEntityAlias() {
        return entityAlias;
    }

    public QueryBuilder setEntityAlias(String entityAlias) {
        this.entityAlias = entityAlias;
        return this;
    }

    private Query build() {
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
        if (getDocumentPrototype() != null) {
            Expression e = (entity.getBuilder().documentToExpression(getDocumentPrototype(), entityName));
            criteria = criteria == null ? e : new And(criteria, e);
        }
        if (getExpression() != null) {
            Expression e = getExpression();
            criteria = criteria == null ? e : new And(criteria, e);
        }
        s.setWhere(criteria);
        s.orderBy(getOrder());
        s.top(getTop());
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

    public int getTop() {
        return top;
    }

    public void setTop(int top) {
        this.top = top;
    }

    @Override
    public Date getDate() throws UPAException {
        return build().getDate();
    }

    @Override
    public Boolean getBoolean() throws UPAException {
        return build().getBoolean();
    }

    @Override
    public Integer getInteger() throws UPAException {
        return build().getInteger();
    }

    @Override
    public Long getLong() throws UPAException {
        return build().getLong();
    }

    @Override
    public Double getDouble() throws UPAException {
        return null;
    }

    @Override
    public String getString() throws UPAException {
        return build().getString();
    }

    @Override
    public Number getNumber() throws UPAException {
        return build().getNumber();
    }

    @Override
    public Object getSingleValue() throws UPAException {
        return build().getString();
    }

    @Override
    public Object getSingleValue(Object defaultValue) throws UPAException {
        return build().getSingleValue(defaultValue);
    }

    @Override
    public MultiDocument getMultiDocument() throws UPAException {
        return build().getMultiDocument();
    }

    @Override
    public Document getDocument() throws UPAException {
        return build().getDocument();
    }

    @Override
    public <R2> List<R2> getEntityList() throws UPAException {
        Query q = build();
        return q.getEntityList();
    }

    @Override
    public <R2> List<R2> getResultList() throws UPAException {
        Query q = build();
        return q.getResultList();
    }

    @Override
    public <T> Set<T> getResultSet() {
        Query q = build();
        return q.getResultSet();
    }

    @Override
    public <R> R getEntity() throws UPAException {
        return build().getEntity();
    }

    @Override
    public <K> List<K> getIdList() throws UPAException {
        return build().getIdList();
    }

    @Override
    public List<Key> getKeyList() throws UPAException {
        return build().getKeyList();
    }

    @Override
    public List<MultiDocument> getMultiDocumentList() throws UPAException {
        return build().getMultiDocumentList();
    }

    @Override
    public List<Document> getDocumentList() throws UPAException {
        return build().getDocumentList();
    }

    @Override
    public ResultMetaData getMetaData() throws UPAException {
        return build().getMetaData();
    }

    public <T> List<T> getValueList(int index) throws UPAException {
        return build().getValueList(index);
    }

    @Override
    public <T> Set<T> getValueSet(int index) throws UPAException {
        return build().getValueSet(index);
    }

    @Override
    public <T> Set<T> getValueSet(String name) throws UPAException {
        return build().getValueSet(name);
    }

    public <T> List<T> getValueList(String name) throws UPAException {
        return build().getValueList(name);
    }

    public <T> List<T> getTypeList(Class<T> type, String... fields) throws UPAException {
        return build().getTypeList(type, fields);
    }

    public <T> Set<T> getTypeSet(Class<T> type, String... fields) throws UPAException {
        return build().getTypeSet(type, fields);
    }

    public <R> R getSingleResult() throws UPAException {
        return build().getSingleResult();
    }

    public <R> R getSingleResultOrNull() throws UPAException {
        return build().getSingleResultOrNull();
    }
    public <R> R getFirstResultOrNull() throws UPAException {
        return build().getFirstResultOrNull();
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

    public void setUpdatable(boolean forUpdate) {
        super.setUpdatable(forUpdate);
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
        return build().executeNonQuery();
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
        return build().isEmpty();
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
    public Query setHint(String key, Object value) {
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
        return build().getIdSet();
    }

    @Override
    public Set<Key> getKeySet() throws UPAException {
        return build().getKeySet();
    }
}
