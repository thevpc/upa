package net.vpc.upa.impl.ext.persistence;

import net.vpc.upa.Entity;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.persistence.ContextOperation;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.EntityOperationManager;
import net.vpc.upa.persistence.PersistenceStore;

/**
 * Created by vpc on 7/6/17.
 */
public interface EntityExecutionContextExt extends EntityExecutionContext{
    void initPersistenceUnit(PersistenceUnit persistenceUnit, PersistenceStore persistenceStore, ContextOperation contextOperation);

    void initEntity(Entity currentEntity, EntityOperationManager entityOperationManager);

}
