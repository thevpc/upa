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



using System.Linq;
namespace Net.Vpc.Upa.Impl.Event
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/27/12 9:07 PM
     */
    public class PersistenceGroupListenerManager {

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Event.PersistenceGroupListenerManager)).FullName);

        private Net.Vpc.Upa.PersistenceGroup group;

        private Net.Vpc.Upa.Impl.Util.CallbackManager callbackManager = new Net.Vpc.Upa.Impl.Util.CallbackManager();

        private static bool DEFAULT_SYSTEM = false;

        private readonly System.Collections.Generic.IList<Net.Vpc.Upa.Callbacks.PersistenceUnitDefinitionListener> persistenceUnitDefinitionListeners = new System.Collections.Generic.List<Net.Vpc.Upa.Callbacks.PersistenceUnitDefinitionListener>();

        public PersistenceGroupListenerManager(Net.Vpc.Upa.PersistenceGroup group) {
            this.group = group;
        }

        public virtual void FireOnCreatePersistenceUnit(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event) {
            Net.Vpc.Upa.EventPhase phase = @event.GetPhase();
            Net.Vpc.Upa.Callbacks.PersistenceUnitDefinitionListener[] interceptorList = GetPersistenceUnitDefinitionListeners();
            if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                foreach (Net.Vpc.Upa.Callbacks.PersistenceUnitDefinitionListener listener in interceptorList) {
                    listener.OnPreCreatePersistenceUnit(@event);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_CREATE, Net.Vpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceGroup().GetName(), DEFAULT_SYSTEM)) {
                    callback.Invoke(@event);
                }
            } else {
                foreach (Net.Vpc.Upa.Callbacks.PersistenceUnitDefinitionListener listener in interceptorList) {
                    listener.OnCreatePersistenceUnit(@event);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPostInvokers(Net.Vpc.Upa.CallbackType.ON_CREATE, Net.Vpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceGroup().GetName(), DEFAULT_SYSTEM)) {
                    callback.Invoke(@event);
                }
            }
        }

        public virtual void FireOnDropPersistenceUnit(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event) {
            Net.Vpc.Upa.EventPhase phase = @event.GetPhase();
            Net.Vpc.Upa.Callbacks.PersistenceUnitDefinitionListener[] interceptorList = GetPersistenceUnitDefinitionListeners();
            if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                foreach (Net.Vpc.Upa.Callbacks.PersistenceUnitDefinitionListener listener in interceptorList) {
                    listener.OnPreDropPersistenceUnit(@event);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_DROP, Net.Vpc.Upa.ObjectType.PERSISTENCE_GROUP, @event.GetPersistenceGroup().GetName(), DEFAULT_SYSTEM)) {
                    callback.Invoke(@event);
                }
            } else {
                foreach (Net.Vpc.Upa.Callbacks.PersistenceUnitDefinitionListener listener in interceptorList) {
                    listener.OnDropPersistenceUnit(@event);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPostInvokers(Net.Vpc.Upa.CallbackType.ON_DROP, Net.Vpc.Upa.ObjectType.PERSISTENCE_GROUP, @event.GetPersistenceGroup().GetName(), DEFAULT_SYSTEM)) {
                    callback.Invoke(@event);
                }
            }
        }

        public virtual void AddPersistenceUnitDefinitionListener(Net.Vpc.Upa.Callbacks.PersistenceUnitDefinitionListener persistenceUnitDefinitionListener) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            persistenceUnitDefinitionListeners.Add(persistenceUnitDefinitionListener);
        }

        public virtual void RemovePersistenceUnitDefinitionListener(Net.Vpc.Upa.Callbacks.PersistenceUnitDefinitionListener persistenceUnitDefinitionListener) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            persistenceUnitDefinitionListeners.Remove(persistenceUnitDefinitionListener);
        }

        public virtual Net.Vpc.Upa.Callbacks.PersistenceUnitDefinitionListener[] GetPersistenceUnitDefinitionListeners() {
            return persistenceUnitDefinitionListeners.ToArray();
        }

        public virtual Net.Vpc.Upa.Impl.Util.CallbackManager GetCallbackManager() {
            return callbackManager;
        }

        public virtual void AddCallback(Net.Vpc.Upa.Callback callback) {
            callbackManager.AddCallback(callback);
        }

        public virtual void RemoveCallback(Net.Vpc.Upa.Callback callback) {
            callbackManager.RemoveCallback(callback);
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Callback> GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType callbackType, Net.Vpc.Upa.ObjectType objectType, string nameFilter, bool system) {
            return GetCallbackEffectiveInvokers(callbackType, objectType, nameFilter, system, Net.Vpc.Upa.EventPhase.BEFORE);
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Callback> GetCallbackPostInvokers(Net.Vpc.Upa.CallbackType callbackType, Net.Vpc.Upa.ObjectType objectType, string nameFilter, bool system) {
            return GetCallbackEffectiveInvokers(callbackType, objectType, nameFilter, system, Net.Vpc.Upa.EventPhase.AFTER);
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Callback> GetCallbackEffectiveInvokers(Net.Vpc.Upa.CallbackType callbackType, Net.Vpc.Upa.ObjectType objectType, string nameFilter, bool system, Net.Vpc.Upa.EventPhase phase) {
            System.Collections.Generic.IList<Net.Vpc.Upa.Callback> allCallbacks = callbackManager.GetCallbacks(callbackType, objectType, nameFilter, system, false, phase);
            Net.Vpc.Upa.Impl.FwkConvertUtils.ListAddRange(allCallbacks, new System.Collections.Generic.List<Net.Vpc.Upa.Callback>(group.GetContext().GetCallbacks(callbackType, objectType, nameFilter, system, false, phase)));
            return allCallbacks;
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Callback> GetCallbacks(Net.Vpc.Upa.CallbackType callbackType, Net.Vpc.Upa.ObjectType objectType, string nameFilter, bool system, bool preparedOnly, Net.Vpc.Upa.EventPhase phase) {
            return callbackManager.GetCallbacks(callbackType, objectType, nameFilter, system, preparedOnly, phase);
        }
    }
}
