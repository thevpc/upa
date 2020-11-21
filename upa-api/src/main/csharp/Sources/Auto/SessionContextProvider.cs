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



namespace Net.TheVpc.Upa
{

    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/12/12 12:02 AM
     */
    public interface SessionContextProvider {

         Net.TheVpc.Upa.Session GetSession(Net.TheVpc.Upa.PersistenceGroup persistenceGroup);

         void SetSession(Net.TheVpc.Upa.PersistenceGroup persistenceGroup, Net.TheVpc.Upa.Session session);
    }
}
