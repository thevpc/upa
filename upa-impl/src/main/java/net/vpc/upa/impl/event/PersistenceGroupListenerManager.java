package net.vpc.upa.impl.event;

import net.vpc.upa.*;
import net.vpc.upa.callbacks.PersistenceUnitDefinitionListener;
import net.vpc.upa.callbacks.PersistenceUnitEvent;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.util.CallbackManager;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/27/12 9:07 PM
 */
public class PersistenceGroupListenerManager {

    private static final Logger log = Logger.getLogger(PersistenceGroupListenerManager.class.getName());

    private PersistenceGroup group;
    private CallbackManager callbackManager = new CallbackManager();
    private static boolean DEFAULT_SYSTEM = false;
    private final List<PersistenceUnitDefinitionListener> persistenceUnitDefinitionListeners = new ArrayList<PersistenceUnitDefinitionListener>();

    public PersistenceGroupListenerManager(PersistenceGroup group) {
        this.group = group;
    }

    public void fireOnCreatePersistenceUnit(PersistenceUnitEvent event) {
        EventPhase phase=event.getPhase();
        PersistenceUnitDefinitionListener[] interceptorList = getPersistenceUnitDefinitionListeners();
        if (phase == EventPhase.BEFORE) {
            for (PersistenceUnitDefinitionListener listener : interceptorList) {
                listener.onPreCreatePersistenceUnit(event);
            }
            for (Callback callback : getCallbackPreInvokers(CallbackType.ON_CREATE, ObjectType.PERSISTENCE_UNIT, event.getPersistenceGroup().getName(), DEFAULT_SYSTEM)) {
                callback.invoke(event);
            }
        } else {
            for (PersistenceUnitDefinitionListener listener : interceptorList) {
                listener.onCreatePersistenceUnit(event);
            }
            for (Callback callback : getCallbackPostInvokers(CallbackType.ON_CREATE, ObjectType.PERSISTENCE_UNIT, event.getPersistenceGroup().getName(), DEFAULT_SYSTEM)) {
                callback.invoke(event);
            }
        }
    }

    public void fireOnDropPersistenceUnit(PersistenceUnitEvent event) {
        EventPhase phase=event.getPhase();
        PersistenceUnitDefinitionListener[] interceptorList = getPersistenceUnitDefinitionListeners();
        if (phase == EventPhase.BEFORE) {
            for (PersistenceUnitDefinitionListener listener : interceptorList) {
                listener.onPreDropPersistenceUnit(event);
            }
            for (Callback callback : getCallbackPreInvokers(CallbackType.ON_DROP, ObjectType.PERSISTENCE_GROUP, event.getPersistenceGroup().getName(), DEFAULT_SYSTEM)) {
                callback.invoke(event);
            }
        } else {
            for (PersistenceUnitDefinitionListener listener : interceptorList) {
                listener.onDropPersistenceUnit(event);
            }
            for (Callback callback : getCallbackPostInvokers(CallbackType.ON_DROP, ObjectType.PERSISTENCE_GROUP, event.getPersistenceGroup().getName(), DEFAULT_SYSTEM)) {
                callback.invoke(event);
            }
        }
    }

    public void addPersistenceUnitDefinitionListener(PersistenceUnitDefinitionListener persistenceUnitDefinitionListener) throws UPAException {
        persistenceUnitDefinitionListeners.add(persistenceUnitDefinitionListener);
    }

    public void removePersistenceUnitDefinitionListener(PersistenceUnitDefinitionListener persistenceUnitDefinitionListener) throws UPAException {
        persistenceUnitDefinitionListeners.remove(persistenceUnitDefinitionListener);
    }

    public PersistenceUnitDefinitionListener[] getPersistenceUnitDefinitionListeners() {
        return persistenceUnitDefinitionListeners.toArray(new PersistenceUnitDefinitionListener[persistenceUnitDefinitionListeners.size()]);
    }

//    public void fireOnClose(PersistenceUnitEvent event, EventPhase phase) {
//        if (phase == EventPhase.BEFORE) {
//            for (PersistenceUnitListener listener : persistenceUnitListeners) {
//                listener.onPreClose(event);
//            }
//            for (Callback invoker : getPreCallbacks(CallbackType.ON_CLOSE, AnyObjectType.PERSISTENCE_UNIT, event.getPersistenceUnit().getName(), DEFAULT_SYSTEM)) {
//                invoker.invoke(event);
//            }
//        } else {
//            for (PersistenceUnitListener listener : persistenceUnitListeners) {
//                listener.onClose(event);
//            }
//            for (Callback invoker : getPreCallbacks(CallbackType.ON_CLOSE, AnyObjectType.PERSISTENCE_UNIT, event.getPersistenceUnit().getName(), DEFAULT_SYSTEM)) {
//                invoker.invoke(event);
//            }
//        }
//    }
//    public void fireOnStart(PersistenceUnitEvent event, EventPhase phase) {
//        if (phase == EventPhase.BEFORE) {
//            for (PersistenceUnitListener listener : persistenceUnitListeners) {
//                listener.onPreStart(event);
//            }
//            for (Callback invoker : getPreCallbacks(CallbackType.ON_START, AnyObjectType.PERSISTENCE_UNIT, event.getPersistenceUnit().getName(), DEFAULT_SYSTEM)) {
//                invoker.invoke(event);
//            }
//        } else {
//            for (PersistenceUnitListener listener : persistenceUnitListeners) {
//                listener.onStart(event);
//            }
//            for (Callback invoker : getPreCallbacks(CallbackType.ON_START, AnyObjectType.PERSISTENCE_UNIT, event.getPersistenceUnit().getName(), DEFAULT_SYSTEM)) {
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

//    public List<Callback> getCallbacks(CallbackType callbackType, AnyObjectType objectType, String name, EventPhase phase, boolean system) {
//        List<Callback> allCallbacks = callbackManager.getCallbacks(callbackType, objectType, name, phase, system);
//        allCallbacks.addAll(((DefaultPersistenceGroup) persistenceUnit.getPersistenceGroup()).getCallbacks(callbackType, objectType, name, phase, system));
//        return allCallbacks;
//    }
    public List<Callback> getCallbackPreInvokers(CallbackType callbackType, ObjectType objectType, String nameFilter, boolean system) {
        return getCallbackEffectiveInvokers(callbackType, objectType, nameFilter, system, EventPhase.BEFORE);
    }

    public List<Callback> getCallbackPostInvokers(CallbackType callbackType, ObjectType objectType, String nameFilter, boolean system) {
        return getCallbackEffectiveInvokers(callbackType, objectType, nameFilter, system, EventPhase.AFTER);
    }

    public List<Callback> getCallbackEffectiveInvokers(CallbackType callbackType, ObjectType objectType, String nameFilter, boolean system, EventPhase phase) {
        List<Callback> allCallbacks = callbackManager.getCallbacks(callbackType, objectType, nameFilter, system, false,phase);
        allCallbacks.addAll(Arrays.asList(group.getContext().getCallbacks(callbackType, objectType, nameFilter, system, false, phase)));
        return allCallbacks;
    }

    public List<Callback> getCallbacks(CallbackType callbackType, ObjectType objectType, String nameFilter, boolean system, boolean preparedOnly, EventPhase phase) {
        return callbackManager.getCallbacks(callbackType, objectType, nameFilter, system,preparedOnly, phase);
    }

}
