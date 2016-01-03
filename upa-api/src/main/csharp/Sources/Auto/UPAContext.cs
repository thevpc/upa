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



namespace Net.Vpc.Upa
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
         void Start(Net.Vpc.Upa.ObjectFactory factory) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.UPAContextFactory GetFactory();

         Net.Vpc.Upa.Persistence.UPAContextConfig GetBootstrapContextConfig();

         void Scan(Net.Vpc.Upa.Config.ScanSource configurationStrategy, Net.Vpc.Upa.ScanListener listener, bool configure);

         Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.PersistenceGroup> GetPersistenceGroups() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.PersistenceGroup GetPersistenceGroup() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetPersistenceGroup(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.PersistenceGroup GetPersistenceGroup(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool ContainsPersistenceGroup(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.PersistenceGroup AddPersistenceGroup(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void RemovePersistenceGroup(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void AddPersistenceGroupDefinitionListener(Net.Vpc.Upa.Callbacks.PersistenceGroupDefinitionListener persistenceGroupDefinitionListener) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Callbacks.PersistenceGroupDefinitionListener[] GetPersistenceGroupDefinitionListeners();

         void RemovePersistenceGroupDefinitionListener(Net.Vpc.Upa.Callbacks.PersistenceGroupDefinitionListener persistenceGroupDefinitionListener) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          T MakeSessionAware<T>(T instance) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          T MakeSessionAware<T>(T instance, System.Type sessionAwareMethodAnnotation) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          T MakeSessionAware<T>(T instance, Net.Vpc.Upa.MethodFilter methodFilter) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          T MakeSessionAware<T>(System.Type type, Net.Vpc.Upa.MethodFilter methodFilter) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          T Invoke<T>(Net.Vpc.Upa.Action<T> action, Net.Vpc.Upa.InvokeContext invokeContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          T InvokePrivileged<T>(Net.Vpc.Upa.Action<T> action, Net.Vpc.Upa.InvokeContext invokeContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

        /**
             * closes context and removed all persistence groups
             *
             * @throws UPAException
             */
         void Close() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void AddCloseListener(Net.Vpc.Upa.CloseListener listener);

         void RemoveCloseListener(Net.Vpc.Upa.CloseListener listener);

         Net.Vpc.Upa.CloseListener[] GetCloseListeners();

        /**
             * prepare UPA context for method invocation. This method is same as
             * beginInvocation(Map<String, Object> properties) but includes also
             * annotation configurations for the method to invoke. Actually
             * beginInvocation does not invoke the given method.
             *
             * @param method     method to be invoked
             * @param properties non null Map to be shared between beginInvocation and
             *                   endInvocation
             */
         void BeginInvocation(System.Reflection.MethodInfo method, System.Collections.Generic.IDictionary<string , object> properties);

        /**
             * prepare UPA context for method invocation. This will prepare session and
             * transaction Actually beginInvocation does not invoke the given method.
             *
             * @param properties non null Map to be shared between beginInvocation and
             *                   endInvocation
             */
         void BeginInvocation(System.Collections.Generic.IDictionary<string , object> properties);

        /**
             * finalize method invocation and catch error if not null
             *
             * @param error      error if any
             * @param properties non null Map to be shared between beginInvocation and
             *                   endInvocation
             */
         void EndInvocation(System.Exception error, System.Collections.Generic.IDictionary<string , object> properties);

         void AddScanFilter(Net.Vpc.Upa.Config.ScanFilter filter);

         void RemoveScanFilter(Net.Vpc.Upa.Config.ScanFilter filter);

         Net.Vpc.Upa.Config.ScanFilter[] GetContextAnnotationStrategyFilters();

         System.Collections.Generic.IDictionary<string , object> GetProperties();

         void SetProperties(System.Collections.Generic.IDictionary<string , object> properties);

         Net.Vpc.Upa.Callback CreateCallback(object instance, System.Reflection.MethodInfo m, Net.Vpc.Upa.CallbackType callbackType, System.Collections.Generic.IDictionary<string , object> configuration);

         void AddCallback(Net.Vpc.Upa.Callback callback);

         void RemoveCallback(Net.Vpc.Upa.Callback callback);

         Net.Vpc.Upa.Callback[] GetCallbacks(Net.Vpc.Upa.CallbackType callbackType, Net.Vpc.Upa.ObjectType objectType, string nameFilter, bool system, Net.Vpc.Upa.EventPhase phase);
    }
}
