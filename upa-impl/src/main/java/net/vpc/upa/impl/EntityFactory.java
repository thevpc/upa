package net.vpc.upa.impl;

import net.vpc.upa.Document;
import net.vpc.upa.Key;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;

import java.util.List;
import java.util.Set;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 1:51 AM
 */
public interface EntityFactory {

    Document createDocument();

    <R> R createObject();

    Document objectToDocument(Object object, Set<String> fields, boolean ignoreUnspecified, boolean ensureIncludeIds);

    void setProperty(Object object, String property, Object value) throws UPAException;

    Object getProperty(Object object, String property) throws UPAException;


    /**
     * transforms object id to a Document key representation of the given object
     * id. Updates to the document are NOT reflected in the provided value and vice
     * versa
     *
     * @param id entity id
     * @return key representation
     */
    Key idToKey(Object id) throws UPAException;

    /**
     * transforms document key to a object id representation of the given document
     * key. Updates to the document are NOT reflected in the provided value and
     * vice versa
     *
     * @param documentKey document key
     * @return key representation
     */
    Object keyToId(Key documentKey) throws UPAException;

    /**
     * transforms object value to a Document value representation of the given
     * object value. Updates to the document are reflected in the provided value
     * and vice versa
     *
     * @param object object value
     * @return objectToDocument(r, false)
     * @throws UPAException
     */
    Document objectToDocument(Object object) throws UPAException;

    /**
     * Document value representation of the given entity. updates to the document
     * are reflected in the provided value
     *
     * @param object entity value
     * @param ignoreUnspecified when true primitive number type zeros and
     * boolean type false values are reported as null (not included in document)
     * @return objectToDocument(r, false)
     * @throws UPAException
     */
    Document objectToDocument(Object object, boolean ignoreUnspecified) throws UPAException;

    Object getMainProperty(Object object) throws UPAException;

    <R> R documentToObject(Document document) throws UPAException;

    <R> R idToObject(Object id) throws UPAException;

    Document idToDocument(Object id) throws UPAException;

    Object objectToId(Object object) throws UPAException;

    Key objectToKey(Object object) throws UPAException;

    Object documentToId(Document document) throws UPAException;

    Key documentToKey(Document document) throws UPAException;

    Object keyToObject(Key key) throws UPAException;

    Document keyToDocument(Key key) throws UPAException;

    void setDocmentId(Document document, Object id) throws UPAException;

    void setObjectId(Object object, Object id) throws UPAException;

    Expression documentToExpression(Document document, String alias) throws UPAException;

    Expression objectToExpression(Object object, boolean ignoreUnspecified, String alias) throws UPAException;

    //    public Expression idToExpression(Object key) throws UPAException;
    Expression idToExpression(Object id, String alias) throws UPAException;

    Expression objectToIdExpression(Object objectOrDocument, String alias) throws UPAException;

    Expression keyToExpression(Key documentKey, String alias) throws UPAException;

    <K> Expression idListToExpression(List<K> idList, String alias) throws UPAException;

    Expression keyListToExpression(List<Key> keyList, String alias) throws UPAException;

}
