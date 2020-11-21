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
namespace Net.TheVpc.Upa.Impl
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/11/12 9:47 PM
     */
    public class DefaultPersistenceGroup : Net.TheVpc.Upa.PersistenceGroup {

        protected internal static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.TheVpc.Upa.Impl.DefaultPersistenceGroup)).FullName);

        private Net.TheVpc.Upa.UPAContext context;

        private Net.TheVpc.Upa.ObjectFactory factory;

        private readonly System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.PersistenceUnit> persistenceUnits = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.PersistenceUnit>();

        private readonly System.Collections.Generic.IList<Net.TheVpc.Upa.Session> sessions = new System.Collections.Generic.List<Net.TheVpc.Upa.Session>();

        private Net.TheVpc.Upa.SessionContextProvider sessionContextProvider;

        private Net.TheVpc.Upa.PersistenceUnitProvider persistenceUnitProvider;

        private string name;

        private bool closed;

        private bool autoScan = true;

        private readonly System.Collections.Generic.IList<Net.TheVpc.Upa.Config.ScanFilter> filters = new System.Collections.Generic.List<Net.TheVpc.Upa.Config.ScanFilter>();

        private Net.TheVpc.Upa.Impl.Config.Decorations.DecorationRepository decorationRepository;

        private Net.TheVpc.Upa.UPASecurityManager securityManager;

        private Net.TheVpc.Upa.PersistenceGroupSecurityManager persistenceGroupSecurityManager;

        private Net.TheVpc.Upa.Impl.Event.PersistenceGroupListenerManager listeners;

        public DefaultPersistenceGroup() {
            listeners = new Net.TheVpc.Upa.Impl.Event.PersistenceGroupListenerManager(this);
        }


        public virtual void Scan(Net.TheVpc.Upa.Config.ScanSource strategy, Net.TheVpc.Upa.ScanListener listener, bool configure) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            decorationRepository = new Net.TheVpc.Upa.Impl.Config.Decorations.DefaultDecorationRepository(GetName() + "-PGRepo", true);
            log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("{0} : Configuring PersistenceGroup with strategy {1}",null,new object[] { GetName(), strategy }));
            Net.TheVpc.Upa.Impl.Config.URLAnnotationStrategySupport s = new Net.TheVpc.Upa.Impl.Config.URLAnnotationStrategySupport();
            s.Scan(this, strategy, decorationRepository, configure ? ((Net.TheVpc.Upa.ScanListener)(new Net.TheVpc.Upa.Impl.Config.ConfigureScanListener(listener))) : listener);
            if (securityManager == null) {
                securityManager = GetFactory().CreateObject<Net.TheVpc.Upa.UPASecurityManager>(typeof(Net.TheVpc.Upa.UPASecurityManager));
            }
        }

        public virtual bool IsAutoScan() {
            return autoScan;
        }

        public virtual void SetAutoScan(bool autoScan) {
            this.autoScan = autoScan;
        }

        public virtual string GetName() {
            return name;
        }

        public virtual void SetContext(Net.TheVpc.Upa.UPAContext context) {
            this.context = context;
        }

        public virtual void SetFactory(Net.TheVpc.Upa.ObjectFactory factory) {
            this.factory = factory;
        }

        public virtual void SetName(string name) {
            this.name = name;
        }

        public virtual Net.TheVpc.Upa.UPAContext GetContext() {
            return context;
        }

        protected internal virtual Net.TheVpc.Upa.SessionContextProvider GetSessionContextProvider() {
            if (sessionContextProvider == null) {
                sessionContextProvider = GetFactory().CreateObject<Net.TheVpc.Upa.SessionContextProvider>(typeof(Net.TheVpc.Upa.SessionContextProvider));
            }
            return sessionContextProvider;
        }

        protected internal virtual Net.TheVpc.Upa.PersistenceUnitProvider GetPersistenceUnitProvider() {
            if (persistenceUnitProvider == null) {
                persistenceUnitProvider = GetFactory().CreateObject<Net.TheVpc.Upa.PersistenceUnitProvider>(typeof(Net.TheVpc.Upa.PersistenceUnitProvider));
            }
            return persistenceUnitProvider;
        }


        public virtual Net.TheVpc.Upa.PersistenceUnit GetPersistenceUnit() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.PersistenceUnit persistenceUnit = GetPersistenceUnitProvider().GetPersistenceUnit(this);
            if (persistenceUnit == null) {
                System.Collections.Generic.IList<Net.TheVpc.Upa.PersistenceUnit> persistenceUnitsCurr = GetPersistenceUnits();
                if ((persistenceUnitsCurr).Count > 0) {
                    foreach (Net.TheVpc.Upa.PersistenceUnit s in persistenceUnitsCurr) {
                        persistenceUnit = s;
                        break;
                    }
                    GetPersistenceUnitProvider().SetPersistenceUnit(this, persistenceUnit);
                } else {
                    throw new Net.TheVpc.Upa.Exceptions.MissingDefaultPersistenceUnitException();
                }
            }
            return persistenceUnit;
        }


        public virtual void SetPersistenceUnit(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.PersistenceUnit newPU = GetPersistenceUnit(name);
            Net.TheVpc.Upa.PersistenceUnit oldPU = GetPersistenceUnitProvider().GetPersistenceUnit(this);
            if (oldPU != newPU) {
                GetPersistenceUnitProvider().SetPersistenceUnit(this, GetPersistenceUnit(name));
            }
        }


        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.PersistenceUnit> GetPersistenceUnits() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            lock (persistenceUnits) {
                return new System.Collections.Generic.List<Net.TheVpc.Upa.PersistenceUnit>((persistenceUnits).Values);
            }
        }


        public virtual Net.TheVpc.Upa.PersistenceUnit GetPersistenceUnit(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            lock (persistenceUnits) {
                Net.TheVpc.Upa.PersistenceUnit persistenceUnit = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.PersistenceUnit>(persistenceUnits,name);
                if (persistenceUnit == null) {
                    throw new Net.TheVpc.Upa.Exceptions.NoSuchPersistenceUnitException(name);
                }
                return persistenceUnit;
            }
        }


        public virtual Net.TheVpc.Upa.ObjectFactory GetFactory() {
            return factory;
        }


        public virtual bool ContainsPersistenceUnit(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (name == null) {
                name = "";
            }
            lock (persistenceUnits) {
                return persistenceUnits.ContainsKey(name);
            }
        }


        public virtual Net.TheVpc.Upa.PersistenceUnit AddPersistenceUnit(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (name == null) {
                name = "";
            }
            Net.TheVpc.Upa.PersistenceUnit persistenceUnit = GetFactory().CreateObject<Net.TheVpc.Upa.PersistenceUnit>(typeof(Net.TheVpc.Upa.PersistenceUnit));
            //        persistenceUnit.setName(name);
            //        persistenceUnit.setPersistenceGroup(this);
            persistenceUnit.Init(name, this);
            lock (persistenceUnits) {
                if (persistenceUnits.ContainsKey(name)) {
                    throw new Net.TheVpc.Upa.Exceptions.PersistenceUnitAlreadyExistsException(name);
                }
                listeners.FireOnCreatePersistenceUnit(new Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent(persistenceUnit, this, Net.TheVpc.Upa.EventPhase.BEFORE));
                persistenceUnits[name]=persistenceUnit;
                Net.TheVpc.Upa.PersistenceUnit oldPersistenceUnit = GetPersistenceUnitProvider().GetPersistenceUnit(this);
                if (oldPersistenceUnit == null) {
                    SetPersistenceUnit(persistenceUnit.GetName());
                }
                listeners.FireOnCreatePersistenceUnit(new Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent(persistenceUnit, this, Net.TheVpc.Upa.EventPhase.AFTER));
            }
            log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Create PersistenceUnit {0}/{1}",null,new object[] { GetName(), persistenceUnit.GetName() }));
            return persistenceUnit;
        }


        public virtual void DropPersistenceUnit(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (name == null) {
                name = "";
            }
            lock (persistenceUnits) {
                if (!persistenceUnits.ContainsKey(name)) {
                    throw new Net.TheVpc.Upa.Exceptions.NoSuchPersistenceUnitException(name);
                }
                Net.TheVpc.Upa.PersistenceUnit persistenceUnit = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.PersistenceUnit>(persistenceUnits,name);
                if (!persistenceUnit.IsClosed()) {
                    persistenceUnit.Close();
                }
                listeners.FireOnDropPersistenceUnit(new Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent(persistenceUnit, this, Net.TheVpc.Upa.EventPhase.BEFORE));
                persistenceUnits.Remove(name);
                listeners.FireOnDropPersistenceUnit(new Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent(persistenceUnit, this, Net.TheVpc.Upa.EventPhase.AFTER));
            }
        }

        private void CheckManagedSession(Net.TheVpc.Upa.Session session) {
        }


        public virtual bool CurrentSessionExists() {
            return GetSessionContextProvider().GetSession(this) != null;
        }


        public virtual Net.TheVpc.Upa.Session GetCurrentSession() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Session session = GetSessionContextProvider().GetSession(this);
            if (session == null) {
                throw new Net.TheVpc.Upa.Exceptions.CurrentSessionNotFoundException();
            }
            return session;
        }


        public virtual Net.TheVpc.Upa.Session FindCurrentSession() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetSessionContextProvider().GetSession(this);
        }

        public virtual void SetCurrentSession(Net.TheVpc.Upa.Session session) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            lock (sessions) {
                if (!sessions.Contains(session)) {
                    throw new System.Exception("Session not found");
                }
            }
            CheckManagedSession(session);
            log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Session Changed {0} for PersistenceGroup {1}",null,new object[] { session, GetName() }));
            GetSessionContextProvider().SetSession(this, session);
        }


        public virtual Net.TheVpc.Upa.Session OpenSession() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Session session = GetFactory().CreateObject<Net.TheVpc.Upa.Session>(typeof(Net.TheVpc.Upa.Session), null);
            session.Init(this);
            lock (sessions) {
                sessions.Add(session);
                SetCurrentSession(session);
                session.AddSessionListener(new Net.TheVpc.Upa.Impl.CloseSessionListener(this));
            }
            return session;
        }

        protected internal virtual void OnSessionClosed(Net.TheVpc.Upa.Session session) {
            lock (sessions) {
                sessions.Remove(session);
                GetSessionContextProvider().SetSession(this, null);
            }
        }


        public override string ToString() {
            return System.Convert.ToString(name);
        }


        public virtual void Close() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("PersistenceGroup {0} Closing",null,GetName()));
            lock (sessions) {
                foreach (Net.TheVpc.Upa.Session next in sessions) {
                    next.Close();
                }
                sessions.Clear();
            }
            lock (persistenceUnits) {
                foreach (Net.TheVpc.Upa.PersistenceUnit persistenceUnit in (persistenceUnits).Values) {
                    persistenceUnit.Close();
                }
                persistenceUnits.Clear();
            }
            closed = true;
            log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("PersistenceGroup {0} Closed",null,GetName()));
        }


        public virtual void AddPersistenceUnitDefinitionListener(Net.TheVpc.Upa.Callbacks.PersistenceUnitDefinitionListener definitionListener) {
            listeners.AddPersistenceUnitDefinitionListener(definitionListener);
        }


        public virtual void RemovePersistenceUnitDefinitionListener(Net.TheVpc.Upa.Callbacks.PersistenceUnitDefinitionListener definitionListener) {
            listeners.RemovePersistenceUnitDefinitionListener(definitionListener);
        }

        public virtual void AddContextAnnotationStrategyFilter(Net.TheVpc.Upa.Config.ScanFilter filter) {
            filters.Add(filter);
        }

        public virtual void RemoveContextAnnotationStrategyFilter(Net.TheVpc.Upa.Config.ScanFilter filter) {
            filters.Remove(filter);
        }

        public virtual Net.TheVpc.Upa.Config.ScanFilter[] GetContextAnnotationStrategyFilters() {
            return filters.ToArray();
        }


        public virtual bool IsClosed() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return closed;
        }

        public virtual Net.TheVpc.Upa.UPASecurityManager GetSecurityManager() {
            return securityManager;
        }

        public virtual void SetSecurityManager(Net.TheVpc.Upa.UPASecurityManager securityManager) {
            this.securityManager = securityManager;
        }

        public virtual Net.TheVpc.Upa.PersistenceGroupSecurityManager GetPersistenceGroupSecurityManager() {
            return persistenceGroupSecurityManager;
        }

        public virtual void SetPersistenceGroupSecurityManager(Net.TheVpc.Upa.PersistenceGroupSecurityManager persistenceGroupSecurityManager) {
            this.persistenceGroupSecurityManager = persistenceGroupSecurityManager;
        }

        public virtual void AddCallback(Net.TheVpc.Upa.Callback callback) {
            if (callback.GetCallbackType() == Net.TheVpc.Upa.CallbackType.ON_EVAL) {
                throw new Net.TheVpc.Upa.Exceptions.UPAException("Unsupported", callback.GetCallbackType());
            }
            listeners.AddCallback(callback);
        }

        public virtual void RemoveCallback(Net.TheVpc.Upa.Callback callback) {
            listeners.RemoveCallback(callback);
        }

        public virtual Net.TheVpc.Upa.Callback[] GetCallbacks(Net.TheVpc.Upa.CallbackType nameFilter, Net.TheVpc.Upa.ObjectType objectType, string name, bool system, bool preparedOnly, Net.TheVpc.Upa.EventPhase phase) {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Callback> callbackInvokers = listeners.GetCallbacks(nameFilter, objectType, name, system, preparedOnly, phase);
            return callbackInvokers.ToArray();
        }

        protected internal virtual Net.TheVpc.Upa.InvokeContext PrepareInvokeContext(Net.TheVpc.Upa.InvokeContext c) {
            if (c == null) {
                c = new Net.TheVpc.Upa.InvokeContext();
            } else {
                c = c.Copy();
            }
            c.SetPersistenceGroup(this);
            if (c.GetPersistenceUnit() != null && c.GetPersistenceUnit().GetPersistenceGroup() != this) {
                c.SetPersistenceUnit(null);
            }
            return c;
        }


        public virtual  T Invoke<T>(Net.TheVpc.Upa.Action<T> action, Net.TheVpc.Upa.InvokeContext invokeContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetContext().Invoke<T>(action, PrepareInvokeContext(invokeContext));
        }


        public virtual  T InvokePrivileged<T>(Net.TheVpc.Upa.Action<T> action, Net.TheVpc.Upa.InvokeContext invokeContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetContext().Invoke<T>(action, PrepareInvokeContext(invokeContext));
        }


        public virtual void Invoke(Net.TheVpc.Upa.VoidAction action, Net.TheVpc.Upa.InvokeContext invokeContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            GetContext().Invoke(action, PrepareInvokeContext(invokeContext));
        }


        public virtual void InvokePrivileged(Net.TheVpc.Upa.VoidAction action, Net.TheVpc.Upa.InvokeContext invokeContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            GetContext().InvokePrivileged(action, PrepareInvokeContext(invokeContext));
        }


        public virtual  T Invoke<T>(Net.TheVpc.Upa.Action<T> action) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetContext().Invoke<T>(action, PrepareInvokeContext(null));
        }


        public virtual  T InvokePrivileged<T>(Net.TheVpc.Upa.Action<T> action) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetContext().InvokePrivileged<T>(action, PrepareInvokeContext(null));
        }


        public virtual void Invoke(Net.TheVpc.Upa.VoidAction action) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            GetContext().Invoke(action, PrepareInvokeContext(null));
        }


        public virtual void InvokePrivileged(Net.TheVpc.Upa.VoidAction action) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            GetContext().InvokePrivileged(action, PrepareInvokeContext(null));
        }
    }
}
