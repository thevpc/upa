package net.thevpc.upa.impl.ext;

import net.thevpc.upa.Query;
import net.thevpc.upa.persistence.EntityExecutionContext;

/**
 * Created by vpc on 7/6/17.
 */
public interface QueryExt extends Query {

    void setContext(EntityExecutionContext context);
}
