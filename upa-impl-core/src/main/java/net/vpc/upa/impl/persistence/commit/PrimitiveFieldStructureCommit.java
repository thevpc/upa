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
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.ext.persistence.PersistenceStoreExt;
import net.vpc.upa.impl.persistence.DefaultPersistenceStore;
import net.vpc.upa.impl.persistence.DefaultPersistenceUnitCommitManager;
import net.vpc.upa.impl.persistence.StructureCommit;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.UConnection;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class PrimitiveFieldStructureCommit extends StructureCommit {

    protected static final Logger log = Logger.getLogger(PrimitiveFieldStructureCommit.class.getName());

    public PrimitiveFieldStructureCommit(PrimitiveField object, DefaultPersistenceUnitCommitManager persistenceUnitCommitManager) {
        super(persistenceUnitCommitManager, object, PrimitiveField.class, null);
    }

    protected PersistenceState getObjectStatus(net.vpc.upa.persistence.EntityExecutionContext entityExecutionContext) {
        return getPersistenceUnitCommitManager().getPersistenceUnitManager().getPersistenceState(object, typedObject.getSpec(), entityExecutionContext);
    }

    @Override
    public void persist(EntityExecutionContext executionContext, PersistenceState status) throws SQLException, UPAException {
        PrimitiveField field = (PrimitiveField) object;
        DefaultPersistenceStore store = (DefaultPersistenceStore) executionContext.getPersistenceStore();
        log.log(Level.FINE, "Commit {0} / {1} : found {2}, persist", new Object[]{object, typedObject, status});
        String q=store.getAlterTableAddColumnStatement(field, executionContext);
        UConnection b = executionContext.getConnection();
        b.executeNonQuery(q, null, null);

    }
}
