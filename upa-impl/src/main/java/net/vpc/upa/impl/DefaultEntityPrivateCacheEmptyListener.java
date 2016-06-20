package net.vpc.upa.impl;

import net.vpc.upa.callbacks.EntityListenerAdapter;
import net.vpc.upa.callbacks.PersistEvent;
import net.vpc.upa.callbacks.RemoveEvent;
import net.vpc.upa.callbacks.UpdateEvent;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/4/13 12:09 AM
 */
public class DefaultEntityPrivateCacheEmptyListener extends EntityListenerAdapter{
    private DefaultEntityCache cache;

    public DefaultEntityPrivateCacheEmptyListener(DefaultEntityCache cache) {
        this.cache = cache;
    }

    @Override
    public void onPersist(PersistEvent event) {
        cache.isEmpty = Boolean.FALSE;
    }

    @Override
    public void onUpdate(UpdateEvent event) {
    }

    @Override
    public void onRemove(RemoveEvent event) {
        cache.isEmpty = null;
    }

    private void resetCache(){
        cache.isEmpty=null;
    }
}
