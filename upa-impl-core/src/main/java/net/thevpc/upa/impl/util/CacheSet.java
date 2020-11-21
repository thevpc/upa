package net.thevpc.upa.impl.util;

import net.thevpc.upa.impl.cache.LRUMap;
import net.thevpc.upa.PortabilityHint;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/14/13 1:10 AM
 */
@PortabilityHint(target = "C#", name = "ignore")
public class CacheSet<K> {
    private LRUMap<K, Boolean> data;

    public CacheSet(int maxCount) {
        data=new LRUMap<K, Boolean>(maxCount);
    }

    public boolean contains(K key){
        return data.get(key)==Boolean.TRUE;
    }

    public void add(K key){
        data.put(key,Boolean.TRUE);
    }

    public void clear(){
        data.clear();
    }

    @Override
    public String toString() {
        return data.keySet().toString();
    }
}
