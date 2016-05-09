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
    public <R> R createObject() {
        return entityFactory.createObject();
    }

    @Override
    public <R> Record getRecord(R entity, boolean ignoreUnspecified) {
        return entityFactory.getRecord(entity, ignoreUnspecified);
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
    public Record objectToRecord(Object entityValue) throws UPAException {
        return entityConverter.entityToRecord(entityValue);
    }

    @Override
    public Record objectToRecord(Object entityValue, boolean ignoreUnspecified) throws UPAException {
        return entityConverter.entityToRecord(entityValue);
    }

    @Override
    public Object getMainValue(Object entityValue) throws UPAException {
        return entityConverter.getMainProperty(entityValue);
    }

    @Override
    public <R> R recordToObject(Record entityRecord) throws UPAException {
        return entityConverter.recordToEntity(entityRecord);
    }

    @Override
    public <R> R idToEntity(Object entityId) throws UPAException {
        return entityConverter.idToEntity(entityId);
    }

    @Override
    public Record idToRecord(Object entityId) throws UPAException {
        return entityConverter.idToEntity(entityId);
    }

    @Override
    public Object objectToId(Object entityValue) throws UPAException {
        return entityConverter.entityToId(entityValue);
    }

    @Override
    public Key objectToKey(Object entityValue) throws UPAException {
        return entityConverter.entityToKey(entityValue);
    }

    @Override
    public Object recordToId(Record entityRecord) throws UPAException {
        return entityConverter.recordToId(entityRecord);
    }

    @Override
    public Key recordToKey(Record entityRecord) throws UPAException {
        return entityConverter.recordToKey(entityRecord);
    }

    @Override
    public Object keyToObject(Key recordKey) throws UPAException {
        return entityConverter.keyToEntity(recordKey);
    }

    @Override
    public Record keyToRecord(Key recordKey) throws UPAException {
        return entityConverter.keyToRecord(recordKey);
    }

    @Override
    public void setRecordId(Record entityRecord, Object entityId) throws UPAException {
        entityConverter.setRecordId(entityRecord, entityId);
    }

    @Override
    public void setObjectId(Object entityObject, Object entityId) throws UPAException {
        entityConverter.setEntityId(entityObject, entityId);
    }

    @Override
    public Expression recordToExpression(Record entityRecord, String entityAlias) throws UPAException {
        return entityConverter.recordToExpression(entityRecord, entityAlias);
    }

    @Override
    public Expression objectToExpression(Object entityValue, boolean ignoreUnspecified, String entityAlias) throws UPAException {
        return entityConverter.entityToExpression(entityValue, ignoreUnspecified, entityAlias);
    }

    @Override
    public Expression objectToIdExpression(Object objectOrRecord, String alias) throws UPAException {
        return entityConverter.objectToIdExpression(objectOrRecord, alias);
    }
    @Override
    public Expression idToExpression(Object entityId, String alias) throws UPAException {
        return entityConverter.idToExpression(entityId, alias);
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
    public Expression keyListToExpression(List<Key> idList, String alias) throws UPAException {
        return entityConverter.keyListToExpression(idList, alias);
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
            if(field.isId() && (field.getModifiers().contains(FieldModifier.PERSIST_FORMULA) || field.getModifiers().contains(FieldModifier.PERSIST_SEQUENCE))){
                r.remove(field.getName());//even if defined in
            }else{
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
            if(field.isId() && (field.getModifiers().contains(FieldModifier.PERSIST_FORMULA) || field.getModifiers().contains(FieldModifier.PERSIST_SEQUENCE))){
                //do nothing
            }else{
                if (df != null) {
                    r.setObject(field.getName(), df);
                }
            }
        }
        return recordToObject(r);
    }

}
