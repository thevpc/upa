/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence.commit;

import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.Index;
import net.vpc.upa.PersistenceState;
import net.vpc.upa.config.PersistenceNameType;
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
public class IndexStructureCommit extends StructureCommit {

    protected static Logger log = Logger.getLogger(IndexStructureCommit.class.getName());

    public IndexStructureCommit(Index object, DefaultPersistenceUnitCommitManager persistenceUnitCommitManager) {
        super(persistenceUnitCommitManager, object, Index.class, PersistenceNameType.INDEX);
    }

    @Override
    public void persist(EntityExecutionContext executionContext, PersistenceState status) throws SQLException, UPAException {
        Index index = (Index) object;
        DefaultPersistenceStore store = (DefaultPersistenceStore) executionContext.getPersistenceStore();
        if (!store.isView(index.getEntity())) {
            log.log(Level.FINE, "[{0}] Commit {1} / {2} : found {3}, persist", new Object[]{executionContext.getPersistenceUnit().getAbsoluteName(),object, typedObject, status});
            UConnection b = executionContext.getConnection();
            if(status== PersistenceState.DIRTY){
                b.executeNonQuery(store.getDropIndexStatement(index), null, null);
            }
            b.executeNonQuery(store.getCreateIndexStatement(index), null, null);
        }
    }
}
