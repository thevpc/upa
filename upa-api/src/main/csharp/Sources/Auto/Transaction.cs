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
     * @creationdate 9/16/12 4:19 PM
     */
    public interface Transaction {

         Net.Vpc.Upa.TransactionStatus GetStatus();

         void Begin() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void Commit() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void Rollback() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void Close() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void AddTransactionListener(Net.Vpc.Upa.TransactionListener transactionListener);

         void RemoveTransactionListener(Net.Vpc.Upa.TransactionListener transactionListener);
    }
}
