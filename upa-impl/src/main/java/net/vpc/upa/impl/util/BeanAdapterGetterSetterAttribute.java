package net.vpc.upa.impl.util;

import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/5/13 11:20 PM
 */
class DefaultPlatformBeanProperty extends AbstractPlatformBeanProperty {

    private Method getter;
    private Method setter;

    DefaultPlatformBeanProperty(String field, Class fieldType, Method getter, Method setter) {
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
            //throw new IllegalArgumentException("Unable to set value " + (value == null ? "null" : value.getClass()) + " for property " + getName() + ". Expected Type is " + getPlatformType(), e);
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
    public boolean isWriteSupported() {
        return setter!=null;
    }

    @Override
    public boolean isReadSupported() {
        return getter!=null;
    }
}
