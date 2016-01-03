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

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/29/12 11:50 PM
 */
public class RecordListenerSupport {

    protected final Logger log = Logger.getLogger(RecordListenerSupport.class.getName());

//    private List<EntityListener> listeners;
    private Entity entity;

    public RecordListenerSupport(Entity entity) {
        this.entity = entity;
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
                        event = new PersistEvent(objectId, record, context);
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
                        event = new PersistEvent(objectId, record, context);
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
                        event = new UpdateEvent(updates, condition, context);
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
//        if (listeners != null && entity.getPersistenceUnit().isTriggersEnabled()) {
//            for (EntityListener t : listeners) {
//                if (event == null) {
//                    event = new UpdateEvent(updates, condition, context);
//                }
//                try {
//                    t.onPreUpdate(event);
//                } catch (Exception e) {
//                    log.log(Level.SEVERE, "Error", e);
//                }
//            }
//        }
//        Log.method_exit(methodExecId, getName(), updates, condition);
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
                        event = new UpdateEvent(updates, condition, context);
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
//        if (listeners != null && entity.getPersistenceUnit().isTriggersEnabled()) {
//            if (event == null) {
//                event = new UpdateEvent(updates, condition, context);
//            }
//            for (EntityListener t : listeners) {
//                try {
//                    t.onUpdate(event);
//                } catch (Exception e) {
//                    log.log(Level.SEVERE, "Error", e);
//                }
//            }
//        }
//        Log.method_exit(methodExecId, getName(), updates, condition);
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
                        event = new RemoveEvent(condition, context);
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
//        if (listeners != null && entity.getPersistenceUnit().isTriggersEnabled()) {
//            if (event == null) {
//                event = new RemoveEvent(condition, context);
//            }
//            for (EntityListener t : listeners) {
//                try {
//                    t.onPreRemove(event);
//                } catch (Exception e) {
//                    log.log(Level.SEVERE, "Error", e);
//                }
//            }
//        }
//        Log.method_exit(methodExecId, getName(), condition);
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
                        event = new RemoveEvent(condition, context);
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
//        if (listeners != null && entity.getPersistenceUnit().isTriggersEnabled()) {
//            if (event == null) {
//                event = new RemoveEvent(condition, context);
//            }
//            for (EntityListener t : listeners) {
//                try {
//                    t.onRemove(event);
//                } catch (Exception e) {
//                    log.log(Level.SEVERE, "Error", e);
//                }
//            }
//        }
//        Log.method_exit(methodExecId, getName(), condition);
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
                        event = new UpdateFormulaEvent(updates, condition, context);
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
//        if (listeners != null && entity.getPersistenceUnit().isTriggersEnabled()) {
//            if (event == null) {
//                event = new UpdateFormulaEvent(updates, condition, context);
//            }
//            for (EntityListener t : listeners) {
//                try {
//                    t.onPreUpdateFormula(event);
//                } catch (Exception e) {
//                    log.log(Level.SEVERE, "Error", e);
//                }
//            }
//        }
//        Log.method_exit(methodExecId, getName(), updates, condition);
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
                        event = new UpdateFormulaEvent(updates, condition, context);
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
//        if (listeners != null && entity.getPersistenceUnit().isTriggersEnabled()) {
//            if (event == null) {
//                event = new UpdateFormulaEvent(updates, condition, context);
//            }
//            for (EntityListener t : listeners) {
//                try {
//                    t.onUpdateFormula(event);
//                } catch (Exception e) {
//                    log.log(Level.SEVERE, "Error", e);
//                }
//            }
//        }
//        Log.method_exit(methodExecId, getName(), updates, condition);
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
                        event = new EntityEvent(context);
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
//        if (listeners != null && entity.getPersistenceUnit().isTriggersEnabled()) {
//            if (event == null) {
//                event = new EntityEvent(context);
//            }
//            for (EntityListener t : listeners) {
//                try {
//                    t.onPreInitialize(event);
//                } catch (Exception e) {
//                    log.log(Level.SEVERE, "Error", e);
//                }
//            }
//        }
//        Log.method_exit(methodExecId, getName(), updates, condition);
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
                        event = new EntityEvent(context);
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
//        if (listeners != null && entity.getPersistenceUnit().isTriggersEnabled()) {
//            if (event == null) {
//                event = new EntityEvent(context);
//            }
//            for (EntityListener t : listeners) {
//                try {
//                    t.onInitialize(event);
//                } catch (Exception e) {
//                    log.log(Level.SEVERE, "Error", e);
//                }
//            }
//        }
//        Log.method_exit(methodExecId, getName(), updates, condition);
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
                        event = new EntityEvent(context);
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
//        if (listeners != null && entity.getPersistenceUnit().isTriggersEnabled()) {
//            if (event == null) {
//                event = new EntityEvent(context);
//            }
//            for (EntityListener t : listeners) {
//                try {
//                    t.onPreClear(event);
//                } catch (Exception e) {
//                    log.log(Level.SEVERE, "Error", e);
//                }
//            }
//        }
//        Log.method_exit(methodExecId, getName(), updates, condition);
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
                        event = new EntityEvent(context);
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
//        if (listeners != null && entity.getPersistenceUnit().isTriggersEnabled()) {
//            if (event == null) {
//                event = new EntityEvent(context);
//            }
//            for (EntityListener t : listeners) {
//                try {
//                    t.onClear(event);
//                } catch (Exception e) {
//                    log.log(Level.SEVERE, "Error", e);
//                }
//            }
//        }
//        Log.method_exit(methodExecId, getName(), updates, condition);
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
                        event = new EntityEvent(context);
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
//        if (listeners != null && entity.getPersistenceUnit().isTriggersEnabled()) {
//            if (event == null) {
//                event = new EntityEvent(context);
//            }
//            for (EntityListener t : listeners) {
//                try {
//                    t.onPreReset(event);
//                } catch (Exception e) {
//                    log.log(Level.SEVERE, "Error", e);
//                }
//            }
//        }
//        Log.method_exit(methodExecId, getName(), updates, condition);
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
                        event = new EntityEvent(context);
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
//        if (listeners != null && entity.getPersistenceUnit().isTriggersEnabled()) {
//            if (event == null) {
//                event = new EntityEvent(context);
//            }
//            for (EntityListener t : listeners) {
//                try {
//                    t.onReset(event);
//                } catch (Exception e) {
//                    log.log(Level.SEVERE, "Error", e);
//                }
//            }
//        }
//        Log.method_exit(methodExecId, getName(), updates, condition);
    }

//    public void addEntityListener(EntityListener listener) {
//        if (listeners == null) {
//            listeners = new ArrayList<EntityListener>(5);
//        }
//        listeners.add(listener);
//    }
//
//    public void removeEntityListener(EntityListener listener) {
//        if (listeners != null) {
//            listeners.remove(listener);
//        }
//    }
}
