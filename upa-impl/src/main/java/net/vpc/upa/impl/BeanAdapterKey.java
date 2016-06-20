package net.vpc.upa.impl;

import net.vpc.upa.BeanType;
import net.vpc.upa.Entity;
import net.vpc.upa.impl.util.PlatformBeanTypeRepository;

import java.util.Set;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 2:06 AM
 */
public class BeanAdapterKey extends AbstractKey {

    private Class keyType;
    private BeanType nfo;
    private Object userObject;

    public BeanAdapterKey(Class keyType, Object userObject, Entity entity) {
        this.keyType = keyType;
        this.userObject = userObject;
        nfo = PlatformBeanTypeRepository.getInstance().getBeanType(keyType);
    }

    @Override
    public Object[] getValue() {
        Object o = userObject;
        Set<String> names = nfo.getPropertyNames();
        Object[] v = new Object[names.size()];
        int i = 0;
        for (String name : names) {
            v[i] = nfo.getProperty(o, name);
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
            nfo.setProperty(o, name, value[i]);
            i++;
        }
    }
}
