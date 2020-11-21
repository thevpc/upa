package net.thevpc.upa.impl;

import net.thevpc.upa.impl.util.Converter;
import net.thevpc.upa.Entity;
import net.thevpc.upa.Key;

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
