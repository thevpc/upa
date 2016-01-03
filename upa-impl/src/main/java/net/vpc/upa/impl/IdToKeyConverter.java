package net.vpc.upa.impl;

import net.vpc.upa.Entity;
import net.vpc.upa.Key;
import net.vpc.upa.impl.util.Converter;

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
