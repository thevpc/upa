package net.thevpc.upa.impl;

import net.thevpc.upa.impl.util.Converter;
import net.thevpc.upa.Entity;
import net.thevpc.upa.Key;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/31/12 1:19 PM
 */
public class IdToKeyConverter<K> implements Converter<K,Key> {
    private Entity entity;
    public IdToKeyConverter(Entity entity) {
        this.entity=entity;
    }
    @Override
    public Key convert(K id) {
        return entity.getBuilder().idToKey(id);
    }
}
