package net.vpc.upa.impl;

import net.vpc.upa.Entity;
import net.vpc.upa.impl.util.EntityBeanAdapter;

import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 2:06 AM
 */
public class BeanAdapterKey extends AbstractKey {

    private Class keyType;
    private EntityBeanAdapter nfo;
    private Object userObject;

    public BeanAdapterKey(Class keyType, Object userObject, Entity entity) {
        this.keyType = keyType;
        this.userObject = userObject;
        nfo = new EntityBeanAdapter(keyType, entity);
    }

    @Override
    public Object[] getValue() {
        Object o = userObject;
        List<String> names = nfo.getFieldNames();
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
        List<String> names = nfo.getFieldNames();
        int i = 0;
        for (String name : names) {
            nfo.setProperty(o, name, value[i]);
            i++;
        }
    }
}
