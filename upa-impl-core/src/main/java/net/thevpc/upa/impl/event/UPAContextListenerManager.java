package net.thevpc.upa.impl.event;

import net.thevpc.upa.impl.config.DefaultUPAContext;
import net.thevpc.upa.Callback;
import net.thevpc.upa.EventType;
import net.thevpc.upa.EventPhase;
import net.thevpc.upa.ObjectType;
import net.thevpc.upa.events.PersistenceGroupDefinitionListener;
import net.thevpc.upa.events.PersistenceGroupEvent;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.impl.util.CallbackManager;

import java.util.ArrayList;
import java.util.List;
import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/27/12 9:07 PM
 */
public class UPAContextListenerManager {

    private static final Logger log = Logger.getLogger(UPAContextListenerManager.class.getName());

    private DefaultUPAContext upaContext;
    private CallbackManager callbackManager = new CallbackManager();
    private static boolean DEFAULT_SYSTEM = false;
    private final List<PersistenceGroupDefinitionListener> persistenceGroupDefinitionListeners = new ArrayList<PersistenceGroupDefinitionListener>();

    public UPAContextListenerManager(DefaultUPAContext upaContext) {
        this.upaContext = upaContext;
    }

    public void fireOnCreatePersistenceGroup(PersistenceGroupEvent event, EventPhase phase) {
        PersistenceGroupDefinitionListener[] interceptorList = getPersistenceGroupDefinitionListeners();
        if (phase == EventPhase.BEFORE) {
            for (PersistenceGroupDefinitionListener listener : interceptorList) {
                listener.onPreCreatePersistenceGroup(event);
            }
            for (Callback callback : getCallbackPreInvokers(EventType.ON_CREATE, ObjectType.PERSISTENCE_GROUP, event.getPersistenceGroup().getName(), DEFAULT_SYSTEM)) {
                callback.invoke(event);
            }
        } else {
            for (PersistenceGroupDefinitionListener listener : interceptorList) {
                listener.onCreatePersistenceGroup(event);
            }
            for (Callback callback : getCallbackPostInvokers(EventType.ON_CREATE, ObjectType.PERSISTENCE_GROUP, event.getPersistenceGroup().getName(), DEFAULT_SYSTEM)) {
                callback.invoke(event);
            }
        }
    }

    public void fireOnDropPersistenceGroup(PersistenceGroupEvent event, EventPhase phase) {
        PersistenceGroupDefinitionListener[] interceptorList = getPersistenceGroupDefinitionListeners();
        if (phase == EventPhase.BEFORE) {
            for (PersistenceGroupDefinitionListener listener : interceptorList) {
                listener.onPreDropPersistenceGroup(event);
            }
            for (Callback callback : getCallbackPreInvokers(EventType.ON_DROP, ObjectType.PERSISTENCE_GROUP, event.getPersistenceGroup().getName(), DEFAULT_SYSTEM)) {
                callback.invoke(event);
            }
        } else {
            for (PersistenceGroupDefinitionListener listener : interceptorList) {
                listener.onDropPersistenceGroup(event);
            }
            for (Callback callback : getCallbackPostInvokers(EventType.ON_DROP, ObjectType.PERSISTENCE_GROUP, event.getPersistenceGroup().getName(), DEFAULT_SYSTEM)) {
                callback.invoke(event);
            }
        }
    }

    public void addPersistenceGroupDefinitionListener(PersistenceGroupDefinitionListener persistenceGroupDefinitionListener) throws UPAException {
        persistenceGroupDefinitionListeners.add(persistenceGroupDefinitionListener);
    }

    public void removePersistenceGroupDefinitionListener(PersistenceGroupDefinitionListener persistenceGroupDefinitionListener) throws UPAException {
        persistenceGroupDefinitionListeners.remove(persistenceGroupDefinitionListener);
    }

    public PersistenceGroupDefinitionListener[] getPersistenceGroupDefinitionListeners() {
        return persistenceGroupDefinitionListeners.toArray(new PersistenceGroupDefinitionListener[0]);
    }

//    public void fireOnClose(PersistenceUnitEvent event, EventPhase phase) {
//        if (phase == EventPhase.BEFORE) {
//            for (PersistenceUnitListener listener : persistenceUnitListeners) {
//                listener.onPreClose(event);
//            }
//            for (Callback invoker : getPreCallbacks(EventType.ON_CLOSE, AnyObjectType.PERSISTENCE_UNIT, event.getPersistenceUnit().getName(), DEFAULT_SYSTEM)) {
//                invoker.invoke(event);
//            }
//        } else {
//            for (PersistenceUnitListener listener : persistenceUnitListeners) {
//                listener.onClose(event);
//            }
//            for (Callback invoker : getPreCallbacks(EventType.ON_CLOSE, AnyObjectType.PERSISTENCE_UNIT, event.getPersistenceUnit().getName(), DEFAULT_SYSTEM)) {
//                invoker.invoke(event);
//            }
//        }
//    }
//    public void fireOnStart(PersistenceUnitEvent event, EventPhase phase) {
//        if (phase == EventPhase.BEFORE) {
//            for (PersistenceUnitListener listener : persistenceUnitListeners) {
//                listener.onPreStart(event);
//            }
//            for (Callback invoker : getPreCallbacks(EventType.ON_START, AnyObjectType.PERSISTENCE_UNIT, event.getPersistenceUnit().getName(), DEFAULT_SYSTEM)) {
//                invoker.invoke(event);
//            }
//        } else {
//            for (PersistenceUnitListener listener : persistenceUnitListeners) {
//                listener.onStart(event);
//            }
//            for (Callback invoker : getPreCallbacks(EventType.ON_START, AnyObjectType.PERSISTENCE_UNIT, event.getPersistenceUnit().getName(), DEFAULT_SYSTEM)) {
//                invoker.invoke(event);
//            }
//        }
//    }
    public CallbackManager getCallbackManager() {
        return callbackManager;
    }

    public void addCallback(Callback callback) {
        callbackManager.addCallback(callback);
    }

    public void removeCallback(Callback callback) {
        callbackManager.removeCallback(callback);
    }

//    public List<Callback> getCallbacks(EventType eventType, AnyObjectType objectType, String name, EventPhase phase, boolean system) {
//        List<Callback> allCallbacks = callbackManager.getCallbacks(eventType, objectType, name, phase, system);
//        allCallbacks.addAll(((DefaultPersistenceGroup) persistenceUnit.getPersistenceGroup()).getCallbacks(eventType, objectType, name, phase, system));
//        return allCallbacks;
//    }
    public List<Callback> getCallbackPreInvokers(EventType eventType, ObjectType objectType, String nameFilter, boolean system) {
        return getEffectiveCallbacks(eventType, objectType, nameFilter, system, false,EventPhase.BEFORE);
    }

    public List<Callback> getCallbackPostInvokers(EventType eventType, ObjectType objectType, String nameFilter, boolean system) {
        return getEffectiveCallbacks(eventType, objectType, nameFilter, system, false,EventPhase.AFTER);
    }

    public List<Callback> getEffectiveCallbacks(EventType eventType, ObjectType objectType, String nameFilter, boolean system,boolean preparedOnly, EventPhase phase) {
        return callbackManager.getCallbacks(eventType, objectType, nameFilter, system, preparedOnly,phase);
    }

    public List<Callback> getCallbacks(EventType eventType, ObjectType objectType, String nameFilter, boolean system,boolean preparedOnly, EventPhase phase) {
        return callbackManager.getCallbacks(eventType, objectType, nameFilter, system, preparedOnly,phase);
    }
}
