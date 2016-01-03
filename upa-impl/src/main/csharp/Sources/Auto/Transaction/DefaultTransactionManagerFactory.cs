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



namespace Net.Vpc.Upa.Impl.Transaction
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DefaultTransactionManagerFactory : Net.Vpc.Upa.Persistence.TransactionManagerFactory {


        public virtual Net.Vpc.Upa.TransactionManager CreateTransactionManager(Net.Vpc.Upa.Persistence.ConnectionProfile connectionProfile, Net.Vpc.Upa.ObjectFactory factory, Net.Vpc.Upa.Properties parameters) {
            //        ConnectionDriver connectionDriver = connectionProfile.getConnectionDriver();
            //        if(connectionDriver==ConnectionDriver.datasource){
            //            throw new UPAException("Not yet supported");
            //        }
            return new Net.Vpc.Upa.Impl.Transaction.DefaultTransactionManager();
        }
    }
}
