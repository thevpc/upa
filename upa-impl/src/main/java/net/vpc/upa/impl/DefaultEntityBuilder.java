/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;

import java.util.List;
import java.util.Set;

/**
 * @author taha.bensalah@gmail.com
 */
public class DefaultEntityBuilder implements EntityBuilder {

    private EntityFactory entityFactory;
    private KeyFactory keyFactory;
//    private EntityConverter entityConverter;
    private Entity entity;

    public DefaultEntityBuilder(Entity entity) {
        this.entity = entity;
    }

    public EntityFactory getBuilder() {
        return entityFactory;
    }

    public void setEntityFactory(EntityFactory entityFactory) {
        this.entityFactory = entityFactory;
    }

    public KeyFactory getKeyFactory() {
        return keyFactory;
    }

    public void setKeyFactory(KeyFactory keyFactory) {
        this.keyFactory = keyFactory;
    }

    @Override
    public Document createDocument() {
        return entityFactory.createDocument();
    }

    @Override
    public <R> R copyObject(R r) {
        return documentToObject(copyDocument(objectToDocument(r)));
    }
    
    @Override
    public Document copyDocument(Document rec) {
        Document r = createDocument();
        r.setAll(rec);
        return r;
    }

    @Override
    public <R> R createObject() {
        return entityFactory.createObject();
    }

    @Override
    public Document objectToDocument(Object entity, boolean ignoreUnspecified) {
        return entityFactory.objectToDocument(entity, ignoreUnspecified);
    }

    @Override
    public Document objectToDocument(Object entity, Set<String> fields, boolean ignoreUnspecified, boolean ensureIncludeIds) {
        return entityFactory.objectToDocument(entity, fields, ignoreUnspecified, ensureIncludeIds);
    }

    @Override
    public Document objectToDocument(Object entity) {
        return entityFactory.objectToDocument(entity);
    }

    @Override
    public <R> R documentToObject(Document document) throws UPAException {
        return entityFactory.documentToObject(document);
    }

    @Override
    public Object getObject(Object objectOrDocument) {
        if(entity.getEntityType().isInstance(objectOrDocument)){
            return objectOrDocument;
        }else{
            return documentToObject(objectToDocument(objectOrDocument));
        }
    }

    @Override
    public Document getDocument(Object objectOrDocument) {
        return objectToDocument(objectOrDocument);
    }

    @Override
    public void setProperty(Object entityObject, String property, Object value) throws UPAException {
        if (entityObject instanceof Document) {
            ((Document) entityObject).setObject(property, value);
            return;
        }
        entityFactory.setProperty(entityObject, property, value);
    }

    @Override
    public Object getProperty(Object entityObject, String property) throws UPAException {
        if (entityObject instanceof Document) {
            return ((Document) entityObject).getObject(property);
        }
        return entityFactory.getProperty(entityObject, property);
    }

    @Override
    public Key createKey(Object... keyValues) {
        return keyFactory.createKey(keyValues);
    }

    @Override
    public Object createId(Object... idValues) {
        return keyFactory.createId(idValues);
    }

    @Override
    public Object getId(Key unstructuredKey) {
        return keyFactory.getId(unstructuredKey);
    }

    @Override
    public Key getKey(Object key) {
        return keyFactory.getKey(key);
    }

    @Override
    public Key idToKey(Object entityId) throws UPAException {
        return entityFactory.idToKey(entityId);
    }

    @Override
    public Object keyToId(Key documentKey) throws UPAException {
        return entityFactory.keyToId(documentKey);
    }



    @Override
    public Object getMainValue(Object objectValue) throws UPAException {
        return entityFactory.getMainProperty(objectValue);
    }


    @Override
    public <R> R idToObject(Object objectId) throws UPAException {
        return entityFactory.idToObject(objectId);
    }

    @Override
    public Document idToDocument(Object objectId) throws UPAException {
        return entityFactory.idToObject(objectId);
    }

    @Override
    public Object objectToId(Object objectValue) throws UPAException {
        return entityFactory.objectToId(objectValue);
    }

    @Override
    public Key objectToKey(Object objectValue) throws UPAException {
        return entityFactory.objectToKey(objectValue);
    }

    @Override
    public Object documentToId(Document document) throws UPAException {
        return entityFactory.documentToId(document);
    }

    @Override
    public Key documentToKey(Document document) throws UPAException {
        return entityFactory.documentToKey(document);
    }

    @Override
    public Object keyToObject(Key key) throws UPAException {
        return entityFactory.keyToObject(key);
    }

    @Override
    public Document keyToDocument(Key key) throws UPAException {
        return entityFactory.keyToDocument(key);
    }

    @Override
    public void setDocumentId(Document document, Object id) throws UPAException {
        entityFactory.setDocmentId(document, id);
    }

    @Override
    public void setObjectId(Object object, Object id) throws UPAException {
        entityFactory.setObjectId(object, id);
    }

    @Override
    public Expression documentToExpression(Document document, String alias) throws UPAException {
        return entityFactory.documentToExpression(document, alias);
    }

    @Override
    public Expression objectToExpression(Object object, boolean ignoreUnspecified, String alias) throws UPAException {
        return entityFactory.objectToExpression(object, ignoreUnspecified, alias);
    }

    @Override
    public Expression objectToIdExpression(Object objectOrDocument, String alias) throws UPAException {
        return entityFactory.objectToIdExpression(objectOrDocument, alias);
    }

    @Override
    public Expression idToExpression(Object id, String alias) throws UPAException {
        return entityFactory.idToExpression(id, alias);
    }

    @Override
    public Expression keyToExpression(Key documentKey, String alias) throws UPAException {
        return entityFactory.keyToExpression(documentKey, alias);
    }

    @Override
    public <K> Expression idListToExpression(List<K> idList, String alias) throws UPAException {
        return entityFactory.idListToExpression(idList, alias);
    }

    @Override
    public Expression keyListToExpression(List<Key> keyList, String alias) throws UPAException {
        return entityFactory.keyListToExpression(keyList, alias);
    }

    @Override
    public QualifiedDocument createQualifiedDocument() throws UPAException {
        return new DefaultQualifiedDocument(entity);
    }

    @Override
    public QualifiedDocument createQualifiedDocument(Document document) throws UPAException {
        return new DefaultQualifiedDocument(entity, document);
    }

    @Override
    public Document createInitializedDocument() {
        Object o = createObject();
        Document r = createDocument();
        r.setAll(objectToDocument(o, false));
        for (Field field : entity.getFields()) {
            if (field.isId() && (field.getModifiers().contains(FieldModifier.PERSIST_FORMULA) || field.getModifiers().contains(FieldModifier.PERSIST_SEQUENCE))) {
                r.remove(field.getName());//even if defined in
            } else {
                Object df = field.getDefaultValue();
                if (df != null) {
                    r.setObject(field.getName(), df);
                }
            }
        }
        return r;
    }

    @Override
    public <R> R createInitializedObject() {
        Object o = createObject();
        Document r = objectToDocument(o, false);
        for (Field field : entity.getFields()) {
            Object df = field.getDefaultValue();
            if (field.isId() && (field.getModifiers().contains(FieldModifier.PERSIST_FORMULA) || field.getModifiers().contains(FieldModifier.PERSIST_SEQUENCE))) {
                //do nothing
            } else if (df != null) {
                r.setObject(field.getName(), df);
            }
        }
        return documentToObject(r);
    }

}
