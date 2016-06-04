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

import java.util.List;
import java.util.Set;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 1:51 AM
 */
public interface EntityBuilder {

    public Record createRecord();

    public Record createInitializedRecord();

    public <R> R createInitializedObject();

    public <R> R createObject();

    public <R> R copyObject(R r);

    public Record copyRecord(Record rec);

    public <R> Record getRecord(R entity);

    public Record getRecord(Object entity, Set<String> fields, boolean ignoreUnspecified,boolean ensureIncludeIds);

    public <R> Record getRecord(R entity, boolean ignoreUnspecified);

    public <R> R getEntity(Record unstructuredRecord);

    public void setProperty(Object entityObject, String property, Object value) throws UPAException;

    public Object getProperty(Object entityObject, String property) throws UPAException;

    public Key createKey(Object... keyValues);

    public Object createId(Object... idValues);

    public Object getId(Key unstructuredKey);

    public Key getKey(Object key);

    /**
     * transforms entity id to a Record key representation of the given entity
     * id. Updates to the record are NOT recorded to the provided value and vice
     * versa
     *
     * @param entityId entity id
     * @return key representation
     */
    Key idToKey(Object entityId) throws UPAException;

    /**
     * transforms record key to a entity id representation of the given record
     * key. Updates to the record are NOT recorded to the provided value and
     * vice versa
     *
     * @param recordKey record key
     * @return key representation
     */
    Object keyToId(Key recordKey) throws UPAException;

    /**
     * transforms entity value to a Record value representation of the given
     * entity value. Updates to the record are recorded to the provided value
     * and vice versa
     *
     * @param objectValue entity value
     * @return entityToRecord(r, false)
     * @throws UPAException
     */
    Record objectToRecord(Object objectValue) throws UPAException;

    /**
     * Record value representation of the given entity. updates to the record
     * are recorded to the provided value
     *
     * @param objectValue entity value
     * @param ignoreUnspecified when true primitive number type zeros and
     * boolean type false values are reported as null (not included in record)
     * @return objectToRecord(r, false)
     * @throws UPAException
     */
    Record objectToRecord(Object objectValue, boolean ignoreUnspecified) throws UPAException;

    Object getMainValue(Object objectValue) throws UPAException;

    <R> R recordToObject(Record record) throws UPAException;

    <R> R idToObject(Object objectId) throws UPAException;

    Record idToRecord(Object objectId) throws UPAException;

    Object objectToId(Object objectValue) throws UPAException;

    Key objectToKey(Object objectValue) throws UPAException;

    Object recordToId(Record record) throws UPAException;

    Key recordToKey(Record record) throws UPAException;

    Object keyToObject(Key key) throws UPAException;

    Record keyToRecord(Key key) throws UPAException;

    public void setRecordId(Record record, Object id) throws UPAException;

    public void setObjectId(Object object, Object id) throws UPAException;

    public Expression recordToExpression(Record record, String alias) throws UPAException;

    public Expression objectToExpression(Object object, boolean ignoreUnspecified, String alias) throws UPAException;

    //    public Expression idToExpression(Object key) throws UPAException;
    public Expression objectToIdExpression(Object objectOrRecord, String alias) throws UPAException;

    public Expression idToExpression(Object id, String alias) throws UPAException;

    public Expression keyToExpression(Key recordKey, String alias) throws UPAException;

    public <K> Expression idListToExpression(List<K> idList, String alias) throws UPAException;

    public Expression keyListToExpression(List<Key> keyList, String alias) throws UPAException;

    public QualifiedRecord createQualifiedRecord() throws UPAException;

    public QualifiedRecord createQualifiedRecord(Record record) throws UPAException;

}
