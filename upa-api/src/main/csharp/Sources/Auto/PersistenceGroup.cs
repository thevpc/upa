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
     * @creationdate 9/11/12 9:38 PM
     */
    public interface PersistenceGroup : Net.Vpc.Upa.Closeable {

         void Scan(Net.Vpc.Upa.Config.ScanSource strategy, Net.Vpc.Upa.ScanListener listener, bool configure) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         string GetName() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

        /**
             * if true, when no scan filter is specified will scan all class-path
             *
             * @return true if auto scan is enabled
             */
         bool IsAutoScan();

         void SetAutoScan(bool autoScan);

         Net.Vpc.Upa.UPAContext GetContext();

         Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetPersistenceUnit(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.PersistenceUnit> GetPersistenceUnits() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.ObjectFactory GetFactory() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool ContainsPersistenceUnit(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.PersistenceUnit AddPersistenceUnit(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void DropPersistenceUnit(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool CurrentSessionExists();

         Net.Vpc.Upa.Session GetCurrentSession() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Session FindCurrentSession() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetCurrentSession(Net.Vpc.Upa.Session session) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Session OpenSession();

         bool IsClosed();

         void AddPersistenceUnitDefinitionListener(Net.Vpc.Upa.Callbacks.PersistenceUnitDefinitionListener definitionListener);

         void RemovePersistenceUnitDefinitionListener(Net.Vpc.Upa.Callbacks.PersistenceUnitDefinitionListener definitionListener);

         void AddContextAnnotationStrategyFilter(Net.Vpc.Upa.Config.ScanFilter filter);

         void RemoveContextAnnotationStrategyFilter(Net.Vpc.Upa.Config.ScanFilter filter);

         Net.Vpc.Upa.Config.ScanFilter[] GetContextAnnotationStrategyFilters();

         Net.Vpc.Upa.UPASecurityManager GetSecurityManager();

         Net.Vpc.Upa.PersistenceGroupSecurityManager GetPersistenceGroupSecurityManager();

         void SetPersistenceGroupSecurityManager(Net.Vpc.Upa.PersistenceGroupSecurityManager securityManager);

         void AddCallback(Net.Vpc.Upa.Callback callback);

         void RemoveCallback(Net.Vpc.Upa.Callback callback);

         Net.Vpc.Upa.Callback[] GetCallbacks(Net.Vpc.Upa.CallbackType nameFilter, Net.Vpc.Upa.ObjectType objectType, string name, bool system, bool preparedOnly, Net.Vpc.Upa.EventPhase phase);

          T Invoke<T>(Net.Vpc.Upa.Action<T> action, Net.Vpc.Upa.InvokeContext invokeContext);

          T Invoke<T>(Net.Vpc.Upa.Action<T> action);

          T InvokePrivileged<T>(Net.Vpc.Upa.Action<T> action, Net.Vpc.Upa.InvokeContext invokeContext);

          T InvokePrivileged<T>(Net.Vpc.Upa.Action<T> action);

         void Invoke(Net.Vpc.Upa.VoidAction action, Net.Vpc.Upa.InvokeContext invokeContext);

         void Invoke(Net.Vpc.Upa.VoidAction action);

         void InvokePrivileged(Net.Vpc.Upa.VoidAction action, Net.Vpc.Upa.InvokeContext invokeContext);

         void InvokePrivileged(Net.Vpc.Upa.VoidAction action);
    }
}
