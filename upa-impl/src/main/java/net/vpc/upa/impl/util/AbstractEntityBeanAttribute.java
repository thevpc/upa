package net.vpc.upa.impl.util;

import net.vpc.upa.Entity;
import net.vpc.upa.exceptions.UPAException;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/5/13 11:24 PM
 */
abstract class AbstractEntityBeanAttribute implements EntityBeanAttribute {

    private String name;
    private Class fieldType;
    private EntityBeanType entityBeanAdapter;

    AbstractEntityBeanAttribute(EntityBeanType entityBeanAdapter, String name, Class fieldType) {
        this.entityBeanAdapter = entityBeanAdapter;
        this.name = name;
        this.fieldType = fieldType;
    }

    @Override
    public String getName() {
        return name;
    }

    @Override
    public Object getDefaultValue() throws UPAException {
        Entity entity = entityBeanAdapter.getEntity();
        net.vpc.upa.Field field = null;
        if (entity != null) {
            field = entity.findField(getName());
            if (field == null) {
                entity = null;
            }
        }
        if (entity == null || field == null) {
            return PlatformUtils.DEFAULT_VALUES_BY_TYPE.get(getFieldType());
        } else {
            return field.getUnspecifiedValueDecoded();
        }
    }

    public boolean isDefaultValue(Object o) throws UPAException {
        Object fieldValue = getValue(o);
        Entity entity = entityBeanAdapter.getEntity();
        net.vpc.upa.Field field = null;
        if (entity != null) {
            field = entity.findField(getName());
            if (field == null) {
                entity = null;
            }
        }
        if (entity == null || field == null) {
            Object fieldDefaultValue = PlatformUtils.DEFAULT_VALUES_BY_TYPE.get(getFieldType());
            if (fieldDefaultValue == null) {
                return fieldValue == null;
            } else {
                return fieldDefaultValue.equals(fieldValue);
            }
        } else {
            return field.isUnspecifiedValue(fieldValue);
        }
    }

    public Class getFieldType() {
        return fieldType;
    }
}
