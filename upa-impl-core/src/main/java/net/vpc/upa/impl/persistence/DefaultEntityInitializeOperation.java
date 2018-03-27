package net.vpc.upa.impl.persistence;

import net.vpc.upa.Entity;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.EntityInitializeOperation;
import net.vpc.upa.persistence.EntityExecutionContext;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/30/12 1:09 AM
 */
public class DefaultEntityInitializeOperation implements EntityInitializeOperation {
    @Override
    public int initialize(Entity entity, EntityExecutionContext context) throws UPAException {
        return 0;
    }

}
