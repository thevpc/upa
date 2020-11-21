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



namespace Net.TheVpc.Upa.Impl.Persistence
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    internal class CloseListenerImpl<R> : Net.TheVpc.Upa.CloseListener {

        private readonly Net.TheVpc.Upa.Impl.Persistence.QueryResultLazyList<R> outer;

        public CloseListenerImpl(Net.TheVpc.Upa.Impl.Persistence.QueryResultLazyList<R> outer) {
            this.outer = outer;
        }


        public virtual void BeforeClose(object source) {
            outer.EnsureLoadAll();
        }


        public virtual void AfterClose(object source) {
            outer.queryExecutor.GetConnection().RemoveCloseListener(this);
        }
    }
}
