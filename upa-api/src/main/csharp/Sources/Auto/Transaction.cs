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



namespace Net.TheVpc.Upa
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/16/12 4:19 PM
     */
    public interface Transaction {

         Net.TheVpc.Upa.TransactionStatus GetStatus();

         void Begin() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void Commit() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void Rollback() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void Close() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void AddTransactionListener(Net.TheVpc.Upa.TransactionListener transactionListener);

         void RemoveTransactionListener(Net.TheVpc.Upa.TransactionListener transactionListener);
    }
}
