/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence.commit;

import java.sql.Connection;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.Entity;
import net.vpc.upa.PersistenceState;
import net.vpc.upa.PrimitiveField;
import net.vpc.upa.config.PersistenceNameType;
import net.vpc.upa.filters.FieldFilters;
import net.vpc.upa.impl.persistence.ColumnDesc;
import net.vpc.upa.impl.persistence.DefaultPersistenceStore;
import net.vpc.upa.impl.persistence.DefaultPersistenceUnitCommitManager;
import net.vpc.upa.impl.persistence.StructureCommitAction;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.UConnection;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class EntityPKStructureCommitAction extends StructureCommitAction {

    protected static final Logger log = Logger.getLogger(EntityPKStructureCommitAction.class.getName());

    public EntityPKStructureCommitAction(Entity object, DefaultPersistenceUnitCommitManager persistenceUnitCommitManager) {
        super(persistenceUnitCommitManager, object, PersistenceNameType.PK_CONSTRAINT);
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
    protected PersistenceState getObjectStatus(net.vpc.upa.persistence.EntityExecutionContext entityExecutionContext) {
        return getPersistenceUnitCommitManager().getPersistenceStore().getPersistenceState(getObject(), getPersistenceNameType(), entityExecutionContext);
    }
}
