package net.vpc.upa.impl.ext;

import net.vpc.upa.Query;
import net.vpc.upa.persistence.EntityExecutionContext;

/**
 * Created by vpc on 7/6/17.
 */
public interface QueryExt extends Query {

    void setContext(EntityExecutionContext context);
}
