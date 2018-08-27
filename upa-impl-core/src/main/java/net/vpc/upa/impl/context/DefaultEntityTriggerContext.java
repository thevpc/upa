package net.vpc.upa.impl.context;

import net.vpc.upa.Entity;
import net.vpc.upa.events.Trigger;
import net.vpc.upa.events.EntityTriggerContext;
import net.vpc.upa.persistence.EntityExecutionContext;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/10/12 12:27 AM
 */
public class DefaultEntityTriggerContext implements EntityTriggerContext {
    private final Entity entity;
    private final Trigger triggerObject;
    private final EntityExecutionContext executionContext;

    public DefaultEntityTriggerContext(Entity entity, Trigger triggerObject, EntityExecutionContext executionContext) {
        this.entity = entity;
        this.triggerObject = triggerObject;
        this.executionContext = executionContext;
    }

    public Entity getEntity() {
        return entity;
    }

    public Trigger getTrigger() {
        return triggerObject;
    }

    public EntityExecutionContext getEntityExecutionContext() {
        return executionContext;
    }
}
