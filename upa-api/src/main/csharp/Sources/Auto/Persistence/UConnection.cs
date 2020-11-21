/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.TheVpc.Upa.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 2/3/13 7:17 PM
     */
    public interface UConnection {

         Net.TheVpc.Upa.Persistence.QueryResult ExecuteQuery(string query, Net.TheVpc.Upa.Types.DataTypeTransform[] types, System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.Parameter> queryParameters, bool updatable) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         int ExecuteNonQuery(string currentQuery, System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.Parameter> queryParameters, System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.Parameter> generatedKeys) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         int ExecuteScript(Net.TheVpc.Upa.Expressions.QueryScript script, bool exitOnError) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void Close() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void AddCloseListener(Net.TheVpc.Upa.CloseListener closeListener);

         void RemoveCloseListener(Net.TheVpc.Upa.CloseListener closeListener);

         object GetMetadataAccessibleConnection() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         object GetPlatformConnection() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         object GetProperty(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IDictionary<string , object> GetProperties() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void SetProperty(string name, object @value) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         void BeginTransaction();

         void CommitTransaction();

         void RollbackTransaction();
    }
}
