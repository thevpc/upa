package net.vpc.upa.impl;

import net.vpc.upa.Entity;
import net.vpc.upa.Key;
import net.vpc.upa.impl.util.Converter;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/31/12 1:19 PM
 */
public class KeyToIdConverter<K> implements Converter<Key, K> {
    private Entity entity;
    public KeyToIdConverter(Entity entity) {
        this.entity=entity;
    }
    @Override
    public K convert(Key key) {
        return (K) entity.getBuilder().keyToId(key);
    }
}
