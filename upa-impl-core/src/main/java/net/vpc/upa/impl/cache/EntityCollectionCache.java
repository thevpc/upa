package net.vpc.upa.impl.cache;

import net.vpc.upa.Key;

public interface EntityCollectionCache {
    void add(String entityName, Key id, Object value);

    Object findById(String entityName, Key id);

    void invalidate();

    void invalidate(String entityName);

    void invalidateByKey(String entityName, Key id);
}
