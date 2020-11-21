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



namespace Net.TheVpc.Upa.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface PersistenceStoreFactory {

         Net.TheVpc.Upa.Persistence.PersistenceStore CreatePersistenceStore(Net.TheVpc.Upa.Persistence.ConnectionProfile connectionProfile, Net.TheVpc.Upa.ObjectFactory factory, Net.TheVpc.Upa.Properties parameters);

         void Configure(Net.TheVpc.Upa.ObjectFactory factory);
    }
}
