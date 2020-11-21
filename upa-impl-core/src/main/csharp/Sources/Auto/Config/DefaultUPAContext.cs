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
namespace Net.TheVpc.Upa.Impl.Config
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DefaultUPAContext : Net.TheVpc.Upa.UPAContext {

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.TheVpc.Upa.Impl.Config.DefaultUPAContext)).FullName);

        private Net.TheVpc.Upa.ObjectFactory bootstrapObjectFactory;

        private Net.TheVpc.Upa.UPAContextFactory objectFactory;

        private Net.TheVpc.Upa.PersistenceGroupContextProvider persistenceGroupContextProvider;

        private readonly System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.PersistenceGroup> persistenceGroups = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.PersistenceGroup>();

        private readonly System.Collections.Generic.IList<Net.TheVpc.Upa.Config.ScanFilter> filters = new System.Collections.Generic.List<Net.TheVpc.Upa.Config.ScanFilter>();

        private readonly System.Collections.Generic.IList<Net.TheVpc.Upa.CloseListener> closeListeners = new System.Collections.Generic.List<Net.TheVpc.Upa.CloseListener>();

        private System.Collections.Generic.IDictionary<string , object> properties = new System.Collections.Generic.Dictionary<string , object>();

        private readonly Net.TheVpc.Upa.Impl.Config.Decorations.DecorationRepository decorationRepository = new Net.TheVpc.Upa.Impl.Config.Decorations.DefaultDecorationRepository("UPAContextRepo", true);

        private Net.TheVpc.Upa.Persistence.UPAContextConfig bootstratContextConfig;

        private Net.TheVpc.Upa.InvokeContext emptyInvokeContext = new Net.TheVpc.Upa.InvokeContext();

        private Net.TheVpc.Upa.Impl.Event.UPAContextListenerManager listeners;

        private System.Threading.ThreadLocal<Net.TheVpc.Upa.Properties> threadProperties = new System.Threading.ThreadLocal<Net.TheVpc.Upa.Properties>();


        public virtual  T MakeSessionAware<T>(T instance, Net.TheVpc.Upa.MethodFilter methodFilter) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return (T) Net.TheVpc.Upa.Impl.Util.PlatformUtils.CreateObjectInterceptor<T>((System.Type) instance.GetType(), new Net.TheVpc.Upa.Impl.Config.MakeSessionAwareMethodInterceptor<?>(this, methodFilter, instance));
        }


        public virtual  T MakeSessionAware<T>(T instance) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return MakeSessionAware<T>(instance, (Net.TheVpc.Upa.MethodFilter) null);
        }

        public DefaultUPAContext() {
            listeners = new Net.TheVpc.Upa.Impl.Event.UPAContextListenerManager(this);
        }

        public virtual Net.TheVpc.Upa.Persistence.UPAContextConfig GetBootstrapContextConfig() {
            if (bootstratContextConfig == null) {
                Net.TheVpc.Upa.Impl.Config.DefaultUPAContextLoader @object = new Net.TheVpc.Upa.Impl.Config.DefaultUPAContextLoader();
                Net.TheVpc.Upa.Persistence.UPAContextConfig contextConfig = @object.Parse();
                if (contextConfig.GetFilters() != null) {
                    int count = 0;
                    foreach (Net.TheVpc.Upa.Config.ScanFilter filter in contextConfig.GetFilters()) {
                        if (filter != null) {
                            count++;
                            AddScanFilter(filter);
                        }
                    }
                    if (count == 0 && (contextConfig.GetAutoScan() == null || (contextConfig.GetAutoScan()).Value)) {
                        AddScanFilter(new Net.TheVpc.Upa.Config.ScanFilter(null, null, false, Net.TheVpc.Upa.Persistence.UPAContextConfig.XML_ORDER));
                    }
                }
                bootstratContextConfig = contextConfig;
            }
            return bootstratContextConfig;
        }

        public virtual void Start(Net.TheVpc.Upa.ObjectFactory factory) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Starting UPAContext",null));
            bootstrapObjectFactory = factory;
            objectFactory = new Net.TheVpc.Upa.Impl.DefaultUPAContextFactory(bootstrapObjectFactory.CreateObject<Net.TheVpc.Upa.ObjectFactory>(typeof(Net.TheVpc.Upa.ObjectFactory)));
            objectFactory.SetParentFactory(bootstrapObjectFactory);
            LoadConfig();
        }

        public virtual void LoadConfig() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Scan(GetFactory().CreateContextScanSource(false), null, true);
            foreach (Net.TheVpc.Upa.PersistenceGroup g in GetPersistenceGroups()) {
                foreach (Net.TheVpc.Upa.PersistenceUnit u in g.GetPersistenceUnits()) {
                    if (!u.IsStarted() && u.IsAutoStart()) {
                        u.Start();
                    }
                }
            }
        }

        public virtual void Scan(Net.TheVpc.Upa.Config.ScanSource configurationStrategy, Net.TheVpc.Upa.ScanListener listener, bool configure) {
            Net.TheVpc.Upa.Impl.Config.URLAnnotationStrategySupport support = new Net.TheVpc.Upa.Impl.Config.URLAnnotationStrategySupport();
            support.Scan(this, configurationStrategy, decorationRepository, configure ? ((Net.TheVpc.Upa.ScanListener)(new Net.TheVpc.Upa.Impl.Config.ConfigureScanListener(listener))) : listener);
        }

        public virtual bool IsContextProviderSet() {
            return persistenceGroupContextProvider != null;
        }

        public virtual Net.TheVpc.Upa.PersistenceUnit GetPersistenceUnit() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceGroup().GetPersistenceUnit();
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.PersistenceGroup> GetPersistenceGroups() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return new System.Collections.Generic.List<Net.TheVpc.Upa.PersistenceGroup>((persistenceGroups).Values);
        }

        public virtual Net.TheVpc.Upa.PersistenceGroup GetPersistenceGroup() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceGroupContextProvider().GetPersistenceGroup();
        }

        public virtual void SetPersistenceGroup(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            GetPersistenceGroupContextProvider().SetPersistenceGroup(GetPersistenceGroup(name));
        }

        private Net.TheVpc.Upa.PersistenceGroupContextProvider GetPersistenceGroupContextProvider() {
            if (persistenceGroupContextProvider == null) {
                throw new System.ArgumentException ("PersistenceGroupContextProvider not found");
            }
            return persistenceGroupContextProvider;
        }

        public virtual void SetPersistenceGroupContextProvider(Net.TheVpc.Upa.PersistenceGroupContextProvider contextProvider) {
            this.persistenceGroupContextProvider = contextProvider;
        }

        public Net.TheVpc.Upa.UPAContextFactory GetFactory() {
            return objectFactory;
        }

        public virtual Net.TheVpc.Upa.PersistenceGroup GetPersistenceGroup(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(name)) {
                name = "";
            }
            if (!persistenceGroups.ContainsKey(name)) {
                throw new System.ArgumentException ("PersistenceGroup " + name + " does not exist");
            }
            return Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.PersistenceGroup>(persistenceGroups,name);
        }

        public virtual bool ContainsPersistenceGroup(string name) {
            if (Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(name)) {
                name = "";
            }
            return persistenceGroups.ContainsKey(name);
        }

        public virtual Net.TheVpc.Upa.PersistenceGroup AddPersistenceGroup(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(name)) {
                name = "";
            }
            if (persistenceGroups.ContainsKey(name)) {
                throw new System.ArgumentException ("PersistenceGroup " + name + " already exists");
            }
            Net.TheVpc.Upa.ObjectFactory factory = GetFactory();
            if (!IsContextProviderSet()) {
                SetPersistenceGroupContextProvider(factory.CreateObject<Net.TheVpc.Upa.PersistenceGroupContextProvider>(typeof(Net.TheVpc.Upa.PersistenceGroupContextProvider)));
            }
            Net.TheVpc.Upa.ObjectFactory persistenceGroupFactory = GetFactory().CreateObject<Net.TheVpc.Upa.ObjectFactory>(typeof(Net.TheVpc.Upa.ObjectFactory));
            persistenceGroupFactory.SetParentFactory(factory);
            Net.TheVpc.Upa.PersistenceGroup persistenceGroup = factory.CreateObject<Net.TheVpc.Upa.PersistenceGroup>(typeof(Net.TheVpc.Upa.PersistenceGroup));
            Net.TheVpc.Upa.Impl.Util.DefaultBeanAdapter a = new Net.TheVpc.Upa.Impl.Util.DefaultBeanAdapter(persistenceGroup);
            a.SetProperty("context", this);
            a.SetProperty("factory", objectFactory);
            a.SetProperty("name", name);
            Net.TheVpc.Upa.Callbacks.PersistenceGroupEvent evt = new Net.TheVpc.Upa.Callbacks.PersistenceGroupEvent(persistenceGroup, this);
            listeners.FireOnCreatePersistenceGroup(evt, Net.TheVpc.Upa.EventPhase.BEFORE);
            persistenceGroups[name]=persistenceGroup;
            if (GetPersistenceGroupContextProvider().GetPersistenceGroup() == null) {
                GetPersistenceGroupContextProvider().SetPersistenceGroup(persistenceGroup);
            }
            listeners.FireOnCreatePersistenceGroup(evt, Net.TheVpc.Upa.EventPhase.AFTER);
            return persistenceGroup;
        }


        public virtual void RemovePersistenceGroup(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.PersistenceGroup persistenceGroup = GetPersistenceGroup(name);
            Net.TheVpc.Upa.Callbacks.PersistenceGroupEvent @event = new Net.TheVpc.Upa.Callbacks.PersistenceGroupEvent(persistenceGroup, this);
            listeners.FireOnDropPersistenceGroup(@event, Net.TheVpc.Upa.EventPhase.BEFORE);
            if (persistenceGroup.IsClosed()) {
                persistenceGroup.Close();
            }
            persistenceGroups.Remove(name);
            listeners.FireOnDropPersistenceGroup(@event, Net.TheVpc.Upa.EventPhase.AFTER);
        }


        public virtual void AddPersistenceGroupDefinitionListener(Net.TheVpc.Upa.Callbacks.PersistenceGroupDefinitionListener persistenceGroupDefinitionListener) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            listeners.AddPersistenceGroupDefinitionListener(persistenceGroupDefinitionListener);
        }


        public virtual void RemovePersistenceGroupDefinitionListener(Net.TheVpc.Upa.Callbacks.PersistenceGroupDefinitionListener persistenceGroupDefinitionListener) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            listeners.RemovePersistenceGroupDefinitionListener(persistenceGroupDefinitionListener);
        }

        public virtual Net.TheVpc.Upa.Callbacks.PersistenceGroupDefinitionListener[] GetPersistenceGroupDefinitionListeners() {
            return listeners.GetPersistenceGroupDefinitionListeners();
        }


        public virtual  T MakeSessionAware<T>(T instance, System.Type sessionAwareMethodAnnotation) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return MakeSessionAware<T>(instance, sessionAwareMethodAnnotation == null ? null : new Net.TheVpc.Upa.Impl.Config.AnnotationMethodFilter(sessionAwareMethodAnnotation, decorationRepository));
        }


        public virtual  T MakeSessionAware<T>(System.Type type, Net.TheVpc.Upa.MethodFilter methodFilter) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return (T) Net.TheVpc.Upa.Impl.Util.PlatformUtils.CreateObjectInterceptor<T>(type, new Net.TheVpc.Upa.Impl.Config.MakeSessionAwareMethodInterceptor2<T>(methodFilter));
        }


        public virtual  T Invoke<T>(Net.TheVpc.Upa.Action<T> action, Net.TheVpc.Upa.InvokeContext invokeContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (invokeContext == null) {
                invokeContext = emptyInvokeContext;
            }
            Net.TheVpc.Upa.PersistenceGroup persistenceGroup = null;
            if (invokeContext.GetPersistenceGroup() != null) {
                persistenceGroup = invokeContext.GetPersistenceGroup();
            } else if (invokeContext.GetPersistenceUnit() != null) {
                persistenceGroup = invokeContext.GetPersistenceUnit().GetPersistenceGroup();
            }
            if (persistenceGroup == null) {
                persistenceGroup = Net.TheVpc.Upa.UPA.GetPersistenceGroup();
            }
            Net.TheVpc.Upa.Session s = persistenceGroup.FindCurrentSession();
            bool sessionCreated = false;
            bool loginCreated = false;
            if (s == null) {
                s = persistenceGroup.OpenSession();
                sessionCreated = true;
            }
            Net.TheVpc.Upa.PersistenceUnit pu = null;
            if (invokeContext.GetPersistenceUnit() != null) {
                pu = invokeContext.GetPersistenceUnit();
            }
            if (pu == null) {
                pu = persistenceGroup.GetPersistenceUnit();
            }
            if (invokeContext.GetLogin() != null) {
                pu.Login(invokeContext.GetLogin(), invokeContext.GetCredentials());
                loginCreated = true;
            }
            bool transactionCreated = false;
            if (invokeContext.GetTransactionType() != default(Net.TheVpc.Upa.TransactionType)) {
                pu.BeginTransaction(invokeContext.GetTransactionType());
                transactionCreated = true;
            }
            T ret = default(T);
            System.Exception anyErr = null;
            try {
                ret = action.Run();
                if (transactionCreated) {
                    pu.CommitTransaction();
                }
            } catch (Net.TheVpc.Upa.Exceptions.UPAException e) {
                anyErr = e;
                if (transactionCreated) {
                    pu.RollbackTransaction();
                }
                throw e;
            } catch (System.Exception e) {
                anyErr = e;
                if (transactionCreated) {
                    pu.RollbackTransaction();
                }
                throw new Net.TheVpc.Upa.Exceptions.UPAException(e, new Net.TheVpc.Upa.Types.I18NString("InvokeError"));
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


        public virtual  T InvokePrivileged<T>(Net.TheVpc.Upa.Action<T> action, Net.TheVpc.Upa.InvokeContext invokeContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (invokeContext == null) {
                invokeContext = emptyInvokeContext;
            }
            Net.TheVpc.Upa.PersistenceGroup persistenceGroup = null;
            Net.TheVpc.Upa.PersistenceGroup _persistenceGroup = invokeContext.GetPersistenceGroup();
            if (_persistenceGroup != null) {
                persistenceGroup = _persistenceGroup;
            } else if (invokeContext.GetPersistenceUnit() != null) {
                persistenceGroup = invokeContext.GetPersistenceUnit().GetPersistenceGroup();
            }
            if (persistenceGroup == null) {
                persistenceGroup = Net.TheVpc.Upa.UPA.GetPersistenceGroup();
            }
            Net.TheVpc.Upa.Session s = persistenceGroup.FindCurrentSession();
            bool sessionCreated = false;
            bool loginCreated = false;
            if (s == null) {
                s = persistenceGroup.OpenSession();
                sessionCreated = true;
            }
            Net.TheVpc.Upa.PersistenceUnit pu = null;
            if (invokeContext.GetPersistenceUnit() != null) {
                pu = invokeContext.GetPersistenceUnit();
            }
            if (pu == null) {
                pu = persistenceGroup.GetPersistenceUnit();
            }
            pu.LoginPrivileged(invokeContext.GetLogin());
            loginCreated = true;
            bool transactionCreated = false;
            if (invokeContext.GetTransactionType() != default(Net.TheVpc.Upa.TransactionType)) {
                pu.BeginTransaction(invokeContext.GetTransactionType());
                transactionCreated = true;
            }
            T ret = default(T);
            System.Exception anyErr = null;
            try {
                ret = action.Run();
                if (transactionCreated) {
                    pu.CommitTransaction();
                }
            } catch (Net.TheVpc.Upa.Exceptions.UPAException e) {
                anyErr = e;
                System.Console.WriteLine(e);
                if (transactionCreated) {
                    pu.RollbackTransaction();
                }
                throw e;
            } catch (System.Exception e) {
                anyErr = e;
                System.Console.WriteLine(e);
                if (transactionCreated) {
                    pu.RollbackTransaction();
                }
                throw new Net.TheVpc.Upa.Exceptions.UPAException(e, new Net.TheVpc.Upa.Types.I18NString("InvokeError"));
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


        public virtual  T Invoke<T>(Net.TheVpc.Upa.Action<T> action) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return Invoke<T>(action, null);
        }


        public virtual  T InvokePrivileged<T>(Net.TheVpc.Upa.Action<T> action) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return InvokePrivileged<T>(action, null);
        }


        public virtual void Invoke(Net.TheVpc.Upa.VoidAction action, Net.TheVpc.Upa.InvokeContext invokeContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Invoke<object>(new Net.TheVpc.Upa.Impl.Config.VoidActionAdapter(action), invokeContext);
        }


        public virtual void Invoke(Net.TheVpc.Upa.VoidAction action) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Invoke<object>(new Net.TheVpc.Upa.Impl.Config.VoidActionAdapter(action));
        }


        public virtual void InvokePrivileged(Net.TheVpc.Upa.VoidAction action, Net.TheVpc.Upa.InvokeContext invokeContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            InvokePrivileged<object>(new Net.TheVpc.Upa.Impl.Config.VoidActionAdapter(action), invokeContext);
        }


        public virtual void InvokePrivileged(Net.TheVpc.Upa.VoidAction action) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            InvokePrivileged<object>(new Net.TheVpc.Upa.Impl.Config.VoidActionAdapter(action));
        }

        public virtual void Close() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.CloseListener[] li = GetCloseListeners();
            foreach (Net.TheVpc.Upa.CloseListener listener in li) {
                listener.BeforeClose(this);
            }
            lock (persistenceGroups) {
                foreach (string name in new System.Collections.Generic.HashSet<string>(new System.Collections.Generic.HashSet<string>(persistenceGroups.Keys))) {
                    RemovePersistenceGroup(name);
                }
            }
            foreach (Net.TheVpc.Upa.CloseListener listener in li) {
                listener.AfterClose(this);
            }
        }

        public virtual void AddCloseListener(Net.TheVpc.Upa.CloseListener listener) {
            lock (closeListeners) {
                closeListeners.Add(listener);
            }
        }

        public virtual void RemoveCloseListener(Net.TheVpc.Upa.CloseListener listener) {
            lock (closeListeners) {
                closeListeners.Remove(listener);
            }
        }

        public virtual Net.TheVpc.Upa.CloseListener[] GetCloseListeners() {
            return closeListeners.ToArray();
        }

        public virtual void AddScanFilter(Net.TheVpc.Upa.Config.ScanFilter filter) {
            filters.Add(filter);
        }

        public virtual void RemoveScanFilter(Net.TheVpc.Upa.Config.ScanFilter filter) {
            filters.Remove(filter);
        }

        public virtual Net.TheVpc.Upa.Config.ScanFilter[] GetContextAnnotationStrategyFilters() {
            return filters.ToArray();
        }

        public virtual System.Collections.Generic.IDictionary<string , object> GetProperties() {
            return properties;
        }

        public virtual void SetProperties(System.Collections.Generic.IDictionary<string , object> properties) {
            this.properties = properties;
        }

        private Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] CreateArguments(System.Reflection.MethodInfo m) {
            System.Type[] parameterTypes = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMethodParameterTypes(m);
            Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] aa = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[parameterTypes.Length];
            for (int i = 0; i < aa.Length; i++) {
                aa[i] = new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument(null, parameterTypes[i], i, false);
            }
            return aa;
        }


        public virtual Net.TheVpc.Upa.Callback CreateCallback(Net.TheVpc.Upa.CallbackConfig callbackConfig) {
            object instance = callbackConfig.GetInstance();
            System.Reflection.MethodInfo m = callbackConfig.GetMethod();
            Net.TheVpc.Upa.CallbackType callbackType = callbackConfig.GetCallbackType();
            System.Collections.Generic.IDictionary<string , object> configuration = callbackConfig.GetConfiguration();
            //        if (configuration == null) {
            //            configuration = new HashMap<String, Object>();
            //        }
            Net.TheVpc.Upa.ObjectType objectType = Net.TheVpc.Upa.Impl.Util.PlatformUtils.GetUndefinedValue<Net.TheVpc.Upa.ObjectType>(typeof(Net.TheVpc.Upa.ObjectType));
            Net.TheVpc.Upa.EventPhase phase = callbackConfig.GetPhase();
            if (Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.TheVpc.Upa.ObjectType>(typeof(Net.TheVpc.Upa.ObjectType), objectType)) {
                foreach (System.Type parameterType in Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMethodParameterTypes(m)) {
                    if (parameterType.Equals(typeof(Net.TheVpc.Upa.Callbacks.ContextEvent))) {
                        objectType = Net.TheVpc.Upa.ObjectType.CONTEXT;
                        break;
                    }
                    if (parameterType.Equals(typeof(Net.TheVpc.Upa.Callbacks.PersistenceGroupEvent))) {
                        objectType = Net.TheVpc.Upa.ObjectType.PERSISTENCE_GROUP;
                        break;
                    }
                    if (parameterType.Equals(typeof(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent))) {
                        objectType = Net.TheVpc.Upa.ObjectType.PERSISTENCE_UNIT;
                        break;
                    }
                    if (parameterType.Equals(typeof(Net.TheVpc.Upa.Callbacks.PackageEvent))) {
                        objectType = Net.TheVpc.Upa.ObjectType.PACKAGE;
                        break;
                    }
                    if (parameterType.Equals(typeof(Net.TheVpc.Upa.Callbacks.FieldEvent))) {
                        objectType = Net.TheVpc.Upa.ObjectType.FIELD;
                        break;
                    }
                    if (parameterType.Equals(typeof(Net.TheVpc.Upa.Callbacks.IndexEvent))) {
                        objectType = Net.TheVpc.Upa.ObjectType.INDEX;
                        break;
                    }
                    if (parameterType.Equals(typeof(Net.TheVpc.Upa.Callbacks.RelationshipEvent))) {
                        objectType = Net.TheVpc.Upa.ObjectType.RELATIONSHIP;
                        break;
                    }
                    if (parameterType.Equals(typeof(Net.TheVpc.Upa.Callbacks.TriggerEvent))) {
                        objectType = Net.TheVpc.Upa.ObjectType.TRIGGER;
                        break;
                    }
                    if (parameterType.Equals(typeof(Net.TheVpc.Upa.Callbacks.FunctionEvent))) {
                        objectType = Net.TheVpc.Upa.ObjectType.FUNCTION;
                        break;
                    }
                    if (parameterType.Equals(typeof(Net.TheVpc.Upa.EvalContext))) {
                        objectType = Net.TheVpc.Upa.ObjectType.FUNCTION;
                        break;
                    }
                    if (typeof(Net.TheVpc.Upa.Callbacks.EntityEvent).IsAssignableFrom(parameterType)) {
                        objectType = Net.TheVpc.Upa.ObjectType.ENTITY;
                        break;
                    }
                }
            }
            if (Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.TheVpc.Upa.ObjectType>(typeof(Net.TheVpc.Upa.ObjectType), objectType)) {
                throw new Net.TheVpc.Upa.Exceptions.UPAException("UnableToResoleObjectType");
            }
            switch(objectType) {
                case Net.TheVpc.Upa.ObjectType.ENTITY:
                    {
                        Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] methodArguments = CreateArguments(m);
                        switch(callbackType) {
                            case Net.TheVpc.Upa.CallbackType.ON_PERSIST:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.PersistEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.TheVpc.Upa.CallbackType.ON_UPDATE:
                                {
                                    bool obj = false;
                                    bool formula = false;
                                    bool found = false;
                                    foreach (System.Type parameterType in Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMethodParameterTypes(m)) {
                                        if (parameterType.Equals(typeof(Net.TheVpc.Upa.Callbacks.UpdateObjectEvent))) {
                                            if (found) {
                                                throw new System.ArgumentException ("Ambiguous");
                                            }
                                            found = true;
                                            obj = true;
                                            formula = false;
                                        }
                                        if (parameterType.Equals(typeof(Net.TheVpc.Upa.Callbacks.UpdateFormulaObjectEvent))) {
                                            if (found) {
                                                throw new System.ArgumentException ("Ambiguous");
                                            }
                                            found = true;
                                            obj = true;
                                            formula = true;
                                        }
                                        if (parameterType.Equals(typeof(Net.TheVpc.Upa.Callbacks.UpdateEvent))) {
                                            if (found) {
                                                throw new System.ArgumentException ("Ambiguous");
                                            }
                                            found = true;
                                            obj = false;
                                            formula = false;
                                        }
                                        if (parameterType.Equals(typeof(Net.TheVpc.Upa.Callbacks.UpdateFormulaEvent))) {
                                            if (found) {
                                                throw new System.ArgumentException ("Ambiguous");
                                            }
                                            found = true;
                                            obj = false;
                                            formula = true;
                                        }
                                    }
                                    if (obj) {
                                        if (formula) {
                                            Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.UpdateFormulaObjectEvent), 0, false) };
                                            Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                            return new Net.TheVpc.Upa.Impl.Event.UpdateFormulaObjectEventCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                        } else {
                                            Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.UpdateObjectEvent), 0, false) };
                                            Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                            return new Net.TheVpc.Upa.Impl.Event.UpdateObjectEventCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                        }
                                    } else if (formula) {
                                        Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.UpdateFormulaEvent), 0, false) };
                                        Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                        return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                    } else {
                                        Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.UpdateEvent), 0, false) };
                                        Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                        return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                    }
                                }
                                break;
                            case Net.TheVpc.Upa.CallbackType.ON_REMOVE:
                                {
                                    bool obj = false;
                                    bool found = false;
                                    foreach (System.Type parameterType in Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMethodParameterTypes(m)) {
                                        if (parameterType.Equals(typeof(Net.TheVpc.Upa.Callbacks.RemoveObjectEvent))) {
                                            if (found) {
                                                throw new System.ArgumentException ("Ambiguous");
                                            }
                                            found = true;
                                            obj = true;
                                        }
                                        if (parameterType.Equals(typeof(Net.TheVpc.Upa.Callbacks.RemoveEvent))) {
                                            if (found) {
                                                throw new System.ArgumentException ("Ambiguous");
                                            }
                                            found = true;
                                            obj = false;
                                        }
                                    }
                                    if (obj) {
                                        Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.RemoveObjectEvent), 0, false) };
                                        Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                        return new Net.TheVpc.Upa.Impl.Event.RemoveObjectEventCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                    } else {
                                        Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.RemoveEvent), 0, false) };
                                        Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                        return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                    }
                                }
                                break;
                            case Net.TheVpc.Upa.CallbackType.ON_RESET:
                            case Net.TheVpc.Upa.CallbackType.ON_CLEAR:
                            case Net.TheVpc.Upa.CallbackType.ON_INITIALIZE:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.EntityEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.TheVpc.Upa.CallbackType.ON_CREATE:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.EntityEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.TheVpc.Upa.CallbackType.ON_DROP:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.EntityEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.TheVpc.Upa.CallbackType.ON_ALTER:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.EntityEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.TheVpc.Upa.CallbackType.ON_MOVE:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.EntityEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.TheVpc.Upa.CallbackType.ON_UPDATE_FORMULAS:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.UpdateFormulaEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            default:
                                {
                                    throw new Net.TheVpc.Upa.Exceptions.UPAException("Unsupported", "EntityCallback", callbackType);
                                }
                        }
                    }
                    break;
                case Net.TheVpc.Upa.ObjectType.FIELD:
                    {
                        Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] methodArguments = CreateArguments(m);
                        switch(callbackType) {
                            case Net.TheVpc.Upa.CallbackType.ON_CREATE:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.FieldEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.TheVpc.Upa.CallbackType.ON_DROP:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.FieldEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.TheVpc.Upa.CallbackType.ON_MOVE:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.FieldEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.TheVpc.Upa.CallbackType.ON_ALTER:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.FieldEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            default:
                                {
                                    throw new Net.TheVpc.Upa.Exceptions.UPAException("Unsupported", "EntityCallback", callbackType);
                                }
                        }
                    }
                    break;
                case Net.TheVpc.Upa.ObjectType.SECTION:
                    {
                        Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] methodArguments = CreateArguments(m);
                        switch(callbackType) {
                            case Net.TheVpc.Upa.CallbackType.ON_CREATE:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.SectionEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.TheVpc.Upa.CallbackType.ON_DROP:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.SectionEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.TheVpc.Upa.CallbackType.ON_MOVE:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.SectionEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.TheVpc.Upa.CallbackType.ON_ALTER:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.SectionEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            default:
                                {
                                    throw new Net.TheVpc.Upa.Exceptions.UPAException("Unsupported", "FieldCallback", callbackType);
                                }
                        }
                    }
                    break;
                case Net.TheVpc.Upa.ObjectType.PACKAGE:
                    {
                        Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] methodArguments = CreateArguments(m);
                        switch(callbackType) {
                            case Net.TheVpc.Upa.CallbackType.ON_CREATE:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.PackageEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.TheVpc.Upa.CallbackType.ON_DROP:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.PackageEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.TheVpc.Upa.CallbackType.ON_MOVE:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.PackageEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.TheVpc.Upa.CallbackType.ON_ALTER:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.PackageEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            default:
                                {
                                    throw new Net.TheVpc.Upa.Exceptions.UPAException("Unsupported", "PackageCallback", callbackType);
                                }
                        }
                    }
                    break;
                case Net.TheVpc.Upa.ObjectType.PERSISTENCE_GROUP:
                    {
                        Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] methodArguments = CreateArguments(m);
                        switch(callbackType) {
                            case Net.TheVpc.Upa.CallbackType.ON_CREATE:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.PersistenceGroupEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.TheVpc.Upa.CallbackType.ON_DROP:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.PersistenceGroupEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.TheVpc.Upa.CallbackType.ON_MOVE:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.PersistenceGroupEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.TheVpc.Upa.CallbackType.ON_ALTER:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.PersistenceGroupEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            default:
                                {
                                    throw new Net.TheVpc.Upa.Exceptions.UPAException("Unsupported", "PErsistenceGroupCallback", callbackType);
                                }
                        }
                    }
                    break;
                case Net.TheVpc.Upa.ObjectType.PERSISTENCE_UNIT:
                    {
                        Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] methodArguments = CreateArguments(m);
                        switch(callbackType) {
                            case Net.TheVpc.Upa.CallbackType.ON_CREATE:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.TheVpc.Upa.CallbackType.ON_DROP:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.TheVpc.Upa.CallbackType.ON_ALTER:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.TheVpc.Upa.CallbackType.ON_START:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.TheVpc.Upa.CallbackType.ON_UPDATE_FORMULAS:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            default:
                                {
                                    throw new Net.TheVpc.Upa.Exceptions.UPAException("Unsupported", "PersistenceUnitCallback", callbackType);
                                }
                        }
                    }
                    break;
                case Net.TheVpc.Upa.ObjectType.TRIGGER:
                    {
                        Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] methodArguments = CreateArguments(m);
                        switch(callbackType) {
                            case Net.TheVpc.Upa.CallbackType.ON_CREATE:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.TriggerEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.TheVpc.Upa.CallbackType.ON_DROP:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.TriggerEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            default:
                                {
                                    throw new Net.TheVpc.Upa.Exceptions.UPAException("Unsupported", "TriggerCallback", callbackType);
                                }
                        }
                    }
                    break;
                case Net.TheVpc.Upa.ObjectType.FUNCTION:
                    {
                        Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] methodArguments = CreateArguments(m);
                        switch(callbackType) {
                            case Net.TheVpc.Upa.CallbackType.ON_CREATE:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.FunctionEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.TheVpc.Upa.CallbackType.ON_DROP:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.FunctionEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            case Net.TheVpc.Upa.CallbackType.ON_EVAL:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("evalContext", typeof(Net.TheVpc.Upa.EvalContext), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    System.Collections.Generic.IDictionary<string , object> configuration2 = new System.Collections.Generic.Dictionary<string , object>();
                                    if (configuration != null) {
                                        Net.TheVpc.Upa.Impl.FwkConvertUtils.PutAllMap<string,object>(configuration2,configuration);
                                    }
                                    if (!configuration2.ContainsKey("functionName")) {
                                        configuration2["functionName"]=(m).Name;
                                    }
                                    if (!configuration2.ContainsKey("returnType")) {
                                        Net.TheVpc.Upa.Types.DataType forNativeType = Net.TheVpc.Upa.Types.TypesFactory.ForPlatformType((m).ReturnType);
                                        configuration2["returnType"]=forNativeType;
                                    }
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration2);
                                }
                            default:
                                {
                                    throw new Net.TheVpc.Upa.Exceptions.UPAException("Unsupported", "FunctionCallback", callbackType);
                                }
                        }
                    }
                    break;
                case Net.TheVpc.Upa.ObjectType.CONTEXT:
                    {
                        Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] methodArguments = CreateArguments(m);
                        switch(callbackType) {
                            case Net.TheVpc.Upa.CallbackType.ON_CLOSE:
                                {
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] { new Net.TheVpc.Upa.Impl.Config.Callback.PosInvokeArgument("event", typeof(Net.TheVpc.Upa.Callbacks.ContextEvent), 0, false) };
                                    Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments = new Net.TheVpc.Upa.Impl.Config.Callback.InvokeArgument[] {};
                                    return new Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback(instance, m, callbackType, phase, objectType, Net.TheVpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter.Create(methodArguments, apiArguments, implicitArguments), configuration);
                                }
                            default:
                                {
                                    throw new Net.TheVpc.Upa.Exceptions.UPAException("Unsupported", "ContextCallback", callbackType);
                                }
                        }
                    }
                    break;
            }
            throw new Net.TheVpc.Upa.Exceptions.UPAException("UnsupportedCallback", objectType, callbackType);
        }


        public virtual Net.TheVpc.Upa.Callback AddCallback(Net.TheVpc.Upa.CallbackConfig callbackConfig) {
            Net.TheVpc.Upa.Callback c = CreateCallback(callbackConfig);
            AddCallback(c);
            return c;
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

        public virtual Net.TheVpc.Upa.Callback[] GetCallbacks(Net.TheVpc.Upa.CallbackType callbackType, Net.TheVpc.Upa.ObjectType objectType, string nameFilter, bool system, bool preparedOnly, Net.TheVpc.Upa.EventPhase phase) {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Callback> callbacks = listeners.GetCallbacks(callbackType, objectType, nameFilter, system, preparedOnly, phase);
            return callbacks.ToArray();
        }

        public virtual Net.TheVpc.Upa.Properties GetThreadProperties() {
            Net.TheVpc.Upa.Properties properties = (threadProperties).Value;
            if (properties == null) {
                properties = GetFactory().CreateObject<Net.TheVpc.Upa.Properties>(typeof(Net.TheVpc.Upa.Properties));
                (threadProperties).Value = properties;
            }
            return properties;
        }
    }
}
