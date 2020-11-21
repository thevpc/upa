/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.persistence.commit;

import java.sql.Connection;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.thevpc.upa.Entity;
import net.thevpc.upa.PersistenceState;
import net.thevpc.upa.PrimitiveField;
import net.thevpc.upa.config.PersistenceNameType;
import net.thevpc.upa.filters.FieldFilters;
import net.thevpc.upa.impl.persistence.ColumnDesc;
import net.thevpc.upa.impl.persistence.DefaultPersistenceStore;
import net.thevpc.upa.impl.persistence.DefaultPersistenceUnitCommitManager;
import net.thevpc.upa.impl.persistence.StructureCommitAction;
import net.thevpc.upa.persistence.EntityExecutionContext;
import net.thevpc.upa.persistence.UConnection;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class EntityPKStructureCommitAction extends StructureCommitAction {

    protected static final Logger log = Logger.getLogger(EntityPKStructureCommitAction.class.getName());

    public EntityPKStructureCommitAction(Entity object, DefaultPersistenceUnitCommitManager persistenceUnitCommitManager) {
        super(persistenceUnitCommitManager, object, PersistenceNameType.PRIMARY_KEY_CONSTRAINT);
    }

    @Override
    public void persist(EntityExecutionContext executionContext, PersistenceState status) {
        Entity entity = (Entity) object;
        DefaultPersistenceStore store = (DefaultPersistenceStore) executionContext.getPersistenceStore();
        if (entity.getIdFields().size() > 0) {
            log.log(Level.FINE, "[{0}] Commit {1} / {2} : found {3}, persist", new Object[]{executionContext.getPersistenceUnit().getAbsoluteName(),object, persistenceNameType, status});
            UConnection b = executionContext.getConnection();
            for (PrimitiveField primaryField : entity.getPrimitiveFields(FieldFilters.id())) {
                ColumnDesc cd = store.loadColumnDesc(primaryField, (Connection)b.getMetadataAccessibleConnection());
                if (cd.isNullable()!=null && cd.isNullable()) {
                    b.executeNonQuery(store.getAlterTableAlterColumnNullStatement(primaryField, false), null, null);
                }
            }
            b.executeNonQuery(store.getCreateTablePKConstraintStatement(entity), null, null);
        }
    }

    @Override
    protected PersistenceState getObjectStatus(EntityExecutionContext entityExecutionContext) {
        return getPersistenceUnitCommitManager().getPersistenceStore().getPersistenceState(getObject(), getPersistenceNameType(), entityExecutionContext);
    }
}
