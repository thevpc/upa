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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/9/12 9:59 AM
     */
    public interface QueryBuilder : Net.TheVpc.Upa.Closeable {

         Net.TheVpc.Upa.Entity GetEntityType();

         Net.TheVpc.Upa.QueryBuilder ByField(string field, object @value);

         Net.TheVpc.Upa.QueryBuilder ByExpression(string expression);

         Net.TheVpc.Upa.QueryBuilder ByExpression(Net.TheVpc.Upa.Expressions.Expression expression);

         Net.TheVpc.Upa.QueryBuilder ByExpression(Net.TheVpc.Upa.Expressions.Expression expression, bool applyAndOp);

         Net.TheVpc.Upa.QueryBuilder OrderBy(Net.TheVpc.Upa.Expressions.Order order);

         Net.TheVpc.Upa.QueryBuilder SetFieldFilter(Net.TheVpc.Upa.Filters.FieldFilter fieldFilter);

         Net.TheVpc.Upa.QueryBuilder ById(object id);

         Net.TheVpc.Upa.QueryBuilder ByIdList(System.Collections.Generic.IList<object> id);

         Net.TheVpc.Upa.QueryBuilder ByKey(Net.TheVpc.Upa.Key key);

         Net.TheVpc.Upa.QueryBuilder ByPrototype(object prototype);

         Net.TheVpc.Upa.QueryBuilder ByDocumentPrototype(Net.TheVpc.Upa.Document prototype);

         Net.TheVpc.Upa.QueryBuilder SetUpdatable(bool updatable);

         Net.TheVpc.Upa.Expressions.Expression GetExpression();

         Net.TheVpc.Upa.Expressions.Order GetOrder();

         Net.TheVpc.Upa.Filters.FieldFilter GetFieldFilter();

         object GetId();

         Net.TheVpc.Upa.Key GetKey();

         object GetPrototype();

         Net.TheVpc.Upa.Document GetDocumentPrototype();

         string GetEntityAlias();

         Net.TheVpc.Upa.QueryBuilder SetEntityAlias(string entityAlias);

         int GetTop();

         void SetTop(int top);

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

         Net.TheVpc.Upa.QueryBuilder SetParameter(string name, object @value);

         Net.TheVpc.Upa.QueryBuilder SetParameters(System.Collections.Generic.IDictionary<string , object> parameters);

         Net.TheVpc.Upa.QueryBuilder SetParameter(int index, object @value);

         Net.TheVpc.Upa.QueryBuilder SetParameter(string name, object @value, bool condition);

         Net.TheVpc.Upa.QueryBuilder SetParameters(System.Collections.Generic.IDictionary<string , object> parameters, bool condition);

         Net.TheVpc.Upa.QueryBuilder SetParameter(int index, object @value, bool condition);

         Net.TheVpc.Upa.QueryBuilder RemoveParameter(string name);

         Net.TheVpc.Upa.QueryBuilder RemoveParameter(int index);

         bool IsLazyListLoadingEnabled();

         Net.TheVpc.Upa.QueryBuilder SetLazyListLoadingEnabled(bool lazyLoadingEnabled);

         Net.TheVpc.Upa.QueryBuilder SetHint(string key, object @value);

         Net.TheVpc.Upa.QueryBuilder SetHints(System.Collections.Generic.IDictionary<string , object> hints);

         System.Collections.Generic.IDictionary<string , object> GetHints();

         object GetHint(string hintName);

         object GetHint(string hintName, object defaultValue);

         bool IsUpdatable();

         void UpdateCurrent();

         int ExecuteNonQuery();

         Net.TheVpc.Upa.Query ToQuery();
    }
}
