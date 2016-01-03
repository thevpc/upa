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



namespace Net.Vpc.Upa.Impl.Persistence
{


    /**
     *
     * @author vpc
     */
    internal class CloseListenerImpl<R> : Net.Vpc.Upa.CloseListener {

        private readonly Net.Vpc.Upa.Impl.Persistence.QueryResultIteratorList<R> outer;

        public CloseListenerImpl(Net.Vpc.Upa.Impl.Persistence.QueryResultIteratorList<R> outer) {
            this.outer = outer;
        }


        public virtual void BeforeClose(object source) {
            outer.EnsureLoadAll();
        }


        public virtual void AfterClose(object source) {
            outer.nativeSQL.GetConnection().RemoveCloseListener(this);
        }
    }
}
