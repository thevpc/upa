package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.Entity;

/**
 * Created by vpc on 6/26/16.
 */
public interface QueryResultRelationLoader {
    public Object loadObject(Entity e, Object id,boolean record,LoaderContext context);
}
