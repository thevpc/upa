/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.persistence.commit;

import java.util.logging.Level;
import java.util.logging.Logger;
import net.thevpc.upa.PersistenceState;
import net.thevpc.upa.Relationship;
import net.thevpc.upa.config.PersistenceNameType;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.impl.persistence.DefaultPersistenceStore;
import net.thevpc.upa.impl.persistence.DefaultPersistenceUnitCommitManager;
import net.thevpc.upa.impl.persistence.StructureCommitAction;
import net.thevpc.upa.persistence.EntityExecutionContext;
import net.thevpc.upa.persistence.UConnection;
import net.thevpc.upa.types.I18NString;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class RelationshipStructureCommitAction extends StructureCommitAction {

    protected static Logger log = Logger.getLogger(RelationshipStructureCommitAction.class.getName());

    public RelationshipStructureCommitAction(Relationship object, DefaultPersistenceUnitCommitManager persistenceUnitCommitManager) {
        super(persistenceUnitCommitManager, object, PersistenceNameType.FOREIGN_KEY_CONSTRAINT);
    }

    @Override
    public void persist(EntityExecutionContext executionContext, PersistenceState status) throws UPAException {
        Relationship relation = (Relationship) object;
        DefaultPersistenceStore store = (DefaultPersistenceStore) executionContext.getPersistenceStore();

        log.log(Level.FINE, "[{0}] Commit {1} / {2} : found {3}, persist", new Object[]{executionContext.getPersistenceUnit().getAbsoluteName(),object, persistenceNameType, status});
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
