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



namespace Net.Vpc.Upa.Impl
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/9/12 4:19 PM
     */
    public interface OnHoldCommitAction : System.IComparable<Net.Vpc.Upa.Impl.OnHoldCommitAction> {

         void CommitModel() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void CommitStorage(Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         int GetOrder();
    }
}
