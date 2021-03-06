package net.thevpc.upa.impl.util;

import net.thevpc.upa.Action;

/**
 * Created by vpc on 7/9/17.
 */
public class NoCacheMap<K, V> implements CacheMap<K, V> {

    public V get(K key){
        return null;
    }

    public V get(K key,Action<V> evaluator){
        return evaluator.run();
    }

    public boolean containsKey(K key){
        return false;
    }

    public void put(K key, V value){

    }

    public void clear(){

    }

    @Override
    public void remove(K key) {

    }

    @Override
    public void updateSize(int size) {

    }
}
