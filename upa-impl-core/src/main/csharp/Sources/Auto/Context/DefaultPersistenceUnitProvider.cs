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



namespace Net.TheVpc.Upa.Impl.Context
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/12/12 12:14 AM
     */
    public class DefaultPersistenceUnitProvider : Net.TheVpc.Upa.PersistenceUnitProvider {

        private static System.Threading.ThreadLocal<System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.PersistenceUnit>> current = new System.Threading.ThreadLocal<System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.PersistenceUnit>>();


        public virtual Net.TheVpc.Upa.PersistenceUnit GetPersistenceUnit(Net.TheVpc.Upa.PersistenceGroup persistenceGroup) {
            return Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.PersistenceUnit>(GetMap(),System.Convert.ToString(System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(persistenceGroup)));
        }


        public virtual void SetPersistenceUnit(Net.TheVpc.Upa.PersistenceGroup persistenceGroup, Net.TheVpc.Upa.PersistenceUnit persistenceUnit) {
            string k = System.Convert.ToString(System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(persistenceGroup));
            if (persistenceUnit == null) {
                GetMap().Remove(k);
            } else {
                GetMap()[k]=persistenceUnit;
            }
        }

        private static System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.PersistenceUnit> GetMap() {
            System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.PersistenceUnit> v = (current).Value;
            if (v == null) {
                v = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.PersistenceUnit>(3);
                (current).Value = v;
            }
            return v;
        }
    }
}
