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
     * @creationdate 9/16/12 5:54 PM
     */
    public interface TransactionManagerFactory {

         Net.Vpc.Upa.TransactionManager CreateTransactionManager(Net.Vpc.Upa.Persistence.ConnectionProfile connectionProfile, Net.Vpc.Upa.ObjectFactory factory, Net.Vpc.Upa.Properties parameters);
    }
}
