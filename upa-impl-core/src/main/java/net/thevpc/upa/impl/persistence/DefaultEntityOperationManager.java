package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.persistence.*;
import net.thevpc.upa.Entity;
import net.thevpc.upa.persistence.*;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/30/12 1:19 AM
 */
public class DefaultEntityOperationManager implements EntityOperationManager {
    private EntityPersistOperation persistencePersistAction = new DefaultEntityPersistOperation();
    private EntityUpdateOperation persistenceUpdateAction = new DefaultEntityUpdateOperation();
    private EntityRemoveOperation persistenceDeleteAction = new DefaultEntityRemoveOperation();
    private EntityFindOperation persistenceFindAction = new DefaultEntityFindOperation();
    private EntityResetOperation persistenceResetAction = new DefaultEntityResetOperation();
    private EntityClearOperation persistenceClearAction = new DefaultEntityClearOperation();
    private EntityInitializeOperation persistenceInitializeAction = new DefaultEntityInitializeOperation();
    private PersistenceStore persistenceStore;
    private Entity entity;

    public void init(Entity entity, PersistenceStore persistenceStore) {
        this.entity= entity;
        this.persistenceStore = persistenceStore;
    }

    @Override
    public PersistenceStore getPersistenceStore() {
        return persistenceStore;
    }

    @Override
    public void setPersistOperation(EntityPersistOperation operation) {
        this.persistencePersistAction = operation;
    }

    @Override
    public EntityPersistOperation getPersistOperation() {
        return persistencePersistAction;
    }

    @Override
    public void setUpdateOperation(EntityUpdateOperation operation) {
        this.persistenceUpdateAction = operation;
    }

    @Override
    public EntityUpdateOperation getUpdateOperation() {
        return persistenceUpdateAction;
    }

    @Override
    public void setRemoveOperation(EntityRemoveOperation operation) {
        this.persistenceDeleteAction = operation;
    }

    @Override
    public EntityRemoveOperation getRemoveOperation() {
        return persistenceDeleteAction;
    }

    @Override
    public void setFindOperation(EntityFindOperation operation) {
        this.persistenceFindAction = operation;
    }

    @Override
    public EntityFindOperation getFindOperation() {
        return persistenceFindAction;
    }

    @Override
    public void setResetOperation(EntityResetOperation operation) {
        this.persistenceResetAction= operation;
    }

    @Override
    public EntityResetOperation getResetOperation() {
        return this.persistenceResetAction;
    }

    public EntityClearOperation getClearOperation() {
        return persistenceClearAction;
    }

    public void setClearOperation(EntityClearOperation operation) {
        this.persistenceClearAction = operation;
    }

    public EntityInitializeOperation getInitializeOperation() {
        return persistenceInitializeAction;
    }

    public void setInitOperation(EntityInitializeOperation operation) {
        this.persistenceInitializeAction = operation;
    }
}
