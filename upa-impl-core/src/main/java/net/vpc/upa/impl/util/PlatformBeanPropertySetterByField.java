package net.vpc.upa.impl.util;

import java.lang.reflect.Field;
import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/5/13 11:20 PM
 */
class PlatformBeanPropertySetterByField implements  PlatformBeanPropertySetter{

    private Field setter;

    PlatformBeanPropertySetterByField(Field setter) {
        this.setter = setter;
        setter.setAccessible(true);
    }

    @Override
    public void setValue(Object o, Object value) {
        try {
            setter.set(o, value);
        } catch (Exception e) {
            //throw new UPAIllegalArgumentException("Unable to set value " + (value == null ? "null" : value.getClass()) + " for property " + getName() + ". Expected Type is " + getPlatformType(), e);
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
