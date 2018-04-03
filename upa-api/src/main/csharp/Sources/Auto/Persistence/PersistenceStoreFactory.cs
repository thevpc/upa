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



namespace Net.Vpc.Upa.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface PersistenceStoreFactory {

         Net.Vpc.Upa.Persistence.PersistenceStore CreatePersistenceStore(Net.Vpc.Upa.Persistence.ConnectionProfile connectionProfile, Net.Vpc.Upa.ObjectFactory factory, Net.Vpc.Upa.Properties parameters);

         void Configure(Net.Vpc.Upa.ObjectFactory factory);
    }
}
