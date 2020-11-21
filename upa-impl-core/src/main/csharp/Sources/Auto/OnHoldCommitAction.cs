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



namespace Net.TheVpc.Upa.Impl
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/9/12 4:19 PM
     */
    public interface OnHoldCommitAction : System.IComparable<Net.TheVpc.Upa.Impl.OnHoldCommitAction> {

         void CommitModel() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void CommitStorage(Net.TheVpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         int GetOrder();
    }
}
