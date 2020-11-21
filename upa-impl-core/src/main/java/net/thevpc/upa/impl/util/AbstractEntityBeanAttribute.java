package net.thevpc.upa.impl.util;

import net.thevpc.upa.Entity;
import net.thevpc.upa.Field;
import net.thevpc.upa.exceptions.UPAException;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/5/13 11:24 PM
 */
abstract class AbstractEntityBeanAttribute implements EntityBeanAttribute {

    private String name;
    private Class fieldType;
    private EntityPlatformBeanType entityBeanAdapter;

    AbstractEntityBeanAttribute(EntityPlatformBeanType entityBeanAdapter, String name, Class fieldType) {
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
        Field field = null;
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
        Field field = null;
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
