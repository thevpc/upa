package net.vpc.upa.impl;

import net.vpc.upa.Key;
import net.vpc.upa.impl.util.EntityBeanAdapter;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 1:51 AM
 */
public class KeySubclassUnstructuredFactory implements KeyFactory {
    private Class keyType;
    private EntityBeanAdapter nfo;

    public KeySubclassUnstructuredFactory(Class keyType, EntityBeanAdapter nfo) {
        this.keyType = keyType;
        this.nfo = nfo;
    }

    public Class getIdType() {
        return keyType;
    }

    @Override
    public Key createKey(Object... keyValues) {
        Key o = (Key) nfo.newInstance();
        o.setValue(keyValues);
        return o;
    }

    @Override
    public Object createId(Object... keyValues) {
        Key o = (Key) nfo.newInstance();
        o.setValue(keyValues);
        return o;
    }

    @Override
    public Object getId(Key unstructuredKey) {
        if(keyType.isInstance(unstructuredKey)){
            return unstructuredKey;
        }
        Key o = (Key) nfo.newInstance();
        o.setValue(unstructuredKey.getValue());
        return o;
    }

    @Override
    public Key getKey(Object id) {
        return (Key) id;
    }
}
