package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.Entity;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.expressions.QueryStatement;
import net.thevpc.upa.persistence.EntityFindOperation;
import net.thevpc.upa.persistence.EntityExecutionContext;
import net.thevpc.upa.Query;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/30/12 1:09 AM
 */
public class DefaultEntityFindOperation implements EntityFindOperation {

    public Query createQuery(Entity e, QueryStatement query, EntityExecutionContext context) throws UPAException {
        return context.getPersistenceStore().createQuery(e, query, context);
    }
}
