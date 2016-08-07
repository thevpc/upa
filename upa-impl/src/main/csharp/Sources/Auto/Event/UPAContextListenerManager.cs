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
    public class UPAContextListenerManager {

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Event.UPAContextListenerManager)).FullName);

        private Net.Vpc.Upa.Impl.Config.DefaultUPAContext upaContext;

        private Net.Vpc.Upa.Impl.Util.CallbackManager callbackManager = new Net.Vpc.Upa.Impl.Util.CallbackManager();

        private static bool DEFAULT_SYSTEM = false;

        private readonly System.Collections.Generic.IList<Net.Vpc.Upa.Callbacks.PersistenceGroupDefinitionListener> persistenceGroupDefinitionListeners = new System.Collections.Generic.List<Net.Vpc.Upa.Callbacks.PersistenceGroupDefinitionListener>();

        public UPAContextListenerManager(Net.Vpc.Upa.Impl.Config.DefaultUPAContext upaContext) {
            this.upaContext = upaContext;
        }

        public virtual void FireOnCreatePersistenceGroup(Net.Vpc.Upa.Callbacks.PersistenceGroupEvent @event, Net.Vpc.Upa.EventPhase phase) {
            Net.Vpc.Upa.Callbacks.PersistenceGroupDefinitionListener[] interceptorList = GetPersistenceGroupDefinitionListeners();
            if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                foreach (Net.Vpc.Upa.Callbacks.PersistenceGroupDefinitionListener listener in interceptorList) {
                    listener.OnPreCreatePersistenceGroup(@event);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_CREATE, Net.Vpc.Upa.ObjectType.PERSISTENCE_GROUP, @event.GetPersistenceGroup().GetName(), DEFAULT_SYSTEM)) {
                    callback.Invoke(@event);
                }
            } else {
                foreach (Net.Vpc.Upa.Callbacks.PersistenceGroupDefinitionListener listener in interceptorList) {
                    listener.OnCreatePersistenceGroup(@event);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPostInvokers(Net.Vpc.Upa.CallbackType.ON_CREATE, Net.Vpc.Upa.ObjectType.PERSISTENCE_GROUP, @event.GetPersistenceGroup().GetName(), DEFAULT_SYSTEM)) {
                    callback.Invoke(@event);
                }
            }
        }

        public virtual void FireOnDropPersistenceGroup(Net.Vpc.Upa.Callbacks.PersistenceGroupEvent @event, Net.Vpc.Upa.EventPhase phase) {
            Net.Vpc.Upa.Callbacks.PersistenceGroupDefinitionListener[] interceptorList = GetPersistenceGroupDefinitionListeners();
            if (phase == Net.Vpc.Upa.EventPhase.BEFORE) {
                foreach (Net.Vpc.Upa.Callbacks.PersistenceGroupDefinitionListener listener in interceptorList) {
                    listener.OnPreDropPersistenceGroup(@event);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPreInvokers(Net.Vpc.Upa.CallbackType.ON_DROP, Net.Vpc.Upa.ObjectType.PERSISTENCE_GROUP, @event.GetPersistenceGroup().GetName(), DEFAULT_SYSTEM)) {
                    callback.Invoke(@event);
                }
            } else {
                foreach (Net.Vpc.Upa.Callbacks.PersistenceGroupDefinitionListener listener in interceptorList) {
                    listener.OnDropPersistenceGroup(@event);
                }
                foreach (Net.Vpc.Upa.Callback callback in GetCallbackPostInvokers(Net.Vpc.Upa.CallbackType.ON_DROP, Net.Vpc.Upa.ObjectType.PERSISTENCE_GROUP, @event.GetPersistenceGroup().GetName(), DEFAULT_SYSTEM)) {
                    callback.Invoke(@event);
                }
            }
        }

        public virtual void AddPersistenceGroupDefinitionListener(Net.Vpc.Upa.Callbacks.PersistenceGroupDefinitionListener persistenceGroupDefinitionListener) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            persistenceGroupDefinitionListeners.Add(persistenceGroupDefinitionListener);
        }

        public virtual void RemovePersistenceGroupDefinitionListener(Net.Vpc.Upa.Callbacks.PersistenceGroupDefinitionListener persistenceGroupDefinitionListener) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            persistenceGroupDefinitionListeners.Remove(persistenceGroupDefinitionListener);
        }

        public virtual Net.Vpc.Upa.Callbacks.PersistenceGroupDefinitionListener[] GetPersistenceGroupDefinitionListeners() {
            return persistenceGroupDefinitionListeners.ToArray();
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
            return GetEffectiveCallbacks(callbackType, objectType, nameFilter, system, false, Net.Vpc.Upa.EventPhase.BEFORE);
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Callback> GetCallbackPostInvokers(Net.Vpc.Upa.CallbackType callbackType, Net.Vpc.Upa.ObjectType objectType, string nameFilter, bool system) {
            return GetEffectiveCallbacks(callbackType, objectType, nameFilter, system, false, Net.Vpc.Upa.EventPhase.AFTER);
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Callback> GetEffectiveCallbacks(Net.Vpc.Upa.CallbackType callbackType, Net.Vpc.Upa.ObjectType objectType, string nameFilter, bool system, bool preparedOnly, Net.Vpc.Upa.EventPhase phase) {
            return callbackManager.GetCallbacks(callbackType, objectType, nameFilter, system, preparedOnly, phase);
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Callback> GetCallbacks(Net.Vpc.Upa.CallbackType callbackType, Net.Vpc.Upa.ObjectType objectType, string nameFilter, bool system, bool preparedOnly, Net.Vpc.Upa.EventPhase phase) {
            return callbackManager.GetCallbacks(callbackType, objectType, nameFilter, system, preparedOnly, phase);
        }
    }
}
