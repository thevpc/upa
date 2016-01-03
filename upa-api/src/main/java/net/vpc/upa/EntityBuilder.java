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

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 1:51 AM
 */
public interface EntityBuilder {

    public Record createRecord();

    public <R> R createObject();

    public <R> Record getRecord(R entity);

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
     * @param entityValue entity value
     * @return entityToRecord(r, false)
     * @throws UPAException
     */
    Record entityToRecord(Object entityValue) throws UPAException;

    /**
     * Record value representation of the given entity. updates to the record
     * are recorded to the provided value
     *
     * @param entityValue entity value
     * @param ignoreUnspecified when true primitive number type zeros and
     * boolean type false values are reported as null (not included in record)
     * @return entityToRecord(r, false)
     * @throws UPAException
     */
    Record entityToRecord(Object entityValue, boolean ignoreUnspecified) throws UPAException;

    Object getMainValue(Object entityValue) throws UPAException;

    <R> R recordToEntity(Record entityRecord) throws UPAException;

    <R> R idToEntity(Object entityId) throws UPAException;

    Record idToRecord(Object entityId) throws UPAException;

    Object entityToId(Object entityValue) throws UPAException;

    Key entityToKey(Object entityValue) throws UPAException;

    Object recordToId(Record entityRecord) throws UPAException;

    Key recordToKey(Record entityRecord) throws UPAException;

    Object keyToEntity(Key recordKey) throws UPAException;

    Record keyToRecord(Key recordKey) throws UPAException;

    public void setRecordId(Record entityRecord, Object entityId) throws UPAException;

    public void setEntityId(Object entityObject, Object entityId) throws UPAException;

    public Expression recordToExpression(Record entityRecord, String entityAlias) throws UPAException;

    public Expression entityToExpression(Object entityValue, boolean ignoreUnspecified, String entityAlias) throws UPAException;

    //    public Expression idToExpression(Object key) throws UPAException;
    public Expression idToExpression(Object entityId, String alias) throws UPAException;

    public Expression keyToExpression(Key recordKey, String alias) throws UPAException;

    public <K> Expression idListToExpression(List<K> entityIdList, String alias) throws UPAException;

    public Expression keyListToExpression(List<Key> entityIdList, String alias) throws UPAException;

    public QualifiedRecord createQualifiedRecord() throws UPAException;

    public QualifiedRecord createQualifiedRecord(Record record) throws UPAException;


}
