/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



using System.Linq;
namespace Net.TheVpc.Upa
{


    /**
     *
     * @author vpc
     */
    public abstract class AbstractObjectFactory : Net.TheVpc.Upa.ObjectFactory {

        private static System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.TheVpc.Upa.AbstractObjectFactory)).FullName);

        private readonly System.Collections.Generic.Dictionary<string , object> singletons = new System.Collections.Generic.Dictionary<string , object>();

        private readonly System.Collections.Generic.IDictionary<System.Type , System.Collections.Generic.ISet<object>> alternatives = new System.Collections.Generic.Dictionary<System.Type , System.Collections.Generic.ISet<object>>();


        public virtual  T GetSingleton<T>(System.Type type) {
            string typeName = (type).FullName;
            if (singletons.ContainsKey(typeName)) {
                return (T) Net.TheVpc.Upa.FwkConvertUtils.GetMapValue<K,V>(singletons,typeName);
            }
            lock (singletons) {
                if (singletons.ContainsKey(typeName)) {
                    return (T) Net.TheVpc.Upa.FwkConvertUtils.GetMapValue<K,V>(singletons,typeName);
                }
                T o = CreateObject<>(type);
                singletons[typeName]=o;
                return o;
            }
        }


        public virtual  T GetSingleton<T>(string typeName) {
            if (singletons.ContainsKey(typeName)) {
                return (T) Net.TheVpc.Upa.FwkConvertUtils.GetMapValue<K,V>(singletons,typeName);
            }
            lock (singletons) {
                if (singletons.ContainsKey(typeName)) {
                    return (T) Net.TheVpc.Upa.FwkConvertUtils.GetMapValue<K,V>(singletons,typeName);
                }
                T o = CreateObject<>(typeName);
                singletons[typeName]=o;
                return o;
            }
        }


        public virtual  T CreateObject<T>(string typeName, string name) {
            System.Type c;
            try {
                c = System.Type.GetType(typeName);
            } catch (System.Exception ex) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.TheVpc.Upa.FwkConvertUtils.LogMessageExceptionFormatter(null,ex));
                throw new System.Exception(typeName);
            }
            return (T) CreateObject<>(c, name);
        }


        public virtual  T CreateObject<T>(System.Type type) {
            return CreateObject<>(type, null);
        }


        public virtual  T CreateObject<T>(string typeName) {
            try {
                return (T) CreateObject<>(System.Type.GetType(typeName));
            } catch (System.Exception ex) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.TheVpc.Upa.FwkConvertUtils.LogMessageExceptionFormatter(null,ex));
                throw new System.Exception("RuntimeException", ex);
            }
        }


        public virtual  System.Type[] GetAlternatives<T>(System.Type type) {
            System.Collections.Generic.IList<System.Type> all = new System.Collections.Generic.List<System.Type>();
            System.Collections.Generic.ISet<object> found = Net.TheVpc.Upa.FwkConvertUtils.GetMapValue<System.Type,System.Collections.Generic.ISet<object>>(alternatives,type);
            if (found != null) {
                Net.TheVpc.Upa.FwkConvertUtils.ListAddRange(all, found);
            }
            return all.ToArray();
        }


        public virtual  void AddAlternative<T>(System.Type type, System.Type impl) {
            System.Collections.Generic.ISet<object> found = Net.TheVpc.Upa.FwkConvertUtils.GetMapValue<System.Type,System.Collections.Generic.ISet<object>>(alternatives,type);
            if (found == null) {
                found = new System.Collections.Generic.HashSet<object>();
                alternatives[type]=found;
            }
            found.Add(impl);
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract int GetContextSupportLevel();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract T CreateObject<T>(System.Type arg1, string arg2);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void Register(System.Type arg1, System.Type arg2);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void SetParentFactory(Net.TheVpc.Upa.ObjectFactory arg1);
    }
}
