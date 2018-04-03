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



namespace Net.Vpc.Upa
{

    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/12/12 12:02 AM
     */
    public interface SessionContextProvider {

         Net.Vpc.Upa.Session GetSession(Net.Vpc.Upa.PersistenceGroup persistenceGroup);

         void SetSession(Net.Vpc.Upa.PersistenceGroup persistenceGroup, Net.Vpc.Upa.Session session);
    }
}
