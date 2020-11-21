package net.thevpc.upa.impl.util;

import net.thevpc.upa.Action;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/14/13 1:10 AM
 */
public interface CacheMap<K, V> {
    V get(K key);

    V get(K key, Action<V> evaluator);

    boolean containsKey(K key);

    void put(K key, V value);

    void clear();

    void remove(K key);

    void updateSize(int size);
}
