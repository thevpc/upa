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
    public Record createRecord() {
        return entityFactory.createRecord();
    }

    @Override
    public <R> R copyObject(R r) {
        return recordToObject(copyRecord(objectToRecord(r)));
    }
    
    @Override
    public Record copyRecord(Record rec) {
        Record r = createRecord();
        r.setAll(rec);
        return r;
    }

    @Override
    public <R> R createObject() {
        return entityFactory.createObject();
    }

    @Override
    public Record objectToRecord(Object entity, boolean ignoreUnspecified) {
        return entityFactory.objectToRecord(entity, ignoreUnspecified);
    }

    @Override
    public Record objectToRecord(Object entity, Set<String> fields, boolean ignoreUnspecified, boolean ensureIncludeIds) {
        return entityFactory.objectToRecord(entity, fields, ignoreUnspecified, ensureIncludeIds);
    }

    @Override
    public Record objectToRecord(Object entity) {
        return entityFactory.objectToRecord(entity);
    }

    @Override
    public <R> R recordToObject(Record record) throws UPAException {
        return entityFactory.recordToObject(record);
    }

    @Override
    public Object getObject(Object objectOrRecord) {
        if(entity.getEntityType().isInstance(objectOrRecord)){
            return objectOrRecord;
        }else{
            return recordToObject(objectToRecord(objectOrRecord));
        }
    }

    @Override
    public Record getRecord(Object objectOrRecord) {
        return objectToRecord(objectOrRecord);
    }

    @Override
    public void setProperty(Object entityObject, String property, Object value) throws UPAException {
        if (entityObject instanceof Record) {
            ((Record) entityObject).setObject(property, value);
            return;
        }
        entityFactory.setProperty(entityObject, property, value);
    }

    @Override
    public Object getProperty(Object entityObject, String property) throws UPAException {
        if (entityObject instanceof Record) {
            return ((Record) entityObject).getObject(property);
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
    public Object keyToId(Key recordKey) throws UPAException {
        return entityFactory.keyToId(recordKey);
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
    public Record idToRecord(Object objectId) throws UPAException {
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
    public Object recordToId(Record record) throws UPAException {
        return entityFactory.recordToId(record);
    }

    @Override
    public Key recordToKey(Record record) throws UPAException {
        return entityFactory.recordToKey(record);
    }

    @Override
    public Object keyToObject(Key key) throws UPAException {
        return entityFactory.keyToObject(key);
    }

    @Override
    public Record keyToRecord(Key key) throws UPAException {
        return entityFactory.keyToRecord(key);
    }

    @Override
    public void setRecordId(Record record, Object id) throws UPAException {
        entityFactory.setRecordId(record, id);
    }

    @Override
    public void setObjectId(Object object, Object id) throws UPAException {
        entityFactory.setObjectId(object, id);
    }

    @Override
    public Expression recordToExpression(Record record, String alias) throws UPAException {
        return entityFactory.recordToExpression(record, alias);
    }

    @Override
    public Expression objectToExpression(Object object, boolean ignoreUnspecified, String alias) throws UPAException {
        return entityFactory.objectToExpression(object, ignoreUnspecified, alias);
    }

    @Override
    public Expression objectToIdExpression(Object objectOrRecord, String alias) throws UPAException {
        return entityFactory.objectToIdExpression(objectOrRecord, alias);
    }

    @Override
    public Expression idToExpression(Object id, String alias) throws UPAException {
        return entityFactory.idToExpression(id, alias);
    }

    @Override
    public Expression keyToExpression(Key recordKey, String alias) throws UPAException {
        return entityFactory.keyToExpression(recordKey, alias);
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
    public QualifiedRecord createQualifiedRecord() throws UPAException {
        return new DefaultQualifiedRecord(entity);
    }

    @Override
    public QualifiedRecord createQualifiedRecord(Record record) throws UPAException {
        return new DefaultQualifiedRecord(entity, record);
    }

    @Override
    public Record createInitializedRecord() {
        Object o = createObject();
        Record r = createRecord();
        r.setAll(objectToRecord(o, false));
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
        Record r = objectToRecord(o, false);
        for (Field field : entity.getFields()) {
            Object df = field.getDefaultValue();
            if (field.isId() && (field.getModifiers().contains(FieldModifier.PERSIST_FORMULA) || field.getModifiers().contains(FieldModifier.PERSIST_SEQUENCE))) {
                //do nothing
            } else if (df != null) {
                r.setObject(field.getName(), df);
            }
        }
        return recordToObject(r);
    }

}
