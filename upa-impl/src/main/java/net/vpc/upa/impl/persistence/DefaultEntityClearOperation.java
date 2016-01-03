package net.vpc.upa.impl.persistence;

import net.vpc.upa.Entity;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Delete;
import net.vpc.upa.persistence.EntityClearOperation;
import net.vpc.upa.persistence.EntityExecutionContext;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/30/12 1:09 AM
 */
public class DefaultEntityClearOperation implements EntityClearOperation {
    @Override
    public int clear(Entity entity, EntityExecutionContext context) throws UPAException {
        if (entity.getShield().isTransient()) {
            return 0;
        }
        Delete stmt = (new Delete()).from(entity.getName());
        return context.getPersistenceStore().executeUpdate(stmt, context);
    }

}
