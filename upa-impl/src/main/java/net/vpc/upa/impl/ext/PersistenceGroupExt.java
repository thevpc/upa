package net.vpc.upa.impl.ext;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.OnHoldCommitAction;
import net.vpc.upa.impl.config.decorations.DecorationRepository;
import net.vpc.upa.impl.event.PersistenceUnitListenerManager;
import net.vpc.upa.persistence.ContextOperation;
import net.vpc.upa.persistence.EntityExecutionContext;

import java.util.Map;

/**
 * Created by vpc on 7/6/17.
 */
public interface PersistenceGroupExt extends PersistenceGroup{
    void init(String name, UPAContext context, ObjectFactory factory);
}
