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
    private Boolean cache_isEmpty;
    @Override
    public void onPersist(PersistEvent event) {
        cache_isEmpty = Boolean.TRUE;
    }

    @Override
    public void onUpdate(UpdateEvent event) {
    }

    @Override
    public void onRemove(RemoveEvent event) {
        cache_isEmpty = null;
    }

    private void resetCache(){
        cache_isEmpty=null;
    }
}
