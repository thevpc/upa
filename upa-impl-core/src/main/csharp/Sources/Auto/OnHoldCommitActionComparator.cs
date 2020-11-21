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
     *
     * @author taha.bensalah@gmail.com
     */
    internal class OnHoldCommitActionComparator : System.Collections.Generic.IComparer<Net.TheVpc.Upa.Impl.OnHoldCommitAction> {

        public OnHoldCommitActionComparator() {
        }


        public virtual int Compare(Net.TheVpc.Upa.Impl.OnHoldCommitAction o1, Net.TheVpc.Upa.Impl.OnHoldCommitAction o2) {
            return o1.GetOrder() - o2.GetOrder();
        }
    }
}
