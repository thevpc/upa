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


    public interface NativeSQL {

         Net.Vpc.Upa.Persistence.UConnection GetConnection();

         void SetConnection(Net.Vpc.Upa.Persistence.UConnection connection);

         Net.Vpc.Upa.Impl.Persistence.MarshallManager GetMarshallManager();

         void SetMarshallManager(Net.Vpc.Upa.Impl.Persistence.MarshallManager marshallManager);

         Net.Vpc.Upa.Persistence.QueryResult GetQueryResult();

         Net.Vpc.Upa.Impl.Persistence.NativeField[] GetFields();

         void SetFields(Net.Vpc.Upa.Impl.Persistence.NativeField[] fields);

         int GetResultCount();

         void Execute() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         string GetQuery();

         void SetQuery(string query);

         Net.Vpc.Upa.Impl.Persistence.NativeStatementType GetStatementType();

         void SetStatementType(Net.Vpc.Upa.Impl.Persistence.NativeStatementType type);

         int Size();

         Net.Vpc.Upa.Impl.Persistence.NativeStatement GetStatement(int i);

         void AddNativeStatement(Net.Vpc.Upa.Impl.Persistence.NativeStatement s);

         string GetErrorTrace();

         int GetCurrentStatementIndex();

         int ExecuteUpdate() /* throws System.Exception */ ;

         Net.Vpc.Upa.Persistence.QueryResult ExecuteQuery() /* throws System.Exception */ ;

         string GetCurrentQuery();

         void SetCurrentQuery(string currentQuery);

         Net.Vpc.Upa.Impl.Persistence.NativeStatement GetCurrentStatement();

         void SetQueryResult(Net.Vpc.Upa.Persistence.QueryResult r);

         void SetResultCount(int r);

         Net.Vpc.Upa.Persistence.PersistenceStore GetPersistenceManager();

         object GetVar(string varName);

         void SetVar(string varName, object @value);

         System.Collections.Generic.IDictionary<string , object> GetVars();

         string GetParameter(string paramName);

         void SetParameter(string paramName, string @value);

         System.Collections.Generic.IDictionary<string , string> GetParameters();

         void SetPersistenceStore(Net.Vpc.Upa.Persistence.PersistenceStore persistenceStore);

         string GetCurrentQueryInfo();

         void SetCurrentQueryInfo(string currentQueryInfo);

         System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Param> GetQueryParameters();

         void SetQueryParameters(System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Param> queryParameters);

         void SetUpdatable(bool updatable);

         bool IsUpdatable();
    }
}
