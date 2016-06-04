/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;

import java.util.List;
import java.util.Set;

/**
 * @author vpc
 */
public class DefaultEntityBuilder implements EntityBuilder {

    private EntityFactory entityFactory;
    private KeyFactory keyFactory;
    private EntityConverter entityConverter;
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

    public EntityConverter getEntityConverter() {
        return entityConverter;
    }

    public void setEntityConverter(EntityConverter entityConverter) {
        this.entityConverter = entityConverter;
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
    public <R> Record getRecord(R entity, boolean ignoreUnspecified) {
        return entityFactory.getRecord(entity, ignoreUnspecified);
    }

    @Override
    public Record getRecord(Object entity, Set<String> fields, boolean ignoreUnspecified, boolean ensureIncludeIds) {
        return entityFactory.getRecord(entity, fields,ignoreUnspecified,ensureIncludeIds);
    }

    @Override
    public <R> Record getRecord(R entity) {
        return entityFactory.getRecord(entity);
    }

    @Override
    public <R> R getEntity(Record unstructuredRecord) {
        return entityFactory.getEntity(unstructuredRecord);
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
        return entityConverter.idToKey(entityId);
    }

    @Override
    public Object keyToId(Key recordKey) throws UPAException {
        return entityConverter.keyToId(recordKey);
    }

    @Override
    public Record objectToRecord(Object objectValue) throws UPAException {
        return entityConverter.objectToRecord(objectValue);
    }

    @Override
    public Record objectToRecord(Object objectValue, boolean ignoreUnspecified) throws UPAException {
        return entityConverter.objectToRecord(objectValue);
    }

    @Override
    public Object getMainValue(Object objectValue) throws UPAException {
        return entityConverter.getMainProperty(objectValue);
    }

    @Override
    public <R> R recordToObject(Record record) throws UPAException {
        return entityConverter.recordToObject(record);
    }

    @Override
    public <R> R idToObject(Object objectId) throws UPAException {
        return entityConverter.idToObject(objectId);
    }

    @Override
    public Record idToRecord(Object objectId) throws UPAException {
        return entityConverter.idToObject(objectId);
    }

    @Override
    public Object objectToId(Object objectValue) throws UPAException {
        return entityConverter.objectToId(objectValue);
    }

    @Override
    public Key objectToKey(Object objectValue) throws UPAException {
        return entityConverter.objectToKey(objectValue);
    }

    @Override
    public Object recordToId(Record record) throws UPAException {
        return entityConverter.recordToId(record);
    }

    @Override
    public Key recordToKey(Record record) throws UPAException {
        return entityConverter.recordToKey(record);
    }

    @Override
    public Object keyToObject(Key key) throws UPAException {
        return entityConverter.keyToObject(key);
    }

    @Override
    public Record keyToRecord(Key key) throws UPAException {
        return entityConverter.keyToRecord(key);
    }

    @Override
    public void setRecordId(Record record, Object id) throws UPAException {
        entityConverter.setRecordId(record, id);
    }

    @Override
    public void setObjectId(Object object, Object id) throws UPAException {
        entityConverter.setObjectId(object, id);
    }

    @Override
    public Expression recordToExpression(Record record, String alias) throws UPAException {
        return entityConverter.recordToExpression(record, alias);
    }

    @Override
    public Expression objectToExpression(Object object, boolean ignoreUnspecified, String alias) throws UPAException {
        return entityConverter.objectToExpression(object, ignoreUnspecified, alias);
    }

    @Override
    public Expression objectToIdExpression(Object objectOrRecord, String alias) throws UPAException {
        return entityConverter.objectToIdExpression(objectOrRecord, alias);
    }

    @Override
    public Expression idToExpression(Object id, String alias) throws UPAException {
        return entityConverter.idToExpression(id, alias);
    }

    @Override
    public Expression keyToExpression(Key recordKey, String alias) throws UPAException {
        return entityConverter.keyToExpression(recordKey, alias);
    }

    @Override
    public <K> Expression idListToExpression(List<K> idList, String alias) throws UPAException {
        return entityConverter.idListToExpression(idList, alias);
    }

    @Override
    public Expression keyListToExpression(List<Key> keyList, String alias) throws UPAException {
        return entityConverter.keyListToExpression(keyList, alias);
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
        Record r = DefaultEntityBuilder.this.objectToRecord(o, false);
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
