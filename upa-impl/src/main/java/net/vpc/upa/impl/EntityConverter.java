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
     * transforms object id to a Record key representation of the given object
     * id. Updates to the record are NOT recorded to the provided value and vice
     * versa
     *
     * @param id entity id
     * @return key representation
     */
    Key idToKey(Object id) throws UPAException;

    /**
     * transforms record key to a object id representation of the given record
     * key. Updates to the record are NOT recorded to the provided value and
     * vice versa
     *
     * @param recordKey record key
     * @return key representation
     */
    Object keyToId(Key recordKey) throws UPAException;

    /**
     * transforms object value to a Record value representation of the given
     * object value. Updates to the record are recorded to the provided value
     * and vice versa
     *
     * @param object object value
     * @return objectToRecord(r, false)
     * @throws UPAException
     */
    Record objectToRecord(Object object) throws UPAException;

    /**
     * Record value representation of the given entity. updates to the record
     * are recorded to the provided value
     *
     * @param object entity value
     * @param ignoreUnspecified when true primitive number type zeros and
     * boolean type false values are reported as null (not included in record)
     * @return objectToRecord(r, false)
     * @throws UPAException
     */
    Record objectToRecord(Object object, boolean ignoreUnspecified) throws UPAException;

    Object getMainProperty(Object object) throws UPAException;

    <R> R recordToObject(Record record) throws UPAException;

    <R> R idToObject(Object id) throws UPAException;

    Record idToRecord(Object id) throws UPAException;

    Object objectToId(Object object) throws UPAException;

    Key objectToKey(Object object) throws UPAException;

    Object recordToId(Record record) throws UPAException;

    Key recordToKey(Record record) throws UPAException;

    Object keyToObject(Key key) throws UPAException;

    Record keyToRecord(Key key) throws UPAException;

    public void setRecordId(Record record, Object id) throws UPAException;

    public void setObjectId(Object object, Object id) throws UPAException;

    public void setProperty(Object object, String property, Object value) throws UPAException;

    public Object getProperty(Object object, String property) throws UPAException;

    public Expression recordToExpression(Record record, String alias) throws UPAException;

    public Expression objectToExpression(Object object, boolean ignoreUnspecified, String alias) throws UPAException;

    //    public Expression idToExpression(Object key) throws UPAException;
    public Expression idToExpression(Object id, String alias) throws UPAException;

    public Expression objectToIdExpression(Object objectOrRecord, String alias) throws UPAException;

    public Expression keyToExpression(Key recordKey, String alias) throws UPAException;

    public <K> Expression idListToExpression(List<K> idList, String alias) throws UPAException;

    public Expression keyListToExpression(List<Key> keyList, String alias) throws UPAException;
}
