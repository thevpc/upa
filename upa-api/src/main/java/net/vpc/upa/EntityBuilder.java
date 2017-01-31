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

import net.vpc.upa.expressions.Expression;

import java.util.List;
import java.util.Set;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 1:51 AM
 */
public interface EntityBuilder {

    public Document createDocument();

    public Document createInitializedDocument();

    public <R> R createInitializedObject();

    public <R> R createObject();

    public <R> R copyObject(R r);

    public Document copyDocument(Document rec);


    public Document objectToDocument(Object entity, Set<String> fields, boolean ignoreUnspecified, boolean ensureIncludeIds);

    public void setProperty(Object entityObject, String property, Object value) ;

    public Object getProperty(Object entityObject, String property) ;

    public Key createKey(Object... keyValues);

    public Object createId(Object... idValues);

    public Object getId(Key unstructuredKey);

    public Object getObject(Object objectOrDocument);

    public Document getDocument(Object objectOrDocument);

    public Key getKey(Object key);

    /**
     * transforms entity id to a Document key representation of the given entity
     * id. Updates to the Document are NOT reflected in the provided value and vice
     * versa
     *
     * @param entityId entity id
     * @return key representation
     */
    Key idToKey(Object entityId) ;

    /**
     * transforms Document key to a entity id representation of the given Document
     * key. Updates to the Document are NOT reflected in the provided value and
     * vice versa
     *
     * @param documentKey Document key
     * @return key representation
     */
    Object keyToId(Key documentKey) ;

    /**
     * transforms entity value to a Document value representation of the given
     * entity value. Updates to the Document are reflected in the provided value
     * and vice versa
     *
     * @param objectValue entity value
     * @return entityToDocument(r, false)
     * @
     */
    Document objectToDocument(Object objectValue) ;

    /**
     * Document value representation of the given entity. updates to the Document
     * are reflected in the provided value
     *
     * @param objectValue entity value
     * @param ignoreUnspecified when true primitive number type zeros and
     * boolean type false values are reported as null (not included in Document)
     * @return objectToDocument(r, false)
     */
    Document objectToDocument(Object objectValue, boolean ignoreUnspecified) ;

    Object getMainValue(Object objectValue) ;

    <R> R documentToObject(Document document) ;

    <R> R idToObject(Object objectId) ;

    Document idToDocument(Object objectId) ;

    Object objectToId(Object objectValue) ;

    Key objectToKey(Object objectValue) ;

    Object documentToId(Document document) ;

    Key documentToKey(Document document) ;

    Object keyToObject(Key key) ;

    Document keyToDocument(Key key) ;

    public void setDocumentId(Document document, Object id) ;

    public void setObjectId(Object object, Object id) ;

    public Expression documentToExpression(Document document, String alias) ;

    public Expression objectToExpression(Object object, boolean ignoreUnspecified, String alias) ;

    //    public Expression idToExpression(Object key) ;
    public Expression objectToIdExpression(Object objectOrDocument, String alias) ;

    public Expression idToExpression(Object id, String alias) ;

    public Expression keyToExpression(Key documentKey, String alias) ;

    public <K> Expression idListToExpression(List<K> idList, String alias) ;

    public Expression keyListToExpression(List<Key> keyList, String alias) ;

    public QualifiedDocument createQualifiedDocument() ;

    public QualifiedDocument createQualifiedDocument(Document document) ;

}
