package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.Entity;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.expressions.Delete;
import net.thevpc.upa.persistence.EntityClearOperation;
import net.thevpc.upa.persistence.EntityExecutionContext;

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
        return context.getPersistenceStore().createQuery(stmt,context).executeNonQuery();
    }

}
