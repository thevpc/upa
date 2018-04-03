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
     * @creationdate 9/11/12 11:57 PM
     */
    public interface PersistenceUnitProvider {

         string GetPersistenceUnitName(Net.Vpc.Upa.PersistenceGroup persistenceGroup);

         void SetPersistenceUnitName(Net.Vpc.Upa.PersistenceGroup persistenceGroup, string current);
    }
}
