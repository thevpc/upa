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
    public class DefaultSessionContextProvider : Net.TheVpc.Upa.SessionContextProvider {

        private static System.Threading.ThreadLocal<System.Collections.Generic.IDictionary<Net.TheVpc.Upa.PersistenceGroup , Net.TheVpc.Upa.Session>> current = new System.Threading.ThreadLocal<System.Collections.Generic.IDictionary<Net.TheVpc.Upa.PersistenceGroup , Net.TheVpc.Upa.Session>>();


        public virtual Net.TheVpc.Upa.Session GetSession(Net.TheVpc.Upa.PersistenceGroup persistenceGroup) {
            return Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.TheVpc.Upa.PersistenceGroup,Net.TheVpc.Upa.Session>(GetMap(),persistenceGroup);
        }


        public virtual void SetSession(Net.TheVpc.Upa.PersistenceGroup persistenceGroup, Net.TheVpc.Upa.Session session) {
            if (session == null) {
                GetMap().Remove(persistenceGroup);
            } else {
                GetMap()[persistenceGroup]=session;
            }
        }

        private static System.Collections.Generic.IDictionary<Net.TheVpc.Upa.PersistenceGroup , Net.TheVpc.Upa.Session> GetMap() {
            System.Collections.Generic.IDictionary<Net.TheVpc.Upa.PersistenceGroup , Net.TheVpc.Upa.Session> v = (current).Value;
            if (v == null) {
                v = new System.Collections.Generic.Dictionary<Net.TheVpc.Upa.PersistenceGroup , Net.TheVpc.Upa.Session>(3);
                (current).Value = v;
            }
            return v;
        }
    }
}
