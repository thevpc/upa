package net.vpc.upa.impl.ext;

import net.vpc.upa.*;

/**
 * Created by vpc on 7/6/17.
 */
public interface PersistenceGroupExt extends PersistenceGroup {

    void init(String name, UPAContext context, ObjectFactory factory);
}
