/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence.commit;

import java.sql.SQLException;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.Entity;
import net.vpc.upa.PersistenceState;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.extensions.FilterEntityExtensionDefinition;
import net.vpc.upa.impl.ext.persistence.PersistenceStoreExt;
import net.vpc.upa.impl.persistence.DefaultPersistenceStore;
import net.vpc.upa.impl.persistence.DefaultPersistenceUnitCommitManager;
import net.vpc.upa.impl.persistence.StructureCommit;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.UConnection;
import net.vpc.upa.persistence.UnionEntityExtension;
import net.vpc.upa.persistence.ViewEntityExtension;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class ViewStructureCommit extends StructureCommit {

    protected static Logger log = Logger.getLogger(ViewStructureCommit.class.getName());

    public ViewStructureCommit(Entity object, DefaultPersistenceUnitCommitManager persistenceUnitCommitManager) {
        super(persistenceUnitCommitManager, object, Entity.class, null);
    }

    @Override
    public void persist(EntityExecutionContext executionContext, PersistenceState status) throws SQLException, UPAException {
        Entity entityManager = (Entity) object;
        DefaultPersistenceStore store = (DefaultPersistenceStore) executionContext.getPersistenceStore();
        log.log(Level.FINE, "Commit {0} / {1} : found {2}, persist", new Object[]{object, typedObject, status});
        UConnection b = executionContext.getConnection();

        List<ViewEntityExtension> specSupport = entityManager.getExtensions(ViewEntityExtension.class);
        for (ViewEntityExtension ss : specSupport) {
            b.executeNonQuery(store.getCreateViewStatement(entityManager, ss.getQuery(), executionContext), null, null);
        }
        List<UnionEntityExtension> uspecSupport = entityManager.getExtensions(UnionEntityExtension.class);
        for (UnionEntityExtension ss : uspecSupport) {
            b.executeNonQuery(store.getCreateViewStatement(entityManager, ss.getQuery(), executionContext), null, null);
        }
        List<FilterEntityExtensionDefinition> fspecSupport = entityManager.getExtensionDefinitions(FilterEntityExtensionDefinition.class);
        for (FilterEntityExtensionDefinition ss : fspecSupport) {
            b.executeNonQuery(store.getCreateViewStatement(entityManager, ss.getQuery(), executionContext), null, null);
        }
    }
}
