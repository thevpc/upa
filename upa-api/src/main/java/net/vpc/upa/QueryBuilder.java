/**
 * ====================================================================
 * UPA (Unstructured Persistence API)
 * Yet another ORM Framework
 * ++++++++++++++++++++++++++++++++++
 * Unstructured Persistence API, referred to as UPA, is a genuine effort
 * to raise programming language frameworks managing relational data in
 * applications using Java Platform, Standard Edition and Java Platform,
 * Enterprise Edition and Dot Net Framework equally to the next level of
 * handling ORM for mutable data structures. UPA is intended to provide
 * a solid reflection mechanisms to the mapped data structures while
 * affording to make changes at runtime of those data structures.
 * Besides, UPA has learned considerably of the leading ORM
 * (JPA, Hibernate/NHibernate, MyBatis and Entity Framework to name a few)
 * failures to satisfy very common even known to be trivial requirement in
 * enterprise applications.
 * <p>
 * Copyright (C) 2014-2015 Taha BEN SALAH
 * <p>
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free Software
 * Foundation; either version 2 of the License, or (at your option) any later
 * version.
 * <p>
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
 * details.
 * <p>
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 51
 * Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * ====================================================================
 */
package net.vpc.upa;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.Order;
import net.vpc.upa.filters.FieldFilter;
import net.vpc.upa.persistence.ResultMetaData;

import java.io.Serializable;
import java.util.*;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/9/12 9:59 AM
 */
public interface QueryBuilder extends Serializable, Closeable {

    Entity getEntityType();

    QueryBuilder byField(String field, Object value);

    QueryBuilder byField(String field, Object value, boolean condition);

    QueryBuilder byField(String field, SearchOperator operator,Object value);

    QueryBuilder byField(String field, SearchOperator operator,Object value, boolean condition);

    QueryBuilder byExpression(String expression);

    QueryBuilder byExpression(String expression, boolean condition);

    QueryBuilder byExpression(Expression expression);

    QueryBuilder byExpression(Expression expression, boolean condition);

    QueryBuilder byKeyList(List<Key> expr);

    QueryBuilder byKeyList(List<Key> expr, boolean condition);

    QueryBuilder byExpressionList(List<Expression> expr);

    QueryBuilder byExpressionList(List<Expression> expr, boolean condition);

    QueryBuilder byId(Object id);

    QueryBuilder byId(Object id, boolean condition);

    QueryBuilder byIdList(List<Object> id);

    QueryBuilder byIdList(List<Object> id, boolean condition);

    QueryBuilder byKey(Key key);

    QueryBuilder byKey(Key key, boolean condition);

    QueryBuilder byPrototype(Object prototype);

    QueryBuilder byPrototype(Object prototype, boolean condition);

    QueryBuilder byDocumentPrototype(Document prototype);

    QueryBuilder byDocumentPrototype(Document prototype, boolean condition);

    QueryBuilder orderBy(Order order);

    QueryBuilder setFieldFilter(FieldFilter fieldFilter);

    QueryBuilder setUpdatable(boolean updatable);

    Expression getExpression();

    Order getOrder();

    FieldFilter getFieldFilter();

    Object getId();

    Key getKey();

    Object getPrototype();

    Document getDocumentPrototype();

    String getEntityAlias();

    QueryBuilder setEntityAlias(String entityAlias);

    int getTop();

    void setTop(int top);

    Date getDate();

    Boolean getBoolean();

    Integer getInteger();

    Long getLong();

    Double getDouble();

    String getString();

    Number getNumber();

    Object getSingleValue();

    Object getSingleValue(Object defaultValue);

    MultiDocument getMultiDocument();

    Document getDocument();

    /**
     * Executes a Select query and returns a single result.
     *
     * @param <R> Result Type
     * @return Single result if unique
     * @throws net.vpc.upa.exceptions.NonUniqueResultException if more thant one
     * result was returned by query
     * @throws net.vpc.upa.exceptions.NoResultException if no result if returned
     * by query
     */
    <R> R getSingleResult();

    /**
     * Executes a Select query and returns a single result if found. If query
     * returns no result null is returned. When Multiple results
     * NonUniqueResultException will be thrown
     *
     * @param <R> Result Type
     * @return Single result if found. When Multiple results
     * NonUniqueResultException will be thrown
     * @throws net.vpc.upa.exceptions.NonUniqueResultException if more thant one
     * result was returned by query
     */
    <R> R getSingleResultOrNull();

    <R> R getSingleResultOrNull(Class<R> type, String... fields);

    <R> R getFirstResultOrNull(Class<R> type, String... fields);

    <R> R getSingleResult(Class<R> type, String... fields);

    /**
     * Executes a Select query and returns a single result if found. If query
     * returns no result null is returned. When Multiple results, the first
     * result will be returned
     *
     * @param <R> Result Type
     * @return Single result if found. When Multiple results, the first result
     * will be returned. If query returns no result null is returned.
     */
    <R> R getFirstResultOrNull();

    boolean isEmpty();

    <K> List<K> getIdList();

    <K> Set<K> getIdSet();

    List<Key> getKeyList();

    Set<Key> getKeySet();

    List<MultiDocument> getMultiDocumentList();

    <T> List<T> getResultList(Class<T> type, String... fields);

    <T> Set<T> getResultSet(Class<T> type, String... fields);

    <T> List<T> getResultList();

    <T> Set<T> getResultSet();

    List<Document> getDocumentList();

    <T> List<T> getValueList(int index);

    <T> Set<T> getValueSet(int index);

    <T> Set<T> getValueSet(String name);

    <T> List<T> getValueList(String name);

    ResultMetaData getMetaData();

    QueryBuilder setParameter(String name, Object value);

    QueryBuilder setParameters(Map<String, Object> parameters);

    QueryBuilder setParameter(int index, Object value);

    QueryBuilder setParameter(String name, Object value, boolean condition);

    QueryBuilder setParameters(Map<String, Object> parameters, boolean condition);

    QueryBuilder setParameter(int index, Object value, boolean condition);

    QueryBuilder removeParameter(String name);

    QueryBuilder removeParameter(int index);

    boolean isLazyListLoadingEnabled();

    QueryBuilder setLazyListLoadingEnabled(boolean lazyLoadingEnabled);

    QueryBuilder setHint(String key, Object value);

    QueryBuilder setHints(Map<String, Object> hints);

    Map<String, Object> getHints();

    Object getHint(String hintName);

    Object getHint(String hintName, Object defaultValue);

    boolean isUpdatable();

    void updateCurrent();

    int executeNonQuery();

    Query toQuery();
}
