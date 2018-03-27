package net.vpc.upa.impl;

import net.vpc.upa.PlatformBeanType;
import net.vpc.upa.Entity;
import net.vpc.upa.PropertyAccessType;
import net.vpc.upa.impl.util.PlatformUtils;

import java.util.Set;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 2:06 AM
 */
public class BeanAdapterKey extends AbstractKey {

    private Class keyType;
    private PlatformBeanType nfo;
    private Object userObject;

    public BeanAdapterKey(Class keyType, Object userObject, Entity entity) {
        this.keyType = keyType;
        this.userObject = userObject;
        nfo = PlatformUtils.getBeanType(keyType);
    }

    @Override
    public Object[] getValue() {
        Object o = userObject;
        Set<String> names = nfo.getPropertyNames();
        Object[] v = new Object[names.size()];
        int i = 0;
        for (String name : names) {
            v[i] = nfo.getPropertyValue(o, name);
            i++;
        }
        return v;
    }

    @Override
    public void setValue(Object[] value) {
        Object o = userObject;
        Set<String> names = nfo.getPropertyNames();
        int i = 0;
        for (String name : names) {
            nfo.setPropertyValue(o, name, value[i]);
            i++;
        }
    }
}
