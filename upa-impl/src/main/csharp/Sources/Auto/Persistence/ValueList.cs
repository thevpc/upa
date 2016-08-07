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
     * Created with IntelliJ IDEA. User: vpc Date: 8/16/12 Time: 6:41 AM To change
     * this template use File | Settings | File Templates.
     */
    public class ValueList<T> : Net.Vpc.Upa.Impl.Persistence.QueryResultLazyList<T> {

        internal int index;

        public ValueList(Net.Vpc.Upa.Impl.Persistence.QueryExecutor queryExecutor, int index)  : base(queryExecutor){

            this.index = index;
        }

        public override T Parse(Net.Vpc.Upa.Persistence.QueryResult result) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return result.Read<T>(index);
        }
    }
}
