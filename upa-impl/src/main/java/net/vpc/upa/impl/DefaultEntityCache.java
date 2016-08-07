package net.vpc.upa.impl;

/**
 * Created by vpc on 6/12/16.
 */
class DefaultEntityCache {
    boolean needsRevalidateCache = false;
    Boolean isEmpty;
    DefaultEntityPrivateCacheEmptyListener cache_isEmpty_Listener;

    public DefaultEntityCache() {
        cache_isEmpty_Listener = new DefaultEntityPrivateCacheEmptyListener(this);
    }


}
