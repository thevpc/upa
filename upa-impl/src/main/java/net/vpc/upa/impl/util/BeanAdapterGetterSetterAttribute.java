package net.vpc.upa.impl.util;

import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/5/13 11:20 PM
 */ //    private class FieldAttrAdapter<R> extends AbstractBeanAdapterAttribute<R> {
//
//        private Field field;
//        private Class cls;
//
//        private FieldAttrAdapter(Field field, Class cls) {
//            super(field.getName(), field.getDataType());
//            this.field = field;
//            this.cls = cls;
//            field.setAccessible(true);
//        }
//
//        @Override
//        public R getValue(Object o) {
//            try {
//                return (R) field.get(o);
//            } catch (IllegalAccessException e) {
//                throw new RuntimeException(e);
//            }
//        }
//
//        @Override
//        public void setValue(Object o, R value) {
//            try {
//                field.set(o, value);
//            } catch (IllegalAccessException e) {
//                throw new RuntimeException(e);
//            }
//        }
//    }
class BeanAdapterGetterSetterAttribute extends AbstractBeanAdapterAttribute {

    private Method getter;
    private Method setter;

    BeanAdapterGetterSetterAttribute(String field, Class fieldType, Method getter, Method setter) {
        super(field, fieldType);
        this.getter = getter;
        if (getter != null) {
            getter.setAccessible(true);
        }
        this.setter = setter;
        if (setter != null) {
            setter.setAccessible(true);
        }
    }

    public Method getGetter() {
        return getter;
    }

    public Method getSetter() {
        return setter;
    }

    @Override
    public Object getValue(Object o) {
        if (getter == null) {
            throw new RuntimeException("Field inaccessible : no getter found for field " + getName());
        }
        try {
            return getter.invoke(o,new Object[0]);
        } catch (Exception e) {
            if (e instanceof InvocationTargetException) {
                e= (Exception)((InvocationTargetException)e).getTargetException();
            }
            if (e instanceof RuntimeException) {
                throw (RuntimeException) e;
            }
            throw new RuntimeException(e);
        }
    }

    @Override
    public void setValue(Object o, Object value) {
        if (setter == null) {
            throw new RuntimeException("Field readonly : no setter found for " + getName() + " in class " + o.getClass());
        }
        try {
            setter.invoke(o, new Object[]{value});
        } catch (Exception e) {
            //throw new IllegalArgumentException("Unable to set value " + (value == null ? "null" : value.getClass()) + " for property " + getName() + ". Expected Type is " + getFieldType(), e);
            if (e instanceof InvocationTargetException) {
                e= (Exception)((InvocationTargetException)e).getTargetException();
            }
            if (e instanceof RuntimeException) {
                throw (RuntimeException) e;
            }
            throw new RuntimeException(e);
        }
    }
}
