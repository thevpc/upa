/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence.commit;

import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.PersistenceState;
import net.vpc.upa.Relationship;
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
public class RelationshipStructureCommit extends StructureCommit {

    protected static Logger log = Logger.getLogger(RelationshipStructureCommit.class.getName());

    public RelationshipStructureCommit(Relationship object, DefaultPersistenceUnitCommitManager persistenceUnitCommitManager) {
        super(persistenceUnitCommitManager, object, Relationship.class, null);
    }

    @Override
    public void persist(EntityExecutionContext executionContext, PersistenceState status) throws SQLException, UPAException {
        Relationship relation = (Relationship) object;
        DefaultPersistenceStore store = (DefaultPersistenceStore) executionContext.getPersistenceStore();

        log.log(Level.FINE, "Commit {0} / {1} : found {2}, persist", new Object[]{object, typedObject, status});
        if (!relation.isTransient() && store.isReferencingSupported()) {
            UConnection b = executionContext.getConnection();
            b.executeNonQuery(store.getCreateRelationshipStatement(relation), null, null);
        }
    }
}
