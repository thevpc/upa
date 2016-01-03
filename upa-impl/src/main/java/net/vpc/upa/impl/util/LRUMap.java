package net.vpc.upa.impl.util;

import net.vpc.upa.PortabilityHint;

import java.util.LinkedHashMap;
import java.util.Map;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/15/12
 * Time: 7:08 PM
 * To change this template use File | Settings | File Templates.
 */
@PortabilityHint(target = "C#", name = "suppress")
public class LRUMap<K,V> extends LinkedHashMap<K,V>{
    private int maxCount;

    public LRUMap(int initialCapacity, float loadFactor, int maxCount) {
        super(initialCapacity, loadFactor);
        this.maxCount = maxCount;
    }

    public LRUMap(int initialCapacity, int maxCount) {
        super(initialCapacity);
        this.maxCount = maxCount;
    }

    public LRUMap(Map<K, V> m, int maxCount) {
        super(m);
        this.maxCount = maxCount;
    }

    public LRUMap(int initialCapacity, float loadFactor, boolean accessOrder, int maxCount) {
        super(initialCapacity, loadFactor, accessOrder);
        this.maxCount = maxCount;
    }

    public LRUMap(int maxCount) {
        this.maxCount = maxCount;
    }


    @Override
    protected boolean removeEldestEntry(final Map.Entry<K, V> eldest) {
        return super.size() > maxCount;
    }
}
