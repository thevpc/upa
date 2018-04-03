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



namespace Net.Vpc.Upa
{


    /**
     * Created with IntelliJ IDEA. User: vpc Date: 8/19/12 Time: 6:07 PM To change
     * this template use File | Settings | File Templates.
     */
    public interface Query : Net.Vpc.Upa.Closeable {

         Net.Vpc.Upa.Types.Temporal GetDate() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool? GetBoolean() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         int? GetInteger() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         long? GetLong() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         double? GetDouble() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         string GetString() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         object GetNumber() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         object GetSingleValue() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         object GetSingleValue(object defaultValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.MultiDocument GetMultiDocument() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Document GetDocument() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

        /**
             * Executes a Select query and returns a single result.
             * @param <R> Result Type
             * @return Single result if unique
             * @throws net.vpc.upa.exceptions.NonUniqueResultException if more thant one result was returned by query
             * @throws net.vpc.upa.exceptions.NoResultException if no result if returned by query
             */
          R GetSingleResult<R>() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

        /**
             * Executes a Select query and returns a single result if found.
             * If query returns no result null is returned.
             * When Multiple results NonUniqueResultException will be thrown
             * @param <R> Result Type
             * @return Single result if found. When Multiple results NonUniqueResultException will be thrown
             * @throws net.vpc.upa.exceptions.NonUniqueResultException if more thant one result was returned by query
             */
          R GetSingleResultOrNull<R>() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

        /**
             * Executes a Select query and returns a single result if found.
             * If query returns no result null is returned.
             * When Multiple results, the first result will be returned
             * @param <R> Result Type
             * @return Single result if found. When Multiple results, the first result will be returned. If query returns no result null is returned.
             */
          R GetFirstResultOrNull<R>() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         bool IsEmpty() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          System.Collections.Generic.IList<K> GetIdList<K>() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          System.Collections.Generic.ISet<K> GetIdSet<K>() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.Key> GetKeyList() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.ISet<Net.Vpc.Upa.Key> GetKeySet() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         System.Collections.Generic.IList<Net.Vpc.Upa.MultiDocument> GetMultiDocumentList() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          System.Collections.Generic.IList<T> GetResultList<T>(System.Type type, params string [] fields);

          System.Collections.Generic.ISet<T> GetResultSet<T>(System.Type type, params string [] fields);

          System.Collections.Generic.IList<T> GetResultList<T>();

          System.Collections.Generic.ISet<T> GetResultSet<T>();

         System.Collections.Generic.IList<Net.Vpc.Upa.Document> GetDocumentList() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          System.Collections.Generic.IList<T> GetValueList<T>(int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          System.Collections.Generic.ISet<T> GetValueSet<T>(int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          System.Collections.Generic.ISet<T> GetValueSet<T>(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

          System.Collections.Generic.IList<T> GetValueList<T>(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Persistence.ResultMetaData GetMetaData() /* throws Net.Vpc.Upa.Exceptions.UPAException */ ;

         Net.Vpc.Upa.Query SetParameter(string name, object @value);

         Net.Vpc.Upa.Query SetParameters(System.Collections.Generic.IDictionary<string , object> parameters);

         Net.Vpc.Upa.Query SetParameter(int index, object @value);

         Net.Vpc.Upa.Query SetParameter(string name, object @value, bool condition);

         Net.Vpc.Upa.Query SetParameters(System.Collections.Generic.IDictionary<string , object> parameters, bool condition);

         Net.Vpc.Upa.Query SetParameter(int index, object @value, bool condition);

         Net.Vpc.Upa.Query RemoveParameter(string name);

         Net.Vpc.Upa.Query RemoveParameter(int index);

         Net.Vpc.Upa.Query SetUpdatable(bool forUpdate);

         bool IsLazyListLoadingEnabled();

         Net.Vpc.Upa.Query SetLazyListLoadingEnabled(bool lazyLoadingEnabled);

         Net.Vpc.Upa.Query SetHint(string key, object @value);

         Net.Vpc.Upa.Query SetHints(System.Collections.Generic.IDictionary<string , object> hints);

         System.Collections.Generic.IDictionary<string , object> GetHints();

         object GetHint(string hintName);

         object GetHint(string hintName, object defaultValue);

         bool IsUpdatable();

         void UpdateCurrent();

         int ExecuteNonQuery();
    }
}
