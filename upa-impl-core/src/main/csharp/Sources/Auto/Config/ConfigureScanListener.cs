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



namespace Net.TheVpc.Upa.Impl.Config
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class ConfigureScanListener : Net.TheVpc.Upa.ScanListener {

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.TheVpc.Upa.Impl.Config.ConfigureScanListener)).FullName);

        private Net.TheVpc.Upa.ScanListener listener;

        private System.Collections.Generic.IDictionary<System.Type , object> instances = new System.Collections.Generic.Dictionary<System.Type , object>();

        internal System.Collections.Generic.IList<Net.TheVpc.Upa.PersistenceGroup> createdPersistenceGroups = new System.Collections.Generic.List<Net.TheVpc.Upa.PersistenceGroup>();

        public ConfigureScanListener(Net.TheVpc.Upa.ScanListener listener) {
            this.listener = listener;
        }

        public virtual void ContextItemScanned(Net.TheVpc.Upa.ScanEvent @event) {
            if (listener != null) {
                listener.ContextItemScanned(@event);
            }
            Net.TheVpc.Upa.UPAContext context = @event.GetContext();
            System.Type tt = @event.GetVisitedType();
            if (@event.GetContract().Equals(typeof(Net.TheVpc.Upa.Callbacks.PersistenceGroupDefinitionListener))) {
                object i = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,object>(instances,tt);
                if (i == null) {
                    i = context.GetFactory().CreateObject<object>(tt);
                    instances[tt]=i;
                }
                context.AddPersistenceGroupDefinitionListener((Net.TheVpc.Upa.Callbacks.PersistenceGroupDefinitionListener) i);
            }
        }

        public virtual void PersistenceGroupItemScanned(Net.TheVpc.Upa.ScanEvent @event) {
            if (listener != null) {
                listener.PersistenceGroupItemScanned(@event);
            }
            Net.TheVpc.Upa.PersistenceGroup persistenceGroup = @event.GetPersistenceGroup();
            System.Type t = @event.GetVisitedType();
            if (@event.GetContract().Equals(typeof(Net.TheVpc.Upa.Callbacks.PersistenceUnitDefinitionListener))) {
                object i = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,object>(instances,t);
                if (i == null) {
                    i = persistenceGroup.GetFactory().GetSingleton<object>(t);
                    instances[t]=i;
                }
                persistenceGroup.AddPersistenceUnitDefinitionListener((Net.TheVpc.Upa.Callbacks.PersistenceUnitDefinitionListener) i);
            }
            if (@event.GetContract().Equals(typeof(Net.TheVpc.Upa.PersistenceGroupSecurityManager))) {
                object i = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,object>(instances,t);
                if (i == null) {
                    i = persistenceGroup.GetFactory().GetSingleton<object>(t);
                    instances[t]=i;
                }
                persistenceGroup.SetPersistenceGroupSecurityManager((Net.TheVpc.Upa.PersistenceGroupSecurityManager) i);
            }
        }

        public virtual void PersistenceUnitItemScanned(Net.TheVpc.Upa.ScanEvent @event) {
            if (listener != null) {
                listener.PersistenceUnitItemScanned(@event);
            }
            Net.TheVpc.Upa.PersistenceUnit persistenceUnit = @event.GetPersistenceUnit();
            System.Type contract = @event.GetContract();
            System.Type type = @event.GetVisitedType();
            if (Net.TheVpc.Upa.Impl.Config.URLAnnotationStrategySupport.IsPersistenceUnitItemDefinitionListener(contract)) {
                object i = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,object>(instances,type);
                if (i == null) {
                    i = persistenceUnit.GetFactory().CreateObject<object>(type);
                    instances[type]=i;
                }
                Net.TheVpc.Upa.Config.Decoration at = (Net.TheVpc.Upa.Config.Decoration) @event.GetUserObject();
                string _filter = at.GetString("filter");
                bool _trackSystemObjects = at.GetBoolean("trackSystemObjects");
                //                    Callback cb = (Callback) at.getAnnotation();
                if ((_filter).Length == 0) {
                    persistenceUnit.AddDefinitionListener((Net.TheVpc.Upa.Callbacks.DefinitionListener) i, _trackSystemObjects);
                } else {
                    persistenceUnit.AddDefinitionListener(_filter, (Net.TheVpc.Upa.Callbacks.DefinitionListener) i, _trackSystemObjects);
                }
            } else if (typeof(Net.TheVpc.Upa.Callbacks.PersistenceUnitListener).Equals(contract)) {
                object i = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,object>(instances,type);
                if (i == null) {
                    i = persistenceUnit.GetFactory().CreateObject<object>(type);
                    instances[type]=i;
                }
                persistenceUnit.AddPersistenceUnitListener((Net.TheVpc.Upa.Callbacks.PersistenceUnitListener) i);
            } else if (typeof(Net.TheVpc.Upa.Callbacks.EntityInterceptor).Equals(contract)) {
                Net.TheVpc.Upa.Callbacks.EntityInterceptor i = (Net.TheVpc.Upa.Callbacks.EntityInterceptor) Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,object>(instances,type);
                if (i == null) {
                    try {
                        i = (Net.TheVpc.Upa.Callbacks.EntityInterceptor) persistenceUnit.GetFactory().CreateObject<object>(type);
                    } catch (System.Exception ex) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter(null,ex));
                    }
                    if (i != null) {
                        instances[type]=i;
                    }
                }
                if (i != null) {
                    Net.TheVpc.Upa.Config.Decoration at = (Net.TheVpc.Upa.Config.Decoration) @event.GetUserObject();
                    string _filter = at.GetString("filter");
                    string _name = at.GetString("name");
                    if (Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(_name)) {
                        _name = (i.GetType()).Name;
                    }
                    bool _trackSystemObjects = at.GetBoolean("trackSystemObjects");
                    //                    Callback cb = (Callback) at.getAnnotation();
                    persistenceUnit.AddTrigger(_name, i, _filter, _trackSystemObjects);
                }
            } else if (typeof(Net.TheVpc.Upa.EntityDescriptor).Equals(@event.GetContract())) {
                Net.TheVpc.Upa.EntityDescriptor desc = (Net.TheVpc.Upa.EntityDescriptor) @event.GetUserObject();
                persistenceUnit.AddEntity(desc);
            } else if (typeof(Net.TheVpc.Upa.Function).Equals(@event.GetContract())) {
                Net.TheVpc.Upa.Function f = (Net.TheVpc.Upa.Function) persistenceUnit.GetFactory().CreateObject<T>(@event.GetVisitedType());
                Net.TheVpc.Upa.Config.Decoration d = (Net.TheVpc.Upa.Config.Decoration) @event.GetUserObject();
                //                Net.TheVpc.Upa.config.FunctionDefinition d = type.getAnnotation();
                Net.TheVpc.Upa.Types.DataType dt = Net.TheVpc.Upa.Types.TypesFactory.ForPlatformType(d.GetType("returnType"));
                string n = d.GetString("name");
                if (Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(n)) {
                    n = d.GetLocationType();
                }
                persistenceUnit.GetExpressionManager().AddFunction(n, dt, f);
            } else if (typeof(Net.TheVpc.Upa.Callback).Equals(@event.GetContract())) {
                Net.TheVpc.Upa.Callback callbackType = (Net.TheVpc.Upa.Callback) persistenceUnit.GetFactory().CreateObject<T>(@event.GetVisitedType());
                persistenceUnit.AddCallback(callbackType);
            } else if (typeof(Net.TheVpc.Upa.EntitySecurityManager).Equals(@event.GetContract())) {
                Net.TheVpc.Upa.Config.Decoration d = (Net.TheVpc.Upa.Config.Decoration) @event.GetUserObject();
                Net.TheVpc.Upa.EntitySecurityManager secu = (Net.TheVpc.Upa.EntitySecurityManager) persistenceUnit.GetFactory().CreateObject<T>(@event.GetVisitedType());
                Net.TheVpc.Upa.Impl.Config.EntityConfiguratorProcessor.ConfigureOneShot(persistenceUnit, new Net.TheVpc.Upa.Impl.Util.SimpleEntityFilter(new Net.TheVpc.Upa.Impl.Util.EqualsStringFilter(d.GetString("entity"), false, false), true), new Net.TheVpc.Upa.Impl.Config.SecurityManagerEntityConfigurator(secu));
            } else if (@event.GetUserObject() is Net.TheVpc.Upa.Impl.Config.DecoratedMethodScan) {
                Net.TheVpc.Upa.Impl.Config.DecoratedMethodScan dms = (Net.TheVpc.Upa.Impl.Config.DecoratedMethodScan) @event.GetUserObject();
                Net.TheVpc.Upa.Config.Decoration callbackDecoration = dms.GetDecoration();
                ConfigureMethodCallback(type, dms.GetMethod(), callbackDecoration, persistenceUnit);
            }
        }

        public static void ConfigureMethodCallback(System.Type type, System.Reflection.MethodInfo method, Net.TheVpc.Upa.Config.Decoration methodDecoration, Net.TheVpc.Upa.PersistenceUnit persistenceUnit) {
            Net.TheVpc.Upa.CallbackType callbackType = Net.TheVpc.Upa.Impl.Util.PlatformUtils.GetUndefinedValue<Net.TheVpc.Upa.CallbackType>(typeof(Net.TheVpc.Upa.CallbackType));
            Net.TheVpc.Upa.EventPhase callbackPhase = Net.TheVpc.Upa.Impl.Util.PlatformUtils.GetUndefinedValue<Net.TheVpc.Upa.EventPhase>(typeof(Net.TheVpc.Upa.EventPhase));
            System.Collections.Generic.IDictionary<string , object> conf = new System.Collections.Generic.Dictionary<string , object>();
            if (methodDecoration.IsName(typeof(Net.TheVpc.Upa.Config.OnPreAlter))) {
                callbackType = Net.TheVpc.Upa.CallbackType.ON_ALTER;
                callbackPhase = Net.TheVpc.Upa.EventPhase.BEFORE;
                conf["trackSystemObjects"]=methodDecoration.GetBoolean("trackSystemObjects");
            } else if (methodDecoration.IsName(typeof(Net.TheVpc.Upa.Config.OnAlter))) {
                callbackType = Net.TheVpc.Upa.CallbackType.ON_ALTER;
                callbackPhase = Net.TheVpc.Upa.EventPhase.AFTER;
                conf["trackSystemObjects"]=methodDecoration.GetBoolean("trackSystemObjects");
            } else if (methodDecoration.IsName(typeof(Net.TheVpc.Upa.Config.OnPreCreate))) {
                callbackType = Net.TheVpc.Upa.CallbackType.ON_CREATE;
                callbackPhase = Net.TheVpc.Upa.EventPhase.BEFORE;
                conf["trackSystemObjects"]=methodDecoration.GetBoolean("trackSystemObjects");
            } else if (methodDecoration.IsName(typeof(Net.TheVpc.Upa.Config.OnCreate))) {
                callbackType = Net.TheVpc.Upa.CallbackType.ON_CREATE;
                callbackPhase = Net.TheVpc.Upa.EventPhase.AFTER;
                conf["trackSystemObjects"]=methodDecoration.GetBoolean("trackSystemObjects");
            } else if (methodDecoration.IsName(typeof(Net.TheVpc.Upa.Config.OnPreDrop))) {
                callbackType = Net.TheVpc.Upa.CallbackType.ON_DROP;
                callbackPhase = Net.TheVpc.Upa.EventPhase.BEFORE;
                conf["trackSystemObjects"]=methodDecoration.GetBoolean("trackSystemObjects");
            } else if (methodDecoration.IsName(typeof(Net.TheVpc.Upa.Config.OnDrop))) {
                callbackType = Net.TheVpc.Upa.CallbackType.ON_DROP;
                callbackPhase = Net.TheVpc.Upa.EventPhase.AFTER;
                conf["trackSystemObjects"]=methodDecoration.GetBoolean("trackSystemObjects");
            } else if (methodDecoration.IsName(typeof(Net.TheVpc.Upa.Config.OnPrePersist))) {
                callbackType = Net.TheVpc.Upa.CallbackType.ON_PERSIST;
                callbackPhase = Net.TheVpc.Upa.EventPhase.BEFORE;
                conf["trackSystemObjects"]=methodDecoration.GetBoolean("trackSystemObjects");
            } else if (methodDecoration.IsName(typeof(Net.TheVpc.Upa.Config.OnPersist))) {
                callbackType = Net.TheVpc.Upa.CallbackType.ON_PERSIST;
                callbackPhase = Net.TheVpc.Upa.EventPhase.AFTER;
                conf["trackSystemObjects"]=methodDecoration.GetBoolean("trackSystemObjects");
            } else if (methodDecoration.IsName(typeof(Net.TheVpc.Upa.Config.OnPreUpdate))) {
                callbackType = Net.TheVpc.Upa.CallbackType.ON_UPDATE;
                callbackPhase = Net.TheVpc.Upa.EventPhase.BEFORE;
                conf["trackSystemObjects"]=methodDecoration.GetBoolean("trackSystemObjects");
            } else if (methodDecoration.IsName(typeof(Net.TheVpc.Upa.Config.OnUpdate))) {
                callbackType = Net.TheVpc.Upa.CallbackType.ON_UPDATE;
                callbackPhase = Net.TheVpc.Upa.EventPhase.AFTER;
                conf["trackSystemObjects"]=methodDecoration.GetBoolean("trackSystemObjects");
            } else if (methodDecoration.IsName(typeof(Net.TheVpc.Upa.Config.OnPreRemove))) {
                callbackType = Net.TheVpc.Upa.CallbackType.ON_REMOVE;
                callbackPhase = Net.TheVpc.Upa.EventPhase.BEFORE;
                conf["trackSystemObjects"]=methodDecoration.GetBoolean("trackSystemObjects");
            } else if (methodDecoration.IsName(typeof(Net.TheVpc.Upa.Config.OnRemove))) {
                callbackType = Net.TheVpc.Upa.CallbackType.ON_REMOVE;
                callbackPhase = Net.TheVpc.Upa.EventPhase.AFTER;
                conf["trackSystemObjects"]=methodDecoration.GetBoolean("trackSystemObjects");
            } else if (methodDecoration.IsName(typeof(Net.TheVpc.Upa.Config.OnPreReset))) {
                callbackType = Net.TheVpc.Upa.CallbackType.ON_RESET;
                callbackPhase = Net.TheVpc.Upa.EventPhase.BEFORE;
                conf["trackSystemObjects"]=methodDecoration.GetBoolean("trackSystemObjects");
            } else if (methodDecoration.IsName(typeof(Net.TheVpc.Upa.Config.OnReset))) {
                callbackType = Net.TheVpc.Upa.CallbackType.ON_RESET;
                callbackPhase = Net.TheVpc.Upa.EventPhase.AFTER;
                conf["trackSystemObjects"]=methodDecoration.GetBoolean("trackSystemObjects");
            } else if (methodDecoration.IsName(typeof(Net.TheVpc.Upa.Config.OnPreInitialize))) {
                callbackType = Net.TheVpc.Upa.CallbackType.ON_INITIALIZE;
                callbackPhase = Net.TheVpc.Upa.EventPhase.BEFORE;
                conf["trackSystemObjects"]=methodDecoration.GetBoolean("trackSystemObjects");
            } else if (methodDecoration.IsName(typeof(Net.TheVpc.Upa.Config.OnInitialize))) {
                callbackType = Net.TheVpc.Upa.CallbackType.ON_INITIALIZE;
                callbackPhase = Net.TheVpc.Upa.EventPhase.AFTER;
                conf["trackSystemObjects"]=methodDecoration.GetBoolean("trackSystemObjects");
            } else if (methodDecoration.IsName(typeof(Net.TheVpc.Upa.Config.OnPreUpdateFormula))) {
                callbackType = Net.TheVpc.Upa.CallbackType.ON_UPDATE_FORMULAS;
                callbackPhase = Net.TheVpc.Upa.EventPhase.BEFORE;
                conf["trackSystemObjects"]=methodDecoration.GetBoolean("trackSystemObjects");
            } else if (methodDecoration.IsName(typeof(Net.TheVpc.Upa.Config.OnUpdateFormula))) {
                callbackType = Net.TheVpc.Upa.CallbackType.ON_UPDATE_FORMULAS;
                callbackPhase = Net.TheVpc.Upa.EventPhase.AFTER;
                conf["trackSystemObjects"]=methodDecoration.GetBoolean("trackSystemObjects");
            } else if (methodDecoration.IsName(typeof(Net.TheVpc.Upa.Config.Function))) {
                callbackType = Net.TheVpc.Upa.CallbackType.ON_EVAL;
                callbackPhase = Net.TheVpc.Upa.EventPhase.AFTER;
                string functionName = methodDecoration.GetString("name");
                System.Type returnType = methodDecoration.GetType("returnType");
                if (!Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(functionName)) {
                    conf["functionName"]=functionName;
                }
                if (returnType != null && !Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsVoid(returnType)) {
                    conf["returnType"]=returnType;
                }
            }
            if (callbackType != default(Net.TheVpc.Upa.CallbackType)) {
                object instance = null;
                if (!Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsStatic(method)) {
                    instance = persistenceUnit.GetFactory().GetSingleton<object>(type);
                }
                persistenceUnit.AddCallback(new Net.TheVpc.Upa.CallbackConfig(instance, method, callbackType, callbackPhase, conf));
            }
        }
    }
}
