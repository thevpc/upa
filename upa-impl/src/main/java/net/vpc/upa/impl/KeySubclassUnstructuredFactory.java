package net.vpc.upa.impl;

import net.vpc.upa.BeanType;
import net.vpc.upa.Key;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 1:51 AM
 */
public class KeySubclassUnstructuredFactory implements KeyFactory {
    private BeanType nfo;

    public KeySubclassUnstructuredFactory(BeanType nfo) {
        this.nfo = nfo;
    }

    public Class getIdType() {
        return nfo.getPlatformType();
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
        if(nfo.getPlatformType().isInstance(unstructuredKey)){
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
