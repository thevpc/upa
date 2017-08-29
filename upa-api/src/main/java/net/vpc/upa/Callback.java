package net.vpc.upa;

import java.util.Map;

/**
 * Callback ae Framework hooks to object (@see {@link ObjectType}) manipulation phases (@see {@link EventPhase}).
 * They are invoked before or after un object action (@see {@link CallbackType})
 * @author taha.bensalah@gmail.com on 7/25/15.
 * @see UPAContext#addCallback(Callback)
 * @see UPAContext#addCallback(MethodCallback)
 * @see PersistenceGroup#addCallback(Callback)
 * @see PersistenceGroup#addCallback(MethodCallback)
 * @see PersistenceUnit#addCallback(Callback)
 * @see PersistenceUnit#addCallback(MethodCallback)
 */
public interface Callback {

    Object invoke(Object... arguments);

    CallbackType getCallbackType();

    EventPhase getPhase();

    ObjectType getObjectType();

    Map<String, Object> getConfiguration();
}
