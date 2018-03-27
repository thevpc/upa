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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/21/12 4:09 PM
     */
    public abstract class QueryResultLazyList<R> : Net.Vpc.Upa.Impl.Util.LazyList<R>, Net.Vpc.Upa.Persistence.QueryResultParser<R> {

        internal Net.Vpc.Upa.Impl.Persistence.QueryExecutor queryExecutor;

        private Net.Vpc.Upa.CloseListener closeListener;

        protected internal QueryResultLazyList(Net.Vpc.Upa.Impl.Persistence.QueryExecutor _queryExecutor)  : base(null){

            this.queryExecutor = _queryExecutor;
            this.@base = new Net.Vpc.Upa.Impl.Persistence.QueryResultReader<R>(queryExecutor.GetQueryResult(), this);
            closeListener = new Net.Vpc.Upa.Impl.Persistence.CloseListenerImpl<?>(this);
            queryExecutor.GetConnection().AddCloseListener(closeListener);
        }


        protected internal override void LoadingFinished() {
            queryExecutor.GetQueryResult().Close();
            queryExecutor.GetConnection().RemoveCloseListener(closeListener);
        }



        public virtual Net.Vpc.Upa.Impl.Persistence.QueryExecutor GetQueryExecutor() {
            return queryExecutor;
        }

        public virtual void LoadAll() {
            EnsureLoadAll();
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract R Parse(Net.Vpc.Upa.Persistence.QueryResult arg1);
    }
}
