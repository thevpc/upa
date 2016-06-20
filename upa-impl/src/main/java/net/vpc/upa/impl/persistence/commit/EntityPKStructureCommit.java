/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence.commit;

import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.Entity;
import net.vpc.upa.PersistenceState;
import net.vpc.upa.PrimitiveField;
import net.vpc.upa.persistence.PersistenceNameType;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.DefaultEntity;
import net.vpc.upa.impl.persistence.ColumnDesc;
import net.vpc.upa.impl.persistence.DefaultPersistenceUnitCommitManager;
import net.vpc.upa.impl.persistence.DefaultPersistenceStore;
import net.vpc.upa.impl.persistence.StructureCommit;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.UConnection;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class EntityPKStructureCommit extends StructureCommit {

    protected static Logger log = Logger.getLogger(EntityPKStructureCommit.class.getName());

    public EntityPKStructureCommit(Entity object, DefaultPersistenceUnitCommitManager persistenceUnitCommitManager) {
        super(persistenceUnitCommitManager, object, Entity.class, PersistenceNameType.PK_CONSTRAINT);
    }

    @Override
    public void persist(EntityExecutionContext executionContext, PersistenceState status) throws SQLException, UPAException {
        Entity entity = (Entity) object;
        DefaultPersistenceStore store = (DefaultPersistenceStore) executionContext.getPersistenceStore();
        if (entity.getPrimaryFields().size() > 0) {
            log.log(Level.FINE, "Commit {0} / {1} : found {2}, persist", new Object[]{object, typedObject, status});
            UConnection b = executionContext.getConnection();
            for (PrimitiveField primaryField : entity.getPrimitiveFields(DefaultEntity.ID)) {
                ColumnDesc cd = store.loadColumnDesc(primaryField, b.getMetadataAccessibleConnection());
                if (cd.isNullable()!=null && cd.isNullable()) {
                    b.executeNonQuery(store.getAlterTableAlterColumnNullStatement(primaryField, false), null, null);
                }
            }
            b.executeNonQuery(store.getCreateTablePKConstraintStatement(entity), null, null);
        }
    }

    @Override
    protected PersistenceState getObjectStatus(net.vpc.upa.persistence.EntityExecutionContext entityExecutionContext) {
        return getPersistenceUnitCommitManager().getPersistenceUnitManager().getPersistenceState(getObject(), getTypedObject().getSpec(), entityExecutionContext);
    }
}
