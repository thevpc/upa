/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.persistence.commit;

import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.thevpc.upa.PersistenceState;
import net.thevpc.upa.PrimitiveField;
import net.thevpc.upa.config.PersistenceNameType;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.impl.persistence.DefaultPersistenceStore;
import net.thevpc.upa.impl.persistence.DefaultPersistenceUnitCommitManager;
import net.thevpc.upa.impl.persistence.StructureCommitAction;
import net.thevpc.upa.persistence.EntityExecutionContext;
import net.thevpc.upa.persistence.UConnection;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class PrimitiveFieldStructureCommitAction extends StructureCommitAction {

    protected static final Logger log = Logger.getLogger(PrimitiveFieldStructureCommitAction.class.getName());

    public PrimitiveFieldStructureCommitAction(PrimitiveField object, DefaultPersistenceUnitCommitManager persistenceUnitCommitManager) {
        super(persistenceUnitCommitManager, object, PersistenceNameType.COLUMN);
    }

    protected PersistenceState getObjectStatus(EntityExecutionContext entityExecutionContext) {
        return getPersistenceUnitCommitManager().getPersistenceStore().getPersistenceState(object, persistenceNameType, entityExecutionContext);
    }

    @Override
    public void persist(EntityExecutionContext executionContext, PersistenceState status) throws SQLException, UPAException {
        PrimitiveField field = (PrimitiveField) object;
        DefaultPersistenceStore store = (DefaultPersistenceStore) executionContext.getPersistenceStore();
        log.log(Level.FINE, "[{0}] Commit {1} / {2} : found {3}, persist", new Object[]{executionContext.getPersistenceUnit().getAbsoluteName(), object, persistenceNameType, status});
        UConnection b = executionContext.getConnection();
        if (status == PersistenceState.MISSING || status == PersistenceState.DEFAULT) {
            String q = store.getAlterTableAddColumnStatement(field, executionContext);
            b.executeNonQuery(q, null, null);
        } else if (status == PersistenceState.DIRTY) {
            String q = store.getAlterTableModifyColumnStatement(field, executionContext);
            b.executeNonQuery(q, null, null);
        }
    }
}
