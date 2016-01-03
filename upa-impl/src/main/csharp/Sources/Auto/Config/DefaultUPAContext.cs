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
namespace Net.Vpc.Upa.Impl.Config
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DefaultUPAContext : Net.Vpc.Upa.UPAContext {

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Config.DefaultUPAContext)).FullName);

        private Net.Vpc.Upa.ObjectFactory bootstrapObjectFactory;

        private Net.Vpc.Upa.UPAContextFactory objectFactory;

        private Net.Vpc.Upa.PersistenceGroupContextProvider persistenceGroupContextProvider;

        private readonly System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.PersistenceGroup> persistenceGroups = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.PersistenceGroup>();

        private readonly System.Collections.Generic.IList<Net.Vpc.Upa.Config.ScanFilter> filters = new System.Collections.Generic.List<Net.Vpc.Upa.Config.ScanFilter>();

        private readonly System.Collections.Generic.IList<Net.Vpc.Upa.CloseListener> closeListeners = new System.Collections.Generic.List<Net.Vpc.Upa.CloseListener>();

        private System.Collections.Generic.IDictionary<string , object> properties = new System.Collections.Generic.Dictionary<string , object>();

        private readonly Net.Vpc.Upa.Impl.Config.Decorations.DecorationRepository decorationRepository = new Net.Vpc.Upa.Impl.Config.Decorations.DefaultDecorationRepository("UPAContextRepo", true);

        private Net.Vpc.Upa.Persistence.UPAContextConfig bootstratContextConfig;

        private Net.Vpc.Upa.InvokeContext emptyInvokeContext = new Net.Vpc.Upa.InvokeContext();

        private Net.Vpc.Upa.Impl.Event.UPAContextListenerManager listeners;

        public DefaultUPAContext() {
            listeners = new Net.Vpc.Upa.Impl.Event.UPAContextListenerManager(this);
        }

        public virtual Net.Vpc.Upa.Persistence.UPAContextConfig GetBootstrapContextConfig() {
            if (bootstratContextConfig == null) {
                Net.Vpc.Upa.Impl.Config.DefaultUPAContextLoader @object = new Net.Vpc.Upa.Impl.Config.DefaultUPAContextLoader();
                Net.Vpc.Upa.Persistence.UPAContextConfig contextConfig = @object.Parse();
                if (contextConfig.GetFilters() != null) {
                    int count = 0;
                    foreach (Net.Vpc.Upa.Config.ScanFilter filter in contextConfig.GetFilters()) {
                        if (filter != null) {
                            count++;
                            AddScanFilter(filter);
                        }
                    }
                    if (count == 0 && (contextConfig.GetAutoScan() == null || (contextConfig.GetAutoScan()).Value)) {
                        AddScanFilter(new Net.Vpc.Upa.Config.ScanFilter(null, null, false, Net.Vpc.Upa.Persistence.UPAContextConfig.XML_ORDER));
                    }
                }
                bootstratContextConfig = contextConfig;
            }
            return bootstratContextConfig;
        }

        public virtual void Start(Net.Vpc.Upa.ObjectFactory factory) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Starting UPAContext",null));
            bootstrapObjectFactory = factory;
            objectFactory = new Net.Vpc.Upa.Impl.DefaultUPAContextFactory(bootstrapObjectFactory.CreateObject<Net.Vpc.Upa.ObjectFactory>(typeof(Net.Vpc.Upa.ObjectFactory)));
            objectFactory.SetParentFactory(bootstrapObjectFactory);
            LoadConfig();
        }

        public virtual void LoadConfig() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Scan(GetFactory().CreateContextScanSource(false), null, true);
            foreach (Net.Vpc.Upa.PersistenceGroup g in GetPersistenceGroups()) {
                foreach (Net.Vpc.Upa.PersistenceUnit u in g.GetPersistenceUnits()) {
                    if (!u.IsStarted() && u.IsAutoStart()) {
                        u.Start();
                    }
                }
            }
        }

        public virtual void Scan(Net.Vpc.Upa.Config.ScanSource configurationStrategy, Net.Vpc.Upa.ScanListener listener, bool configure) {
            Net.Vpc.Upa.Impl.Config.URLAnnotationStrategySupport support = new Net.Vpc.Upa.Impl.Config.URLAnnotationStrategySupport();
            support.Scan(this, configurationStrategy, decorationRepository, configure ? ((Net.Vpc.Upa.ScanListener)(new Net.Vpc.Upa.Impl.Config.ConfigureScanListener(listener))) : listener);
        }

        public virtual bool IsContextProviderSet() {
            return persistenceGroupContextProvider != null;
        }

        public virtual Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceGroup().GetPersistenceUnit();
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.PersistenceGroup> GetPersistenceGroups() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return new System.Collections.Generic.List<Net.Vpc.Upa.PersistenceGroup>((persistenceGroups).Values);
        }

        public virtual Net.Vpc.Upa.PersistenceGroup GetPersistenceGroup() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceGroupContextProvider().GetPersistenceGroup();
        }

        public virtual void SetPersistenceGroup(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            GetPersistenceGroupContextProvider().SetPersistenceGroup(GetPersistenceGroup(name));
        }

        private Net.Vpc.Upa.PersistenceGroupContextProvider GetPersistenceGroupContextProvider() {
            if (persistenceGroupContextProvider == null) {
                throw new System.ArgumentException ("PersistenceGroupContextProvider not found");
            }
            return persistenceGroupContextProvider;
        }

        public virtual void SetPersistenceGroupContextProvider(Net.Vpc.Upa.PersistenceGroupContextProvider contextProvider) {
            this.persistenceGroupContextProvider = contextProvider;
        }

        public Net.Vpc.Upa.UPAContextFactory GetFactory() {
            return objectFactory;
        }

        public virtual Net.Vpc.Upa.PersistenceGroup GetPersistenceGroup(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (Net.Vpc.Upa.Impl.Util.Strings.IsNullOrEmpty(name)) {
                name = "";
            }
            if (!persistenceGroups.ContainsKey(name)) {
                throw new System.ArgumentException ("PersistenceGroup " + name + " does not exist");
            }
            return Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.PersistenceGroup>(persistenceGroups,name);
        }

        public virtual bool ContainsPersistenceGroup(string name) {
            if (Net.Vpc.Upa.Impl.Util.Strings.IsNullOrEmpty(name)) {
                name = "";
            }
            return persistenceGroups.ContainsKey(name);
        }

        public virtual Net.Vpc.Upa.PersistenceGroup AddPersistenceGroup(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (Net.Vpc.Upa.Impl.Util.Strings.IsNullOrEmpty(name)) {
                name = "";
            }
            if (persistenceGroups.ContainsKey(name)) {
                throw new System.ArgumentException ("PersistenceGroup " + name + " already exists");
            }
            Net.Vpc.Upa.ObjectFactory factory = GetFactory();
            if (!IsContextProviderSet()) {
                SetPersistenceGroupContextProvider(factory.CreateObject<Net.Vpc.Upa.PersistenceGroupContextProvider>(typeof(Net.Vpc.Upa.PersistenceGroupContextProvider)));
            }
            Net.Vpc.Upa.ObjectFactory persistenceGroupFactory = GetFactory().CreateObject<Net.Vpc.Upa.ObjectFactory>(typeof(Net.Vpc.Upa.ObjectFactory));
            persistenceGroupFactory.SetParentFactory(factory);
            Net.Vpc.Upa.PersistenceGroup persistenceGroup = factory.CreateObject<Net.Vpc.Upa.PersistenceGroup>(typeof(Net.Vpc.Upa.PersistenceGroup));
            Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter a = new Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter(persistenceGroup);
            a.SetProperty("context", this);
            a.SetProperty("factory", objectFactory);
            a.SetProperty("name", name);
            Net.Vpc.Upa.Callbacks.PersistenceGroupEvent evt = new Net.Vpc.Upa.Callbacks.PersistenceGroupEvent(persistenceGroup, this);
            listeners.FireOnCreatePersistenceGroup(evt, Net.Vpc.Upa.EventPhase.BEFORE);
            persistenceGroups[name]=persistenceGroup;
            if (GetPersistenceGroupContextProvider().GetPersistenceGroup() == null) {
                GetPersistenceGroupContextProvider().SetPersistenceGroup(persistenceGroup);
            }
            listeners.FireOnCreatePersistenceGroup(evt, Net.Vpc.Upa.EventPhase.AFTER);
            return persistenceGroup;
        }


        public virtual void RemovePersistenceGroup(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.PersistenceGroup persistenceGroup = GetPersistenceGroup(name);
            Net.Vpc.Upa.Callbacks.PersistenceGroupEvent @event = new Net.Vpc.Upa.Callbacks.PersistenceGroupEvent(persistenceGroup, this);
            listeners.FireOnDropPersistenceGroup(@event, Net.Vpc.Upa.EventPhase.BEFORE);
            if (persistenceGroup.IsClosed()) {
                persistenceGroup.Close();
            }
            persistenceGroups.Remove(name);
            listeners.FireOnDropPersistenceGroup(@event, Net.Vpc.Upa.EventPhase.AFTER);
        }


        public virtual void AddPersistenceGroupDefinitionListener(Net.Vpc.Upa.Callbacks.PersistenceGroupDefinitionListener persistenceGroupDefinitionListener) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            listeners.AddPersistenceGroupDefinitionListener(persistenceGroupDefinitionListener);
        }


        public virtual void RemovePersistenceGroupDefinitionListener(Net.Vpc.Upa.Callbacks.PersistenceGroupDefinitionListener persistenceGroupDefinitionListener) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            listeners.RemovePersistenceGroupDefinitionListener(persistenceGroupDefinitionListener);
        }

        public virtual Net.Vpc.Upa.Callbacks.PersistenceGroupDefinitionListener[] GetPersistenceGroupDefinitionListeners() {
            return listeners.GetPersistenceGroupDefinitionListeners();
        }


        public virtual  T MakeSessionAware<T>(T instance) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return MakeSessionAware<T>(instance, (Net.Vpc.Upa.MethodFilter) null);
        }


        public virtual  T MakeSessionAware<T>(T instance, System.Type sessionAwareMethodAnnotation) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return MakeSessionAware<T>(instance, sessionAwareMethodAnnotation == null ? null : new Net.Vpc.Upa.Impl.Config.AnnotationMethodFilter(sessionAwareMethodAnnotation, decorationRepository));
        }


        public virtual  T MakeSessionAware<T>(T instance, Net.Vpc.Upa.MethodFilter methodFilter) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return (T) Net.Vpc.Upa.Impl.Util.PlatformUtils.CreateObjectInterceptor<object>(instance.GetType(), new Net.Vpc.Upa.Impl.Config.MakeSessionAwareMethodInterceptor<T>(this, methodFilter, instance));
        }


        public virtual  T MakeSessionAware<T>(System.Type type, Net.Vpc.Upa.MethodFilter methodFilter) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return (T) Net.Vpc.Upa.Impl.Util.PlatformUtils.CreateObjectInterceptor<T>(type, new Net.Vpc.Upa.Impl.Config.MakeSessionAwareMethodInterceptor2<T>(methodFilter));
        }


        public virtual  T Invoke<T>(Net.Vpc.Upa.Action<T> action, Net.Vpc.Upa.InvokeContext invokeContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (invokeContext == null) {
                invokeContext = emptyInvokeContext;
            }
            Net.Vpc.Upa.PersistenceGroup persistenceGroup = Net.Vpc.Upa.UPA.GetPersistenceGroup();
            Net.Vpc.Upa.Session s = null;
            if (persistenceGroup.CurrentSessionExists()) {
                s = persistenceGroup.GetCurrentSession();
            }
            bool sessionCreated = false;
            bool loginCreated = false;
            if (s == null) {
                s = persistenceGroup.OpenSession();
                sessionCreated = true;
            }
            Net.Vpc.Upa.PersistenceUnit pu = persistenceGroup.GetPersistenceUnit();
            if (invokeContext.GetLogin() != null) {
                pu.Login(invokeContext.GetLogin(), invokeContext.GetCredentials());
                loginCreated = true;
            }
            bool transactionCreated = false;
            if (invokeContext.GetTransactionType() != null) {
                pu.BeginTransaction(invokeContext.GetTransactionType());
                transactionCreated = true;
            }
            T ret = default(T);
            try {
                ret = action.Run();
                if (transactionCreated) {
                    pu.CommitTransaction();
                }
            } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
                if (transactionCreated) {
                    pu.RollbackTransaction();
                }
                throw e;
            } catch (System.Exception e) {
                if (transactionCreated) {
                    pu.RollbackTransaction();
                }
                throw new Net.Vpc.Upa.Exceptions.UPAException(e, new Net.Vpc.Upa.Types.I18NString("InvokeError"));
            } finally {
                if (loginCreated) {
                    pu.Logout();
                }
                if (sessionCreated) {
                    s.Close();
                }
            }
            return ret;
        }


        public virtual  T InvokePrivileged<T>(Net.Vpc.Upa.Action<T> action, Net.Vpc.Upa.InvokeContext invokeContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (invokeContext == null) {
                invokeContext = emptyInvokeContext;
            }
            Net.Vpc.Upa.PersistenceGroup persistenceGroup = Net.Vpc.Upa.UPA.GetPersistenceGroup();
            Net.Vpc.Upa.Session s = null;
            if (persistenceGroup.CurrentSessionExists()) {
                s = persistenceGroup.GetCurrentSession();
            }
            bool sessionCreated = false;
            bool loginCreated = false;
            if (s == null) {
                s = persistenceGroup.OpenSession();
                sessionCreated = true;
            }
            Net.Vpc.Upa.PersistenceUnit pu = persistenceGroup.GetPersistenceUnit();
            pu.LoginPrivileged(invokeContext.GetLogin());
            loginCreated = true;
            bool transactionCreated = false;
            if (invokeContext.GetTransactionType() != null) {
                pu.BeginTransaction(invokeContext.GetTransactionType());
                transactionCreated = true;
            }
            T ret = default(T);
            try {
                ret = action.Run();
                if (transactionCreated) {
                    pu.CommitTransaction();
                }
            } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
                if (transactionCreated) {
                    pu.RollbackTransaction();
                }
                throw e;
            } catch (System.Exception e) {
                if (transactionCreated) {
                    pu.RollbackTransaction();
                }
                throw new Net.Vpc.Upa.Exceptions.UPAException(e, new Net.Vpc.Upa.Types.I18NString("InvokeError"));
            } finally {
                if (loginCreated) {
                    pu.Logout();
                }
                if (sessionCreated) {
                    s.Close();
                }
            }
            return ret;
        }

        public virtual void Close() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.CloseListener[] li = GetCloseListeners();
            foreach (Net.Vpc.Upa.CloseListener listener in li) {
                listener.BeforeClose(this);
            }
            lock (persistenceGroups) {
                foreach (string name in new System.Collections.Generic.HashSet<string>(new System.Collections.Generic.HashSet<string>(persistenceGroups.Keys))) {
                    RemovePersistenceGroup(name);
                }
            }
            foreach (Net.Vpc.Upa.CloseListener listener in li) {
                listener.AfterClose(this);
            }
        }

        public virtual void AddCloseListener(Net.Vpc.Upa.CloseListener listener) {
            lock (closeListeners) {
                closeListeners.Add(listener);
            }
        }

        public virtual void RemoveCloseListener(Net.Vpc.Upa.CloseListener listener) {
            lock (closeListeners) {
                closeListeners.Remove(listener);
            }
        }

        public virtual Net.Vpc.Upa.CloseListener[] GetCloseListeners() {
            return closeListeners.ToArray();
        }

        public virtual void BeginInvocation(System.Reflection.MethodInfo method, System.Collections.Generic.IDictionary<string , object> properties) {
            Net.Vpc.Upa.TransactionType transactionType = Net.Vpc.Upa.Impl.Util.PlatformUtils.GetUndefinedValue<Net.Vpc.Upa.TransactionType>(typeof(Net.Vpc.Upa.TransactionType));
            Net.Vpc.Upa.Config.Decoration r = decorationRepository.GetMethodDecoration(method, (typeof(Net.Vpc.Upa.Config.Transactional)).FullName);
            if (r != null) {
                transactionType = (Net.Vpc.Upa.TransactionType)(System.Enum.Parse(typeof(Net.Vpc.Upa.TransactionType),r.GetString("value")));
            }
            if (transactionType == null) {
                r = decorationRepository.GetMethodDecoration(method, "javax.ejb.TransactionAttribute");
                if (r != null) {
                    try {
                        transactionType = (Net.Vpc.Upa.TransactionType)(System.Enum.Parse(typeof(Net.Vpc.Upa.TransactionType),r.GetString("value")));
                    } catch (System.Exception e) {
                    }
                }
            }
            //not all types are supported, so ignore...
            if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.Vpc.Upa.TransactionType>(typeof(Net.Vpc.Upa.TransactionType), transactionType)) {
                r = decorationRepository.GetTypeDecoration((method).DeclaringType, typeof(Net.Vpc.Upa.Config.Transactional));
                if (r != null) {
                    transactionType = (Net.Vpc.Upa.TransactionType)(System.Enum.Parse(typeof(Net.Vpc.Upa.TransactionType),r.GetString("value")));
                }
            }
            if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.Vpc.Upa.TransactionType>(typeof(Net.Vpc.Upa.TransactionType), transactionType)) {
                r = decorationRepository.GetTypeDecoration((method).DeclaringType, "javax.ejb.TransactionAttribute");
                if (r != null) {
                    try {
                        transactionType = (Net.Vpc.Upa.TransactionType)(System.Enum.Parse(typeof(Net.Vpc.Upa.TransactionType),r.GetString("value")));
                    } catch (System.Exception e) {
                    }
                }
            }
            //not all types are supported, so ignore...
            if (properties == null) {
                properties = new System.Collections.Generic.Dictionary<string , object>();
            }
            properties[(typeof(Net.Vpc.Upa.TransactionType)).FullName]=Net.Vpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.Vpc.Upa.TransactionType>(typeof(Net.Vpc.Upa.TransactionType), transactionType) ? Net.Vpc.Upa.TransactionType.REQUIRED : transactionType;
            BeginInvocation(properties);
        }

        public virtual void BeginInvocation(System.Collections.Generic.IDictionary<string , object> properties) {
            Net.Vpc.Upa.Session s = null;
            Net.Vpc.Upa.PersistenceGroup persistenceGroup = GetPersistenceGroup();
            try {
                s = persistenceGroup.GetCurrentSession();
            } catch (Net.Vpc.Upa.Exceptions.CurrentSessionNotFoundException ignore) {
            }
            //ignore
            bool sessionCreated = false;
            if (s == null) {
                s = persistenceGroup.OpenSession();
                sessionCreated = true;
            }
            Net.Vpc.Upa.TransactionType transactionType = (Net.Vpc.Upa.TransactionType) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(properties,(typeof(Net.Vpc.Upa.TransactionType)).FullName);
            if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.Vpc.Upa.TransactionType>(typeof(Net.Vpc.Upa.TransactionType), transactionType)) {
                transactionType = Net.Vpc.Upa.TransactionType.REQUIRED;
            }
            bool transactionCreated = false;
            Net.Vpc.Upa.PersistenceUnit pu = persistenceGroup.GetPersistenceUnit();
            pu.BeginTransaction(transactionType);
            transactionCreated = true;
            properties["sessionCreated"]=sessionCreated;
            properties["transactionCreated"]=transactionCreated;
        }

        public virtual void EndInvocation(System.Exception error, System.Collections.Generic.IDictionary<string , object> properties) {
            Net.Vpc.Upa.PersistenceUnit persistenceUnit = GetPersistenceUnit();
            bool? sessionCreated = (bool?) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(properties,"sessionCreated");
            if (sessionCreated == null) {
                sessionCreated = false;
            }
            bool? transactionCreated = (bool?) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(properties,"transactionCreated");
            if (transactionCreated == null) {
                transactionCreated = false;
            }
            if (error == null) {
                persistenceUnit.CommitTransaction();
            } else {
                if ((transactionCreated).Value) {
                    try {
                        persistenceUnit.RollbackTransaction();
                    } catch (System.Exception e2) {
                        //errors in rollback are ignored but traced
                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Invocation Error",null,error));
                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Rollback Error",null,e2));
                    }
                }
            }
            if ((sessionCreated).Value) {
                try {
                    if ((sessionCreated).Value) {
                        GetPersistenceGroup().GetCurrentSession().Close();
                    }
                } catch (System.Exception e) {
                    log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Failed to close session after error",null,e));
                }
            }
        }

        public virtual void AddScanFilter(Net.Vpc.Upa.Config.ScanFilter filter) {
            filters.Add(filter);
        }

        public virtual void RemoveScanFilter(Net.Vpc.Upa.Config.ScanFilter filter) {
            filters.Remove(filter);
        }

        public virtual Net.Vpc.Upa.Config.ScanFilter[] GetContextAnnotationStrategyFilters() {
            return filters.ToArray();
        }

        public virtual System.Collections.Generic.IDictionary<string , object> GetProperties() {
            return properties;
        }

        public virtual void SetProperties(System.Collections.Generic.IDictionary<string , object> properties) {
            this.properties = properties;
        }

        private Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] CreateArguments(System.Reflection.MethodInfo m) {
            System.Type[] parameterTypes = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMethodParameterTypes(m);
            Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] aa = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[parameterTypes.Length];
            for (int i = 0; i < aa.Length; i++) {
                aa[i] = new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument(null, parameterTypes[i], i, false);
            }
            return aa;
        }


        public virtual Net.Vpc.Upa.Callback CreateCallback(object instance, System.Reflection.MethodInfo m, Net.Vpc.Upa.CallbackType callbackType, System.Collections.Generic.IDictionary<string , object> configuration) {
            Net.Vpc.Upa.ObjectType objectType = Net.Vpc.Upa.Impl.Util.PlatformUtils.GetUndefinedValue<Net.Vpc.Upa.ObjectType>(typeof(Net.Vpc.Upa.ObjectType));
            if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.Vpc.Upa.ObjectType>(typeof(Net.Vpc.Upa.ObjectType), objectType)) {
                foreach (System.Type parameterType in Net.Vpc.Upa.Impl.FwkConvertUtils.GetMethodParameterTypes(m)) {
                    if (parameterType.Equals(typeof(Net.Vpc.Upa.Callbacks.ContextEvent))) {
                        objectType = Net.Vpc.Upa.ObjectType.CONTEXT;
                        break;
                    }
                    if (parameterType.Equals(typeof(Net.Vpc.Upa.Callbacks.PersistenceGroupEvent))) {
                        objectType = Net.Vpc.Upa.ObjectType.PERSISTENCE_GROUP;
                        break;
                    }
                    if (parameterType.Equals(typeof(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent))) {
                        objectType = Net.Vpc.Upa.ObjectType.PERSISTENCE_UNIT;
                        break;
                    }
                    if (parameterType.Equals(typeof(Net.Vpc.Upa.Callbacks.PackageEvent))) {
                        objectType = Net.Vpc.Upa.ObjectType.PACKAGE;
                        break;
                    }
                    if (parameterType.Equals(typeof(Net.Vpc.Upa.Callbacks.FieldEvent))) {
                        objectType = Net.Vpc.Upa.ObjectType.FIELD;
                        break;
                    }
                    if (parameterType.Equals(typeof(Net.Vpc.Upa.Callbacks.IndexEvent))) {
                        objectType = Net.Vpc.Upa.ObjectType.INDEX;
                        break;
                    }
                    if (parameterType.Equals(typeof(Net.Vpc.Upa.Callbacks.RelationshipEvent))) {
                        objectType = Net.Vpc.Upa.ObjectType.RELATIONSHIP;
                        break;
                    }
                    if (parameterType.Equals(typeof(Net.Vpc.Upa.Callbacks.TriggerEvent))) {
                        objectType = Net.Vpc.Upa.ObjectType.TRIGGER;
                        break;
                    }
                    if (parameterType.Equals(typeof(Net.Vpc.Upa.Callbacks.FunctionEvent))) {
                        objectType = Net.Vpc.Upa.ObjectType.FUNCTION;
                        break;
                    }
                    if (parameterType.Equals(typeof(Net.Vpc.Upa.EvalContext))) {
                        objectType = Net.Vpc.Upa.ObjectType.FUNCTION;
                        break;
                    }
                    if (typeof(Net.Vpc.Upa.Callbacks.EntityEvent).IsAssignableFrom(parameterType)) {
                        objectType = Net.Vpc.Upa.ObjectType.ENTITY;
                        break;
                    }
                }
            }
            if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.Vpc.Upa.ObjectType>(typeof(Net.Vpc.Upa.ObjectType), objectType)) {
                throw new Net.Vpc.Upa.Exceptions.UPAException("UnableToResoleObjectType");
            }
            switch(objectType) {
                case Net.Vpc.Upa.ObjectType.ENTITY:
                    {
                        Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] methodArguments = CreateArguments(m);
                        switch(callbackType) {
                            case Net.Vpc.Upa.CallbackType.ON_PERSIST:
                                {
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.PersistEvent), 0, false) };
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.Vpc.Upa.CallbackType.ON_UPDATE:
                                {
                                    bool obj = false;
                                    bool formula = false;
                                    bool found = false;
                                    foreach (System.Type parameterType in Net.Vpc.Upa.Impl.FwkConvertUtils.GetMethodParameterTypes(m)) {
                                        if (parameterType.Equals(typeof(Net.Vpc.Upa.Callbacks.UpdateObjectEvent))) {
                                            if (found) {
                                                throw new System.ArgumentException ("Ambigous");
                                            }
                                            found = true;
                                            obj = true;
                                            formula = false;
                                        }
                                        if (parameterType.Equals(typeof(Net.Vpc.Upa.Callbacks.UpdateFormulaObjectEvent))) {
                                            if (found) {
                                                throw new System.ArgumentException ("Ambigous");
                                            }
                                            found = true;
                                            obj = true;
                                            formula = true;
                                        }
                                        if (parameterType.Equals(typeof(Net.Vpc.Upa.Callbacks.UpdateEvent))) {
                                            if (found) {
                                                throw new System.ArgumentException ("Ambigous");
                                            }
                                            found = true;
                                            obj = false;
                                            formula = false;
                                        }
                                        if (parameterType.Equals(typeof(Net.Vpc.Upa.Callbacks.UpdateFormulaEvent))) {
                                            if (found) {
                                                throw new System.ArgumentException ("Ambigous");
                                            }
                                            found = true;
                                            obj = false;
                                            formula = true;
                                        }
                                    }
                                    if (obj) {
                                        if (formula) {
                                            Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.UpdateFormulaObjectEvent), 0, false) };
                                            Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                            return new Net.Vpc.Upa.Impl.Event.UpdateFormulaObjectEventCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                        } else {
                                            Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.UpdateObjectEvent), 0, false) };
                                            Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                            return new Net.Vpc.Upa.Impl.Event.UpdateObjectEventCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                        }
                                    } else {
                                        if (formula) {
                                            Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.UpdateFormulaEvent), 0, false) };
                                            Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                            return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                        } else {
                                            Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.UpdateEvent), 0, false) };
                                            Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                            return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                        }
                                    }
                                }
                                break;
                            case Net.Vpc.Upa.CallbackType.ON_REMOVE:
                                {
                                    bool obj = false;
                                    bool found = false;
                                    foreach (System.Type parameterType in Net.Vpc.Upa.Impl.FwkConvertUtils.GetMethodParameterTypes(m)) {
                                        if (parameterType.Equals(typeof(Net.Vpc.Upa.Callbacks.RemoveObjectEvent))) {
                                            if (found) {
                                                throw new System.ArgumentException ("Ambigous");
                                            }
                                            found = true;
                                            obj = true;
                                        }
                                        if (parameterType.Equals(typeof(Net.Vpc.Upa.Callbacks.RemoveEvent))) {
                                            if (found) {
                                                throw new System.ArgumentException ("Ambigous");
                                            }
                                            found = true;
                                            obj = false;
                                        }
                                    }
                                    if (obj) {
                                        Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.RemoveObjectEvent), 0, false) };
                                        Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                        return new Net.Vpc.Upa.Impl.Event.RemoveObjectEventCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                    } else {
                                        Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.RemoveEvent), 0, false) };
                                        Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                        return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                    }
                                }
                                break;
                            case Net.Vpc.Upa.CallbackType.ON_RESET:
                            case Net.Vpc.Upa.CallbackType.ON_CLEAR:
                            case Net.Vpc.Upa.CallbackType.ON_INITIALIZE:
                                {
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.EntityEvent), 0, false) };
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.Vpc.Upa.CallbackType.ON_CREATE:
                                {
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.EntityEvent), 0, false) };
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.Vpc.Upa.CallbackType.ON_DROP:
                                {
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.EntityEvent), 0, false) };
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.Vpc.Upa.CallbackType.ON_ALTER:
                                {
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.EntityEvent), 0, false) };
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.Vpc.Upa.CallbackType.ON_MOVE:
                                {
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.EntityEvent), 0, false) };
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                        }
                    }
                    break;
                case Net.Vpc.Upa.ObjectType.FIELD:
                    {
                        Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] methodArguments = CreateArguments(m);
                        switch(callbackType) {
                            case Net.Vpc.Upa.CallbackType.ON_CREATE:
                                {
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.FieldEvent), 0, false) };
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.Vpc.Upa.CallbackType.ON_DROP:
                                {
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.FieldEvent), 0, false) };
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.Vpc.Upa.CallbackType.ON_MOVE:
                                {
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.FieldEvent), 0, false) };
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.Vpc.Upa.CallbackType.ON_ALTER:
                                {
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.FieldEvent), 0, false) };
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            default:
                                {
                                    throw new Net.Vpc.Upa.Exceptions.UPAException("Unsupported", "EntityCallback", callbackType);
                                }
                        }
                    }
                    break;
                case Net.Vpc.Upa.ObjectType.SECTION:
                    {
                        Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] methodArguments = CreateArguments(m);
                        switch(callbackType) {
                            case Net.Vpc.Upa.CallbackType.ON_CREATE:
                                {
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.SectionEvent), 0, false) };
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.Vpc.Upa.CallbackType.ON_DROP:
                                {
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.SectionEvent), 0, false) };
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.Vpc.Upa.CallbackType.ON_MOVE:
                                {
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.SectionEvent), 0, false) };
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.Vpc.Upa.CallbackType.ON_ALTER:
                                {
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.SectionEvent), 0, false) };
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            default:
                                {
                                    throw new Net.Vpc.Upa.Exceptions.UPAException("Unsupported", "FieldCallback", callbackType);
                                }
                        }
                    }
                    break;
                case Net.Vpc.Upa.ObjectType.PACKAGE:
                    {
                        Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] methodArguments = CreateArguments(m);
                        switch(callbackType) {
                            case Net.Vpc.Upa.CallbackType.ON_CREATE:
                                {
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.PackageEvent), 0, false) };
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.Vpc.Upa.CallbackType.ON_DROP:
                                {
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.PackageEvent), 0, false) };
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.Vpc.Upa.CallbackType.ON_MOVE:
                                {
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.PackageEvent), 0, false) };
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.Vpc.Upa.CallbackType.ON_ALTER:
                                {
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.PackageEvent), 0, false) };
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            default:
                                {
                                    throw new Net.Vpc.Upa.Exceptions.UPAException("Unsupported", "PackageCallback", callbackType);
                                }
                        }
                    }
                    break;
                case Net.Vpc.Upa.ObjectType.PERSISTENCE_GROUP:
                    {
                        Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] methodArguments = CreateArguments(m);
                        switch(callbackType) {
                            case Net.Vpc.Upa.CallbackType.ON_CREATE:
                                {
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.PersistenceGroupEvent), 0, false) };
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.Vpc.Upa.CallbackType.ON_DROP:
                                {
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.PersistenceGroupEvent), 0, false) };
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.Vpc.Upa.CallbackType.ON_MOVE:
                                {
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.PersistenceGroupEvent), 0, false) };
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.Vpc.Upa.CallbackType.ON_ALTER:
                                {
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.PersistenceGroupEvent), 0, false) };
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            default:
                                {
                                    throw new Net.Vpc.Upa.Exceptions.UPAException("Unsupported", "PErsistenceGroupCallback", callbackType);
                                }
                        }
                    }
                    break;
                case Net.Vpc.Upa.ObjectType.PERSISTENCE_UNIT:
                    {
                        Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] methodArguments = CreateArguments(m);
                        switch(callbackType) {
                            case Net.Vpc.Upa.CallbackType.ON_CREATE:
                                {
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent), 0, false) };
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.Vpc.Upa.CallbackType.ON_DROP:
                                {
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent), 0, false) };
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.Vpc.Upa.CallbackType.ON_ALTER:
                                {
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent), 0, false) };
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.Vpc.Upa.CallbackType.ON_START:
                                {
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent), 0, false) };
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            default:
                                {
                                    throw new Net.Vpc.Upa.Exceptions.UPAException("Unsupported", "PersistenceUnitCallback", callbackType);
                                }
                        }
                    }
                    break;
                case Net.Vpc.Upa.ObjectType.TRIGGER:
                    {
                        Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] methodArguments = CreateArguments(m);
                        switch(callbackType) {
                            case Net.Vpc.Upa.CallbackType.ON_CREATE:
                                {
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.TriggerEvent), 0, false) };
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.Vpc.Upa.CallbackType.ON_DROP:
                                {
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.TriggerEvent), 0, false) };
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            default:
                                {
                                    throw new Net.Vpc.Upa.Exceptions.UPAException("Unsupported", "TriggerCallback", callbackType);
                                }
                        }
                    }
                    break;
                case Net.Vpc.Upa.ObjectType.FUNCTION:
                    {
                        Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] methodArguments = CreateArguments(m);
                        switch(callbackType) {
                            case Net.Vpc.Upa.CallbackType.ON_CREATE:
                                {
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.FunctionEvent), 0, false) };
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.Vpc.Upa.CallbackType.ON_DROP:
                                {
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.FunctionEvent), 0, false) };
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.Vpc.Upa.CallbackType.ON_EVAL:
                                {
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("evalContext", typeof(Net.Vpc.Upa.EvalContext), 0, false) };
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    System.Collections.Generic.IDictionary<string , object> configuration2 = new System.Collections.Generic.Dictionary<string , object>();
                                    if (configuration != null) {
                                        Net.Vpc.Upa.Impl.FwkConvertUtils.PutAllMap<string,object>(configuration2,configuration);
                                    }
                                    if (!configuration2.ContainsKey("functionName")) {
                                        configuration2["functionName"]=(m).Name;
                                    }
                                    if (!configuration2.ContainsKey("returnType")) {
                                        Net.Vpc.Upa.Types.DataType forNativeType = Net.Vpc.Upa.Types.TypesFactory.ForPlatformType((m).ReturnType);
                                        configuration2["returnType"]=forNativeType;
                                    }
                                    return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            default:
                                {
                                    throw new Net.Vpc.Upa.Exceptions.UPAException("Unsupported", "FunctionCallback", callbackType);
                                }
                        }
                    }
                    break;
                case Net.Vpc.Upa.ObjectType.CONTEXT:
                    {
                        Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] methodArguments = CreateArguments(m);
                        switch(callbackType) {
                            case Net.Vpc.Upa.CallbackType.ON_CLOSE:
                                {
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.Vpc.Upa.Callbacks.ContextEvent), 0, false) };
                                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, objectType, Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            default:
                                {
                                    throw new Net.Vpc.Upa.Exceptions.UPAException("Unsupported", "ContextCallback", callbackType);
                                }
                        }
                    }
                    break;
            }
            throw new System.ArgumentException ("Unsupported Callback for " + objectType + " with " + callbackType);
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

        public virtual Net.Vpc.Upa.Callback[] GetCallbacks(Net.Vpc.Upa.CallbackType callbackType, Net.Vpc.Upa.ObjectType objectType, string nameFilter, bool system, Net.Vpc.Upa.EventPhase phase) {
            System.Collections.Generic.IList<Net.Vpc.Upa.Callback> callbacks = listeners.GetCallbacks(callbackType, objectType, nameFilter, system, phase);
            return callbacks.ToArray();
        }
    }
}
