package net.vpc.upa.impl.persistence;

import net.vpc.upa.RemoveTrace;
import net.vpc.upa.Entity;
import net.vpc.upa.Query;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Delete;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.persistence.EntityRemoveOperation;
import net.vpc.upa.persistence.EntityExecutionContext;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/30/12 1:09 AM
 */
public class DefaultEntityRemoveOperation implements EntityRemoveOperation {
    @Override
    public int remove(Entity entity, EntityExecutionContext context, Expression condition, boolean recurse, RemoveTrace deleteInfo) throws UPAException {
        if (entity.getShield().isTransient()) {
            return 0;
        }
        Delete stmt = (new Delete()).from(entity.getName()).where(condition);
        return context.getPersistenceStore().createQuery(stmt, context).executeNonQuery();
    }

    public Query createQuery(Entity e, Delete query, EntityExecutionContext context) throws UPAException {
        return context.getPersistenceStore().createQuery(e, query, context);
    }

    
}
