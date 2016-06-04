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
 *
 * Copyright (C) 2014-2015 Taha BEN SALAH
 *
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free Software
 * Foundation; either version 2 of the License, or (at your option) any later
 * version.
 *
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
 * details.
 *
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 51
 * Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * ====================================================================
 */
package net.vpc.upa;

import net.vpc.upa.exceptions.UPAException;
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

    public Date getDate() throws UPAException;

    public Boolean getBoolean() throws UPAException;

    public String getString() throws UPAException;

    public Number getNumber() throws UPAException;

    public Object getSingleValue() throws UPAException;

    public Object getSingleValue(Object defaultValue) throws UPAException;

    public MultiRecord getMultiRecord() throws UPAException;

    public Record getRecord() throws UPAException;

    //    <R2> List<R2> getEntityList(Entity e) throws UPAException;
//    <K2> List<K2> getIdList(Entity e) throws UPAException;
    <R> List<R> getEntityList() throws UPAException;

    <R> R getSingleEntity() throws UPAException;

    public <R> R getSingleEntityOrNull() throws UPAException;

    <R> R getEntity() throws UPAException;

    boolean isEmpty() throws UPAException;

    <K> List<K> getIdList() throws UPAException;

    <K> Set<K> getIdSet() throws UPAException;

    List<Key> getKeyList() throws UPAException;

    Set<Key> getKeySet() throws UPAException;

    public List<MultiRecord> getMultiRecordList() throws UPAException;

    public List<Record> getRecordList() throws UPAException;

    public <T> List<T> getValueList(int index) throws UPAException;

    public <T> Set<T> getValueSet(int index) throws UPAException;

    public <T> Set<T> getValueSet(String name) throws UPAException ;

    public <T> List<T> getValueList(String name) throws UPAException;

    public <T> List<T> getTypeList(Class<T> type, String... fields) throws UPAException;

    public <T> Set<T> getTypeSet(Class<T> type, String... fields) throws UPAException ;

    public ResultMetaData getMetaData() throws UPAException;

    Query setParameter(String name, Object value);

    Query setParameters(Map<String, Object> parameters);

    Query setParameter(int index, Object value);

    public void setUpdatable(boolean forUpdate);

    public boolean isLazyListLoadingEnabled();

    public Query setLazyListLoadingEnabled(boolean lazyLoadingEnabled);

    public Query setHint(String key, Object value);

    public Map<String, Object> getHints();

    public boolean isUpdatable();

    public void updateCurrent();

    public int executeNonQuery();

    public void close();
}
