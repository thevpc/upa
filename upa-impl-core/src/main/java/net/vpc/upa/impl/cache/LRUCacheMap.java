package net.vpc.upa.impl.cache;

import net.vpc.upa.Action;
import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.util.CacheMap;

/**
 * Created by vpc on 7/9/17.
 */
@PortabilityHint(target = "C#", name = "ignore")
public class LRUCacheMap<K, V> implements CacheMap<K, V> {
    private LRUMap<K, V> data;

    public LRUCacheMap(int maxCount) {
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
        boolean found=false;
        if(data.containsKey(key)){
            found=true;
        }
        data.put(key,value);
    }

    public void clear(){
        data.clear();
    }

    @Override
    public void remove(K key){
        data.remove(key);
    }

    public void updateSize(int size){
        LRUMap<K, V> newData=new LRUMap<K, V>(size);
        newData.putAll(data);
        data=newData;
    }
}
