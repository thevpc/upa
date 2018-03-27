package net.vpc.upa.impl;

import java.util.ArrayList;

import net.vpc.upa.*;

import java.util.List;
import java.util.Set;

import net.vpc.upa.impl.util.PlatformUtils;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 1:51 AM
 */
public class KeyBeanFactory implements KeyFactory {

    private boolean isEntityKey;
    private PlatformBeanType bnfo;
    private Class idType;
    private String[] fieldNames;
    private Entity entity;
    private Entity idEntity;

    public KeyBeanFactory(Class keyType, Entity entity) {
        this.idType = keyType;
        this.entity = entity;
    }

    private boolean build() {
        if (this.fieldNames == null) {
            idEntity = entity.getPersistenceUnit().findEntity(idType);
            if (idEntity != null) {
                isEntityKey = true;
                List<String> fn = new ArrayList<String>();
//                for (Field primaryField : entity.getIdFields()) {
//                    fn.add(primaryField.getName());
//                }
                this.fieldNames = fn.toArray(new String[fn.size()]);
            } else {
                bnfo = PlatformUtils.getBeanType(idType);
                Set<String> fn = bnfo.getPropertyNames();
                this.fieldNames = fn.toArray(new String[fn.size()]);
            }
        }
        return isEntityKey;
    }

    public Class getIdType() {
        return idType;
    }

    @Override
    public Key createKey(Object... keyValues) {
        if (keyValues == null) {
            return null;
        }
        return new DefaultKey(keyValues);
    }

    @Override
    public Object createId(Object... keyValues) {
        if (keyValues == null) {
            return null;
        }
        if (build()) {
//            Object o = idEntity.getBuilder().createObject();
//            EntityBuilder f = idEntity.getBuilder();
//            for (int i = 0; i < keyValues.length; i++) {
//                f.setProperty(o, fieldNames[i], keyValues[i]);
//            }
            return keyValues[0];
        } else {
            Object o = bnfo.newInstance();
            for (int i = 0; i < keyValues.length; i++) {
                bnfo.setPropertyValue(o, fieldNames[i], keyValues[i]);
            }
            return o;
        }
    }

    @Override
    public Object getId(Key unstructuredKey) {
        if (unstructuredKey == null) {
            return null;
        }
        return createId(unstructuredKey.getValue());
    }

    @Override
    public Key getKey(Object id) {
        if (id == null) {
            return null;
        }
        if (build()) {
//            Object[] value = new Object[fieldNames.length];
//            EntityBuilder entityFactory = idEntity.getBuilder();
//            for (int i = 0; i < value.length; i++) {
//                value[i] = entityFactory.getProperty(key, fieldNames[i]);
//            }
            if (!PlatformUtils.isInstance(idType,id)) {
                Entity ee = entity.getPersistenceUnit().findEntity(idType);
                if (ee != null) {
                    //check assume this is the id of the entity ee
                    if(id instanceof Document) {
                        id = ee.getBuilder().documentToObject((Document)id);
                    }
                }
            }
            return createKey(new Object[]{id});
        } else {
            Object[] value = new Object[fieldNames.length];
            for (int i = 0; i < value.length; i++) {
                value[i] = bnfo.getPropertyValue(id, fieldNames[i]);
            }
            return createKey(value);
        }
    }
}
