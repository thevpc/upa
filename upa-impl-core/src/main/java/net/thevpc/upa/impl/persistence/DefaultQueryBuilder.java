package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.*;
import net.thevpc.upa.expressions.*;

import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.expressions.*;
import net.thevpc.upa.filters.FieldFilter;
import net.thevpc.upa.impl.ext.QueryExt;
import net.thevpc.upa.persistence.ResultMetaData;

import java.util.*;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/29/12 2:28 AM
 */
public final class DefaultQueryBuilder extends AbstractQueryBuilder implements QueryBuilder {

    private boolean lazyListLoadingEnabled = true;
    private Entity entity;
    private String entityAlias;
    private CriteriaBuilder criteriaBuilder;
    private Order order;
    private int top;
    private FieldFilter fieldFilter;
//    private Object id;
//    private Key key;
//    private Object prototype;
//    private Document documentPrototype;
//    private Expression expression;
    private Map<String, Object> hints = new HashMap<String, Object>();
    private QueryExt query;
    private LinkedHashMap<String, Object> paramsByName = new LinkedHashMap<String, Object>();
    private LinkedHashMap<Integer, Object> paramsByIndex = new LinkedHashMap<Integer, Object>();

    public DefaultQueryBuilder(Entity entity) {
        this.entity = entity;
        criteriaBuilder = new CriteriaBuilder(entity);
    }

    public Entity getEntityType() {
        return entity;
    }

    public QueryBuilder byExpression(String expression) {
        return byExpression(expression == null ? null : new UserExpression(expression));
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
        criteriaBuilder.byId(id);
        return this;
    }

    public QueryBuilder byExpression(Expression expression) {
        criteriaBuilder.byExpression(expression);
        return this;
    }

    @Override
    public QueryBuilder byExpression(Expression expression, boolean condition) {
        if (condition) {
            criteriaBuilder.byExpression(expression);
        }
        return this;
    }

    @Override
    public QueryBuilder byKey(Key key) {
        criteriaBuilder.byKey(key);
        return this;
    }

    @Override
    public QueryBuilder byPrototype(Object prototype) {
        criteriaBuilder.byPrototype(prototype);
        return this;
    }

    @Override
    public QueryBuilder byDocumentPrototype(Document prototype) {
        criteriaBuilder.byDocumentPrototype(prototype);
        return this;
    }

    @Override
    public Expression getExpression() {
        return criteriaBuilder.getExpression();
    }

    @Override
    public Object getId() {
        return criteriaBuilder.getId();
    }

    @Override
    public Key getKey() {
        return criteriaBuilder.getKey();
    }

    @Override
    public Object getPrototype() {
        return criteriaBuilder.getPrototype();
    }

    public Document getDocumentPrototype() {
        return criteriaBuilder.getDocumentPrototype();
    }

    @Override
    public Order getOrder() {
        return order;
    }

