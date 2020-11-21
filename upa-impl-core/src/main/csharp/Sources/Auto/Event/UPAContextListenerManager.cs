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
namespace Net.TheVpc.Upa.Impl.Event
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/27/12 9:07 PM
     */
    public class UPAContextListenerManager {

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.TheVpc.Upa.Impl.Event.UPAContextListenerManager)).FullName);

        private Net.TheVpc.Upa.Impl.Config.DefaultUPAContext upaContext;

        private Net.TheVpc.Upa.Impl.Util.CallbackManager callbackManager = new Net.TheVpc.Upa.Impl.Util.CallbackManager();

        private static bool DEFAULT_SYSTEM = false;

        private readonly System.Collections.Generic.IList<Net.TheVpc.Upa.Callbacks.PersistenceGroupDefinitionListener> persistenceGroupDefinitionListeners = new System.Collections.Generic.List<Net.TheVpc.Upa.Callbacks.PersistenceGroupDefinitionListener>();

        public UPAContextListenerManager(Net.TheVpc.Upa.Impl.Config.DefaultUPAContext upaContext) {
            this.upaContext = upaContext;
        }

        public virtual void FireOnCreatePersistenceGroup(Net.TheVpc.Upa.Callbacks.PersistenceGroupEvent @event, Net.TheVpc.Upa.EventPhase phase) {
            Net.TheVpc.Upa.Callbacks.PersistenceGroupDefinitionListener[] interceptorList = GetPersistenceGroupDefinitionListeners();
            if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                foreach (Net.TheVpc.Upa.Callbacks.PersistenceGroupDefinitionListener listener in interceptorList) {
                    listener.OnPreCreatePersistenceGroup(@event);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetCallbackPreInvokers(Net.TheVpc.Upa.CallbackType.ON_CREATE, Net.TheVpc.Upa.ObjectType.PERSISTENCE_GROUP, @event.GetPersistenceGroup().GetName(), DEFAULT_SYSTEM)) {
                    callback.Invoke(@event);
                }
            } else {
                foreach (Net.TheVpc.Upa.Callbacks.PersistenceGroupDefinitionListener listener in interceptorList) {
                    listener.OnCreatePersistenceGroup(@event);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetCallbackPostInvokers(Net.TheVpc.Upa.CallbackType.ON_CREATE, Net.TheVpc.Upa.ObjectType.PERSISTENCE_GROUP, @event.GetPersistenceGroup().GetName(), DEFAULT_SYSTEM)) {
                    callback.Invoke(@event);
                }
            }
        }

        public virtual void FireOnDropPersistenceGroup(Net.TheVpc.Upa.Callbacks.PersistenceGroupEvent @event, Net.TheVpc.Upa.EventPhase phase) {
            Net.TheVpc.Upa.Callbacks.PersistenceGroupDefinitionListener[] interceptorList = GetPersistenceGroupDefinitionListeners();
            if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                foreach (Net.TheVpc.Upa.Callbacks.PersistenceGroupDefinitionListener listener in interceptorList) {
                    listener.OnPreDropPersistenceGroup(@event);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetCallbackPreInvokers(Net.TheVpc.Upa.CallbackType.ON_DROP, Net.TheVpc.Upa.ObjectType.PERSISTENCE_GROUP, @event.GetPersistenceGroup().GetName(), DEFAULT_SYSTEM)) {
                    callback.Invoke(@event);
                }
            } else {
                foreach (Net.TheVpc.Upa.Callbacks.PersistenceGroupDefinitionListener listener in interceptorList) {
                    listener.OnDropPersistenceGroup(@event);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetCallbackPostInvokers(Net.TheVpc.Upa.CallbackType.ON_DROP, Net.TheVpc.Upa.ObjectType.PERSISTENCE_GROUP, @event.GetPersistenceGroup().GetName(), DEFAULT_SYSTEM)) {
                    callback.Invoke(@event);
                }
            }
        }

        public virtual void AddPersistenceGroupDefinitionListener(Net.TheVpc.Upa.Callbacks.PersistenceGroupDefinitionListener persistenceGroupDefinitionListener) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            persistenceGroupDefinitionListeners.Add(persistenceGroupDefinitionListener);
        }

        public virtual void RemovePersistenceGroupDefinitionListener(Net.TheVpc.Upa.Callbacks.PersistenceGroupDefinitionListener persistenceGroupDefinitionListener) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            persistenceGroupDefinitionListeners.Remove(persistenceGroupDefinitionListener);
        }

        public virtual Net.TheVpc.Upa.Callbacks.PersistenceGroupDefinitionListener[] GetPersistenceGroupDefinitionListeners() {
            return persistenceGroupDefinitionListeners.ToArray();
        }

        public virtual Net.TheVpc.Upa.Impl.Util.CallbackManager GetCallbackManager() {
            return callbackManager;
        }

        public virtual void AddCallback(Net.TheVpc.Upa.Callback callback) {
            callbackManager.AddCallback(callback);
        }

        public virtual void RemoveCallback(Net.TheVpc.Upa.Callback callback) {
            callbackManager.RemoveCallback(callback);
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Callback> GetCallbackPreInvokers(Net.TheVpc.Upa.CallbackType callbackType, Net.TheVpc.Upa.ObjectType objectType, string nameFilter, bool system) {
            return GetEffectiveCallbacks(callbackType, objectType, nameFilter, system, false, Net.TheVpc.Upa.EventPhase.BEFORE);
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Callback> GetCallbackPostInvokers(Net.TheVpc.Upa.CallbackType callbackType, Net.TheVpc.Upa.ObjectType objectType, string nameFilter, bool system) {
            return GetEffectiveCallbacks(callbackType, objectType, nameFilter, system, false, Net.TheVpc.Upa.EventPhase.AFTER);
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Callback> GetEffectiveCallbacks(Net.TheVpc.Upa.CallbackType callbackType, Net.TheVpc.Upa.ObjectType objectType, string nameFilter, bool system, bool preparedOnly, Net.TheVpc.Upa.EventPhase phase) {
            return callbackManager.GetCallbacks(callbackType, objectType, nameFilter, system, preparedOnly, phase);
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Callback> GetCallbacks(Net.TheVpc.Upa.CallbackType callbackType, Net.TheVpc.Upa.ObjectType objectType, string nameFilter, bool system, bool preparedOnly, Net.TheVpc.Upa.EventPhase phase) {
            return callbackManager.GetCallbacks(callbackType, objectType, nameFilter, system, preparedOnly, phase);
        }
    }
}
