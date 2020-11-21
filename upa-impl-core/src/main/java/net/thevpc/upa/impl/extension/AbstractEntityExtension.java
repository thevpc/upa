package net.thevpc.upa.impl.extension;

import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.Entity;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.EntityExtensionDefinition;
import net.thevpc.upa.persistence.EntityExtension;
import net.thevpc.upa.persistence.EntityOperationManager;

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
