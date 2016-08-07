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
     * @creationdate 9/16/12 4:58 PM
     */
    public class DefaultTransactionManager : Net.Vpc.Upa.TransactionManager {


        public virtual Net.Vpc.Upa.Transaction CreateTransaction(Net.Vpc.Upa.Persistence.UConnection connection, Net.Vpc.Upa.PersistenceUnit persistenceUnit, Net.Vpc.Upa.Persistence.PersistenceStore persistenceStore) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (connection == null) {
                throw new System.Exception("No Active Connection Found");
            }
            Net.Vpc.Upa.Impl.Transaction.DefaultTransaction t = new Net.Vpc.Upa.Impl.Transaction.DefaultTransaction();
            t.Init(connection);
            return t;
        }
    }
}
