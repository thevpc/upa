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



namespace Net.TheVpc.Upa
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/11/12 9:21 PM
     */
    public class RootObjectFactory : Net.TheVpc.Upa.ObjectFactory {

        internal readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.TheVpc.Upa.RootObjectFactory)).FullName);

        private Net.TheVpc.Upa.ObjectFactory parentFactory;

        private Net.TheVpc.Upa.Impl.Util.ClassMap<System.Type> map = new Net.TheVpc.Upa.Impl.Util.ClassMap<System.Type>();

        private readonly System.Collections.Generic.Dictionary<string , object> singletons = new System.Collections.Generic.Dictionary<string , object>();

        public RootObjectFactory() {
            Register(typeof(Net.TheVpc.Upa.UPAContext), typeof(Net.TheVpc.Upa.Impl.Config.DefaultUPAContext));
            Register(typeof(Net.TheVpc.Upa.UPAContextProvider), typeof(Net.TheVpc.Upa.Impl.Context.DefaultUPAContextProvider));
            Register(typeof(Net.TheVpc.Upa.ObjectFactory), typeof(Net.TheVpc.Upa.Impl.DefaultTypedFactory));
            Register(typeof(Net.TheVpc.Upa.PersistenceUnitProvider), typeof(Net.TheVpc.Upa.Impl.Context.DefaultPersistenceUnitProvider));
            Register(typeof(Net.TheVpc.Upa.PersistenceGroupContextProvider), typeof(Net.TheVpc.Upa.Impl.Context.DefaultPersistenceGroupContextProvider));
            Register(typeof(Net.TheVpc.Upa.PersistenceGroup), typeof(Net.TheVpc.Upa.Impl.DefaultPersistenceGroup));
            Register(typeof(Net.TheVpc.Upa.PersistenceUnit), typeof(Net.TheVpc.Upa.Impl.DefaultPersistenceUnit));
            Register(typeof(Net.TheVpc.Upa.I18NStringStrategy), typeof(Net.TheVpc.Upa.Impl.DefaultI18NStringStrategy));
            Register(typeof(Net.TheVpc.Upa.Key), typeof(Net.TheVpc.Upa.Impl.DefaultKey));
            Register(typeof(Net.TheVpc.Upa.Record), typeof(Net.TheVpc.Upa.Impl.DefaultRecord));
            Register(typeof(Net.TheVpc.Upa.Persistence.PersistenceStoreFactory), typeof(Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceStoreFactory));
            Register(typeof(Net.TheVpc.Upa.SessionContextProvider), typeof(Net.TheVpc.Upa.Impl.Context.DefaultSessionContextProvider));
            //        register(PropertiesConnectionProfileManager.class,DefaultPropertiesConnectionProfileManager.class);
            Register(typeof(Net.TheVpc.Upa.Persistence.EntityExecutionContext), typeof(Net.TheVpc.Upa.Impl.Persistence.DefaultExecutionContext));
            Register(typeof(Net.TheVpc.Upa.EntityShield), typeof(Net.TheVpc.Upa.Impl.DefaultEntityShield));
            Register(typeof(Net.TheVpc.Upa.Impl.DefaultEntityExtensionManager), typeof(Net.TheVpc.Upa.Impl.DefaultEntityExtensionManager));
            Register(typeof(Net.TheVpc.Upa.Persistence.EntityOperationManager), typeof(Net.TheVpc.Upa.Impl.Persistence.DefaultEntityOperationManager));
            Register(typeof(Net.TheVpc.Upa.Types.DataTypeTransformFactory), typeof(Net.TheVpc.Upa.Impl.Transform.DefaultDataTypeTransformFactory));
            Register(typeof(Net.TheVpc.Upa.Index), typeof(Net.TheVpc.Upa.Impl.DefaultIndex));
            Register(typeof(Net.TheVpc.Upa.Entity), typeof(Net.TheVpc.Upa.Impl.DefaultEntity));
            Register(typeof(Net.TheVpc.Upa.Package), typeof(Net.TheVpc.Upa.Impl.DefaultPackage));
            Register(typeof(Net.TheVpc.Upa.Relationship), typeof(Net.TheVpc.Upa.Impl.DefaultRelationship));
            Register(typeof(Net.TheVpc.Upa.Section), typeof(Net.TheVpc.Upa.Impl.DefaultSection));
            Register(typeof(Net.TheVpc.Upa.UPASecurityManager), typeof(Net.TheVpc.Upa.Impl.Security.DefaultSecurityManager));
            Register(typeof(Net.TheVpc.Upa.Persistence.TransactionManagerFactory), typeof(Net.TheVpc.Upa.Impl.Transaction.DefaultTransactionManagerFactory));
            Register(typeof(Net.TheVpc.Upa.TransactionManager), typeof(Net.TheVpc.Upa.Impl.Transaction.DefaultTransactionManager));
            Register(typeof(Net.TheVpc.Upa.Session), typeof(Net.TheVpc.Upa.Impl.Context.DefaultSession));
            //        register(Modifiers.class, DefaultModifiers.class);
            Register(typeof(Net.TheVpc.Upa.Persistence.PersistenceNameStrategy), typeof(Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceNameStrategy));
            Register(typeof(Net.TheVpc.Upa.Extensions.HierarchyExtension), typeof(Net.TheVpc.Upa.Impl.Extension.HierarchicalRelationshipSupport));
            Register(typeof(Net.TheVpc.Upa.Persistence.UnionEntityExtension), typeof(Net.TheVpc.Upa.Impl.Extension.DefaultUnionEntityExtension));
            Register(typeof(Net.TheVpc.Upa.Persistence.SingletonExtension), typeof(Net.TheVpc.Upa.Impl.Extension.DefaultSingletonExtension));
            Register(typeof(Net.TheVpc.Upa.Persistence.ViewEntityExtension), typeof(Net.TheVpc.Upa.Impl.Extension.DefaultViewEntityExtension));
            Register(typeof(Net.TheVpc.Upa.Persistence.FilterEntityExtension), typeof(Net.TheVpc.Upa.Impl.Extension.DefaultFilterEntityExtension));
            Register(typeof(Net.TheVpc.Upa.QLExpressionParser), typeof(Net.TheVpc.Upa.Impl.Uql.DefaultQLExpressionParser));
            Register(typeof(Net.TheVpc.Upa.BeanAdapterFactory), typeof(Net.TheVpc.Upa.Impl.Util.DefaultBeanAdapterFactory));
            Register(typeof(Net.TheVpc.Upa.QLEvaluator), typeof(Net.TheVpc.Upa.Impl.Eval.DefaultQLEvaluator));
            Register(typeof(Net.TheVpc.Upa.Properties), typeof(Net.TheVpc.Upa.Impl.DefaultProperties));
            
        }

        public void Register(System.Type contract, System.Type impl) {
            map.Put(contract, impl);
        }


        public virtual void SetParentFactory(Net.TheVpc.Upa.ObjectFactory factory) {
            this.parentFactory = factory;
        }


        public virtual  T CreateObject<T>(System.Type type, string name) {
            System.Type best = map.Get(type);
            if (best == null || !type.IsAssignableFrom(best)) {
                if (parentFactory != null) {
                    return parentFactory.CreateObject<T>(type, name);
                }
                if (Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsAbstract(type) || Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsInterface(type)) {
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
                c = Net.TheVpc.Upa.Impl.Util.PlatformUtils.ForName(typeName);
            } catch (System.Exception ex) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter(null,ex));
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
                System.Type c = (System.Type) Net.TheVpc.Upa.Impl.Util.PlatformUtils.ForName(typeName);
                return (T) CreateObject<T>(c);
            } catch (System.Exception ex) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter(null,ex));
                throw new System.Exception("RuntimeException", ex);
            }
        }


        public virtual  T GetSingleton<T>(System.Type type) {
            string typeName = (type).FullName;
            if (singletons.ContainsKey(typeName)) {
                return (T) Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(singletons,typeName);
            }
            lock (singletons) {
                if (singletons.ContainsKey(typeName)) {
                    return (T) Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(singletons,typeName);
                }
                T o = CreateObject<T>(type);
                singletons[typeName]=o;
                return o;
            }
        }


        public virtual  T GetSingleton<T>(string typeName) {
            if (singletons.ContainsKey(typeName)) {
                return (T) Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(singletons,typeName);
            }
            lock (singletons) {
                if (singletons.ContainsKey(typeName)) {
                    return (T) Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(singletons,typeName);
                }
                T o = CreateObject<T>(typeName);
                singletons[typeName]=o;
                return o;
            }
        }
    }
}
