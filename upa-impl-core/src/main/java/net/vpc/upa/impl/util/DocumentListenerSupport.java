package net.vpc.upa.impl.util;

import net.vpc.upa.*;
import net.vpc.upa.callbacks.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.impl.DefaultTrigger;
import net.vpc.upa.persistence.EntityExecutionContext;

import java.util.logging.Level;
import java.util.logging.Logger;

import net.vpc.upa.impl.event.PersistenceUnitListenerManager;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/29/12 11:50 PM
 */
public class DocumentListenerSupport {

    protected final Logger log = Logger.getLogger(DocumentListenerSupport.class.getName());

//    private List<EntityListener> listeners;
    private Entity entity;
    private PersistenceUnitListenerManager persistenceUnitListenerManager;

    public DocumentListenerSupport(Entity entity, PersistenceUnitListenerManager persistenceUnitListenerManager) {
        this.entity = entity;
        this.persistenceUnitListenerManager = persistenceUnitListenerManager;
    }

    public void fireBeforePersist(Object objectId, Document document, EntityExecutionContext context) throws UPAException {
//        Object methodExecId = Math.random();
//        log.log(Level.FINE,"enter {} {}", new Object[]{key, document});
        //Log.method_enter(methodExecId, getName(), key, document);
//        entity.preInsertDocument(key, document, context);
        PersistEvent event = null;
        if (entity.getPersistenceUnit().isTriggersEnabled()) {
            for (Trigger et : entity.getSoftTriggers()) {
                DefaultTrigger t = (DefaultTrigger) et;
//                Log.log(EditorConstants.Logs.TRIGGER, "<START " + getName() + ".firePreInsertTable> " + t.toString());
                try {
                    EntityListener li = t.getListener();
                    if (event == null) {
                        event = new PersistEvent(objectId, document, context, EventPhase.BEFORE);
                    }
                    event.setTrigger(et);
                    li.onPrePersist(event);
                } catch (UPAException ex) {
                    //do some thing
                    log.log(Level.SEVERE, "problem when executing trigger " + t.getName() + ".onPrePersist(" + t.getEntity().getName() + "," + objectId + ")", ex);
//                    Log.bug(e);
                    throw ex;
                }
//                Log.log(EditorConstants.Logs.TRIGGER, "<END   " + getName() + ".firePreInsertTable> " + t.toString());
            }
        }
        if (event == null) {
            event = new PersistEvent(objectId, document, context, EventPhase.BEFORE);
        }
        for (Callback invoker : persistenceUnitListenerManager.getPreCallbacks(
                CallbackType.ON_PERSIST,
                ObjectType.ENTITY,
                event.getEntity().getName(), PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
            invoker.invoke(event);
        }
        for (PreparedCallback invoker : persistenceUnitListenerManager.getPostPreparedCallbacks(
                CallbackType.ON_PERSIST,
                ObjectType.ENTITY,
                event.getEntity().getName(), PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
            invoker.prepare(event);
        }

//        if (listeners != null && entity.getPersistenceUnit().isTriggersEnabled()) {
//            for (EntityListener t : listeners) {
//                if (event == null) {
//                    event = new PersistEvent(objectId, document, context);
//                }
//                try {
//                    t.onPrePersist(event);
//                } catch (Throwable e) {
//                    log.log(Level.SEVERE, "Error", e);
//                }
//            }
//        }
//        log.log(Level.FINE,"exit {} {}", new Object[]{key, document});
    }

    public void fireAfterPersist(Object objectId, Document document,
            EntityExecutionContext context) throws UPAException {
//        Object methodExecId = Math.random();
//        Log.method_enter(methodExecId, getName(), key, document);
//        entity.postInsertDocument(key, document, context);
        PersistEvent event = null;
        if (entity.getPersistenceUnit().isTriggersEnabled()) {
            for (Trigger et : entity.getSoftTriggers()) {
                DefaultTrigger t = (DefaultTrigger) et;
//                Log.log(EditorConstants.Logs.TRIGGER, "<START " + getName() + ".firePostInsertTable> " + t.toString());
                try {
                    EntityListener li = t.getListener();
                    if (event == null) {
                        event = new PersistEvent(objectId, document, context, EventPhase.AFTER);
                    }
                    event.setTrigger(et);
                    li.onPersist(event);
                } catch (UPAException e) {
                    log.log(Level.SEVERE, "problem when executing trigger " + t.getName() + ".onPersist(" + t.getEntity().getName() + "," + objectId + ")", e);
//                    Log.bug("19987", "problem when executing trigger " + t.getName() + ".entityInserted(" + getName() + "," + key + ")");
//                    Log.bug(e);
                    throw e;
                }
//                Log.log(EditorConstants.Logs.TRIGGER, "<END   " + getName() + ".firePostInsertTable> " + t.toString());
            }
        }
        if (event == null) {
            event = new PersistEvent(objectId, document, context, EventPhase.AFTER);
        }
        for (Callback invoker : persistenceUnitListenerManager.getPostCallbacks(
                CallbackType.ON_PERSIST,
                ObjectType.ENTITY,
                event.getEntity().getName(), PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
            invoker.invoke(event);
        }
//        if (listeners != null && entity.getPersistenceUnit().isTriggersEnabled()) {
//            for (EntityListener t : listeners) {
//                if (event == null) {
//                    event = new PersistEvent(objectId, document, context);
//                }
//                try {
//                    t.onPersist(event);
//                } catch (Throwable e) {
//                    log.log(Level.SEVERE, "Error", e);
//                }
//            }
//        }
//        Log.method_exit(methodExecId, getName(), key, document);
    }

    public void fireBeforeUpdate(Document updates, Expression condition,
                                 EntityExecutionContext context) throws UPAException {
//        Object methodExecId = Math.random();
//        Log.method_enter(methodExecId, getName(), updates, condition);
//        entity.preUpdateTable(updates, condition, context);
        UpdateEvent event = null;
        if (entity.getPersistenceUnit().isTriggersEnabled()) {
            for (Trigger et : entity.getSoftTriggers()) {
                DefaultTrigger t = (DefaultTrigger) et;
//                Log.log(EditorConstants.Logs.TRIGGER, "<START " + getName() + ".fireBeforeUpdate> " + t.toString());
                try {
                    EntityListener li = t.getListener();
                    if (event == null) {
                        event = new UpdateEvent(updates, condition, context, EventPhase.BEFORE);
                    }

                    li.onPreUpdate(event);
                } catch (UPAException e) {
                    log.log(Level.SEVERE, "problem when executing trigger " + t.getName() + ".onPreUpdate(" + t.getEntity().getName() + "," + condition + ")", e);
//                    Log.bug("19987", "problem when executing trigger " + t.getName() + ".beforeUpdate(" + getName() + "," + condition + ")");
//                    Log.bug(e);
                    throw e;
                }
//                Log.log(EditorConstants.Logs.TRIGGER, "<END   " + getName() + ".fireBeforeUpdate> " + t.toString());
            }
        }
        if (event == null) {
            event = new UpdateEvent(updates, condition, context, EventPhase.BEFORE);
        }
        for (Callback invoker : persistenceUnitListenerManager.getPreCallbacks(
                CallbackType.ON_UPDATE,
                ObjectType.ENTITY,
                event.getEntity().getName(), PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
            invoker.invoke(event);
        }
        for (PreparedCallback invoker : persistenceUnitListenerManager.getPostPreparedCallbacks(
                CallbackType.ON_UPDATE,
                ObjectType.ENTITY,
                event.getEntity().getName(), PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
            invoker.prepare(event);
        }
    }

    public void fireAfterUpdate(Document updates, Expression condition,
                                EntityExecutionContext context) throws UPAException {
//        Object methodExecId = Math.random();
//        Log.method_enter(methodExecId, getName(), updates, condition);
//        entity.postUpdateTable(updates, condition, context);
        UpdateEvent event = null;
        if (entity.getPersistenceUnit().isTriggersEnabled()) {
            for (Trigger et : entity.getSoftTriggers()) {
                DefaultTrigger t = (DefaultTrigger) et;
//                Log.log(EditorConstants.Logs.TRIGGER, "<START " + getName() + ".fireAfterUpdate> " + t.toString());
                try {
                    EntityListener li = t.getListener();
                    if (event == null) {
                        event = new UpdateEvent(updates, condition, context, EventPhase.AFTER);
                    }

                    li.onUpdate(event);
                } catch (UPAException e) {
                    log.log(Level.SEVERE, "problem when executing trigger " + t.getName() + ".onUpdate(" + t.getEntity().getName() + "," + condition + ")", e);
//                    Log.bug(e);
                    throw e;
                }
//                Log.log(EditorConstants.Logs.TRIGGER, "<END   " + getName() + ".fireAfterUpdate> " + t.toString());
            }
        }
        if (event == null) {
            event = new UpdateEvent(updates, condition, context, EventPhase.AFTER);
        }
        for (Callback invoker : persistenceUnitListenerManager.getPostCallbacks(
                CallbackType.ON_UPDATE,
                ObjectType.ENTITY,
                event.getEntity().getName(), PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
            invoker.invoke(event);
        }
    }

    public void fireBeforeRemove(Expression condition,
            EntityExecutionContext context) throws UPAException {
//        Object methodExecId = Math.random();
//        Log.method_enter(methodExecId, getName(), condition);
//        entity.preDeleteTable(condition, context);
        RemoveEvent event = null;
        if (entity.getPersistenceUnit().isTriggersEnabled()) {
            for (Trigger et : entity.getSoftTriggers()) {
                DefaultTrigger t = (DefaultTrigger) et;
//                Log.log(EditorConstants.Logs.TRIGGER, "<START " + getName() + ".fireBeforeRemove> " + t.toString());
                try {
                    EntityListener li = t.getListener();
                    if (event == null) {
                        event = new RemoveEvent(condition, context, EventPhase.BEFORE);
                    }

                    li.onPreRemove(event);

                } catch (UPAException e) {
                    log.log(Level.SEVERE, "problem when executing trigger " + t.getName() + ".onPreRemove(" + t.getEntity().getName() + "," + condition + ")", e);
//                    Log.bug(e);
                    throw e;
                }
//                Log.log(EditorConstants.Logs.TRIGGER, "<END   " + getName() + ".fireBeforeRemove> " + t.toString());
            }
        }
        if (event == null) {
            event = new RemoveEvent(condition, context, EventPhase.BEFORE);
        }
        for (Callback invoker : persistenceUnitListenerManager.getPreCallbacks(
                CallbackType.ON_REMOVE,
                ObjectType.ENTITY,
                event.getEntity().getName(), PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
            invoker.invoke(event);
        }
        for (PreparedCallback invoker : persistenceUnitListenerManager.getPostPreparedCallbacks(
                CallbackType.ON_REMOVE,
                ObjectType.ENTITY,
                event.getEntity().getName(), PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
            invoker.prepare(event);
        }
    }

    public void fireAfterRemove(Expression condition,
            EntityExecutionContext context) throws UPAException {
//        Object methodExecId = Math.random();
//        Log.method_enter(methodExecId, getName(), condition);
//        entity.postDeleteTable(condition, context);
        RemoveEvent event = null;
        if (entity.getPersistenceUnit().isTriggersEnabled()) {
            for (Trigger et : entity.getSoftTriggers()) {
                DefaultTrigger t = (DefaultTrigger) et;
//                Log.log(EditorConstants.Logs.TRIGGER, "<START " + getName() + ".fireAfterRemove> " + t.toString());
                try {
                    EntityListener li = t.getListener();
                    if (event == null) {
                        event = new RemoveEvent(condition, context, EventPhase.AFTER);
                    }

                    li.onRemove(event);
                } catch (UPAException ex) {
                    log.log(Level.SEVERE, "problem when executing trigger " + t.getName() + ".onPreRemove(" + t.getEntity().getName() + "," + condition + ")", ex);
//                    Log.bug(e);
                    throw ex;
                }
//                Log.log(EditorConstants.Logs.TRIGGER, "<END   " + getName() + ".fireAfterRemove> " + t.toString());
            }
        }
        if (event == null) {
            event = new RemoveEvent(condition, context, EventPhase.AFTER);
        }
        for (Callback invoker : persistenceUnitListenerManager.getPostCallbacks(
                CallbackType.ON_REMOVE,
                ObjectType.ENTITY,
                event.getEntity().getName(), PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
            invoker.invoke(event);
        }
    }

    public void fireBeforeFormulasUpdate(Document updates, Expression condition,
                                         EntityExecutionContext context) throws UPAException {
//        Object methodExecId = Math.random();
//        Log.method_enter(methodExecId, getName(), updates, condition);
//        entity.preUpdateTable(updates, condition, context);
        UpdateFormulaEvent event = null;
        if (entity.getPersistenceUnit().isTriggersEnabled()) {
            for (Trigger et : entity.getSoftTriggers()) {
                DefaultTrigger t = (DefaultTrigger) et;
//                Log.log(EditorConstants.Logs.TRIGGER, "<START " + getName() + ".fireBeforeUpdate> " + t.toString());
                try {
                    EntityListener li = t.getListener();
                    if (event == null) {
                        event = new UpdateFormulaEvent(updates, condition, context, EventPhase.BEFORE);
                    }

                    li.onPreUpdateFormula(event);

                } catch (UPAException ex) {
                    log.log(Level.SEVERE, "problem when executing trigger " + t.getName() + ".onPreUpdateFormula(" + t.getEntity().getName() + "," + condition + ")", ex);
//                    Log.bug("19987", "problem when executing trigger " + t.getName() + ".beforeUpdate(" + getName() + "," + condition + ")");
//                    Log.bug(e);
                    throw ex;
                }
//                Log.log(EditorConstants.Logs.TRIGGER, "<END   " + getName() + ".fireBeforeUpdate> " + t.toString());
            }
        }
        if (event == null) {
            event = new UpdateFormulaEvent(updates, condition, context, EventPhase.BEFORE);
        }
        for (Callback invoker : persistenceUnitListenerManager.getPreCallbacks(
                CallbackType.ON_UPDATE_FORMULAS,
                ObjectType.ENTITY,
                event.getEntity().getName(), PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
            invoker.invoke(event);
        }
        for (PreparedCallback invoker : persistenceUnitListenerManager.getPostPreparedCallbacks(
                CallbackType.ON_UPDATE_FORMULAS,
                ObjectType.ENTITY,
                event.getEntity().getName(), PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
            invoker.prepare(event);
        }
    }

    public void fireAfterFormulasUpdate(Document updates, Expression condition,
                                        EntityExecutionContext context) throws UPAException {
//        Object methodExecId = Math.random();
//        Log.method_enter(methodExecId, getName(), updates, condition);
//        entity.postUpdateTable(updates, condition, context);
        UpdateFormulaEvent event = null;
        if (entity.getPersistenceUnit().isTriggersEnabled()) {
            for (Trigger et : entity.getSoftTriggers()) {
                DefaultTrigger t = (DefaultTrigger) et;
//                Log.log(EditorConstants.Logs.TRIGGER, "<START " + getName() + ".fireAfterUpdate> " + t.toString());
                try {
                    EntityListener li = t.getListener();
                    if (event == null) {
                        event = new UpdateFormulaEvent(updates, condition, context, EventPhase.AFTER);
                    }

                    li.onUpdateFormula(event);
                } catch (UPAException ex) {
                    log.log(Level.SEVERE, "problem when executing trigger " + t.getName() + ".onUpdateFormula(" + t.getEntity().getName() + "," + condition + ")", ex);
//                    Log.bug(e);
                    throw ex;
                }
//                Log.log(EditorConstants.Logs.TRIGGER, "<END   " + getName() + ".fireAfterUpdate> " + t.toString());
            }
        }
        if (event == null) {
            event = new UpdateFormulaEvent(updates, condition, context, EventPhase.AFTER);
        }
        for (Callback invoker : persistenceUnitListenerManager.getPostCallbacks(
                CallbackType.ON_UPDATE_FORMULAS,
                ObjectType.ENTITY,
                event.getEntity().getName(), PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
            invoker.invoke(event);
        }
    }

    public void fireBeforeInitialize(EntityExecutionContext context) throws UPAException {
//        Object methodExecId = Math.random();
//        Log.method_enter(methodExecId, getName(), updates, condition);
//        entity.preUpdateTable(updates, condition, context);
        EntityEvent event = null;
        if (entity.getPersistenceUnit().isTriggersEnabled()) {
            for (Trigger et : entity.getSoftTriggers()) {
                DefaultTrigger t = (DefaultTrigger) et;
//                Log.log(EditorConstants.Logs.TRIGGER, "<START " + getName() + ".fireBeforeUpdate> " + t.toString());
                try {
                    EntityListener li = t.getListener();
                    if (event == null) {
                        event = new EntityEvent(context, EventPhase.BEFORE);
                    }

                    li.onPreInitialize(event);
                } catch (UPAException e) {
                    log.log(Level.SEVERE, "problem when executing trigger " + t.getName() + ".onPreInitialize(" + t.getEntity().getName() + ")", e);
//                    Log.bug(e);
                    throw e;
                }
//                Log.log(EditorConstants.Logs.TRIGGER, "<END   " + getName() + ".fireBeforeUpdate> " + t.toString());
            }
        }
        if (event == null) {
            event = new EntityEvent(context, EventPhase.BEFORE);
        }
        for (Callback callback : persistenceUnitListenerManager.getPreCallbacks(
                CallbackType.ON_INIT,
                ObjectType.ENTITY,
                event.getEntity().getName(), PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
            callback.invoke(event);
        }
        for (PreparedCallback callback : persistenceUnitListenerManager.getPostPreparedCallbacks(
                CallbackType.ON_INIT,
                ObjectType.ENTITY,
                event.getEntity().getName(), PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
            callback.prepare(event);
        }

//        EntityEvent evt = new EntityEvent(entity, entity.getPersistenceUnit(), entity.getParent(), position, null, -1, phase);
//        String entityTypeListenerId = getEntityTypeListenerId(entity.getEntityType());
//        boolean system = entity.getUserModifiers().contains(EntityModifier.SYSTEM);
//        if (phase == EventPhase.BEFORE) {
//            for (EntityDefinitionListener listener : entities.getAllListeners(system, entity.getName(), entityTypeListenerId)) {
//                listener.onPrePrepareEntity(evt);
//            }
//            for (Callback callback : getPreCallbacks(CallbackType.ON_INIT, ObjectType.ENTITY, entity.getName(), system)) {
//                callback.invoke(evt);
//            }
//            for (PreparedCallback callback : getPostPreparedCallbacks(CallbackType.ON_INIT, ObjectType.ENTITY, entity.getName(), system)) {
//                callback.prepare(evt);
//            }
//        } else {
//            for (EntityDefinitionListener listener : entities.getAllListeners(system, entity.getName(), entityTypeListenerId)) {
//                listener.onPrepareEntity(evt);
//            }
//            for (Callback callback : getPostCallbacks(CallbackType.ON_INIT, ObjectType.ENTITY, entity.getName(), system)) {
//                callback.invoke(evt);
//            }
//        }


    }

    public void fireAfterInitialize(EntityExecutionContext context) throws UPAException {
//        Object methodExecId = Math.random();
//        Log.method_enter(methodExecId, getName(), updates, condition);
//        entity.postUpdateTable(updates, condition, context);
        EntityEvent event = null;
        if (entity.getPersistenceUnit().isTriggersEnabled()) {
            for (Trigger et : entity.getSoftTriggers()) {
                DefaultTrigger t = (DefaultTrigger) et;
//                Log.log(EditorConstants.Logs.TRIGGER, "<START " + getName() + ".fireAfterUpdate> " + t.toString());
                try {
                    EntityListener li = t.getListener();
                    if (event == null) {
                        event = new EntityEvent(context, EventPhase.AFTER);
                    }

                    li.onInitialize(event);
                } catch (UPAException e) {
                    log.log(Level.SEVERE, "problem when executing trigger " + t.getName() + ".onInitialize(" + t.getEntity().getName() + ")", e);
//                    Log.bug(e);
                    throw e;
                }
//                Log.log(EditorConstants.Logs.TRIGGER, "<END   " + getName() + ".fireAfterUpdate> " + t.toString());
            }
        }
        if (event == null) {
            event = new EntityEvent(context, EventPhase.AFTER);
        }
        for (Callback invoker : persistenceUnitListenerManager.getPostCallbacks(
                CallbackType.ON_INIT,
                ObjectType.ENTITY,
                event.getEntity().getName(), PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
            invoker.invoke(event);
        }
    }

    public void fireBeforeClear(EntityExecutionContext context) throws UPAException {
//        Object methodExecId = Math.random();
//        Log.method_enter(methodExecId, getName(), updates, condition);
//        entity.preUpdateTable(updates, condition, context);
        EntityEvent event = null;
        if (entity.getPersistenceUnit().isTriggersEnabled()) {
            for (Trigger et : entity.getSoftTriggers()) {
                DefaultTrigger t = (DefaultTrigger) et;
//                Log.log(EditorConstants.Logs.TRIGGER, "<START " + getName() + ".fireBeforeUpdate> " + t.toString());
                try {
                    EntityListener li = t.getListener();
                    if (event == null) {
                        event = new EntityEvent(context, EventPhase.BEFORE);
                    }

                    li.onPreClear(event);
                } catch (UPAException e) {
                    log.log(Level.SEVERE, "problem when executing trigger " + t.getName() + ".onPreClear(" + t.getEntity().getName() + ")", e);
//                    Log.bug(e);
                    throw e;
                }
//                Log.log(EditorConstants.Logs.TRIGGER, "<END   " + getName() + ".fireBeforeUpdate> " + t.toString());
            }
        }
        if (event == null) {
            event = new EntityEvent(context, EventPhase.BEFORE);
        }
        for (Callback invoker : persistenceUnitListenerManager.getPreCallbacks(
                CallbackType.ON_CLEAR,
                ObjectType.ENTITY,
                event.getEntity().getName(), PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
            invoker.invoke(event);
        }
        for (PreparedCallback invoker : persistenceUnitListenerManager.getPostPreparedCallbacks(
                CallbackType.ON_CLEAR,
                ObjectType.ENTITY,
                event.getEntity().getName(), PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
            invoker.invoke(event);
        }
    }

    public void fireAfterClear(EntityExecutionContext context) throws UPAException {
        EntityEvent event = null;
        Object methodExecId = Math.random();
//        Log.method_enter(methodExecId, getName(), updates, condition);
//        entity.postUpdateTable(updates, condition, context);
        if (entity.getPersistenceUnit().isTriggersEnabled()) {
            for (Trigger et : entity.getSoftTriggers()) {
                DefaultTrigger t = (DefaultTrigger) et;
//                Log.log(EditorConstants.Logs.TRIGGER, "<START " + getName() + ".fireAfterUpdate> " + t.toString());
                try {
                    EntityListener li = t.getListener();
                    if (event == null) {
                        event = new EntityEvent(context, EventPhase.AFTER);
                    }

                    li.onClear(event);
                } catch (UPAException e) {
                    log.log(Level.SEVERE, "problem when executing trigger " + t.getName() + ".onClear(" + t.getEntity().getName() + ")", e);
//                    Log.bug(e);
                    throw e;
                }
//                Log.log(EditorConstants.Logs.TRIGGER, "<END   " + getName() + ".fireAfterUpdate> " + t.toString());
            }
        }
        if (event == null) {
            event = new EntityEvent(context, EventPhase.AFTER);
        }
        for (Callback invoker : persistenceUnitListenerManager.getPostCallbacks(
                CallbackType.ON_CLEAR,
                ObjectType.ENTITY,
                event.getEntity().getName(), PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
            invoker.invoke(event);
        }
    }

    public void fireBeforeReset(EntityExecutionContext context) throws UPAException {
        EntityEvent event = null;
        Object methodExecId = Math.random();
//        Log.method_enter(methodExecId, getName(), updates, condition);
//        entity.preUpdateTable(updates, condition, context);
        if (entity.getPersistenceUnit().isTriggersEnabled()) {
            for (Trigger et : entity.getSoftTriggers()) {
                DefaultTrigger t = (DefaultTrigger) et;
//                Log.log(EditorConstants.Logs.TRIGGER, "<START " + getName() + ".fireBeforeUpdate> " + t.toString());
                try {
                    EntityListener li = t.getListener();
                    if (event == null) {
                        event = new EntityEvent(context, EventPhase.BEFORE);
                    }

                    li.onPreReset(event);
                } catch (UPAException e) {
                    log.log(Level.SEVERE, "problem when executing trigger " + t.getName() + ".onPreReset(" + t.getEntity().getName() + ")", e);
//                    Log.bug(e);
                    throw e;
                }
//                Log.log(EditorConstants.Logs.TRIGGER, "<END   " + getName() + ".fireBeforeUpdate> " + t.toString());
            }
        }
        if (event == null) {
            event = new EntityEvent(context, EventPhase.BEFORE);
        }
        for (Callback invoker : persistenceUnitListenerManager.getPreCallbacks(
                CallbackType.ON_RESET,
                ObjectType.ENTITY,
                event.getEntity().getName(), PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
            invoker.invoke(event);
        }
        for (PreparedCallback invoker : persistenceUnitListenerManager.getPostPreparedCallbacks(
                CallbackType.ON_RESET,
                ObjectType.ENTITY,
                event.getEntity().getName(), PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
            invoker.prepare(event);
        }
    }

    public void fireAfterReset(EntityExecutionContext context) throws UPAException {
        EntityEvent event = null;
        Object methodExecId = Math.random();
//        Log.method_enter(methodExecId, getName(), updates, condition);
//        entity.postUpdateTable(updates, condition, context);
        if (entity.getPersistenceUnit().isTriggersEnabled()) {
            for (Trigger et : entity.getSoftTriggers()) {
                DefaultTrigger t = (DefaultTrigger) et;
//                Log.log(EditorConstants.Logs.TRIGGER, "<START " + getName() + ".fireAfterUpdate> " + t.toString());
                try {
                    EntityListener li = t.getListener();
                    if (event == null) {
                        event = new EntityEvent(context, EventPhase.AFTER);
                    }

                    li.onReset(event);
                } catch (UPAException e) {
                    log.log(Level.SEVERE, "problem when executing trigger " + t.getName() + ".onReset(" + t.getEntity().getName() + ")", e);
//                    Log.bug(e);
                    throw e;
                }
//                Log.log(EditorConstants.Logs.TRIGGER, "<END   " + getName() + ".fireAfterUpdate> " + t.toString());
            }
        }
        if (event == null) {
            event = new EntityEvent(context, EventPhase.AFTER);
        }
        for (Callback invoker : persistenceUnitListenerManager.getPostCallbacks(
                CallbackType.ON_RESET,
                ObjectType.ENTITY,
                event.getEntity().getName(), PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
            invoker.invoke(event);
        }
    }

}
