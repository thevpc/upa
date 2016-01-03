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



namespace Net.Vpc.Upa.Impl.Config
{


    /**
     *
     * @author vpc
     */
    public class ConfigureScanListener : Net.Vpc.Upa.ScanListener {

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Config.ConfigureScanListener)).FullName);

        private Net.Vpc.Upa.ScanListener listener;

        private System.Collections.Generic.IDictionary<System.Type , object> instances = new System.Collections.Generic.Dictionary<System.Type , object>();

        internal System.Collections.Generic.IList<Net.Vpc.Upa.PersistenceGroup> createdPersistenceGroups = new System.Collections.Generic.List<Net.Vpc.Upa.PersistenceGroup>();

        public ConfigureScanListener(Net.Vpc.Upa.ScanListener listener) {
            this.listener = listener;
        }

        public virtual void ContextItemScanned(Net.Vpc.Upa.ScanEvent @event) {
            if (listener != null) {
                listener.ContextItemScanned(@event);
            }
            Net.Vpc.Upa.UPAContext context = @event.GetContext();
            System.Type tt = @event.GetVisitedType();
            if (@event.GetContract().Equals(typeof(Net.Vpc.Upa.Callbacks.PersistenceGroupDefinitionListener))) {
                object i = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,object>(instances,tt);
                if (i == null) {
                    i = context.GetFactory().CreateObject<object>(tt);
                    instances[tt]=i;
                }
                context.AddPersistenceGroupDefinitionListener((Net.Vpc.Upa.Callbacks.PersistenceGroupDefinitionListener) i);
            }
        }

        public virtual void PersistenceGroupItemScanned(Net.Vpc.Upa.ScanEvent @event) {
            if (listener != null) {
                listener.PersistenceGroupItemScanned(@event);
            }
            Net.Vpc.Upa.PersistenceGroup persistenceGroup = @event.GetPersistenceGroup();
            System.Type t = @event.GetVisitedType();
            if (@event.GetContract().Equals(typeof(Net.Vpc.Upa.Callbacks.PersistenceUnitDefinitionListener))) {
                object i = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,object>(instances,t);
                if (i == null) {
                    i = persistenceGroup.GetFactory().CreateObject<object>(t);
                    instances[t]=i;
                }
                persistenceGroup.AddPersistenceUnitDefinitionListener((Net.Vpc.Upa.Callbacks.PersistenceUnitDefinitionListener) i);
            }
            if (@event.GetContract().Equals(typeof(Net.Vpc.Upa.PersistenceGroupSecurityManager))) {
                object i = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,object>(instances,t);
                if (i == null) {
                    i = persistenceGroup.GetFactory().CreateObject<object>(t);
                    instances[t]=i;
                }
                persistenceGroup.SetPersistenceGroupSecurityManager((Net.Vpc.Upa.PersistenceGroupSecurityManager) i);
            }
        }

        public virtual void PersistenceUnitItemScanned(Net.Vpc.Upa.ScanEvent @event) {
            if (listener != null) {
                listener.PersistenceUnitItemScanned(@event);
            }
            Net.Vpc.Upa.PersistenceUnit persistenceUnit = @event.GetPersistenceUnit();
            System.Type contract = @event.GetContract();
            System.Type type = @event.GetVisitedType();
            if (Net.Vpc.Upa.Impl.Config.URLAnnotationStrategySupport.IsPersistenceUnitItemDefinitionListener(contract)) {
                object i = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,object>(instances,type);
                if (i == null) {
                    i = persistenceUnit.GetFactory().CreateObject<object>(type);
                    instances[type]=i;
                }
                Net.Vpc.Upa.Config.Decoration at = (Net.Vpc.Upa.Config.Decoration) @event.GetUserObject();
                string _filter = at.GetString("filter");
                bool _trackSystemObjects = at.GetBoolean("trackSystemObjects");
                //                    Callback cb = (Callback) at.getAnnotation();
                if ((_filter).Length == 0) {
                    persistenceUnit.AddDefinitionListener((Net.Vpc.Upa.Callbacks.DefinitionListener) i, _trackSystemObjects);
                } else {
                    persistenceUnit.AddDefinitionListener(_filter, (Net.Vpc.Upa.Callbacks.DefinitionListener) i, _trackSystemObjects);
                }
            } else if (typeof(Net.Vpc.Upa.Callbacks.PersistenceUnitListener).Equals(contract)) {
                object i = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,object>(instances,type);
                if (i == null) {
                    i = persistenceUnit.GetFactory().CreateObject<object>(type);
                    instances[type]=i;
                }
                persistenceUnit.AddPersistenceUnitListener((Net.Vpc.Upa.Callbacks.PersistenceUnitListener) i);
            } else if (typeof(Net.Vpc.Upa.Callbacks.EntityInterceptor).Equals(contract)) {
                Net.Vpc.Upa.Callbacks.EntityInterceptor i = (Net.Vpc.Upa.Callbacks.EntityInterceptor) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,object>(instances,type);
                if (i == null) {
                    try {
                        i = (Net.Vpc.Upa.Callbacks.EntityInterceptor) persistenceUnit.GetFactory().CreateObject<Net.Vpc.Upa.Callbacks.EntityInterceptor>(type);
                    } catch (System.Exception ex) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter(null,ex));
                    }
                    if (i != null) {
                        instances[type]=i;
                    }
                }
                if (i != null) {
                    Net.Vpc.Upa.Config.Decoration at = (Net.Vpc.Upa.Config.Decoration) @event.GetUserObject();
                    string _filter = at.GetString("filter");
                    string _name = at.GetString("name");
                    if (Net.Vpc.Upa.Impl.Util.Strings.IsNullOrEmpty(_name)) {
                        _name = (i.GetType()).Name;
                    }
                    bool _trackSystemObjects = at.GetBoolean("trackSystemObjects");
                    //                    Callback cb = (Callback) at.getAnnotation();
                    persistenceUnit.AddTrigger(_name, i, _filter, _trackSystemObjects);
                }
            } else if (typeof(Net.Vpc.Upa.EntityDescriptor).Equals(@event.GetContract())) {
                Net.Vpc.Upa.EntityDescriptor desc = (Net.Vpc.Upa.EntityDescriptor) @event.GetUserObject();
                persistenceUnit.AddEntity(desc);
            } else if (typeof(Net.Vpc.Upa.Function).Equals(@event.GetContract())) {
                Net.Vpc.Upa.Function f = (Net.Vpc.Upa.Function) persistenceUnit.GetFactory().CreateObject<Net.Vpc.Upa.Function>(@event.GetVisitedType());
                Net.Vpc.Upa.Config.Decoration d = (Net.Vpc.Upa.Config.Decoration) @event.GetUserObject();
                //                net.vpc.upa.config.FunctionDefinition d = type.getAnnotation();
                Net.Vpc.Upa.Types.DataType dt = Net.Vpc.Upa.Types.TypesFactory.ForPlatformType(d.GetType("returnType"));
                string n = d.GetString("name");
                if (Net.Vpc.Upa.Impl.Util.Strings.IsNullOrEmpty(n)) {
                    n = d.GetLocationType();
                }
                persistenceUnit.GetExpressionManager().AddFunction(n, dt, f);
            } else if (typeof(Net.Vpc.Upa.Callback).Equals(@event.GetContract())) {
                Net.Vpc.Upa.Impl.Config.DecoratedMethodScan dms = (Net.Vpc.Upa.Impl.Config.DecoratedMethodScan) @event.GetUserObject();
                Net.Vpc.Upa.Config.Decoration at = dms.GetDecoration();
                //                net.vpc.upa.config.FunctionDefinition d = type.getAnnotation();
                Net.Vpc.Upa.CallbackType callbackType = Net.Vpc.Upa.Impl.Util.PlatformUtils.GetUndefinedValue<Net.Vpc.Upa.CallbackType>(typeof(Net.Vpc.Upa.CallbackType));
                System.Collections.Generic.IDictionary<string , object> conf = new System.Collections.Generic.Dictionary<string , object>();
                if (at.IsName(typeof(Net.Vpc.Upa.Config.OnAlter))) {
                    callbackType = Net.Vpc.Upa.CallbackType.ON_UPDATE;
                    conf["before"]=at.GetBoolean("before");
                    conf["after"]=at.GetBoolean("after");
                    conf["trackSystemObjects"]=at.GetBoolean("trackSystemObjects");
                } else if (at.IsName(typeof(Net.Vpc.Upa.Config.OnCreate))) {
                    callbackType = Net.Vpc.Upa.CallbackType.ON_CREATE;
                    conf["before"]=at.GetBoolean("before");
                    conf["after"]=at.GetBoolean("after");
                    conf["trackSystemObjects"]=at.GetBoolean("trackSystemObjects");
                } else if (at.IsName(typeof(Net.Vpc.Upa.Config.OnDrop))) {
                    callbackType = Net.Vpc.Upa.CallbackType.ON_DROP;
                    conf["before"]=at.GetBoolean("before");
                    conf["after"]=at.GetBoolean("after");
                    conf["trackSystemObjects"]=at.GetBoolean("trackSystemObjects");
                } else if (at.IsName(typeof(Net.Vpc.Upa.Config.OnPersist))) {
                    callbackType = Net.Vpc.Upa.CallbackType.ON_PERSIST;
                    conf["before"]=at.GetBoolean("before");
                    conf["after"]=at.GetBoolean("after");
                    conf["trackSystemObjects"]=at.GetBoolean("trackSystemObjects");
                } else if (at.IsName(typeof(Net.Vpc.Upa.Config.OnUpdate))) {
                    callbackType = Net.Vpc.Upa.CallbackType.ON_UPDATE;
                    conf["before"]=at.GetBoolean("before");
                    conf["after"]=at.GetBoolean("after");
                    conf["trackSystemObjects"]=at.GetBoolean("trackSystemObjects");
                } else if (at.IsName(typeof(Net.Vpc.Upa.Config.OnRemove))) {
                    callbackType = Net.Vpc.Upa.CallbackType.ON_REMOVE;
                    conf["before"]=at.GetBoolean("before");
                    conf["after"]=at.GetBoolean("after");
                    conf["trackSystemObjects"]=at.GetBoolean("trackSystemObjects");
                } else if (at.IsName(typeof(Net.Vpc.Upa.Config.OnReset))) {
                    callbackType = Net.Vpc.Upa.CallbackType.ON_RESET;
                    conf["before"]=at.GetBoolean("before");
                    conf["after"]=at.GetBoolean("after");
                    conf["trackSystemObjects"]=at.GetBoolean("trackSystemObjects");
                } else if (at.IsName(typeof(Net.Vpc.Upa.Config.OnInitialize))) {
                    callbackType = Net.Vpc.Upa.CallbackType.ON_INITIALIZE;
                    conf["before"]=at.GetBoolean("before");
                    conf["after"]=at.GetBoolean("after");
                    conf["trackSystemObjects"]=at.GetBoolean("trackSystemObjects");
                } else if (at.IsName(typeof(Net.Vpc.Upa.Config.Function))) {
                    callbackType = Net.Vpc.Upa.CallbackType.ON_EVAL;
                    string functionName = at.GetString("name");
                    System.Type returnType = at.GetType("returnType");
                    if (!Net.Vpc.Upa.Impl.Util.Strings.IsNullOrEmpty(functionName)) {
                        conf["functionName"]=functionName;
                    }
                    if (returnType != null && !Net.Vpc.Upa.Impl.Util.PlatformUtils.IsVoid(returnType)) {
                        conf["returnType"]=returnType;
                    }
                }
                if (callbackType != null) {
                    object instance = null;
                    if (!Net.Vpc.Upa.Impl.Util.PlatformUtils.IsStatic(dms.GetMethod())) {
                        instance = persistenceUnit.GetFactory().GetSingleton<object>(@event.GetVisitedType());
                    }
                    Net.Vpc.Upa.Callback cb = persistenceUnit.GetPersistenceGroup().GetContext().CreateCallback(instance, dms.GetMethod(), callbackType, conf);
                    persistenceUnit.AddCallback(cb);
                }
            } else if (typeof(Net.Vpc.Upa.EntitySecurityManager).Equals(@event.GetContract())) {
                Net.Vpc.Upa.Config.Decoration d = (Net.Vpc.Upa.Config.Decoration) @event.GetUserObject();
                Net.Vpc.Upa.EntitySecurityManager secu = (Net.Vpc.Upa.EntitySecurityManager) persistenceUnit.GetFactory().CreateObject<Net.Vpc.Upa.EntitySecurityManager>(@event.GetVisitedType());
                Net.Vpc.Upa.Impl.Config.EntityConfiguratorProcessor.ConfigureOneShot(persistenceUnit, new Net.Vpc.Upa.Impl.Util.SimpleEntityFilter(new Net.Vpc.Upa.Impl.Util.EqualsStringFilter(d.GetString("entity"), false, false), true), new Net.Vpc.Upa.Impl.Config.SecurityManagerEntityConfigurator(secu));
            }
        }
    }
}
