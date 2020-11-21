package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.RemoveTrace;
import net.thevpc.upa.Entity;
import net.thevpc.upa.Query;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.expressions.Delete;
import net.thevpc.upa.expressions.Expression;
import net.thevpc.upa.persistence.EntityRemoveOperation;
import net.thevpc.upa.persistence.EntityExecutionContext;

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
