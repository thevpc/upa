package net.vpc.upa.impl.util;

import net.vpc.upa.Action;
import net.vpc.upa.PortabilityHint;

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
}
