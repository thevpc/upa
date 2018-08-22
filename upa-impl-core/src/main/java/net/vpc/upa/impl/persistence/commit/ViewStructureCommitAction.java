/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence.commit;

import java.sql.Connection;
import java.sql.SQLException;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.Entity;
import net.vpc.upa.PersistenceState;
import net.vpc.upa.config.PersistenceNameType;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.QueryStatement;
import net.vpc.upa.extensions.FilterEntityExtensionDefinition;
import net.vpc.upa.impl.persistence.DefaultPersistenceStore;
import net.vpc.upa.impl.persistence.DefaultPersistenceUnitCommitManager;
import net.vpc.upa.impl.persistence.StructureCommitAction;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.UConnection;
import net.vpc.upa.persistence.UnionEntityExtension;
import net.vpc.upa.persistence.ViewEntityExtension;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class ViewStructureCommitAction extends StructureCommitAction {

    protected static final Logger log = Logger.getLogger(ViewStructureCommitAction.class.getName());

    public ViewStructureCommitAction(Entity object, DefaultPersistenceUnitCommitManager persistenceUnitCommitManager) {
        super(persistenceUnitCommitManager, object, PersistenceNameType.VIEW);
    }

    @Override
    public void persist(EntityExecutionContext executionContext, PersistenceState status) throws SQLException, UPAException {
        Entity entity = (Entity) object;
        DefaultPersistenceStore store = (DefaultPersistenceStore) executionContext.getPersistenceStore();
        log.log(Level.FINE, "[{0}] Commit {1} / {2} : found {3}, persist", new Object[]{executionContext.getPersistenceUnit().getAbsoluteName(), object, persistenceNameType, status});
        UConnection b = executionContext.getConnection();

        List<ViewEntityExtension> specSupport = entity.getExtensions(ViewEntityExtension.class);
        QueryStatement query = null;
        for (ViewEntityExtension ss : specSupport) {
            query = ss.getQuery();
        }
        List<UnionEntityExtension> uspecSupport = entity.getExtensions(UnionEntityExtension.class);
        for (UnionEntityExtension ss : uspecSupport) {
            query = ss.getQuery();
        }
        List<FilterEntityExtensionDefinition> fspecSupport = entity.getExtensionDefinitions(FilterEntityExtensionDefinition.class);
        for (FilterEntityExtensionDefinition ss : fspecSupport) {
            query = ss.getQuery();
        }
        if (query != null) {
            switch (status) {
                case DEFAULT: 
                case MISSING: 
                {
                    b.executeNonQuery(store.getCreateViewStatement(entity, executionContext), null, null);
                    break;
                }
                case DIRTY: {
                    b.executeNonQuery(store.getDropViewStatement(entity, executionContext), null, null);
                    b.executeNonQuery(store.getCreateViewStatement(entity, executionContext), null, null);
                    break;
                }
            }
        }
    }
}
