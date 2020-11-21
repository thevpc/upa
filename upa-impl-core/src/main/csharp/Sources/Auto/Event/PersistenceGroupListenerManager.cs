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
    public class PersistenceGroupListenerManager {

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.TheVpc.Upa.Impl.Event.PersistenceGroupListenerManager)).FullName);

        private Net.TheVpc.Upa.PersistenceGroup group;

        private Net.TheVpc.Upa.Impl.Util.CallbackManager callbackManager = new Net.TheVpc.Upa.Impl.Util.CallbackManager();

        private static bool DEFAULT_SYSTEM = false;

        private readonly System.Collections.Generic.IList<Net.TheVpc.Upa.Callbacks.PersistenceUnitDefinitionListener> persistenceUnitDefinitionListeners = new System.Collections.Generic.List<Net.TheVpc.Upa.Callbacks.PersistenceUnitDefinitionListener>();

        public PersistenceGroupListenerManager(Net.TheVpc.Upa.PersistenceGroup group) {
            this.group = group;
        }

        public virtual void FireOnCreatePersistenceUnit(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event) {
            Net.TheVpc.Upa.EventPhase phase = @event.GetPhase();
            Net.TheVpc.Upa.Callbacks.PersistenceUnitDefinitionListener[] interceptorList = GetPersistenceUnitDefinitionListeners();
            if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                foreach (Net.TheVpc.Upa.Callbacks.PersistenceUnitDefinitionListener listener in interceptorList) {
                    listener.OnPreCreatePersistenceUnit(@event);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetCallbackPreInvokers(Net.TheVpc.Upa.CallbackType.ON_CREATE, Net.TheVpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceGroup().GetName(), DEFAULT_SYSTEM)) {
                    callback.Invoke(@event);
                }
            } else {
                foreach (Net.TheVpc.Upa.Callbacks.PersistenceUnitDefinitionListener listener in interceptorList) {
                    listener.OnCreatePersistenceUnit(@event);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetCallbackPostInvokers(Net.TheVpc.Upa.CallbackType.ON_CREATE, Net.TheVpc.Upa.ObjectType.PERSISTENCE_UNIT, @event.GetPersistenceGroup().GetName(), DEFAULT_SYSTEM)) {
                    callback.Invoke(@event);
                }
            }
        }

        public virtual void FireOnDropPersistenceUnit(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event) {
            Net.TheVpc.Upa.EventPhase phase = @event.GetPhase();
            Net.TheVpc.Upa.Callbacks.PersistenceUnitDefinitionListener[] interceptorList = GetPersistenceUnitDefinitionListeners();
            if (phase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                foreach (Net.TheVpc.Upa.Callbacks.PersistenceUnitDefinitionListener listener in interceptorList) {
                    listener.OnPreDropPersistenceUnit(@event);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetCallbackPreInvokers(Net.TheVpc.Upa.CallbackType.ON_DROP, Net.TheVpc.Upa.ObjectType.PERSISTENCE_GROUP, @event.GetPersistenceGroup().GetName(), DEFAULT_SYSTEM)) {
                    callback.Invoke(@event);
                }
            } else {
                foreach (Net.TheVpc.Upa.Callbacks.PersistenceUnitDefinitionListener listener in interceptorList) {
                    listener.OnDropPersistenceUnit(@event);
                }
                foreach (Net.TheVpc.Upa.Callback callback in GetCallbackPostInvokers(Net.TheVpc.Upa.CallbackType.ON_DROP, Net.TheVpc.Upa.ObjectType.PERSISTENCE_GROUP, @event.GetPersistenceGroup().GetName(), DEFAULT_SYSTEM)) {
                    callback.Invoke(@event);
                }
            }
        }

        public virtual void AddPersistenceUnitDefinitionListener(Net.TheVpc.Upa.Callbacks.PersistenceUnitDefinitionListener persistenceUnitDefinitionListener) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            persistenceUnitDefinitionListeners.Add(persistenceUnitDefinitionListener);
        }

        public virtual void RemovePersistenceUnitDefinitionListener(Net.TheVpc.Upa.Callbacks.PersistenceUnitDefinitionListener persistenceUnitDefinitionListener) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            persistenceUnitDefinitionListeners.Remove(persistenceUnitDefinitionListener);
        }

        public virtual Net.TheVpc.Upa.Callbacks.PersistenceUnitDefinitionListener[] GetPersistenceUnitDefinitionListeners() {
            return persistenceUnitDefinitionListeners.ToArray();
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
            return GetCallbackEffectiveInvokers(callbackType, objectType, nameFilter, system, Net.TheVpc.Upa.EventPhase.BEFORE);
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Callback> GetCallbackPostInvokers(Net.TheVpc.Upa.CallbackType callbackType, Net.TheVpc.Upa.ObjectType objectType, string nameFilter, bool system) {
            return GetCallbackEffectiveInvokers(callbackType, objectType, nameFilter, system, Net.TheVpc.Upa.EventPhase.AFTER);
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Callback> GetCallbackEffectiveInvokers(Net.TheVpc.Upa.CallbackType callbackType, Net.TheVpc.Upa.ObjectType objectType, string nameFilter, bool system, Net.TheVpc.Upa.EventPhase phase) {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Callback> allCallbacks = callbackManager.GetCallbacks(callbackType, objectType, nameFilter, system, false, phase);
            Net.TheVpc.Upa.Impl.FwkConvertUtils.ListAddRange(allCallbacks, new System.Collections.Generic.List<Net.TheVpc.Upa.Callback>(group.GetContext().GetCallbacks(callbackType, objectType, nameFilter, system, false, phase)));
            return allCallbacks;
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Callback> GetCallbacks(Net.TheVpc.Upa.CallbackType callbackType, Net.TheVpc.Upa.ObjectType objectType, string nameFilter, bool system, bool preparedOnly, Net.TheVpc.Upa.EventPhase phase) {
            return callbackManager.GetCallbacks(callbackType, objectType, nameFilter, system, preparedOnly, phase);
        }
    }
}
