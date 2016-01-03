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
namespace Net.Vpc.Upa.Impl
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/11/12 9:47 PM
     */
    public class DefaultPersistenceGroup : Net.Vpc.Upa.PersistenceGroup {

        protected internal static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.DefaultPersistenceGroup)).FullName);

        private Net.Vpc.Upa.UPAContext context;

        private Net.Vpc.Upa.ObjectFactory factory;

        private readonly System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.PersistenceUnit> persistenceUnits = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.PersistenceUnit>();

        private readonly System.Collections.Generic.IList<Net.Vpc.Upa.Session> sessions = new System.Collections.Generic.List<Net.Vpc.Upa.Session>();

        private Net.Vpc.Upa.SessionContextProvider sessionContextProvider;

        private Net.Vpc.Upa.PersistenceUnitProvider persistenceUnitProvider;

        private string name;

        private bool closed;

        private bool autoScan = true;

        private readonly System.Collections.Generic.IList<Net.Vpc.Upa.Config.ScanFilter> filters = new System.Collections.Generic.List<Net.Vpc.Upa.Config.ScanFilter>();

        private Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository decorationRepository;

        private Net.Vpc.Upa.UPASecurityManager securityManager;

        private Net.Vpc.Upa.PersistenceGroupSecurityManager persistenceGroupSecurityManager;

        private Net.Vpc.Upa.Impl.Event.PersistenceGroupListenerManager listeners;

        public DefaultPersistenceGroup() {
            listeners = new Net.Vpc.Upa.Impl.Event.PersistenceGroupListenerManager(this);
        }


        public virtual void Scan(Net.Vpc.Upa.Config.ScanSource strategy, Net.Vpc.Upa.ScanListener listener, bool configure) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            decorationRepository = new Net.Vpc.Upa.Impl.Config.Decorations.DefaultDecorationRepository(GetName() + "-PGRepo", true);
            log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("{0} : Configuring PersistenceGroup with strategy {1}",null,new object[] { GetName(), strategy }));
            Net.Vpc.Upa.Impl.Config.URLAnnotationStrategySupport s = new Net.Vpc.Upa.Impl.Config.URLAnnotationStrategySupport();
            s.Scan(this, strategy, decorationRepository, configure ? ((Net.Vpc.Upa.ScanListener)(new Net.Vpc.Upa.Impl.Config.ConfigureScanListener(listener))) : listener);
            if (securityManager == null) {
                securityManager = GetFactory().CreateObject<Net.Vpc.Upa.UPASecurityManager>(typeof(Net.Vpc.Upa.UPASecurityManager));
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

        public virtual void SetContext(Net.Vpc.Upa.UPAContext context) {
            this.context = context;
        }

        public virtual void SetFactory(Net.Vpc.Upa.ObjectFactory factory) {
            this.factory = factory;
        }

        public virtual void SetName(string name) {
            this.name = name;
        }

        public virtual Net.Vpc.Upa.UPAContext GetContext() {
            return context;
        }

        protected internal virtual Net.Vpc.Upa.SessionContextProvider GetSessionContextProvider() {
            if (sessionContextProvider == null) {
                sessionContextProvider = GetFactory().CreateObject<Net.Vpc.Upa.SessionContextProvider>(typeof(Net.Vpc.Upa.SessionContextProvider));
            }
            return sessionContextProvider;
        }

        protected internal virtual Net.Vpc.Upa.PersistenceUnitProvider GetPersistenceUnitProvider() {
            if (persistenceUnitProvider == null) {
                persistenceUnitProvider = GetFactory().CreateObject<Net.Vpc.Upa.PersistenceUnitProvider>(typeof(Net.Vpc.Upa.PersistenceUnitProvider));
            }
            return persistenceUnitProvider;
        }


        public virtual Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.PersistenceUnit persistenceUnit = GetPersistenceUnitProvider().GetPersistenceUnit(this);
            if (persistenceUnit == null) {
                System.Collections.Generic.IList<Net.Vpc.Upa.PersistenceUnit> persistenceUnitsCurr = GetPersistenceUnits();
                if ((persistenceUnitsCurr).Count > 0) {
                    foreach (Net.Vpc.Upa.PersistenceUnit s in persistenceUnitsCurr) {
                        persistenceUnit = s;
                        break;
                    }
                    GetPersistenceUnitProvider().SetPersistenceUnit(this, persistenceUnit);
                } else {
                    throw new Net.Vpc.Upa.Exceptions.MissingDefaultPersistenceUnitException();
                }
            }
            return persistenceUnit;
        }


        public virtual void SetPersistenceUnit(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.PersistenceUnit newPU = GetPersistenceUnit(name);
            Net.Vpc.Upa.PersistenceUnit oldPU = GetPersistenceUnitProvider().GetPersistenceUnit(this);
            if (oldPU != newPU) {
                GetPersistenceUnitProvider().SetPersistenceUnit(this, GetPersistenceUnit(name));
            }
        }


        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.PersistenceUnit> GetPersistenceUnits() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            lock (persistenceUnits) {
                return new System.Collections.Generic.List<Net.Vpc.Upa.PersistenceUnit>((persistenceUnits).Values);
            }
        }


        public virtual Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            lock (persistenceUnits) {
                Net.Vpc.Upa.PersistenceUnit persistenceUnit = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.PersistenceUnit>(persistenceUnits,name);
                if (persistenceUnit == null) {
                    throw new Net.Vpc.Upa.Exceptions.NoSuchPersistenceUnitException(name);
                }
                return persistenceUnit;
            }
        }


        public virtual Net.Vpc.Upa.ObjectFactory GetFactory() {
            return factory;
        }


        public virtual bool ContainsPersistenceUnit(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (name == null) {
                name = "";
            }
            lock (persistenceUnits) {
                return persistenceUnits.ContainsKey(name);
            }
        }


        public virtual Net.Vpc.Upa.PersistenceUnit AddPersistenceUnit(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (name == null) {
                name = "";
            }
            Net.Vpc.Upa.PersistenceUnit persistenceUnit = GetFactory().CreateObject<Net.Vpc.Upa.PersistenceUnit>(typeof(Net.Vpc.Upa.PersistenceUnit));
            //        persistenceUnit.setName(name);
            //        persistenceUnit.setPersistenceGroup(this);
            persistenceUnit.Init(name, this);
            lock (persistenceUnits) {
                if (persistenceUnits.ContainsKey(name)) {
                    throw new Net.Vpc.Upa.Exceptions.PersistenceUnitAlreadyExistsException(name);
                }
                Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event = new Net.Vpc.Upa.Callbacks.PersistenceUnitEvent(persistenceUnit, this);
                listeners.FireOnCreatePersistenceUnit(@event, Net.Vpc.Upa.EventPhase.BEFORE);
                persistenceUnits[name]=persistenceUnit;
                Net.Vpc.Upa.PersistenceUnit oldPersistenceUnit = GetPersistenceUnitProvider().GetPersistenceUnit(this);
                if (oldPersistenceUnit == null) {
                    SetPersistenceUnit(persistenceUnit.GetName());
                }
                listeners.FireOnCreatePersistenceUnit(@event, Net.Vpc.Upa.EventPhase.AFTER);
            }
            log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Create PersistenceUnit {0}/{1}",null,new object[] { GetName(), persistenceUnit.GetName() }));
            return persistenceUnit;
        }


        public virtual void DropPersistenceUnit(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (name == null) {
                name = "";
            }
            lock (persistenceUnits) {
                if (!persistenceUnits.ContainsKey(name)) {
                    throw new Net.Vpc.Upa.Exceptions.NoSuchPersistenceUnitException(name);
                }
                Net.Vpc.Upa.PersistenceUnit persistenceUnit = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.PersistenceUnit>(persistenceUnits,name);
                if (!persistenceUnit.IsClosed()) {
                    persistenceUnit.Close();
                }
                Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event = new Net.Vpc.Upa.Callbacks.PersistenceUnitEvent(persistenceUnit, this);
                listeners.FireOnDropPersistenceUnit(@event, Net.Vpc.Upa.EventPhase.BEFORE);
                persistenceUnits.Remove(name);
                listeners.FireOnDropPersistenceUnit(@event, Net.Vpc.Upa.EventPhase.AFTER);
            }
        }

        private void CheckManagedSession(Net.Vpc.Upa.Session session) {
        }


        public virtual bool CurrentSessionExists() {
            return GetSessionContextProvider().GetSession(this) != null;
        }


        public virtual Net.Vpc.Upa.Session GetCurrentSession() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Session session = GetSessionContextProvider().GetSession(this);
            if (session == null) {
                throw new Net.Vpc.Upa.Exceptions.CurrentSessionNotFoundException();
            }
            return session;
        }

        public virtual void SetCurrentSession(Net.Vpc.Upa.Session session) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            lock (sessions) {
                if (!sessions.Contains(session)) {
                    throw new System.Exception("Session not found");
                }
            }
            CheckManagedSession(session);
            log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Session Changed {0} for PersistenceGroup {1}",null,new object[] { session, GetName() }));
            GetSessionContextProvider().SetSession(this, session);
        }


        public virtual Net.Vpc.Upa.Session OpenSession() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Session session = GetFactory().CreateObject<Net.Vpc.Upa.Session>(typeof(Net.Vpc.Upa.Session), null);
            session.Init(this);
            lock (sessions) {
                sessions.Add(session);
                SetCurrentSession(session);
                session.AddSessionListener(new Net.Vpc.Upa.Impl.CloseSessionListener(this));
            }
            return session;
        }

        protected internal virtual void OnSessionClosed(Net.Vpc.Upa.Session session) {
            lock (sessions) {
                sessions.Remove(session);
                GetSessionContextProvider().SetSession(this, null);
            }
        }


        public override string ToString() {
            return System.Convert.ToString(name);
        }


        public virtual void Close() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("PersistenceGroup {0} Closing",null,GetName()));
            lock (sessions) {
                foreach (Net.Vpc.Upa.Session next in sessions) {
                    next.Close();
                }
                sessions.Clear();
            }
            lock (persistenceUnits) {
                foreach (Net.Vpc.Upa.PersistenceUnit persistenceUnit in (persistenceUnits).Values) {
                    persistenceUnit.Close();
                }
                persistenceUnits.Clear();
            }
            closed = true;
            log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("PersistenceGroup {0} Closed",null,GetName()));
        }


        public virtual void AddPersistenceUnitDefinitionListener(Net.Vpc.Upa.Callbacks.PersistenceUnitDefinitionListener definitionListener) {
            listeners.AddPersistenceUnitDefinitionListener(definitionListener);
        }


        public virtual void RemovePersistenceUnitDefinitionListener(Net.Vpc.Upa.Callbacks.PersistenceUnitDefinitionListener definitionListener) {
            listeners.RemovePersistenceUnitDefinitionListener(definitionListener);
        }

        public virtual void AddContextAnnotationStrategyFilter(Net.Vpc.Upa.Config.ScanFilter filter) {
            filters.Add(filter);
        }

        public virtual void RemoveContextAnnotationStrategyFilter(Net.Vpc.Upa.Config.ScanFilter filter) {
            filters.Remove(filter);
        }

        public virtual Net.Vpc.Upa.Config.ScanFilter[] GetContextAnnotationStrategyFilters() {
            return filters.ToArray();
        }


        public virtual bool IsClosed() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return closed;
        }

        public virtual Net.Vpc.Upa.UPASecurityManager GetSecurityManager() {
            return securityManager;
        }

        public virtual void SetSecurityManager(Net.Vpc.Upa.UPASecurityManager securityManager) {
            this.securityManager = securityManager;
        }

        public virtual Net.Vpc.Upa.PersistenceGroupSecurityManager GetPersistenceGroupSecurityManager() {
            return persistenceGroupSecurityManager;
        }

        public virtual void SetPersistenceGroupSecurityManager(Net.Vpc.Upa.PersistenceGroupSecurityManager persistenceGroupSecurityManager) {
            this.persistenceGroupSecurityManager = persistenceGroupSecurityManager;
        }

        public virtual void AddCallback(Net.Vpc.Upa.Callback callback) {
            if (callback.GetCallbackType() == Net.Vpc.Upa.CallbackType.ON_EVAL) {
                throw new Net.Vpc.Upa.Exceptions.UPAException("Unsupported", callback.GetCallbackType());
            }
            listeners.AddCallback(callback);
        }

        public virtual void RemoveCallback(Net.Vpc.Upa.Callback callback) {
            listeners.RemoveCallback(callback);
        }

        public virtual Net.Vpc.Upa.Callback[] GetCallbacks(Net.Vpc.Upa.CallbackType nameFilter, Net.Vpc.Upa.ObjectType objectType, string name, bool system, Net.Vpc.Upa.EventPhase phase) {
            System.Collections.Generic.IList<Net.Vpc.Upa.Callback> callbackInvokers = listeners.GetCallbacks(nameFilter, objectType, name, system, phase);
            return callbackInvokers.ToArray();
        }
    }
}
