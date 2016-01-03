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



namespace Net.Vpc.Upa
{

    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/11/12 11:57 PM
     */
    public interface PersistenceUnitProvider {

         Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit(Net.Vpc.Upa.PersistenceGroup persistenceGroup);

         void SetPersistenceUnit(Net.Vpc.Upa.PersistenceGroup persistenceGroup, Net.Vpc.Upa.PersistenceUnit current);
    }
}
