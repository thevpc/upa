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



namespace Net.TheVpc.Upa
{


    /**
     * Created with IntelliJ IDEA. User: vpc Date: 8/19/12 Time: 6:07 PM To change
     * this template use File | Settings | File Templates.
     */
    public interface Query : Net.TheVpc.Upa.Closeable {

         Net.TheVpc.Upa.Types.Temporal GetDate() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool? GetBoolean() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         int? GetInteger() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         long? GetLong() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         double? GetDouble() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         string GetString() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         object GetNumber() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         object GetSingleValue() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         object GetSingleValue(object defaultValue) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.MultiDocument GetMultiDocument() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Document GetDocument() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

        /**
             * Executes a Select query and returns a single result.
             * @param <R> Result Type
             * @return Single result if unique
             * @throws Net.TheVpc.Upa.exceptions.NonUniqueResultException if more thant one result was returned by query
             * @throws Net.TheVpc.Upa.exceptions.NoResultException if no result if returned by query
             */
          R GetSingleResult<R>() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

        /**
             * Executes a Select query and returns a single result if found.
             * If query returns no result null is returned.
             * When Multiple results NonUniqueResultException will be thrown
             * @param <R> Result Type
             * @return Single result if found. When Multiple results NonUniqueResultException will be thrown
             * @throws Net.TheVpc.Upa.exceptions.NonUniqueResultException if more thant one result was returned by query
             */
          R GetSingleResultOrNull<R>() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

        /**
             * Executes a Select query and returns a single result if found.
             * If query returns no result null is returned.
             * When Multiple results, the first result will be returned
             * @param <R> Result Type
             * @return Single result if found. When Multiple results, the first result will be returned. If query returns no result null is returned.
             */
          R GetFirstResultOrNull<R>() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         bool IsEmpty() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

          System.Collections.Generic.IList<K> GetIdList<K>() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

          System.Collections.Generic.ISet<K> GetIdSet<K>() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.TheVpc.Upa.Key> GetKeyList() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.ISet<Net.TheVpc.Upa.Key> GetKeySet() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.TheVpc.Upa.MultiDocument> GetMultiDocumentList() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

          System.Collections.Generic.IList<T> GetResultList<T>(System.Type type, params string [] fields);

          System.Collections.Generic.ISet<T> GetResultSet<T>(System.Type type, params string [] fields);

          System.Collections.Generic.IList<T> GetResultList<T>();

          System.Collections.Generic.ISet<T> GetResultSet<T>();

         System.Collections.Generic.IList<Net.TheVpc.Upa.Document> GetDocumentList() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

          System.Collections.Generic.IList<T> GetValueList<T>(int index) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

          System.Collections.Generic.ISet<T> GetValueSet<T>(int index) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

          System.Collections.Generic.ISet<T> GetValueSet<T>(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

          System.Collections.Generic.IList<T> GetValueList<T>(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Persistence.ResultMetaData GetMetaData() /* throws Net.TheVpc.Upa.Exceptions.UPAException */ ;

         Net.TheVpc.Upa.Query SetParameter(string name, object @value);

         Net.TheVpc.Upa.Query SetParameters(System.Collections.Generic.IDictionary<string , object> parameters);

         Net.TheVpc.Upa.Query SetParameter(int index, object @value);

         Net.TheVpc.Upa.Query SetParameter(string name, object @value, bool condition);

         Net.TheVpc.Upa.Query SetParameters(System.Collections.Generic.IDictionary<string , object> parameters, bool condition);

         Net.TheVpc.Upa.Query SetParameter(int index, object @value, bool condition);

         Net.TheVpc.Upa.Query RemoveParameter(string name);

         Net.TheVpc.Upa.Query RemoveParameter(int index);

         Net.TheVpc.Upa.Query SetUpdatable(bool forUpdate);

         bool IsLazyListLoadingEnabled();

         Net.TheVpc.Upa.Query SetLazyListLoadingEnabled(bool lazyLoadingEnabled);

         Net.TheVpc.Upa.Query SetHint(string key, object @value);

         Net.TheVpc.Upa.Query SetHints(System.Collections.Generic.IDictionary<string , object> hints);

         System.Collections.Generic.IDictionary<string , object> GetHints();

         object GetHint(string hintName);

         object GetHint(string hintName, object defaultValue);

         bool IsUpdatable();

         void UpdateCurrent();

         int ExecuteNonQuery();
    }
}
