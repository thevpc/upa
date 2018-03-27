package net.vpc.upa.impl.persistence;

import net.vpc.upa.Entity;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.QueryStatement;
import net.vpc.upa.persistence.EntityFindOperation;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.Query;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/30/12 1:09 AM
 */
public class DefaultEntityFindOperation implements EntityFindOperation {

    public Query createQuery(Entity e, QueryStatement query, EntityExecutionContext context) throws UPAException {
        return context.getPersistenceStore().createQuery(e, query, context);
    }
}
