package net.vpc.upa.impl.util;

import java.lang.reflect.Field;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/5/13 11:27 PM
*/
class EntityBeanFieldAttribute extends AbstractEntityBeanAttribute {

    private Field field;

    EntityBeanFieldAttribute(EntityPlatformBeanType entityBeanAdapter, Field field, Class cls) {
        super(entityBeanAdapter,field.getName(), field.getType());
        this.field = field;
        field.setAccessible(true);
    }

    @Override
    public Object getValue(Object o) {
        try {
            return field.get(o);
        } catch (IllegalAccessException e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    public void setValue(Object o, Object value) {
        try {
            field.set(o, value);
        } catch (IllegalAccessException e) {
            throw new RuntimeException(e);
        }
    }
}
