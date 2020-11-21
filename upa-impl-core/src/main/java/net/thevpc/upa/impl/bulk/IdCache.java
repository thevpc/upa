package net.thevpc.upa.impl.bulk;

import net.thevpc.upa.PortabilityHint;

/**
 * @author taha.bensalah@gmail.com on 7/6/16.
 */
@PortabilityHint(target = "C#",name = "suppress")
class IdCache {
    Object id;
    String entityName;

    public IdCache(Object id, String entityName) {
        this.id = id;
        this.entityName = entityName;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof IdCache)) return false;

        IdCache idCache = (IdCache) o;

        if (!id.equals(idCache.id)) return false;
        return entityName.equals(idCache.entityName);

    }

    @Override
    public int hashCode() {
        int result = id.hashCode();
        result = 31 * result + entityName.hashCode();
        return result;
    }

    @Override
    public String toString() {
        return entityName + "[" +
                id +
                ']';
    }
}
