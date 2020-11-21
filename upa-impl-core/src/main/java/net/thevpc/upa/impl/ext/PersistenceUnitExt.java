package net.thevpc.upa.impl.ext;

import net.thevpc.upa.*;
import net.thevpc.upa.impl.config.decorations.DecorationRepository;
import net.thevpc.upa.impl.event.PersistenceUnitListenerManager;

import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.impl.OnHoldCommitAction;
import net.thevpc.upa.persistence.ContextOperation;
import net.thevpc.upa.persistence.EntityExecutionContext;

import java.util.Map;

/**
 * Created by vpc on 7/6/17.
 */
public interface PersistenceUnitExt extends PersistenceUnit {

    void init(String name, PersistenceGroup persistenceGroup);

    EntityExecutionContext createContext(ContextOperation operation, Map<String, Object> hints) throws UPAException;

    PersistenceUnitListenerManager getPersistenceUnitListenerManager();

    DecorationRepository getDecorationRepository();

    void postponeCommit(OnHoldCommitAction modelCommit);

    void addLockingSupport(Entity entity) throws UPAException;

    Relationship addRelationshipImmediate(RelationshipDescriptor relationDescriptor) throws UPAException;
}
