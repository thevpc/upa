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
     * Created with IntelliJ IDEA.
     * User: vpc
     * Date: 8/16/12
     * Time: 6:34 AM
     * To change this template use File | Settings | File Templates.
     */

    public partial class QueryResultReader<T> : System.Collections.Generic.IEnumerator<T> {

        private Net.TheVpc.Upa.Persistence.QueryResult queryResult;

        private Net.TheVpc.Upa.Persistence.QueryResultParser<T> queryResultParser;

        public QueryResultReader(Net.TheVpc.Upa.Persistence.QueryResult resultSet, Net.TheVpc.Upa.Persistence.QueryResultParser<T> queryResultParser) {
            this.queryResult = resultSet;
            this.queryResultParser = queryResultParser;
        }






    }
}
