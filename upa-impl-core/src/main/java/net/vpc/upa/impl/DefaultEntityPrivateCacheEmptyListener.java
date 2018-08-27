package net.vpc.upa.impl;

import net.vpc.upa.events.EntityListenerAdapter;
import net.vpc.upa.events.PersistEvent;
import net.vpc.upa.events.RemoveEvent;
import net.vpc.upa.events.UpdateEvent;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/4/13 12:09 AM
 */
class DefaultEntityPrivateCacheEmptyListener extends EntityListenerAdapter{
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
