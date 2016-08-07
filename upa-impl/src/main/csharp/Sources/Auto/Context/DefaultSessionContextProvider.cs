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
    public class DefaultSessionContextProvider : Net.Vpc.Upa.SessionContextProvider {

        private static System.Threading.ThreadLocal<System.Collections.Generic.IDictionary<Net.Vpc.Upa.PersistenceGroup , Net.Vpc.Upa.Session>> current = new System.Threading.ThreadLocal<System.Collections.Generic.IDictionary<Net.Vpc.Upa.PersistenceGroup , Net.Vpc.Upa.Session>>();


        public virtual Net.Vpc.Upa.Session GetSession(Net.Vpc.Upa.PersistenceGroup persistenceGroup) {
            return Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.Vpc.Upa.PersistenceGroup,Net.Vpc.Upa.Session>(GetMap(),persistenceGroup);
        }


        public virtual void SetSession(Net.Vpc.Upa.PersistenceGroup persistenceGroup, Net.Vpc.Upa.Session session) {
            if (session == null) {
                GetMap().Remove(persistenceGroup);
            } else {
                GetMap()[persistenceGroup]=session;
            }
        }

        private static System.Collections.Generic.IDictionary<Net.Vpc.Upa.PersistenceGroup , Net.Vpc.Upa.Session> GetMap() {
            System.Collections.Generic.IDictionary<Net.Vpc.Upa.PersistenceGroup , Net.Vpc.Upa.Session> v = (current).Value;
            if (v == null) {
                v = new System.Collections.Generic.Dictionary<Net.Vpc.Upa.PersistenceGroup , Net.Vpc.Upa.Session>(3);
                (current).Value = v;
            }
            return v;
        }
    }
}
