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
     * @creationdate 9/16/12 4:58 PM
     */
    public class DefaultTransactionManager : Net.TheVpc.Upa.TransactionManager {


        public virtual Net.TheVpc.Upa.Transaction CreateTransaction(Net.TheVpc.Upa.Persistence.UConnection connection, Net.TheVpc.Upa.PersistenceUnit persistenceUnit, Net.TheVpc.Upa.Persistence.PersistenceStore persistenceStore) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (connection == null) {
                throw new System.Exception("No Active Connection Found");
            }
            Net.TheVpc.Upa.Impl.Transaction.DefaultTransaction t = new Net.TheVpc.Upa.Impl.Transaction.DefaultTransaction();
            t.Init(connection);
            return t;
        }
    }
}
