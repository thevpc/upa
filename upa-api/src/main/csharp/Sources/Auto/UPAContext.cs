/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.TheVpc.Upa
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/11/12 9:54 PM
     */
    public interface UPAContext {

        /**
             * start context and load config
             *
             * @param factory
             * @throws UPAException
             */
         void Start(Net.TheVpc.Upa.ObjectFactory factory, Net.TheVpc.Upa.Persistence.UPAContextConfig[] contextConfig, System.Type[] configClasses) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.UPAContextFactory GetFactory();

         Net.TheVpc.Upa.Persistence.UPAContextConfig GetBootstrapContextConfig();

         void Scan(Net.TheVpc.Upa.Persistence.UPAContextConfig contextConfig, Net.TheVpc.Upa.Config.ScanSource configurationStrategy, Net.TheVpc.Upa.ScanListener listener, bool configure);

         Net.TheVpc.Upa.PersistenceUnit GetPersistenceUnit() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.TheVpc.Upa.PersistenceGroup> GetPersistenceGroups() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.PersistenceGroup GetPersistenceGroup() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void SetPersistenceGroup(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.PersistenceGroup GetPersistenceGroup(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool ContainsPersistenceGroup(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.PersistenceGroup AddPersistenceGroup(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void RemovePersistenceGroup(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void AddPersistenceGroupDefinitionListener(Net.TheVpc.Upa.Callbacks.PersistenceGroupDefinitionListener persistenceGroupDefinitionListener) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Callbacks.PersistenceGroupDefinitionListener[] GetPersistenceGroupDefinitionListeners();

         void RemovePersistenceGroupDefinitionListener(Net.TheVpc.Upa.Callbacks.PersistenceGroupDefinitionListener persistenceGroupDefinitionListener) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

          T MakeSessionAware<T>(T instance) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

          T MakeSessionAware<T>(T instance, System.Type sessionAwareMethodAnnotation) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

          T MakeSessionAware<T>(T instance, Net.TheVpc.Upa.MethodFilter methodFilter) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

          T MakeSessionAware<T>(System.Type type, Net.TheVpc.Upa.MethodFilter methodFilter) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

          T Invoke<T>(Net.TheVpc.Upa.Action<T> action, Net.TheVpc.Upa.InvokeContext invokeContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

          T Invoke<T>(Net.TheVpc.Upa.Action<T> action) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

          T InvokePrivileged<T>(Net.TheVpc.Upa.Action<T> action, Net.TheVpc.Upa.InvokeContext invokeContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

          T InvokePrivileged<T>(Net.TheVpc.Upa.Action<T> action) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void Invoke(Net.TheVpc.Upa.VoidAction action, Net.TheVpc.Upa.InvokeContext invokeContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void Invoke(Net.TheVpc.Upa.VoidAction action) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void InvokePrivileged(Net.TheVpc.Upa.VoidAction action, Net.TheVpc.Upa.InvokeContext invokeContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void InvokePrivileged(Net.TheVpc.Upa.VoidAction action) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

        /**
             * closes context and removed all persistence groups
             *
             * @throws UPAException
             */
         void Close() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void AddCloseListener(Net.TheVpc.Upa.CloseListener listener);

         void RemoveCloseListener(Net.TheVpc.Upa.CloseListener listener);

         Net.TheVpc.Upa.CloseListener[] GetCloseListeners();

         void AddScanFilter(Net.TheVpc.Upa.Config.ScanFilter filter);

         void RemoveScanFilter(Net.TheVpc.Upa.Config.ScanFilter filter);

         Net.TheVpc.Upa.Config.ScanFilter[] GetContextAnnotationStrategyFilters();

         System.Collections.Generic.IDictionary<string , object> GetProperties();

         void SetProperties(System.Collections.Generic.IDictionary<string , object> properties);

         Net.TheVpc.Upa.Callback CreateCallback(Net.TheVpc.Upa.MethodCallback methodCallback);

         Net.TheVpc.Upa.Callback AddCallback(Net.TheVpc.Upa.MethodCallback methodCallback);

         void AddCallback(Net.TheVpc.Upa.Callback callback);

         void RemoveCallback(Net.TheVpc.Upa.Callback callback);

         Net.TheVpc.Upa.Callback[] GetCallbacks(Net.TheVpc.Upa.CallbackType callbackType, Net.TheVpc.Upa.ObjectType objectType, string nameFilter, bool system, bool preparedOnly, Net.TheVpc.Upa.EventPhase phase);

         Net.TheVpc.Upa.Properties GetThreadProperties();

         Net.TheVpc.Upa.PersistenceContextInfo GetInfo();
    }
}
