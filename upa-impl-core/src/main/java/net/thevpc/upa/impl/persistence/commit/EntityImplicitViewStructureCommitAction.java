/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.persistence.commit;

import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.thevpc.upa.Entity;
import net.thevpc.upa.PersistenceState;
import net.thevpc.upa.config.PersistenceNameType;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.impl.ext.persistence.PersistenceStoreExt;
import net.thevpc.upa.impl.persistence.DefaultPersistenceUnitCommitManager;
import net.thevpc.upa.impl.persistence.StructureCommitAction;
import net.thevpc.upa.persistence.EntityExecutionContext;
import net.thevpc.upa.persistence.UConnection;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class EntityImplicitViewStructureCommitAction extends StructureCommitAction {

    protected static Logger log = Logger.getLogger(EntityImplicitViewStructureCommitAction.class.getName());

    public EntityImplicitViewStructureCommitAction(Entity object, DefaultPersistenceUnitCommitManager persistenceUnitCommitManager) {
        super(persistenceUnitCommitManager, object, PersistenceNameType.IMPLICIT_VIEW);
    }

    @Override
    public void persist(EntityExecutionContext executionContext, PersistenceState status) throws SQLException, UPAException {
        Entity entity = (Entity) object;
        PersistenceStoreExt persistenceStore = (PersistenceStoreExt) executionContext.getPersistenceStore();
        if (persistenceStore.isViewSupported() && entity.hasAssociatedView()) {
            log.log(Level.FINE, "[{0}] Commit {1} / {2} : found {3}, persist", new Object[]{executionContext.getPersistenceUnit().getAbsoluteName(),object, persistenceNameType, status});
            UConnection b = executionContext.getConnection();
            b.executeNonQuery(persistenceStore.getCreateImplicitViewStatement(entity, executionContext), null, null);
        }

    }
}
