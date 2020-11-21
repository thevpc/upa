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



namespace Net.TheVpc.Upa.Impl.Transaction
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DefaultTransactionManagerFactory : Net.TheVpc.Upa.Persistence.TransactionManagerFactory {


        public virtual Net.TheVpc.Upa.TransactionManager CreateTransactionManager(Net.TheVpc.Upa.Persistence.ConnectionProfile connectionProfile, Net.TheVpc.Upa.ObjectFactory factory, Net.TheVpc.Upa.Properties parameters) {
            //        ConnectionDriver connectionDriver = connectionProfile.getConnectionDriver();
            //        if(connectionDriver==ConnectionDriver.datasource){
            //            throw new UPAException("Not yet supported");
            //        }
            return new Net.TheVpc.Upa.Impl.Transaction.DefaultTransactionManager();
        }
    }
}
