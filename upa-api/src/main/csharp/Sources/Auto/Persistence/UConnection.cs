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



namespace Net.Vpc.Upa.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 2/3/13 7:17 PM
     */
    public interface UConnection {

         Net.Vpc.Upa.Persistence.QueryResult ExecuteQuery(string query, Net.Vpc.Upa.Types.DataTypeTransform[] types, System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.Parameter> queryParameters, bool updatable) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         int ExecuteNonQuery(string currentQuery, System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.Parameter> queryParameters, System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.Parameter> generatedKeys) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         int ExecuteScript(Net.Vpc.Upa.Expressions.QueryScript script, bool exitOnError) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void Close() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void AddCloseListener(Net.Vpc.Upa.CloseListener closeListener);

         void RemoveCloseListener(Net.Vpc.Upa.CloseListener closeListener);

         System.Data.IDbConnection GetMetadataAccessibleConnection() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Data.IDbConnection GetPlatformConnection() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         object GetProperty(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IDictionary<string , object> GetProperties() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         void SetProperty(string name, object @value) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;
    }
}
