package net.vpc.upa.impl.extension;

import net.vpc.upa.Entity;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.extensions.EntityExtensionDefinition;
import net.vpc.upa.persistence.EntityExtension;
import net.vpc.upa.persistence.EntityOperationManager;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/30/12 12:39 AM
 */
public abstract class AbstractEntityExtension implements EntityExtension {
    private EntityExtensionDefinition spec;
    private Entity entity;
    private PersistenceUnit persistenceUnit;

    @Override
    public EntityExtensionDefinition getDefinition() {
        return spec;
    }

    @Override
    public void install(Entity entity, EntityOperationManager entityOperationManager, EntityExtensionDefinition spec) throws UPAException{
        this.spec=spec;
        this.entity=entity;
        this.persistenceUnit =entity.getPersistenceUnit();
    }

    public Entity getEntity() {
        return entity;
    }

    public PersistenceUnit getPersistenceUnit() {
        return persistenceUnit;
    }

    @Override
    public void commitModelChanges() throws UPAException{
    }

}
