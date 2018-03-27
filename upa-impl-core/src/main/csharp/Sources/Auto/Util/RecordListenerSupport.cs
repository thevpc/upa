/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE AS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa.Impl.Util
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/29/12 11:50 PM
     */
    public class RecordListenerSupport {

        protected internal readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Util.RecordListenerSupport)).FullName);

        private Net.Vpc.Upa.Entity entity;

        private Net.Vpc.Upa.Impl.Event.PersistenceUnitListenerManager persistenceUnitListenerManager;

        public RecordListenerSupport(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Impl.Event.PersistenceUnitListenerManager persistenceUnitListenerManager) {
            this.entity = entity;
            this.persistenceUnitListenerManager = persistenceUnitListenerManager;
        }

        public virtual void FireBeforePersist(object objectId, Net.Vpc.Upa.Record record, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            //        Object methodExecId = Math.random();
            //        log.log(Level.FINE,"enter {} {}", new Object[]{key, record});
            //Log.method_enter(methodExecId, getName(), key, record);
            //        entity.preInsertRecord(key, record, context);
            Net.Vpc.Upa.Callbacks.PersistEvent @event = null;
            if (entity.GetPersistenceUnit().IsTriggersEnabled()) {
                foreach (Net.Vpc.Upa.Callbacks.Trigger et in entity.GetSoftTriggers()) {
                    Net.Vpc.Upa.Impl.DefaultTrigger t = (Net.Vpc.Upa.Impl.DefaultTrigger) et;
                    //                Log.log(EditorConstants.Logs.TRIGGER, "<START " + getName() + ".firePreInsertTable> " + t.toString());
                    try {
                        Net.Vpc.Upa.Callbacks.EntityListener li = t.GetListener();
                        if (@event == null) {
                            @event = new Net.Vpc.Upa.Callbacks.PersistEvent(objectId, record, context, Net.Vpc.Upa.EventPhase.BEFORE);
                        }
                        @event.SetTrigger(et);
                        li.OnPrePersist(@event);
                    } catch (Net.Vpc.Upa.Exceptions.UPAException ex) {
                        //do some thing
                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("problem when executing trigger " + t.GetName() + ".onPrePersist(" + t.GetEntity().GetName() + "," + objectId + ")",ex));
                        //                    Log.bug(e);
                        throw ex;
                    }
                }
            }
            //                Log.log(EditorConstants.Logs.TRIGGER, "<END   " + getName() + ".firePreInsertTable> " + t.toString());
            if (@event == null) {
                @event = new Net.Vpc.Upa.Callbacks.PersistEvent(objectId, record, context, Net.Vpc.Upa.EventPhase.BEFORE);
            }
            foreach (Net.Vpc.Upa.Callback invoker in persistenceUnitListenerManager.GetPreCallbacks(Net.Vpc.Upa.CallbackType.ON_PERSIST, Net.Vpc.Upa.ObjectType.ENTITY, @event.GetEntity().GetName(), Net.Vpc.Upa.Impl.Event.PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
                invoker.Invoke(@event);
            }
            foreach (Net.Vpc.Upa.PreparedCallback invoker in persistenceUnitListenerManager.GetPostPreparedCallbacks(Net.Vpc.Upa.CallbackType.ON_PERSIST, Net.Vpc.Upa.ObjectType.ENTITY, @event.GetEntity().GetName(), Net.Vpc.Upa.Impl.Event.PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
                invoker.Prepare(@event);
            }
        }

        public virtual void FireAfterPersist(object objectId, Net.Vpc.Upa.Record record, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            //        Object methodExecId = Math.random();
            //        Log.method_enter(methodExecId, getName(), key, record);
            //        entity.postInsertRecord(key, record, context);
            Net.Vpc.Upa.Callbacks.PersistEvent @event = null;
            if (entity.GetPersistenceUnit().IsTriggersEnabled()) {
                foreach (Net.Vpc.Upa.Callbacks.Trigger et in entity.GetSoftTriggers()) {
                    Net.Vpc.Upa.Impl.DefaultTrigger t = (Net.Vpc.Upa.Impl.DefaultTrigger) et;
                    //                Log.log(EditorConstants.Logs.TRIGGER, "<START " + getName() + ".firePostInsertTable> " + t.toString());
                    try {
                        Net.Vpc.Upa.Callbacks.EntityListener li = t.GetListener();
                        if (@event == null) {
                            @event = new Net.Vpc.Upa.Callbacks.PersistEvent(objectId, record, context, Net.Vpc.Upa.EventPhase.AFTER);
                        }
                        @event.SetTrigger(et);
                        li.OnPersist(@event);
                    } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("problem when executing trigger " + t.GetName() + ".onPersist(" + t.GetEntity().GetName() + "," + objectId + ")",e));
                        //                    Log.bug("19987", "problem when executing trigger " + t.getName() + ".entityInserted(" + getName() + "," + key + ")");
                        //                    Log.bug(e);
                        throw e;
                    }
                }
            }
            //                Log.log(EditorConstants.Logs.TRIGGER, "<END   " + getName() + ".firePostInsertTable> " + t.toString());
            if (@event == null) {
                @event = new Net.Vpc.Upa.Callbacks.PersistEvent(objectId, record, context, Net.Vpc.Upa.EventPhase.AFTER);
            }
            foreach (Net.Vpc.Upa.Callback invoker in persistenceUnitListenerManager.GetPostCallbacks(Net.Vpc.Upa.CallbackType.ON_PERSIST, Net.Vpc.Upa.ObjectType.ENTITY, @event.GetEntity().GetName(), Net.Vpc.Upa.Impl.Event.PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
                invoker.Invoke(@event);
            }
        }

        public virtual void FireBeforeUpdate(Net.Vpc.Upa.Record updates, Net.Vpc.Upa.Expressions.Expression condition, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            //        Object methodExecId = Math.random();
            //        Log.method_enter(methodExecId, getName(), updates, condition);
            //        entity.preUpdateTable(updates, condition, context);
            Net.Vpc.Upa.Callbacks.UpdateEvent @event = null;
            if (entity.GetPersistenceUnit().IsTriggersEnabled()) {
                foreach (Net.Vpc.Upa.Callbacks.Trigger et in entity.GetSoftTriggers()) {
                    Net.Vpc.Upa.Impl.DefaultTrigger t = (Net.Vpc.Upa.Impl.DefaultTrigger) et;
                    //                Log.log(EditorConstants.Logs.TRIGGER, "<START " + getName() + ".fireBeforeUpdate> " + t.toString());
                    try {
                        Net.Vpc.Upa.Callbacks.EntityListener li = t.GetListener();
                        if (@event == null) {
                            @event = new Net.Vpc.Upa.Callbacks.UpdateEvent(updates, condition, context, Net.Vpc.Upa.EventPhase.BEFORE);
                        }
                        li.OnPreUpdate(@event);
                    } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("problem when executing trigger " + t.GetName() + ".onPreUpdate(" + t.GetEntity().GetName() + "," + condition + ")",e));
                        //                    Log.bug("19987", "problem when executing trigger " + t.getName() + ".beforeUpdate(" + getName() + "," + condition + ")");
                        //                    Log.bug(e);
                        throw e;
                    }
                }
            }
            //                Log.log(EditorConstants.Logs.TRIGGER, "<END   " + getName() + ".fireBeforeUpdate> " + t.toString());
            if (@event == null) {
                @event = new Net.Vpc.Upa.Callbacks.UpdateEvent(updates, condition, context, Net.Vpc.Upa.EventPhase.BEFORE);
            }
            foreach (Net.Vpc.Upa.Callback invoker in persistenceUnitListenerManager.GetPreCallbacks(Net.Vpc.Upa.CallbackType.ON_UPDATE, Net.Vpc.Upa.ObjectType.ENTITY, @event.GetEntity().GetName(), Net.Vpc.Upa.Impl.Event.PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
                invoker.Invoke(@event);
            }
            foreach (Net.Vpc.Upa.PreparedCallback invoker in persistenceUnitListenerManager.GetPostPreparedCallbacks(Net.Vpc.Upa.CallbackType.ON_UPDATE, Net.Vpc.Upa.ObjectType.ENTITY, @event.GetEntity().GetName(), Net.Vpc.Upa.Impl.Event.PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
                invoker.Prepare(@event);
            }
        }

        public virtual void FireAfterUpdate(Net.Vpc.Upa.Record updates, Net.Vpc.Upa.Expressions.Expression condition, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            //        Object methodExecId = Math.random();
            //        Log.method_enter(methodExecId, getName(), updates, condition);
            //        entity.postUpdateTable(updates, condition, context);
            Net.Vpc.Upa.Callbacks.UpdateEvent @event = null;
            if (entity.GetPersistenceUnit().IsTriggersEnabled()) {
                foreach (Net.Vpc.Upa.Callbacks.Trigger et in entity.GetSoftTriggers()) {
                    Net.Vpc.Upa.Impl.DefaultTrigger t = (Net.Vpc.Upa.Impl.DefaultTrigger) et;
                    //                Log.log(EditorConstants.Logs.TRIGGER, "<START " + getName() + ".fireAfterUpdate> " + t.toString());
                    try {
                        Net.Vpc.Upa.Callbacks.EntityListener li = t.GetListener();
                        if (@event == null) {
                            @event = new Net.Vpc.Upa.Callbacks.UpdateEvent(updates, condition, context, Net.Vpc.Upa.EventPhase.AFTER);
                        }
                        li.OnUpdate(@event);
                    } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("problem when executing trigger " + t.GetName() + ".onUpdate(" + t.GetEntity().GetName() + "," + condition + ")",e));
                        //                    Log.bug(e);
                        throw e;
                    }
                }
            }
            //                Log.log(EditorConstants.Logs.TRIGGER, "<END   " + getName() + ".fireAfterUpdate> " + t.toString());
            if (@event == null) {
                @event = new Net.Vpc.Upa.Callbacks.UpdateEvent(updates, condition, context, Net.Vpc.Upa.EventPhase.AFTER);
            }
            foreach (Net.Vpc.Upa.Callback invoker in persistenceUnitListenerManager.GetPostCallbacks(Net.Vpc.Upa.CallbackType.ON_UPDATE, Net.Vpc.Upa.ObjectType.ENTITY, @event.GetEntity().GetName(), Net.Vpc.Upa.Impl.Event.PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
                invoker.Invoke(@event);
            }
        }

        public virtual void FireBeforeRemove(Net.Vpc.Upa.Expressions.Expression condition, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            //        Object methodExecId = Math.random();
            //        Log.method_enter(methodExecId, getName(), condition);
            //        entity.preDeleteTable(condition, context);
            Net.Vpc.Upa.Callbacks.RemoveEvent @event = null;
            if (entity.GetPersistenceUnit().IsTriggersEnabled()) {
                foreach (Net.Vpc.Upa.Callbacks.Trigger et in entity.GetSoftTriggers()) {
                    Net.Vpc.Upa.Impl.DefaultTrigger t = (Net.Vpc.Upa.Impl.DefaultTrigger) et;
                    //                Log.log(EditorConstants.Logs.TRIGGER, "<START " + getName() + ".fireBeforeRemove> " + t.toString());
                    try {
                        Net.Vpc.Upa.Callbacks.EntityListener li = t.GetListener();
                        if (@event == null) {
                            @event = new Net.Vpc.Upa.Callbacks.RemoveEvent(condition, context, Net.Vpc.Upa.EventPhase.BEFORE);
                        }
                        li.OnPreRemove(@event);
                    } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("problem when executing trigger " + t.GetName() + ".onPreRemove(" + t.GetEntity().GetName() + "," + condition + ")",e));
                        //                    Log.bug(e);
                        throw e;
                    }
                }
            }
            //                Log.log(EditorConstants.Logs.TRIGGER, "<END   " + getName() + ".fireBeforeRemove> " + t.toString());
            if (@event == null) {
                @event = new Net.Vpc.Upa.Callbacks.RemoveEvent(condition, context, Net.Vpc.Upa.EventPhase.BEFORE);
            }
            foreach (Net.Vpc.Upa.Callback invoker in persistenceUnitListenerManager.GetPreCallbacks(Net.Vpc.Upa.CallbackType.ON_REMOVE, Net.Vpc.Upa.ObjectType.ENTITY, @event.GetEntity().GetName(), Net.Vpc.Upa.Impl.Event.PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
                invoker.Invoke(@event);
            }
            foreach (Net.Vpc.Upa.PreparedCallback invoker in persistenceUnitListenerManager.GetPostPreparedCallbacks(Net.Vpc.Upa.CallbackType.ON_REMOVE, Net.Vpc.Upa.ObjectType.ENTITY, @event.GetEntity().GetName(), Net.Vpc.Upa.Impl.Event.PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
                invoker.Prepare(@event);
            }
        }

        public virtual void FireAfterRemove(Net.Vpc.Upa.Expressions.Expression condition, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            //        Object methodExecId = Math.random();
            //        Log.method_enter(methodExecId, getName(), condition);
            //        entity.postDeleteTable(condition, context);
            Net.Vpc.Upa.Callbacks.RemoveEvent @event = null;
            if (entity.GetPersistenceUnit().IsTriggersEnabled()) {
                foreach (Net.Vpc.Upa.Callbacks.Trigger et in entity.GetSoftTriggers()) {
                    Net.Vpc.Upa.Impl.DefaultTrigger t = (Net.Vpc.Upa.Impl.DefaultTrigger) et;
                    //                Log.log(EditorConstants.Logs.TRIGGER, "<START " + getName() + ".fireAfterRemove> " + t.toString());
                    try {
                        Net.Vpc.Upa.Callbacks.EntityListener li = t.GetListener();
                        if (@event == null) {
                            @event = new Net.Vpc.Upa.Callbacks.RemoveEvent(condition, context, Net.Vpc.Upa.EventPhase.AFTER);
                        }
                        li.OnRemove(@event);
                    } catch (Net.Vpc.Upa.Exceptions.UPAException ex) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("problem when executing trigger " + t.GetName() + ".onPreRemove(" + t.GetEntity().GetName() + "," + condition + ")",ex));
                        //                    Log.bug(e);
                        throw ex;
                    }
                }
            }
            //                Log.log(EditorConstants.Logs.TRIGGER, "<END   " + getName() + ".fireAfterRemove> " + t.toString());
            if (@event == null) {
                @event = new Net.Vpc.Upa.Callbacks.RemoveEvent(condition, context, Net.Vpc.Upa.EventPhase.AFTER);
            }
            foreach (Net.Vpc.Upa.Callback invoker in persistenceUnitListenerManager.GetPostCallbacks(Net.Vpc.Upa.CallbackType.ON_REMOVE, Net.Vpc.Upa.ObjectType.ENTITY, @event.GetEntity().GetName(), Net.Vpc.Upa.Impl.Event.PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
                invoker.Invoke(@event);
            }
        }

        public virtual void FireBeforeFormulasUpdate(Net.Vpc.Upa.Record updates, Net.Vpc.Upa.Expressions.Expression condition, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            //        Object methodExecId = Math.random();
            //        Log.method_enter(methodExecId, getName(), updates, condition);
            //        entity.preUpdateTable(updates, condition, context);
            Net.Vpc.Upa.Callbacks.UpdateFormulaEvent @event = null;
            if (entity.GetPersistenceUnit().IsTriggersEnabled()) {
                foreach (Net.Vpc.Upa.Callbacks.Trigger et in entity.GetSoftTriggers()) {
                    Net.Vpc.Upa.Impl.DefaultTrigger t = (Net.Vpc.Upa.Impl.DefaultTrigger) et;
                    //                Log.log(EditorConstants.Logs.TRIGGER, "<START " + getName() + ".fireBeforeUpdate> " + t.toString());
                    try {
                        Net.Vpc.Upa.Callbacks.EntityListener li = t.GetListener();
                        if (@event == null) {
                            @event = new Net.Vpc.Upa.Callbacks.UpdateFormulaEvent(updates, condition, context, Net.Vpc.Upa.EventPhase.BEFORE);
                        }
                        li.OnPreUpdateFormula(@event);
                    } catch (Net.Vpc.Upa.Exceptions.UPAException ex) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("problem when executing trigger " + t.GetName() + ".onPreUpdateFormula(" + t.GetEntity().GetName() + "," + condition + ")",ex));
                        //                    Log.bug("19987", "problem when executing trigger " + t.getName() + ".beforeUpdate(" + getName() + "," + condition + ")");
                        //                    Log.bug(e);
                        throw ex;
                    }
                }
            }
            //                Log.log(EditorConstants.Logs.TRIGGER, "<END   " + getName() + ".fireBeforeUpdate> " + t.toString());
            if (@event == null) {
                @event = new Net.Vpc.Upa.Callbacks.UpdateFormulaEvent(updates, condition, context, Net.Vpc.Upa.EventPhase.BEFORE);
            }
            foreach (Net.Vpc.Upa.Callback invoker in persistenceUnitListenerManager.GetPreCallbacks(Net.Vpc.Upa.CallbackType.ON_UPDATE_FORMULAS, Net.Vpc.Upa.ObjectType.ENTITY, @event.GetEntity().GetName(), Net.Vpc.Upa.Impl.Event.PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
                invoker.Invoke(@event);
            }
            foreach (Net.Vpc.Upa.PreparedCallback invoker in persistenceUnitListenerManager.GetPostPreparedCallbacks(Net.Vpc.Upa.CallbackType.ON_UPDATE_FORMULAS, Net.Vpc.Upa.ObjectType.ENTITY, @event.GetEntity().GetName(), Net.Vpc.Upa.Impl.Event.PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
                invoker.Prepare(@event);
            }
        }

        public virtual void FireAfterFormulasUpdate(Net.Vpc.Upa.Record updates, Net.Vpc.Upa.Expressions.Expression condition, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            //        Object methodExecId = Math.random();
            //        Log.method_enter(methodExecId, getName(), updates, condition);
            //        entity.postUpdateTable(updates, condition, context);
            Net.Vpc.Upa.Callbacks.UpdateFormulaEvent @event = null;
            if (entity.GetPersistenceUnit().IsTriggersEnabled()) {
                foreach (Net.Vpc.Upa.Callbacks.Trigger et in entity.GetSoftTriggers()) {
                    Net.Vpc.Upa.Impl.DefaultTrigger t = (Net.Vpc.Upa.Impl.DefaultTrigger) et;
                    //                Log.log(EditorConstants.Logs.TRIGGER, "<START " + getName() + ".fireAfterUpdate> " + t.toString());
                    try {
                        Net.Vpc.Upa.Callbacks.EntityListener li = t.GetListener();
                        if (@event == null) {
                            @event = new Net.Vpc.Upa.Callbacks.UpdateFormulaEvent(updates, condition, context, Net.Vpc.Upa.EventPhase.AFTER);
                        }
                        li.OnUpdateFormula(@event);
                    } catch (Net.Vpc.Upa.Exceptions.UPAException ex) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("problem when executing trigger " + t.GetName() + ".onUpdateFormula(" + t.GetEntity().GetName() + "," + condition + ")",ex));
                        //                    Log.bug(e);
                        throw ex;
                    }
                }
            }
            //                Log.log(EditorConstants.Logs.TRIGGER, "<END   " + getName() + ".fireAfterUpdate> " + t.toString());
            if (@event == null) {
                @event = new Net.Vpc.Upa.Callbacks.UpdateFormulaEvent(updates, condition, context, Net.Vpc.Upa.EventPhase.AFTER);
            }
            foreach (Net.Vpc.Upa.Callback invoker in persistenceUnitListenerManager.GetPostCallbacks(Net.Vpc.Upa.CallbackType.ON_UPDATE_FORMULAS, Net.Vpc.Upa.ObjectType.ENTITY, @event.GetEntity().GetName(), Net.Vpc.Upa.Impl.Event.PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
                invoker.Invoke(@event);
            }
        }

        public virtual void FireBeforeInitialize(Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            //        Object methodExecId = Math.random();
            //        Log.method_enter(methodExecId, getName(), updates, condition);
            //        entity.preUpdateTable(updates, condition, context);
            Net.Vpc.Upa.Callbacks.EntityEvent @event = null;
            if (entity.GetPersistenceUnit().IsTriggersEnabled()) {
                foreach (Net.Vpc.Upa.Callbacks.Trigger et in entity.GetSoftTriggers()) {
                    Net.Vpc.Upa.Impl.DefaultTrigger t = (Net.Vpc.Upa.Impl.DefaultTrigger) et;
                    //                Log.log(EditorConstants.Logs.TRIGGER, "<START " + getName() + ".fireBeforeUpdate> " + t.toString());
                    try {
                        Net.Vpc.Upa.Callbacks.EntityListener li = t.GetListener();
                        if (@event == null) {
                            @event = new Net.Vpc.Upa.Callbacks.EntityEvent(context, Net.Vpc.Upa.EventPhase.BEFORE);
                        }
                        li.OnPreInitialize(@event);
                    } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("problem when executing trigger " + t.GetName() + ".onPreInitialize(" + t.GetEntity().GetName() + ")",e));
                        //                    Log.bug(e);
                        throw e;
                    }
                }
            }
            //                Log.log(EditorConstants.Logs.TRIGGER, "<END   " + getName() + ".fireBeforeUpdate> " + t.toString());
            if (@event == null) {
                @event = new Net.Vpc.Upa.Callbacks.EntityEvent(context, Net.Vpc.Upa.EventPhase.BEFORE);
            }
            foreach (Net.Vpc.Upa.Callback invoker in persistenceUnitListenerManager.GetPreCallbacks(Net.Vpc.Upa.CallbackType.ON_INITIALIZE, Net.Vpc.Upa.ObjectType.ENTITY, @event.GetEntity().GetName(), Net.Vpc.Upa.Impl.Event.PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
                invoker.Invoke(@event);
            }
            foreach (Net.Vpc.Upa.PreparedCallback invoker in persistenceUnitListenerManager.GetPostPreparedCallbacks(Net.Vpc.Upa.CallbackType.ON_INITIALIZE, Net.Vpc.Upa.ObjectType.ENTITY, @event.GetEntity().GetName(), Net.Vpc.Upa.Impl.Event.PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
                invoker.Prepare(@event);
            }
        }

        public virtual void FireAfterInitialize(Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            //        Object methodExecId = Math.random();
            //        Log.method_enter(methodExecId, getName(), updates, condition);
            //        entity.postUpdateTable(updates, condition, context);
            Net.Vpc.Upa.Callbacks.EntityEvent @event = null;
            if (entity.GetPersistenceUnit().IsTriggersEnabled()) {
                foreach (Net.Vpc.Upa.Callbacks.Trigger et in entity.GetSoftTriggers()) {
                    Net.Vpc.Upa.Impl.DefaultTrigger t = (Net.Vpc.Upa.Impl.DefaultTrigger) et;
                    //                Log.log(EditorConstants.Logs.TRIGGER, "<START " + getName() + ".fireAfterUpdate> " + t.toString());
                    try {
                        Net.Vpc.Upa.Callbacks.EntityListener li = t.GetListener();
                        if (@event == null) {
                            @event = new Net.Vpc.Upa.Callbacks.EntityEvent(context, Net.Vpc.Upa.EventPhase.AFTER);
                        }
                        li.OnInitialize(@event);
                    } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("problem when executing trigger " + t.GetName() + ".onInitialize(" + t.GetEntity().GetName() + ")",e));
                        //                    Log.bug(e);
                        throw e;
                    }
                }
            }
            //                Log.log(EditorConstants.Logs.TRIGGER, "<END   " + getName() + ".fireAfterUpdate> " + t.toString());
            if (@event == null) {
                @event = new Net.Vpc.Upa.Callbacks.EntityEvent(context, Net.Vpc.Upa.EventPhase.AFTER);
            }
            foreach (Net.Vpc.Upa.Callback invoker in persistenceUnitListenerManager.GetPostCallbacks(Net.Vpc.Upa.CallbackType.ON_INITIALIZE, Net.Vpc.Upa.ObjectType.ENTITY, @event.GetEntity().GetName(), Net.Vpc.Upa.Impl.Event.PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
                invoker.Invoke(@event);
            }
        }

        public virtual void FireBeforeClear(Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            //        Object methodExecId = Math.random();
            //        Log.method_enter(methodExecId, getName(), updates, condition);
            //        entity.preUpdateTable(updates, condition, context);
            Net.Vpc.Upa.Callbacks.EntityEvent @event = null;
            if (entity.GetPersistenceUnit().IsTriggersEnabled()) {
                foreach (Net.Vpc.Upa.Callbacks.Trigger et in entity.GetSoftTriggers()) {
                    Net.Vpc.Upa.Impl.DefaultTrigger t = (Net.Vpc.Upa.Impl.DefaultTrigger) et;
                    //                Log.log(EditorConstants.Logs.TRIGGER, "<START " + getName() + ".fireBeforeUpdate> " + t.toString());
                    try {
                        Net.Vpc.Upa.Callbacks.EntityListener li = t.GetListener();
                        if (@event == null) {
                            @event = new Net.Vpc.Upa.Callbacks.EntityEvent(context, Net.Vpc.Upa.EventPhase.BEFORE);
                        }
                        li.OnPreClear(@event);
                    } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("problem when executing trigger " + t.GetName() + ".onPreClear(" + t.GetEntity().GetName() + ")",e));
                        //                    Log.bug(e);
                        throw e;
                    }
                }
            }
            //                Log.log(EditorConstants.Logs.TRIGGER, "<END   " + getName() + ".fireBeforeUpdate> " + t.toString());
            if (@event == null) {
                @event = new Net.Vpc.Upa.Callbacks.EntityEvent(context, Net.Vpc.Upa.EventPhase.BEFORE);
            }
            foreach (Net.Vpc.Upa.Callback invoker in persistenceUnitListenerManager.GetPreCallbacks(Net.Vpc.Upa.CallbackType.ON_CLEAR, Net.Vpc.Upa.ObjectType.ENTITY, @event.GetEntity().GetName(), Net.Vpc.Upa.Impl.Event.PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
                invoker.Invoke(@event);
            }
            foreach (Net.Vpc.Upa.PreparedCallback invoker in persistenceUnitListenerManager.GetPostPreparedCallbacks(Net.Vpc.Upa.CallbackType.ON_CLEAR, Net.Vpc.Upa.ObjectType.ENTITY, @event.GetEntity().GetName(), Net.Vpc.Upa.Impl.Event.PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
                invoker.Invoke(@event);
            }
        }

        public virtual void FireAfterClear(Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Callbacks.EntityEvent @event = null;
            object methodExecId = Net.Vpc.Upa.Impl.FwkConvertUtils.Random();
            //        Log.method_enter(methodExecId, getName(), updates, condition);
            //        entity.postUpdateTable(updates, condition, context);
            if (entity.GetPersistenceUnit().IsTriggersEnabled()) {
                foreach (Net.Vpc.Upa.Callbacks.Trigger et in entity.GetSoftTriggers()) {
                    Net.Vpc.Upa.Impl.DefaultTrigger t = (Net.Vpc.Upa.Impl.DefaultTrigger) et;
                    //                Log.log(EditorConstants.Logs.TRIGGER, "<START " + getName() + ".fireAfterUpdate> " + t.toString());
                    try {
                        Net.Vpc.Upa.Callbacks.EntityListener li = t.GetListener();
                        if (@event == null) {
                            @event = new Net.Vpc.Upa.Callbacks.EntityEvent(context, Net.Vpc.Upa.EventPhase.AFTER);
                        }
                        li.OnClear(@event);
                    } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("problem when executing trigger " + t.GetName() + ".onClear(" + t.GetEntity().GetName() + ")",e));
                        //                    Log.bug(e);
                        throw e;
                    }
                }
            }
            //                Log.log(EditorConstants.Logs.TRIGGER, "<END   " + getName() + ".fireAfterUpdate> " + t.toString());
            if (@event == null) {
                @event = new Net.Vpc.Upa.Callbacks.EntityEvent(context, Net.Vpc.Upa.EventPhase.AFTER);
            }
            foreach (Net.Vpc.Upa.Callback invoker in persistenceUnitListenerManager.GetPostCallbacks(Net.Vpc.Upa.CallbackType.ON_CLEAR, Net.Vpc.Upa.ObjectType.ENTITY, @event.GetEntity().GetName(), Net.Vpc.Upa.Impl.Event.PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
                invoker.Invoke(@event);
            }
        }

        public virtual void FireBeforeReset(Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Callbacks.EntityEvent @event = null;
            object methodExecId = Net.Vpc.Upa.Impl.FwkConvertUtils.Random();
            //        Log.method_enter(methodExecId, getName(), updates, condition);
            //        entity.preUpdateTable(updates, condition, context);
            if (entity.GetPersistenceUnit().IsTriggersEnabled()) {
                foreach (Net.Vpc.Upa.Callbacks.Trigger et in entity.GetSoftTriggers()) {
                    Net.Vpc.Upa.Impl.DefaultTrigger t = (Net.Vpc.Upa.Impl.DefaultTrigger) et;
                    //                Log.log(EditorConstants.Logs.TRIGGER, "<START " + getName() + ".fireBeforeUpdate> " + t.toString());
                    try {
                        Net.Vpc.Upa.Callbacks.EntityListener li = t.GetListener();
                        if (@event == null) {
                            @event = new Net.Vpc.Upa.Callbacks.EntityEvent(context, Net.Vpc.Upa.EventPhase.BEFORE);
                        }
                        li.OnPreReset(@event);
                    } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("problem when executing trigger " + t.GetName() + ".onPreReset(" + t.GetEntity().GetName() + ")",e));
                        //                    Log.bug(e);
                        throw e;
                    }
                }
            }
            //                Log.log(EditorConstants.Logs.TRIGGER, "<END   " + getName() + ".fireBeforeUpdate> " + t.toString());
            if (@event == null) {
                @event = new Net.Vpc.Upa.Callbacks.EntityEvent(context, Net.Vpc.Upa.EventPhase.BEFORE);
            }
            foreach (Net.Vpc.Upa.Callback invoker in persistenceUnitListenerManager.GetPreCallbacks(Net.Vpc.Upa.CallbackType.ON_RESET, Net.Vpc.Upa.ObjectType.ENTITY, @event.GetEntity().GetName(), Net.Vpc.Upa.Impl.Event.PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
                invoker.Invoke(@event);
            }
            foreach (Net.Vpc.Upa.PreparedCallback invoker in persistenceUnitListenerManager.GetPostPreparedCallbacks(Net.Vpc.Upa.CallbackType.ON_RESET, Net.Vpc.Upa.ObjectType.ENTITY, @event.GetEntity().GetName(), Net.Vpc.Upa.Impl.Event.PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
                invoker.Prepare(@event);
            }
        }

        public virtual void FireAfterReset(Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Callbacks.EntityEvent @event = null;
            object methodExecId = Net.Vpc.Upa.Impl.FwkConvertUtils.Random();
            //        Log.method_enter(methodExecId, getName(), updates, condition);
            //        entity.postUpdateTable(updates, condition, context);
            if (entity.GetPersistenceUnit().IsTriggersEnabled()) {
                foreach (Net.Vpc.Upa.Callbacks.Trigger et in entity.GetSoftTriggers()) {
                    Net.Vpc.Upa.Impl.DefaultTrigger t = (Net.Vpc.Upa.Impl.DefaultTrigger) et;
                    //                Log.log(EditorConstants.Logs.TRIGGER, "<START " + getName() + ".fireAfterUpdate> " + t.toString());
                    try {
                        Net.Vpc.Upa.Callbacks.EntityListener li = t.GetListener();
                        if (@event == null) {
                            @event = new Net.Vpc.Upa.Callbacks.EntityEvent(context, Net.Vpc.Upa.EventPhase.AFTER);
                        }
                        li.OnReset(@event);
                    } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("problem when executing trigger " + t.GetName() + ".onReset(" + t.GetEntity().GetName() + ")",e));
                        //                    Log.bug(e);
                        throw e;
                    }
                }
            }
            //                Log.log(EditorConstants.Logs.TRIGGER, "<END   " + getName() + ".fireAfterUpdate> " + t.toString());
            if (@event == null) {
                @event = new Net.Vpc.Upa.Callbacks.EntityEvent(context, Net.Vpc.Upa.EventPhase.AFTER);
            }
            foreach (Net.Vpc.Upa.Callback invoker in persistenceUnitListenerManager.GetPostCallbacks(Net.Vpc.Upa.CallbackType.ON_RESET, Net.Vpc.Upa.ObjectType.ENTITY, @event.GetEntity().GetName(), Net.Vpc.Upa.Impl.Event.PersistenceUnitListenerManager.DEFAULT_SYSTEM)) {
                invoker.Invoke(@event);
            }
        }
    }
}
