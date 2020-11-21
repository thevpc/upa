package net.thevpc.upa.impl;

import net.thevpc.upa.events.EntityListenerAdapter;
import net.thevpc.upa.events.PersistEvent;
import net.thevpc.upa.events.RemoveEvent;
import net.thevpc.upa.events.UpdateEvent;

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
