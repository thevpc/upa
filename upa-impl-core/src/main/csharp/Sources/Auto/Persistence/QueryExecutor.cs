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


    public interface QueryExecutor {

         Net.TheVpc.Upa.Persistence.QueryResult GetQueryResult();

         System.Collections.Generic.IDictionary<string , object> GetHints();

         int GetResultCount();

         Net.TheVpc.Upa.Impl.Persistence.NativeField[] GetFields();

         Net.TheVpc.Upa.Impl.Persistence.QueryExecutor Execute() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Persistence.ResultMetaData GetMetaData();

         Net.TheVpc.Upa.Persistence.UConnection GetConnection();
    }
}
