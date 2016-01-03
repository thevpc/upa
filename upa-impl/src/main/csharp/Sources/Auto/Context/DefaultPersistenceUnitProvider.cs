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



namespace Net.Vpc.Upa.Impl.Context
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/12/12 12:14 AM
     */
    public class DefaultPersistenceUnitProvider : Net.Vpc.Upa.PersistenceUnitProvider {

        private static System.Threading.ThreadLocal<System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.PersistenceUnit>> current = new System.Threading.ThreadLocal<System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.PersistenceUnit>>();


        public virtual Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit(Net.Vpc.Upa.PersistenceGroup persistenceGroup) {
            return Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.PersistenceUnit>(GetMap(),System.Convert.ToString(System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(persistenceGroup)));
        }


        public virtual void SetPersistenceUnit(Net.Vpc.Upa.PersistenceGroup persistenceGroup, Net.Vpc.Upa.PersistenceUnit persistenceUnit) {
            string k = System.Convert.ToString(System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(persistenceGroup));
            if (persistenceUnit == null) {
                GetMap().Remove(k);
            } else {
                GetMap()[k]=persistenceUnit;
            }
        }

        private static System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.PersistenceUnit> GetMap() {
            System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.PersistenceUnit> v = (current).Value;
            if (v == null) {
                v = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.PersistenceUnit>(3);
                (current).Value = v;
            }
            return v;
        }
    }
}
