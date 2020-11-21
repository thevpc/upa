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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/21/12 4:09 PM
     */
    public abstract class QueryResultLazyList<R> : Net.TheVpc.Upa.Impl.Util.LazyList<R>, Net.TheVpc.Upa.Persistence.QueryResultParser<R> {

        internal Net.TheVpc.Upa.Impl.Persistence.QueryExecutor queryExecutor;

        private Net.TheVpc.Upa.CloseListener closeListener;

        protected internal QueryResultLazyList(Net.TheVpc.Upa.Impl.Persistence.QueryExecutor _queryExecutor)  : base(null){

            this.queryExecutor = _queryExecutor;
            this.@base = new Net.TheVpc.Upa.Impl.Persistence.QueryResultReader<R>(queryExecutor.GetQueryResult(), this);
            closeListener = new Net.TheVpc.Upa.Impl.Persistence.CloseListenerImpl<?>(this);
            queryExecutor.GetConnection().AddCloseListener(closeListener);
        }


        protected internal override void LoadingFinished() {
            queryExecutor.GetQueryResult().Close();
            queryExecutor.GetConnection().RemoveCloseListener(closeListener);
        }



        public virtual Net.TheVpc.Upa.Impl.Persistence.QueryExecutor GetQueryExecutor() {
            return queryExecutor;
        }

        public virtual void LoadAll() {
            EnsureLoadAll();
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract R Parse(Net.TheVpc.Upa.Persistence.QueryResult arg1);
    }
}
