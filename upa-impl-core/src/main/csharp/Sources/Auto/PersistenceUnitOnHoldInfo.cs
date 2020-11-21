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



namespace Net.TheVpc.Upa.Impl
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/9/12 2:48 PM
     */
    public class PersistenceUnitOnHoldInfo {

        public System.Collections.Generic.ISet<string> names = new System.Collections.Generic.HashSet<string>();

        public System.Collections.Generic.IDictionary<string , System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Callbacks.EntityInterceptor>> triggers = new System.Collections.Generic.Dictionary<string , System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Callbacks.EntityInterceptor>>();

        public virtual System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Callbacks.EntityInterceptor> GetTriggersMap(string entityName) {
            System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Callbacks.EntityInterceptor> tt = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Callbacks.EntityInterceptor>>(triggers,entityName);
            if (tt == null) {
                tt = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Callbacks.EntityInterceptor>();
                triggers[entityName]=tt;
            }
            return tt;
        }

        public virtual bool IsDeclared(string type, string name) {
            return names.Contains(type + "." + name);
        }
    }
}
