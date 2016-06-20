package net.vpc.upa.impl.util;

import net.vpc.upa.Action;
import net.vpc.upa.PortabilityHint;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/14/13 1:10 AM
 */
@PortabilityHint(target = "C#", name = "ignore")
public class CacheMap<K, V> {
    private LRUMap<K, V> data;

    public CacheMap(int maxCount) {
        data=new LRUMap<K, V>(maxCount);
    }

    public V get(K key){
        return data.get(key);
    }

    public V get(K key,Action<V> evaluator){
        V existingValue = data.get(key);
        if(existingValue==null && !data.containsKey(key)){
            existingValue=evaluator.run();
            data.put(key,existingValue);
        }
        return existingValue;
    }

    public boolean containsKey(K key){
        return data.containsKey(key);
    }

    public void put(K key, V value){
        data.put(key,value);
    }

    public void clear(){
        data.clear();
    }
}
