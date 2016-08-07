package net.vpc.upa.impl.context;

import net.vpc.upa.Entity;
import net.vpc.upa.callbacks.Trigger;
import net.vpc.upa.callbacks.EntityTriggerContext;
import net.vpc.upa.persistence.EntityExecutionContext;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/10/12 12:27 AM
 */
public class DefaultEntityTriggerContext implements EntityTriggerContext {
    private Entity entityManager;
    private Trigger triggerObject;
    private EntityExecutionContext executionContext;

    public DefaultEntityTriggerContext(Entity entityManager, Trigger triggerObject, EntityExecutionContext executionContext) {
        this.entityManager = entityManager;
        this.triggerObject = triggerObject;
        this.executionContext = executionContext;
    }

    public Entity getEntity() {
        return entityManager;
    }

    public Trigger getTrigger() {
        return triggerObject;
    }

    public EntityExecutionContext getEntityExecutionContext() {
        return executionContext;
    }
}
