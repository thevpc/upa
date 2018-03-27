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


    public interface QueryExecutor {

         Net.Vpc.Upa.Persistence.QueryResult GetQueryResult();

         System.Collections.Generic.IDictionary<string , object> GetHints();

         int GetResultCount();

         Net.Vpc.Upa.Impl.Persistence.NativeField[] GetFields();

         Net.Vpc.Upa.Impl.Persistence.QueryExecutor Execute() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Persistence.ResultMetaData GetMetaData();

         Net.Vpc.Upa.Persistence.UConnection GetConnection();
    }
}
