package net.vpc.upa.impl.cache;

import net.vpc.upa.Key;
import net.vpc.upa.UPA;

import java.util.HashMap;
import java.util.Map;

public class DefaultEntityCollectionCache implements EntityCollectionCache {
    private final Map<String, LRUCacheMap<Key, Object>> cache;
    protected int defaultEntitySize = 1024;

    public DefaultEntityCollectionCache(int defaultEntitySize) {
        this.cache = new HashMap<>();
        this.defaultEntitySize = defaultEntitySize <= 0 ? 1024 : defaultEntitySize;
    }

    protected LRUCacheMap<Key, Object> getEntityCache(String entityName) {
        LRUCacheMap<Key, Object> p = cache.get(entityName);
        if (p == null) {
            synchronized (cache) {
                p = cache.get(entityName);
                if (p == null) {
                    p = create(entityName);
                    cache.put(entityName, p);
                }
            }
        }
        return p;
    }

    protected LRUCacheMap<Key, Object> create(String entityName) {
        return new LRUCacheMap<>(defaultEntitySize);
    }

    @Override
    public void add(String entityName, Key id, Object value) {
        LRUCacheMap<Key, Object> p = getEntityCache(entityName);
        synchronized (p) {
            Key id2 = UPA.getPersistenceUnit().getEntity(entityName).getBuilder().objectToKey(value);
            if(id2==null || !id2.equals(id)
                    || (id.getObjectAt(0) instanceof Integer && id.getIntAt(0)==0)
            ){
                System.out.println("Unexpectd Error Error");
            }
            p.put(id, value);
        }
    }

    @Override
    public Object findById(String entityName, Key id) {
        LRUCacheMap<Key, Object> p = cache.get(entityName);
        if (p == null) {
            return null;
        }
        synchronized (p) {
            return p.get(id);
        }
    }

    @Override
    public void invalidate() {
        synchronized (cache) {
            cache.clear();
        }
    }

    @Override
    public void invalidate(String entityName) {
        synchronized (cache) {
            cache.remove(entityName);
        }
    }

    @Override
    public void invalidateByKey(String entityName, Key id) {
        LRUCacheMap<Key, Object> p = cache.get(entityName);
        if (p != null) {
            synchronized (cache) {
                p.remove(id);
            }
        }
    }
}
