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



namespace Net.Vpc.Upa.Impl
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/11/12 9:21 PM
     */
    public class DefaultTypedFactory : Net.Vpc.Upa.ObjectFactory {

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.DefaultTypedFactory)).FullName);

        private Net.Vpc.Upa.ObjectFactory parentFactory;

        private readonly System.Collections.Generic.Dictionary<string , object> singletons = new System.Collections.Generic.Dictionary<string , object>();

        public DefaultTypedFactory() {
        }

        public virtual void SetParentFactory(Net.Vpc.Upa.ObjectFactory factory) {
            this.parentFactory = factory;
        }


        public virtual  T CreateObject<T>(System.Type type, string name) {
            return parentFactory.CreateObject<T>(type, name);
        }

        public virtual  T CreateObject<T>(string typeName, string name) {
            return parentFactory.CreateObject<T>(typeName, name);
        }

        public virtual  T CreateObject<T>(System.Type type) {
            return parentFactory.CreateObject<T>(type);
        }

        public virtual  T CreateObject<T>(string typeName) {
            try {
                System.Type type = (System.Type) Net.Vpc.Upa.Impl.Util.PlatformUtils.ForName(typeName);
                return (T) CreateObject<T>(type);
            } catch (System.Exception ex) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter(null,ex));
                throw new System.Exception("RuntimeException", ex);
            }
        }

        public virtual int GetContextSupportLevel() {
            return 0;
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
