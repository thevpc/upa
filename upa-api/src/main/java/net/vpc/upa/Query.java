/**
 * ==================================================================== UPA
 * (Unstructured Persistence API) Yet another ORM Framework
 * ++++++++++++++++++++++++++++++++++ Unstructured Persistence API, referred to
 * as UPA, is a genuine effort to raise programming language frameworks managing
 * relational data in applications using Java Platform, Standard Edition and
 * Java Platform, Enterprise Edition and Dot Net Framework equally to the next
 * level of handling ORM for mutable data structures. UPA is intended to provide
 * a solid reflection mechanisms to the mapped data structures while affording
 * to make changes at runtime of those data structures. Besides, UPA has learned
 * considerably of the leading ORM (JPA, Hibernate/NHibernate, MyBatis and
 * Entity Framework to name a few) failures to satisfy very common even known to
 * be trivial requirement in enterprise applications.
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

import net.vpc.upa.persistence.ResultMetaData;

import java.util.Date;
import java.util.List;
import java.util.Map;
import java.util.Set;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/19/12 Time: 6:07 PM To change
 * this template use File | Settings | File Templates.
 */
public interface Query extends Closeable {

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

    <R> R getSingleResult(Class<R> type, String... fields);

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

    <R> R getFirstResultOrNull(Class<R> type, String... fields);

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

    Query setParameter(String name, Object value);

    Query setParameters(Map<String, Object> parameters);

    Query setParameter(int index, Object value);

    Query setParameter(String name, Object value, boolean condition);

    Query setParameters(Map<String, Object> parameters, boolean condition);

    Query setParameter(int index, Object value, boolean condition);

    Query removeParameter(String name);

    Query removeParameter(int index);

    Query setUpdatable(boolean forUpdate);

    boolean isLazyListLoadingEnabled();

    Query setLazyListLoadingEnabled(boolean lazyLoadingEnabled);

    Query setHint(String key, Object value);

    Query setHints(Map<String, Object> hints);

    Map<String, Object> getHints();

    Object getHint(String hintName);

    Object getHint(String hintName, Object defaultValue);

    boolean isUpdatable();

    void updateCurrent();

    int executeNonQuery();

}
