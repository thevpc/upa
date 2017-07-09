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
public interface PersistenceUnitExt extends PersistenceUnit{
    void init(String name, PersistenceGroup persistenceGroup);
    EntityExecutionContext createContext(ContextOperation operation, Map<String, Object> hints) throws UPAException ;
    PersistenceUnitListenerManager getPersistenceUnitListenerManager();
    DecorationRepository getDecorationRepository();
    void postponeCommit(OnHoldCommitAction modelCommit);
    void addLockingSupport(Entity entity) throws UPAException;
    Relationship addRelationshipImmediate(RelationshipDescriptor relationDescriptor) throws UPAException;
}
