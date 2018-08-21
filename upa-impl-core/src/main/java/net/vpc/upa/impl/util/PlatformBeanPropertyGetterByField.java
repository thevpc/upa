package net.vpc.upa.impl.util;

import java.lang.reflect.Field;
import java.lang.reflect.InvocationTargetException;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/5/13 11:20 PM
 */
class PlatformBeanPropertyGetterByField implements PlatformBeanPropertyGetter{

    private Field getter;

    PlatformBeanPropertyGetterByField(Field getter) {
        this.getter = getter;
        getter.setAccessible(true);
    }

    @Override
    public Object getValue(Object o) {
        try {
            return getter.get(o);
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
