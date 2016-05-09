package net.vpc.upa.impl;

import net.vpc.upa.Key;
import net.vpc.upa.Record;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;

import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/28/12 12:51 AM
 */
public interface EntityConverter {

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

    Object getMainProperty(Object entityValue) throws UPAException;

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

    public void setProperty(Object entityObject, String property, Object value) throws UPAException;

    public Object getProperty(Object entityObject, String property) throws UPAException;

    public Expression recordToExpression(Record entityRecord, String entityAlias) throws UPAException;

    public Expression entityToExpression(Object entityValue, boolean ignoreUnspecified, String entityAlias) throws UPAException;

    //    public Expression idToExpression(Object key) throws UPAException;
    public Expression idToExpression(Object entityId, String alias) throws UPAException;

    public Expression objectToIdExpression(Object objectOrRecord, String alias) throws UPAException;

    public Expression keyToExpression(Key recordKey, String alias) throws UPAException;

    public <K> Expression idListToExpression(List<K> entityIdList, String alias) throws UPAException;

    public Expression keyListToExpression(List<Key> entityIdList, String alias) throws UPAException;
}
