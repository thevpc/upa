package net.thevpc.upa.impl.util;

import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/5/13 11:20 PM
 */
class PlatformBeanPropertySetterByMethod implements  PlatformBeanPropertySetter{

    private Method setter;

    PlatformBeanPropertySetterByMethod(Method setter) {
        this.setter = setter;
        setter.setAccessible(true);
    }

    @Override
    public void setValue(Object o, Object value) {
        try {
            setter.invoke(o, new Object[]{value});
        } catch (Exception e) {
            //throw new UPAIllegalArgumentException("Unable to set value " + (value == null ? "null" : value.getClass()) + " for property " + getName() + ". Expected Type is " + getPlatformType(), e);
            if (e instanceof InvocationTargetException) {
                e= (Exception)((InvocationTargetException)e).getTargetException();
            }
//            if (e instanceof RuntimeException) {
//                throw (RuntimeException) e;
//            }
            throw new RuntimeException("Unable to set value of type "+(value==null?"null":value.getClass().getName())+" using "+setter,e);
        }
    }
}