    @Override
    public FieldFilter getFieldFilter() {
        return fieldFilter;
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
        s.setWhere(criteriaBuilder.createExpression());
        s.orderBy(getOrder());
        s.top(getTop());
        query = (QueryExt) entity.createQuery(s);
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
    public <R> R getSingleResultOrNull(Class<R> type, String... fields) {
        return build().getSingleResultOrNull(type, fields);
    }

    @Override
    public <R> R getFirstResultOrNull(Class<R> type, String... fields) {
        return build().getFirstResultOrNull(type, fields);
    }

    @Override
    public <R> R getSingleResult(Class<R> type, String... fields) {
        return build().getSingleResult(type, fields);
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
    public <T> List<T> getResultList(Class<T> type, String... fields) {
        Query q = build();
        return q.getResultList(type, fields);
    }

    @Override
    public <T> Set<T> getResultSet(Class<T> type, String... fields) {
        Query q = build();
        return q.getResultSet(type, fields);
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
    public QueryBuilder setParameter(String name, Object value) {
        if (query != null) {
            throw new IllegalUPAArgumentException("Query is already executed");
        }
        paramsByName.put(name, value);
        return this;
    }

    public QueryBuilder setParameters(Map<String, Object> parameters) {
        if (parameters != null) {
            if (query != null) {
                throw new IllegalUPAArgumentException("Query is already executed");
            }
            paramsByName.putAll(parameters);
        }
        return this;
    }

    @Override
    public QueryBuilder setParameter(int index, Object value) {
        if (query != null) {
            throw new IllegalUPAArgumentException("Query is already executed");
        }
        paramsByIndex.put(index, value);
        return this;
    }

    @Override
    public QueryBuilder removeParameter(String name) {
        if (paramsByName != null) {
            paramsByName.remove(name);
        }
        return this;
    }

    @Override
    public QueryBuilder removeParameter(int index) {
        if (paramsByIndex != null) {
            paramsByIndex.remove(index);
        }
        return this;
    }

    public boolean isLazyListLoadingEnabled() {
        return lazyListLoadingEnabled;
    }

    public QueryBuilder setLazyListLoadingEnabled(boolean lazyLoadingEnabled) {
        this.lazyListLoadingEnabled = lazyLoadingEnabled;
        if (query != null) {
            query.setLazyListLoadingEnabled(lazyListLoadingEnabled);
        }
        return this;
    }

    public QueryBuilder setUpdatable(boolean forUpdate) {
        super.setUpdatable(forUpdate);
        if (query != null) {
            query.setUpdatable(forUpdate);
        }
        return this;
    }

    public void updateCurrent() {
        if (query == null) {
            throw new IllegalUPAArgumentException("Not yet executed");
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

    @Override
    public QueryBuilder byIdList(List<Object> ids) {
        criteriaBuilder.byIdList(ids);
        return this;
    }

    public QueryBuilder byField(String field, Object value) {
        criteriaBuilder.byField(field, value);
        return this;
    }

    @Override
    public QueryBuilder byField(String field, SearchOperator operator, Object value) {
        criteriaBuilder.byField(field, operator,value);
        return this;
    }

    @Override
    public QueryBuilder byField(String field, SearchOperator operator, Object value, boolean condition) {
        if (condition) {
            criteriaBuilder.byField(field, operator,value);
        }
        return this;
    }

    @Override
    public QueryBuilder byField(String field, Object value, boolean condition) {
        if (condition) {
            return byField(field, value);
        }
        return this;
    }

    @Override
    public QueryBuilder byExpression(String expression, boolean condition) {
        if (condition) {
            return byExpression(expression);
        }
        return this;
    }

    @Override
    public QueryBuilder byKeyList(List<Key> expr, boolean condition) {
        if (condition) {
            return byKeyList(expr);
        }
        return this;
    }

    @Override
    public QueryBuilder byExpressionList(List<Expression> expr, boolean condition) {
        if (condition) {
            return byExpressionList(expr);
        }
        return this;
    }

    @Override
    public QueryBuilder byId(Object id, boolean condition) {
        if (condition) {
            return byId(id);
        }
        return this;
    }

    @Override
    public QueryBuilder byIdList(List<Object> id, boolean condition) {
        if (condition) {
            return byIdList(id);
        }
        return this;
    }

    @Override
    public QueryBuilder byKey(Key key, boolean condition) {
        if (condition) {
            return byKey(key);
        }
        return this;
    }

    @Override
    public QueryBuilder byPrototype(Object prototype, boolean condition) {
        if (condition) {
            return byPrototype(prototype);
        }
        return this;
    }

    @Override
    public QueryBuilder byDocumentPrototype(Document prototype, boolean condition) {
        if (condition) {
            return byDocumentPrototype(prototype);
        }
        return this;
    }

    @Override
    public QueryBuilder byKeyList(List<Key> expr) {
        criteriaBuilder.byKeyList(expr);
        return this;
    }

    @Override
    public QueryBuilder byExpressionList(List<Expression> expr) {
        criteriaBuilder.byExpressionList(expr);
        return this;
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
        return hints == null ? null : hints.get(hintName);
    }

    public Object getHint(String hintName, Object defaultValue) {
        if (query != null) {
            return query.getHint(hintName, defaultValue);
        }
        Object c = hints == null ? null : hints.get(hintName);
        return c == null ? defaultValue : c;
    }

    @Override
    public QueryBuilder setHint(String key, Object value) {
        if (query != null) {
            throw new IllegalUPAArgumentException("Query is already executed");
        }
        if (value == null) {
            hints.remove(key);
        } else {
            hints.put(key, value);
        }
        return this;
    }

    @Override
    public QueryBuilder setHints(Map<String, Object> hints) {
        if (hints != null) {
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

//    //@Override
//    public void setContext(EntityExecutionContext context) {
//        if(query!=null){
//            query.setContext(context);
//        }
//    }
}
