package net.thevpc.upa.impl;

import net.thevpc.upa.Entity;
import net.thevpc.upa.events.EntityInterceptor;
import net.thevpc.upa.events.EntityListener;
import net.thevpc.upa.events.Trigger;
import net.thevpc.upa.exceptions.UPAException;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/9/12 4:33 PM
 */
public class DefaultTrigger extends AbstractUPAObject implements Trigger {

    private Entity entity;
    private EntityInterceptor interceptor;
    private EntityListener listener;

    public DefaultTrigger() {
    }

    public Entity getEntity() {
        return entity;
    }

    public void setEntity(Entity entity) {
        this.entity = entity;
    }

    public EntityInterceptor getInterceptor() {
        return interceptor;
    }

    public void setInterceptor(EntityInterceptor interceptor) {
        this.interceptor = interceptor;
    }

    public EntityListener getListener() {
        return listener;
    }

    public void setListener(EntityListener listener) {
        this.listener = listener;
    }

    @Override
    public String getAbsoluteName() {
        return getEntity().getAbsoluteName() + "." + getName();
    }

    public void close() throws UPAException {

    }

}
