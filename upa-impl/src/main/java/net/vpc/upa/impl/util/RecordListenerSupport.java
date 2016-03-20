package net.vpc.upa.impl.util;

import net.vpc.upa.callbacks.EntityListener;
import net.vpc.upa.callbacks.EntityEvent;
import net.vpc.upa.callbacks.UpdateEvent;
import net.vpc.upa.callbacks.PersistEvent;
import net.vpc.upa.callbacks.UpdateFormulaEvent;
import net.vpc.upa.callbacks.RemoveEvent;
import net.vpc.upa.Entity;
import net.vpc.upa.Record;
import net.vpc.upa.callbacks.Trigger;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.impl.DefaultTrigger;
import net.vpc.upa.persistence.EntityExecutionContext;

import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.Callback;
import net.vpc.upa.CallbackType;
import net.vpc.upa.EventPhase;
import net.vpc.upa.ObjectType;
import net.vpc.upa.impl.event.PersistenceUnitListenerManager;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/29/12 11:50 PM
 */
public class RecordListenerSupport {

    protected final Logger log = Logger.getLogger(RecordListenerSupport.class.getName());

//    private List<EntityListener> listeners;
    private Entity entity;
    private PersistenceUnitListenerManager persistenceUnitListenerManager;

    public RecordListenerSupport(Entity entity, PersistenceUnitListenerManager persistenceUnitListenerManager) {
        this.entity = entity;
        this.persistenceUnitListenerManager = persistenceUnitListenerManager;
    }

    public void fireBeforePersist(Object objectId, Record record, EntityExecutionContext context) throws UPAException {
//        Object methodExecId = Math.random();
//        log.log(Level.FINE,"enter {} {}", new Object[]{key, record});
        //Log.method_enter(methodExecId, getName(), key, record);
//        entity.preInsertRecord(key, record, context);
        PersistEvent event = null;
        if (entity.getPersistenceUnit().isTriggersEnabled()) {
            for (Trigger et : entity.getSoftTriggers()) {
                DefaultTrigger t = (DefaultTrigger) et;
//                Log.log(EditorConstants.Logs.TRIGGER, "<START " + getName() + ".firePreInsertTable> " + t.toString());
                try {
                    EntityListener li = t.getListener();
                    if (event == null) {
                        event = new PersistEvent(objectId, record, context, EventPhase.BEFORE);
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
            event = new PersistEvent(objectId, record, context, EventPhase.BEFORE);
        }
        for (Callback invoker : persistenceUnitListenerManager.getCallbackPreInvokers(
                CallbackType.ON_PRE_PERSIST,
                ObjectType.ENTITY,
                event.getEntity().getName(), PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
            invoker.invoke(event);
        }

//        if (listeners != null && entity.getPersistenceUnit().isTriggersEnabled()) {
//            for (EntityListener t : listeners) {
//                if (event == null) {
//                    event = new PersistEvent(objectId, record, context);
//                }
//                try {
//                    t.onPrePersist(event);
//                } catch (Throwable e) {
//                    log.log(Level.SEVERE, "Error", e);
//                }
//            }
//        }
//        log.log(Level.FINE,"exit {} {}", new Object[]{key, record});
    }

    public void fireAfterPersist(Object objectId, Record record,
            EntityExecutionContext context) throws UPAException {
//        Object methodExecId = Math.random();
//        Log.method_enter(methodExecId, getName(), key, record);
//        entity.postInsertRecord(key, record, context);
        PersistEvent event = null;
        if (entity.getPersistenceUnit().isTriggersEnabled()) {
            for (Trigger et : entity.getSoftTriggers()) {
                DefaultTrigger t = (DefaultTrigger) et;
//                Log.log(EditorConstants.Logs.TRIGGER, "<START " + getName() + ".firePostInsertTable> " + t.toString());
                try {
                    EntityListener li = t.getListener();
                    if (event == null) {
                        event = new PersistEvent(objectId, record, context, EventPhase.AFTER);
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
            event = new PersistEvent(objectId, record, context, EventPhase.AFTER);
        }
        for (Callback invoker : persistenceUnitListenerManager.getCallbackPostInvokers(
                CallbackType.ON_PERSIST,
                ObjectType.ENTITY,
                event.getEntity().getName(), PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
            invoker.invoke(event);
        }
//        if (listeners != null && entity.getPersistenceUnit().isTriggersEnabled()) {
//            for (EntityListener t : listeners) {
//                if (event == null) {
//                    event = new PersistEvent(objectId, record, context);
//                }
//                try {
//                    t.onPersist(event);
//                } catch (Throwable e) {
//                    log.log(Level.SEVERE, "Error", e);
//                }
//            }
//        }
//        Log.method_exit(methodExecId, getName(), key, record);
    }

    public void fireBeforeUpdate(Record updates, Expression condition,
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
        for (Callback invoker : persistenceUnitListenerManager.getCallbackPreInvokers(
                CallbackType.ON_PRE_UPDATE,
                ObjectType.ENTITY,
                event.getEntity().getName(), PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
            invoker.invoke(event);
        }
    }

    public void fireAfterUpdate(Record updates, Expression condition,
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
        for (Callback invoker : persistenceUnitListenerManager.getCallbackPostInvokers(
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
        for (Callback invoker : persistenceUnitListenerManager.getCallbackPreInvokers(
                CallbackType.ON_PRE_REMOVE,
                ObjectType.ENTITY,
                event.getEntity().getName(), PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
            invoker.invoke(event);
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
        for (Callback invoker : persistenceUnitListenerManager.getCallbackPostInvokers(
                CallbackType.ON_REMOVE,
                ObjectType.ENTITY,
                event.getEntity().getName(), PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
            invoker.invoke(event);
        }
    }

    public void fireBeforeFormulasUpdate(Record updates, Expression condition,
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
        for (Callback invoker : persistenceUnitListenerManager.getCallbackPreInvokers(
                CallbackType.ON_PRE_UPDATE_FORMULAS,
                ObjectType.ENTITY,
                event.getEntity().getName(), PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
            invoker.invoke(event);
        }
    }

    public void fireAfterFormulasUpdate(Record updates, Expression condition,
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
        for (Callback invoker : persistenceUnitListenerManager.getCallbackPostInvokers(
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
        for (Callback invoker : persistenceUnitListenerManager.getCallbackPreInvokers(
                CallbackType.ON_PRE_INITIALIZE,
                ObjectType.ENTITY,
                event.getEntity().getName(), PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
            invoker.invoke(event);
        }
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
        for (Callback invoker : persistenceUnitListenerManager.getCallbackPostInvokers(
                CallbackType.ON_INITIALIZE,
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
        for (Callback invoker : persistenceUnitListenerManager.getCallbackPreInvokers(
                CallbackType.ON_PRE_CLEAR,
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
        for (Callback invoker : persistenceUnitListenerManager.getCallbackPostInvokers(
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
        for (Callback invoker : persistenceUnitListenerManager.getCallbackPreInvokers(
                CallbackType.ON_PRE_RESET,
                ObjectType.ENTITY,
                event.getEntity().getName(), PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
            invoker.invoke(event);
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
        for (Callback invoker : persistenceUnitListenerManager.getCallbackPostInvokers(
                CallbackType.ON_RESET,
                ObjectType.ENTITY,
                event.getEntity().getName(), PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
            invoker.invoke(event);
        }
    }

}
