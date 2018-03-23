package net.vpc.upa.impl.util;

import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/5/13 11:20 PM
 */
class PlatformBeanPropertyGetterByMethod implements PlatformBeanPropertyGetter{

    private Method getter;

    PlatformBeanPropertyGetterByMethod(Method getter) {
        this.getter = getter;
        getter.setAccessible(true);
    }

    @Override
    public Object getValue(Object o) {
        try {
            return getter.invoke(o,UPAUtils.UNDEFINED_ARRAY);
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
}
