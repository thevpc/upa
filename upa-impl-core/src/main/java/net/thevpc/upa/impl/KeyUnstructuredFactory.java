package net.thevpc.upa.impl;

import net.thevpc.upa.Entity;
import net.thevpc.upa.Key;
import net.thevpc.upa.exceptions.IllegalUPAArgumentException;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 1:51 AM
 */
public class KeyUnstructuredFactory implements KeyFactory {
    private Entity entity;
    public KeyUnstructuredFactory(Entity entity) {
        this.entity=entity;
    }

    public Class<Key> getIdType() {
        return Key.class;
    }

    @Override
    public Key createKey(Object... idValues) {
        return new DefaultKey(idValues);
    }

    @Override
    public Object createId(Object... idValues) {
        if(entity.getIdFields().size()!=idValues.length){
            throw new IllegalUPAArgumentException("Invalid Key Size. Expected "+entity.getIdFields().size()+" but found "+idValues.length);
        }
        return new DefaultKey(idValues);
    }

    @Override
    public Object getId(Key unstructuredKey) {
        return unstructuredKey;
    }

    @Override
    public Key getKey(Object id) {
        return (Key) id;
    }
}
