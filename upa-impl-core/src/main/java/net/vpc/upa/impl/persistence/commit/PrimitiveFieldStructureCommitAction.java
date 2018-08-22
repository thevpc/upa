/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence.commit;

import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.PersistenceState;
import net.vpc.upa.PrimitiveField;
import net.vpc.upa.config.PersistenceNameType;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.DefaultPersistenceStore;
import net.vpc.upa.impl.persistence.DefaultPersistenceUnitCommitManager;
import net.vpc.upa.impl.persistence.StructureCommitAction;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.UConnection;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class PrimitiveFieldStructureCommitAction extends StructureCommitAction {

    protected static final Logger log = Logger.getLogger(PrimitiveFieldStructureCommitAction.class.getName());

    public PrimitiveFieldStructureCommitAction(PrimitiveField object, DefaultPersistenceUnitCommitManager persistenceUnitCommitManager) {
        super(persistenceUnitCommitManager, object, PersistenceNameType.COLUMN);
    }

    protected PersistenceState getObjectStatus(net.vpc.upa.persistence.EntityExecutionContext entityExecutionContext) {
        return getPersistenceUnitCommitManager().getPersistenceStore().getPersistenceState(object, persistenceNameType, entityExecutionContext);
    }

    @Override
    public void persist(EntityExecutionContext executionContext, PersistenceState status) throws SQLException, UPAException {
        PrimitiveField field = (PrimitiveField) object;
        DefaultPersistenceStore store = (DefaultPersistenceStore) executionContext.getPersistenceStore();
        log.log(Level.FINE, "[{0}] Commit {1} / {2} : found {3}, persist", new Object[]{executionContext.getPersistenceUnit().getAbsoluteName(),object, persistenceNameType, status});
        String q=store.getAlterTableAddColumnStatement(field, executionContext);
        UConnection b = executionContext.getConnection();
        b.executeNonQuery(q, null, null);

    }
}