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
     * @creationdate 9/11/12 9:38 PM
     */
    public interface PersistenceGroup : Net.TheVpc.Upa.Closeable {

         void Scan(Net.TheVpc.Upa.Config.ScanSource strategy, Net.TheVpc.Upa.ScanListener listener, bool configure) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         string GetName() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

        /**
             * if true, when no scan filter is specified will scan all class-path
             *
             * @return true if auto scan is enabled
             */
         bool IsAutoScan();

         void SetAutoScan(bool autoScan);

         Net.TheVpc.Upa.UPAContext GetContext();

         Net.TheVpc.Upa.PersistenceUnit GetPersistenceUnit() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void SetPersistenceUnit(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.TheVpc.Upa.PersistenceUnit> GetPersistenceUnits() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.PersistenceUnit GetPersistenceUnit(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.ObjectFactory GetFactory() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool ContainsPersistenceUnit(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.PersistenceUnit AddPersistenceUnit(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void DropPersistenceUnit(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool CurrentSessionExists();

         Net.TheVpc.Upa.Session GetCurrentSession() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void SetCurrentSession(Net.TheVpc.Upa.Session session) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Session FindCurrentSession() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Session OpenSession();

         bool IsClosed();

         void AddPersistenceUnitDefinitionListener(Net.TheVpc.Upa.Callbacks.PersistenceUnitDefinitionListener definitionListener);

         void RemovePersistenceUnitDefinitionListener(Net.TheVpc.Upa.Callbacks.PersistenceUnitDefinitionListener definitionListener);

         void AddContextAnnotationStrategyFilter(Net.TheVpc.Upa.Config.ScanFilter filter);

         void RemoveContextAnnotationStrategyFilter(Net.TheVpc.Upa.Config.ScanFilter filter);

         Net.TheVpc.Upa.Config.ScanFilter[] GetContextAnnotationStrategyFilters();

         Net.TheVpc.Upa.UPASecurityManager GetSecurityManager();

         Net.TheVpc.Upa.PersistenceGroupSecurityManager GetPersistenceGroupSecurityManager();

         void SetPersistenceGroupSecurityManager(Net.TheVpc.Upa.PersistenceGroupSecurityManager securityManager);

         Net.TheVpc.Upa.Callback AddCallback(Net.TheVpc.Upa.MethodCallback callback);

         void AddCallback(Net.TheVpc.Upa.Callback callback);

         void RemoveCallback(Net.TheVpc.Upa.Callback callback);

         Net.TheVpc.Upa.Callback[] GetCallbacks(Net.TheVpc.Upa.CallbackType nameFilter, Net.TheVpc.Upa.ObjectType objectType, string name, bool system, bool preparedOnly, Net.TheVpc.Upa.EventPhase phase);

          T Invoke<T>(Net.TheVpc.Upa.Action<T> action, Net.TheVpc.Upa.InvokeContext invokeContext);

          T Invoke<T>(Net.TheVpc.Upa.Action<T> action);

          T InvokePrivileged<T>(Net.TheVpc.Upa.Action<T> action, Net.TheVpc.Upa.InvokeContext invokeContext);

          T InvokePrivileged<T>(Net.TheVpc.Upa.Action<T> action);

         void Invoke(Net.TheVpc.Upa.VoidAction action, Net.TheVpc.Upa.InvokeContext invokeContext);

         void Invoke(Net.TheVpc.Upa.VoidAction action);

         void InvokePrivileged(Net.TheVpc.Upa.VoidAction action, Net.TheVpc.Upa.InvokeContext invokeContext);

         void InvokePrivileged(Net.TheVpc.Upa.VoidAction action);

         Net.TheVpc.Upa.Properties GetProperties();

         Net.TheVpc.Upa.PersistenceGroupInfo GetInfo();

         Net.TheVpc.Upa.UPAI18n GetI18n();

         void SetI18n(Net.TheVpc.Upa.UPAI18n i18n);

         Net.TheVpc.Upa.UPAI18n GetI18nOrDefault();
    }
}
