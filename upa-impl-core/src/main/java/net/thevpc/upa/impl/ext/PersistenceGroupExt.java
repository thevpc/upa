package net.thevpc.upa.impl.ext;

import net.thevpc.upa.ObjectFactory;
import net.thevpc.upa.PersistenceGroup;
import net.thevpc.upa.UPAContext;


/**
 * Created by vpc on 7/6/17.
 */
public interface PersistenceGroupExt extends PersistenceGroup {

    void init(String name, UPAContext context, ObjectFactory factory);
}
