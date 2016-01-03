/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence.commit;

import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.Entity;
import net.vpc.upa.PersistenceState;
import net.vpc.upa.persistence.PersistenceNameType;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.DefaultPersistenceUnitCommitManager;
import net.vpc.upa.impl.persistence.DefaultPersistenceStore;
import net.vpc.upa.impl.persistence.StructureCommit;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.UConnection;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class EntityImplicitViewStructureCommit extends StructureCommit {

    protected static Logger log = Logger.getLogger(EntityImplicitViewStructureCommit.class.getName());

    public EntityImplicitViewStructureCommit(Entity object, DefaultPersistenceUnitCommitManager persistenceUnitCommitManager) {
        super(persistenceUnitCommitManager, object, Entity.class, PersistenceNameType.IMPLICIT_VIEW);
    }

    @Override
    public void persist(EntityExecutionContext executionContext, PersistenceState status) throws SQLException, UPAException {
        Entity entity = (Entity) object;
        DefaultPersistenceStore persistenceUnitManager = (DefaultPersistenceStore) executionContext.getPersistenceStore();
        if (persistenceUnitManager.isViewSupported() && entity.needsView()) {
            log.log(Level.FINE, "Commit {0} / {1} : found {2}, persist", new Object[]{object, typedObject, status});
            UConnection b = persistenceUnitManager.getConnection();
            b.executeNonQuery(persistenceUnitManager.getCreateImplicitViewStatement(entity, executionContext), null, null);
        }

    }
}
