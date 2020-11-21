package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.Entity;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.persistence.EntityInitializeOperation;
import net.thevpc.upa.persistence.EntityExecutionContext;

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
