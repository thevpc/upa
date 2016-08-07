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
     * @creationdate 9/11/12 9:21 PM
     */
    public class RootObjectFactory : Net.Vpc.Upa.ObjectFactory {

        internal readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.RootObjectFactory)).FullName);

        private Net.Vpc.Upa.ObjectFactory parentFactory;

        private Net.Vpc.Upa.Impl.Util.ClassMap<System.Type> map = new Net.Vpc.Upa.Impl.Util.ClassMap<System.Type>();

        private readonly System.Collections.Generic.Dictionary<string , object> singletons = new System.Collections.Generic.Dictionary<string , object>();

        public RootObjectFactory() {
            Register(typeof(Net.Vpc.Upa.UPAContext), typeof(Net.Vpc.Upa.Impl.Config.DefaultUPAContext));
            Register(typeof(Net.Vpc.Upa.UPAContextProvider), typeof(Net.Vpc.Upa.Impl.Context.DefaultUPAContextProvider));
            Register(typeof(Net.Vpc.Upa.ObjectFactory), typeof(Net.Vpc.Upa.Impl.DefaultTypedFactory));
            Register(typeof(Net.Vpc.Upa.PersistenceUnitProvider), typeof(Net.Vpc.Upa.Impl.Context.DefaultPersistenceUnitProvider));
            Register(typeof(Net.Vpc.Upa.PersistenceGroupContextProvider), typeof(Net.Vpc.Upa.Impl.Context.DefaultPersistenceGroupContextProvider));
            Register(typeof(Net.Vpc.Upa.PersistenceGroup), typeof(Net.Vpc.Upa.Impl.DefaultPersistenceGroup));
            Register(typeof(Net.Vpc.Upa.PersistenceUnit), typeof(Net.Vpc.Upa.Impl.DefaultPersistenceUnit));
            Register(typeof(Net.Vpc.Upa.I18NStringStrategy), typeof(Net.Vpc.Upa.Impl.DefaultI18NStringStrategy));
            Register(typeof(Net.Vpc.Upa.Key), typeof(Net.Vpc.Upa.Impl.DefaultKey));
            Register(typeof(Net.Vpc.Upa.Record), typeof(Net.Vpc.Upa.Impl.DefaultRecord));
            Register(typeof(Net.Vpc.Upa.Persistence.PersistenceStoreFactory), typeof(Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceStoreFactory));
            Register(typeof(Net.Vpc.Upa.SessionContextProvider), typeof(Net.Vpc.Upa.Impl.Context.DefaultSessionContextProvider));
            //        register(PropertiesConnectionProfileManager.class,DefaultPropertiesConnectionProfileManager.class);
            Register(typeof(Net.Vpc.Upa.Persistence.EntityExecutionContext), typeof(Net.Vpc.Upa.Impl.Persistence.DefaultExecutionContext));
            Register(typeof(Net.Vpc.Upa.EntityShield), typeof(Net.Vpc.Upa.Impl.DefaultEntityShield));
            Register(typeof(Net.Vpc.Upa.Impl.DefaultEntityExtensionManager), typeof(Net.Vpc.Upa.Impl.DefaultEntityExtensionManager));
            Register(typeof(Net.Vpc.Upa.Persistence.EntityOperationManager), typeof(Net.Vpc.Upa.Impl.Persistence.DefaultEntityOperationManager));
            Register(typeof(Net.Vpc.Upa.Types.DataTypeTransformFactory), typeof(Net.Vpc.Upa.Impl.Transform.DefaultDataTypeTransformFactory));
            Register(typeof(Net.Vpc.Upa.Index), typeof(Net.Vpc.Upa.Impl.DefaultIndex));
            Register(typeof(Net.Vpc.Upa.Entity), typeof(Net.Vpc.Upa.Impl.DefaultEntity));
            Register(typeof(Net.Vpc.Upa.Package), typeof(Net.Vpc.Upa.Impl.DefaultPackage));
            Register(typeof(Net.Vpc.Upa.Relationship), typeof(Net.Vpc.Upa.Impl.DefaultRelationship));
            Register(typeof(Net.Vpc.Upa.Section), typeof(Net.Vpc.Upa.Impl.DefaultSection));
            Register(typeof(Net.Vpc.Upa.UPASecurityManager), typeof(Net.Vpc.Upa.Impl.Security.DefaultSecurityManager));
            Register(typeof(Net.Vpc.Upa.Persistence.TransactionManagerFactory), typeof(Net.Vpc.Upa.Impl.Transaction.DefaultTransactionManagerFactory));
            Register(typeof(Net.Vpc.Upa.TransactionManager), typeof(Net.Vpc.Upa.Impl.Transaction.DefaultTransactionManager));
            Register(typeof(Net.Vpc.Upa.Session), typeof(Net.Vpc.Upa.Impl.Context.DefaultSession));
            //        register(Modifiers.class, DefaultModifiers.class);
            Register(typeof(Net.Vpc.Upa.Persistence.PersistenceNameStrategy), typeof(Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceNameStrategy));
            Register(typeof(Net.Vpc.Upa.Extensions.HierarchyExtension), typeof(Net.Vpc.Upa.Impl.Extension.HierarchicalRelationshipSupport));
            Register(typeof(Net.Vpc.Upa.Persistence.UnionEntityExtension), typeof(Net.Vpc.Upa.Impl.Extension.DefaultUnionEntityExtension));
            Register(typeof(Net.Vpc.Upa.Persistence.SingletonExtension), typeof(Net.Vpc.Upa.Impl.Extension.DefaultSingletonExtension));
            Register(typeof(Net.Vpc.Upa.Persistence.ViewEntityExtension), typeof(Net.Vpc.Upa.Impl.Extension.DefaultViewEntityExtension));
            Register(typeof(Net.Vpc.Upa.Persistence.FilterEntityExtension), typeof(Net.Vpc.Upa.Impl.Extension.DefaultFilterEntityExtension));
            Register(typeof(Net.Vpc.Upa.QLExpressionParser), typeof(Net.Vpc.Upa.Impl.Uql.DefaultQLExpressionParser));
            Register(typeof(Net.Vpc.Upa.BeanAdapterFactory), typeof(Net.Vpc.Upa.Impl.Util.DefaultBeanAdapterFactory));
            Register(typeof(Net.Vpc.Upa.QLEvaluator), typeof(Net.Vpc.Upa.Impl.Eval.DefaultQLEvaluator));
            Register(typeof(Net.Vpc.Upa.Properties), typeof(Net.Vpc.Upa.Impl.DefaultProperties));
            
        }

        public void Register(System.Type contract, System.Type impl) {
            map.Put(contract, impl);
        }


        public virtual void SetParentFactory(Net.Vpc.Upa.ObjectFactory factory) {
            this.parentFactory = factory;
        }


        public virtual  T CreateObject<T>(System.Type type, string name) {
            System.Type best = map.Get(type);
            if (best == null || !type.IsAssignableFrom(best)) {
                if (parentFactory != null) {
                    return parentFactory.CreateObject<T>(type, name);
                }
                if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsAbstract(type) || Net.Vpc.Upa.Impl.Util.PlatformUtils.IsInterface(type)) {
                    throw new System.Exception((type).Name);
                }
                best = type;
            }
            try {
                return (T) (T)System.Activator.CreateInstance(best);
            } catch (System.Exception e) {
                throw new System.Exception("RuntimeException", e);
            }
        }

        public virtual  T CreateObject<T>(string typeName, string name) {
            System.Type c;
            try {
                c = Net.Vpc.Upa.Impl.Util.PlatformUtils.ForName(typeName);
            } catch (System.Exception ex) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter(null,ex));
                throw new System.Exception(typeName);
            }
            return (T) CreateObject<T>(c, name);
        }

        public virtual int GetContextSupportLevel() {
            return 0;
        }

        public virtual  T CreateObject<T>(System.Type type) {
            return CreateObject<T>(type, null);
        }

        public virtual  T CreateObject<T>(string typeName) {
            try {
                System.Type c = (System.Type) Net.Vpc.Upa.Impl.Util.PlatformUtils.ForName(typeName);
                return (T) CreateObject<T>(c);
            } catch (System.Exception ex) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter(null,ex));
                throw new System.Exception("RuntimeException", ex);
            }
        }


        public virtual  T GetSingleton<T>(System.Type type) {
            string typeName = (type).FullName;
            if (singletons.ContainsKey(typeName)) {
                return (T) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(singletons,typeName);
            }
            lock (singletons) {
                if (singletons.ContainsKey(typeName)) {
                    return (T) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(singletons,typeName);
                }
                T o = CreateObject<T>(type);
                singletons[typeName]=o;
                return o;
            }
        }


        public virtual  T GetSingleton<T>(string typeName) {
            if (singletons.ContainsKey(typeName)) {
                return (T) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(singletons,typeName);
            }
            lock (singletons) {
                if (singletons.ContainsKey(typeName)) {
                    return (T) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(singletons,typeName);
                }
                T o = CreateObject<T>(typeName);
                singletons[typeName]=o;
                return o;
            }
        }
    }
}
