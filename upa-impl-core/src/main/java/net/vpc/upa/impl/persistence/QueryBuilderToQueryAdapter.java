package net.vpc.upa.impl.persistence;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.ResultMetaData;

import java.util.Date;
import java.util.List;
import java.util.Map;
import java.util.Set;

public class QueryBuilderToQueryAdapter implements Query {
    private QueryBuilder query;

    public QueryBuilderToQueryAdapter(QueryBuilder query) {
        this.query = query;
    }

    public QueryBuilder getQueryBuilder() {
        return query;
    }

    public Date getDate() throws UPAException {
        return query.getDate();
    }

    public Boolean getBoolean() throws UPAException {
        return query.getBoolean();
    }

    public Integer getInteger() throws UPAException {
        return query.getInteger();
    }

    public Long getLong() throws UPAException {
        return query.getLong();
    }

    public Double getDouble() throws UPAException {
        return query.getDouble();
    }

    public String getString() throws UPAException {
        return query.getString();
    }

    public Number getNumber() throws UPAException {
        return query.getNumber();
    }

    public Object getSingleValue() throws UPAException {
        return query.getSingleValue();
    }

    public Object getSingleValue(Object defaultValue) throws UPAException {
        return query.getSingleValue(defaultValue);
    }

    public MultiDocument getMultiDocument() throws UPAException {
        return query.getMultiDocument();
    }

    public Document getDocument() throws UPAException {
        return query.getDocument();
    }

    public <R> R getSingleResult() throws UPAException {
        return query.getSingleResult();
    }

    public <R> R getSingleResultOrNull() throws UPAException {
        return query.getSingleResultOrNull();
    }

    public <R> R getFirstResultOrNull() throws UPAException {
        return query.getFirstResultOrNull();
    }

    public boolean isUpdatable() {
        return query.isUpdatable();
    }

    public Query setParameters(Map<String, Object> parameters) {
        query.setParameters(parameters);
        return this;
    }

    public Query setUpdatable(boolean forUpdate) {
        query.setUpdatable(forUpdate);
        return this;
    }

    public Query setParameter(String name, Object value, boolean condition) {
        query.setParameter(name, value, condition);
        return this;
    }

    public Query setParameters(Map<String, Object> parameters, boolean condition) {
        query.setParameters(parameters, condition);
        return this;
    }

    public Query setParameter(int index, Object value, boolean condition) {
        query.setParameter(index, value, condition);
        return this;
    }

//    public void setContext(EntityExecutionContext context) {
//        query.setContext(context);
//    }

    public int executeNonQuery() {
        return query.executeNonQuery();
    }

    public List<MultiDocument> getMultiDocumentList() throws UPAException {
        return query.getMultiDocumentList();
    }

    public boolean isEmpty() throws UPAException {
        return query.isEmpty();
    }

    public <T> List<T> getResultList(Class<T> type, String... fields) {
        return query.getResultList(type, fields);
    }

    public <T> Set<T> getResultSet(Class<T> type, String... fields) {
        return query.getResultSet(type, fields);
    }

    public <T> List<T> getResultList() throws UPAException {
        return query.getResultList();
    }

    public <T> Set<T> getResultSet() throws UPAException {
        return query.getResultSet();
    }

    public List<Document> getDocumentList() throws UPAException {
        return query.getDocumentList();
    }

    public <T> List<T> getValueList(int index) throws UPAException {
        return query.getValueList(index);
    }

    public <T> Set<T> getValueSet(int index) throws UPAException {
        return query.getValueSet(index);
    }

    public <T> Set<T> getValueSet(String name) throws UPAException {
        return query.getValueSet(name);
    }

    public <T> List<T> getValueList(String name) throws UPAException {
        return query.getValueList(name);
    }

    public List<Key> getKeyList() throws UPAException {
        return query.getKeyList();
    }

    public <K2> List<K2> getIdList() throws UPAException {
        return query.getIdList();
    }

    public <K> Set<K> getIdSet() throws UPAException {
        return query.getIdSet();
    }

    public Set<Key> getKeySet() throws UPAException {
        return query.getKeySet();
    }

    public Query setParameter(final String name, Object value) {
        query.setParameter(name, value);
        return this;
    }

    public Query removeParameter(final String name) {
        query.removeParameter(name);
        return this;
    }

    public Query removeParameter(int index) {
        query.removeParameter(index);
        return this;
    }

    public Query setParameter(int index, Object value) {
        query.setParameter(index, value);
        return this;
    }

    public ResultMetaData getMetaData() throws UPAException {
        return query.getMetaData();
    }

    @Override
    public <R> R getSingleResult(Class<R> type, String... fields) {
        return query.getSingleResult(type, fields);
    }

    @Override
    public <R> R getSingleResultOrNull(Class<R> type, String... fields) {
        return query.getSingleResultOrNull(type, fields);
    }

    @Override
    public <R> R getFirstResultOrNull(Class<R> type, String... fields) {
        return query.getFirstResultOrNull(type, fields);
    }

    public boolean isLazyListLoadingEnabled() {
        return query.isLazyListLoadingEnabled();
    }

    public Query setLazyListLoadingEnabled(boolean lazyLoadingEnabled) {
        query.setLazyListLoadingEnabled(lazyLoadingEnabled);
        return this;
    }

    public void updateCurrent() {
        query.updateCurrent();
    }

    public void close() {
        query.close();
    }

    public Query setHint(String key, Object value) {
        query.setHint(key, value);
        return this;
    }

    public Query setHints(Map<String, Object> hints) {
        query.setHints(hints);
        return this;
    }

    public Map<String, Object> getHints() {
        return query.getHints();
    }

    public Object getHint(String hintName) {
        return query.getHint(hintName);
    }

    public Object getHint(String hintName, Object defaultValue) {
        return query.getHint(hintName, defaultValue);
    }
}
