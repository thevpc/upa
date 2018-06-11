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
import net.vpc.upa.config.PersistenceNameType;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.ext.persistence.PersistenceStoreExt;
import net.vpc.upa.impl.persistence.DefaultPersistenceStore;
import net.vpc.upa.impl.persistence.DefaultPersistenceUnitCommitManager;
import net.vpc.upa.impl.persistence.StructureCommit;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.UConnection;
import net.vpc.upa.types.I18NString;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class RelationshipStructureCommit extends StructureCommit {

    protected static Logger log = Logger.getLogger(RelationshipStructureCommit.class.getName());

    public RelationshipStructureCommit(Relationship object, DefaultPersistenceUnitCommitManager persistenceUnitCommitManager) {
        super(persistenceUnitCommitManager, object, Relationship.class, PersistenceNameType.FK_CONSTRAINT);
    }

    @Override
    public void persist(EntityExecutionContext executionContext, PersistenceState status) throws UPAException {
        Relationship relation = (Relationship) object;
        DefaultPersistenceStore store = (DefaultPersistenceStore) executionContext.getPersistenceStore();

        log.log(Level.FINE, "[{0}] Commit {1} / {2} : found {3}, persist", new Object[]{executionContext.getPersistenceUnit().getAbsoluteName(),object, typedObject, status});
        if (!relation.isTransient() && store.isReferencingSupported()) {
            UConnection b = executionContext.getConnection();
            try {
                String statement = store.getCreateRelationshipStatement(relation);
                b.executeNonQuery(statement, null, null);
            }catch (Exception ex){
                throw new UPAException(ex, new I18NString("UnableToStoreRelation"), object);
            }
        }
    }
}
