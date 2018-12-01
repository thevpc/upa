package net.vpc.upa.impl.cache;

import net.vpc.upa.Key;

import java.util.HashMap;
import java.util.Map;

public class DefaultEntityCollectionCache implements EntityCollectionCache {
    private Map<String, LRUCacheMap<Key, Object>> cache;
    protected int defaultEntitySize = 1024;

    public DefaultEntityCollectionCache(int defaultEntitySize) {
        this.cache = new HashMap<>();
        this.defaultEntitySize = defaultEntitySize <= 0 ? 1024 : defaultEntitySize;
    }

    protected LRUCacheMap<Key, Object> getEntityCache(String entityName) {
        LRUCacheMap<Key, Object> p = cache.get(entityName);
        if (p == null) {
            p = create(entityName);
            cache.put(entityName,p);
        }
        return p;
    }

    protected LRUCacheMap<Key, Object> create(String entityName) {
        return new LRUCacheMap<>(defaultEntitySize);
    }

    @Override
    public void add(String entityName, Key id, Object value) {
        getEntityCache(entityName).put(id, value);
    }

    @Override
    public Object findById(String entityName, Key id) {
        LRUCacheMap<Key, Object> p = cache.get(entityName);
        if (p == null) {
            return null;
        }
        return p.get(id);
    }

    @Override
    public void invalidate() {
        cache.clear();
    }

    @Override
    public void invalidate(String entityName) {
        cache.remove(entityName);
    }

    @Override
    public void invalidateById(String entityName, Key id) {
        LRUCacheMap<Key, Object> p = cache.get(entityName);
        if (p != null) {
            p.remove(id);
        }
    }
}
