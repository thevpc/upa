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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/9/12 9:59 AM
     */
    public interface QueryBuilder : Net.Vpc.Upa.Closeable {

         Net.Vpc.Upa.Entity GetEntityType();

         Net.Vpc.Upa.QueryBuilder ByField(string field, object @value);

         Net.Vpc.Upa.QueryBuilder ByExpression(string expression);

         Net.Vpc.Upa.QueryBuilder ByExpression(Net.Vpc.Upa.Expressions.Expression expression);

         Net.Vpc.Upa.QueryBuilder ByExpression(Net.Vpc.Upa.Expressions.Expression expression, bool applyAndOp);

         Net.Vpc.Upa.QueryBuilder OrderBy(Net.Vpc.Upa.Expressions.Order order);

         Net.Vpc.Upa.QueryBuilder SetFieldFilter(Net.Vpc.Upa.Filters.FieldFilter fieldFilter);

         Net.Vpc.Upa.QueryBuilder ById(object id);

         Net.Vpc.Upa.QueryBuilder ByIdList(System.Collections.Generic.IList<object> id);

         Net.Vpc.Upa.QueryBuilder ByKey(Net.Vpc.Upa.Key key);

         Net.Vpc.Upa.QueryBuilder ByPrototype(object prototype);

         Net.Vpc.Upa.QueryBuilder ByDocumentPrototype(Net.Vpc.Upa.Document prototype);

         Net.Vpc.Upa.QueryBuilder SetUpdatable(bool updatable);

         Net.Vpc.Upa.Expressions.Expression GetExpression();

         Net.Vpc.Upa.Expressions.Order GetOrder();

         Net.Vpc.Upa.Filters.FieldFilter GetFieldFilter();

         object GetId();

         Net.Vpc.Upa.Key GetKey();

         object GetPrototype();

         Net.Vpc.Upa.Document GetDocumentPrototype();

         string GetEntityAlias();

         Net.Vpc.Upa.QueryBuilder SetEntityAlias(string entityAlias);

         int GetTop();

         void SetTop(int top);

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

         Net.Vpc.Upa.QueryBuilder SetParameter(string name, object @value);

         Net.Vpc.Upa.QueryBuilder SetParameters(System.Collections.Generic.IDictionary<string , object> parameters);

         Net.Vpc.Upa.QueryBuilder SetParameter(int index, object @value);

         Net.Vpc.Upa.QueryBuilder SetParameter(string name, object @value, bool condition);

         Net.Vpc.Upa.QueryBuilder SetParameters(System.Collections.Generic.IDictionary<string , object> parameters, bool condition);

         Net.Vpc.Upa.QueryBuilder SetParameter(int index, object @value, bool condition);

         Net.Vpc.Upa.QueryBuilder RemoveParameter(string name);

         Net.Vpc.Upa.QueryBuilder RemoveParameter(int index);

         bool IsLazyListLoadingEnabled();

         Net.Vpc.Upa.QueryBuilder SetLazyListLoadingEnabled(bool lazyLoadingEnabled);

         Net.Vpc.Upa.QueryBuilder SetHint(string key, object @value);

         Net.Vpc.Upa.QueryBuilder SetHints(System.Collections.Generic.IDictionary<string , object> hints);

         System.Collections.Generic.IDictionary<string , object> GetHints();

         object GetHint(string hintName);

         object GetHint(string hintName, object defaultValue);

         bool IsUpdatable();

         void UpdateCurrent();

         int ExecuteNonQuery();

         Net.Vpc.Upa.Query ToQuery();
    }
}
