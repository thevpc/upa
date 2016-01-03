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
    public abstract class QueryResultIteratorList<R> : Net.Vpc.Upa.Impl.Util.IteratorList<R>, Net.Vpc.Upa.Persistence.QueryResultParser<R> {

        internal Net.Vpc.Upa.Impl.Persistence.NativeSQL nativeSQL;

        private Net.Vpc.Upa.CloseListener closeListener;

        protected internal QueryResultIteratorList(Net.Vpc.Upa.Impl.Persistence.NativeSQL _nativeSQL)  : base(null){

            this.nativeSQL = _nativeSQL;
            this.@base = new Net.Vpc.Upa.Impl.Persistence.QueryResultReader<R>(nativeSQL.GetQueryResult(), this);
            closeListener = new Net.Vpc.Upa.Impl.Persistence.CloseListenerImpl<R>(this);
            nativeSQL.GetConnection().AddCloseListener(closeListener);
        }


        protected internal override void LoadingFinished() {
            nativeSQL.GetQueryResult().Close();
            nativeSQL.GetConnection().RemoveCloseListener(closeListener);
        }



        public virtual Net.Vpc.Upa.Impl.Persistence.NativeSQL GetNativeSQL() {
            return nativeSQL;
        }

        public virtual void LoadAll() {
            Count;
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract R Parse(Net.Vpc.Upa.Persistence.QueryResult arg1);
    }
}
