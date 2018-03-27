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


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/29/12 2:28 AM
     */
    public sealed class DefaultQueryBuilder : Net.Vpc.Upa.QueryBuilder {

        private bool updatable;

        private bool lazyListLoadingEnabled = true;

        private Net.Vpc.Upa.Entity entity;

        private string entityAlias;

        private Net.Vpc.Upa.Expressions.Expression expression;

        private Net.Vpc.Upa.Expressions.Order order;

        private Net.Vpc.Upa.Filters.FieldFilter fieldFilter;

        private object id;

        private Net.Vpc.Upa.Key key;

        private object prototype;

        private Net.Vpc.Upa.Record recordPrototype;

        private System.Collections.Generic.IDictionary<string , object> hints = new System.Collections.Generic.Dictionary<string , object>();

        private Net.Vpc.Upa.Query query;

        private System.Collections.Generic.Dictionary<string , object> paramsByName = new System.Collections.Generic.Dictionary<string , object>();

        private System.Collections.Generic.Dictionary<int? , object> paramsByIndex = new System.Collections.Generic.Dictionary<int? , object>();

        public DefaultQueryBuilder(Net.Vpc.Upa.Entity entity) {
            this.entity = entity;
        }

        public Net.Vpc.Upa.Entity GetEntityType() {
            return entity;
        }

        public Net.Vpc.Upa.QueryBuilder ByExpression(string expression) {
            return ByExpression(expression == null ? null : new Net.Vpc.Upa.Expressions.UserExpression(expression));
        }

        public Net.Vpc.Upa.QueryBuilder ByExpression(Net.Vpc.Upa.Expressions.Expression expression) {
            if (this.expression == null) {
                this.expression = expression;
            } else if (expression != null) {
                this.expression = new Net.Vpc.Upa.Expressions.And(this.expression, expression);
            }
            return this;
        }


        public Net.Vpc.Upa.QueryBuilder ByExpression(Net.Vpc.Upa.Expressions.Expression expression, bool applyAndOp) {
            if (applyAndOp || this.expression == null) {
                this.expression = expression;
            } else {
                this.expression = new Net.Vpc.Upa.Expressions.And(this.expression, expression);
            }
            return this;
        }


        public Net.Vpc.Upa.QueryBuilder OrderBy(Net.Vpc.Upa.Expressions.Order order) {
            this.order = order;
            return this;
        }


        public Net.Vpc.Upa.QueryBuilder SetFieldFilter(Net.Vpc.Upa.Filters.FieldFilter fieldFilter) {
            this.fieldFilter = fieldFilter;
            return this;
        }


        public Net.Vpc.Upa.QueryBuilder ById(object id) {
            if (id is Net.Vpc.Upa.Key) {
                ByKey((Net.Vpc.Upa.Key) id);
            } else {
                this.id = id;
            }
            return this;
        }


        public Net.Vpc.Upa.QueryBuilder ByKey(Net.Vpc.Upa.Key key) {
            this.key = key;
            return this;
        }


        public Net.Vpc.Upa.QueryBuilder ByPrototype(object prototype) {
            this.prototype = prototype;
            return this;
        }


        public Net.Vpc.Upa.QueryBuilder ByRecordPrototype(Net.Vpc.Upa.Record prototype) {
            this.recordPrototype = prototype;
            return this;
        }


        public Net.Vpc.Upa.Expressions.Expression GetExpression() {
            return expression;
        }


        public Net.Vpc.Upa.Expressions.Order GetOrder() {
            return order;
        }


        public Net.Vpc.Upa.Filters.FieldFilter GetFieldFilter() {
            return fieldFilter;
        }


        public object GetId() {
            return id;
        }


        public Net.Vpc.Upa.Key GetKey() {
            return key;
        }


        public object GetPrototype() {
            return prototype;
        }


        public Net.Vpc.Upa.Record GetRecordPrototype() {
            return recordPrototype;
        }

        public string GetEntityAlias() {
            return entityAlias;
        }

        public Net.Vpc.Upa.QueryBuilder SetEntityAlias(string entityAlias) {
            this.entityAlias = entityAlias;
            return this;
        }

        private Net.Vpc.Upa.Query Build() {
            //        if (query == null) {
            string entityName = entity.GetName();
            Net.Vpc.Upa.Expressions.Select s = (new Net.Vpc.Upa.Expressions.Select()).From(entityName, entityAlias);
            if (GetFieldFilter() != null) {
                foreach (Net.Vpc.Upa.Field field in entity.GetFields(GetFieldFilter())) {
                    if (field != null) {
                        s.Field(new Net.Vpc.Upa.Expressions.Var(field.GetName()), field.GetName());
                    }
                }
            }
            Net.Vpc.Upa.Expressions.Expression criteria = null;
            if (GetId() != null) {
                Net.Vpc.Upa.Expressions.Expression e = entity.GetBuilder().IdToExpression(GetId(), entityName);
                criteria = criteria == null ? ((Net.Vpc.Upa.Expressions.Expression)(e)) : new Net.Vpc.Upa.Expressions.And(criteria, e);
            }
            if (GetKey() != null) {
                Net.Vpc.Upa.Expressions.Expression e = (entity.GetBuilder().IdToExpression(entity.GetBuilder().KeyToId(GetKey()), entityName));
                criteria = criteria == null ? ((Net.Vpc.Upa.Expressions.Expression)(e)) : new Net.Vpc.Upa.Expressions.And(criteria, e);
            }
            if (GetPrototype() != null) {
                Net.Vpc.Upa.Expressions.Expression e = entity.GetBuilder().ObjectToExpression(GetPrototype(), true, entityName);
                criteria = criteria == null ? ((Net.Vpc.Upa.Expressions.Expression)(e)) : new Net.Vpc.Upa.Expressions.And(criteria, e);
            }
            if (GetRecordPrototype() != null) {
                Net.Vpc.Upa.Expressions.Expression e = (entity.GetBuilder().RecordToExpression(GetRecordPrototype(), entityName));
                criteria = criteria == null ? ((Net.Vpc.Upa.Expressions.Expression)(e)) : new Net.Vpc.Upa.Expressions.And(criteria, e);
            }
            if (GetExpression() != null) {
                Net.Vpc.Upa.Expressions.Expression e = GetExpression();
                criteria = criteria == null ? ((Net.Vpc.Upa.Expressions.Expression)(e)) : new Net.Vpc.Upa.Expressions.And(criteria, e);
            }
            s.SetWhere(criteria);
            s.OrderBy(GetOrder());
            query = entity.CreateQuery(s);
            foreach (System.Collections.Generic.KeyValuePair<string , object> e in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,object>>(paramsByName)) {
                query.SetParameter((e).Key, (e).Value);
            }
            foreach (System.Collections.Generic.KeyValuePair<int? , object> e in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<int?,object>>(paramsByIndex)) {
                query.SetParameter(((e).Key).Value, (e).Value);
            }
            query.SetUpdatable(this.IsUpdatable());
            if (hints != null) {
                foreach (System.Collections.Generic.KeyValuePair<string , object> h in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,object>>(hints)) {
                    query.SetHint((h).Key, (h).Value);
                }
            }
            //        }
            return query;
        }


        public Net.Vpc.Upa.Types.Temporal GetDate() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Build().GetDate();
        }


        public bool? GetBoolean() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Build().GetBoolean();
        }


        public int? GetInteger() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Build().GetInteger();
        }


        public long? GetLong() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Build().GetLong();
        }


        public double? GetDouble() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return null;
        }


        public string GetString() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Build().GetString();
        }


        public object GetNumber() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Build().GetNumber();
        }


        public object GetSingleValue() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Build().GetString();
        }


        public object GetSingleValue(object defaultValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Build().GetSingleValue(defaultValue);
        }


        public Net.Vpc.Upa.MultiRecord GetMultiRecord() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Build().GetMultiRecord();
        }


        public Net.Vpc.Upa.Record GetRecord() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Build().GetRecord();
        }


        public  System.Collections.Generic.IList<R2> GetEntityList<R2>() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Query q = Build();
            return q.GetEntityList<R>();
        }


        public  System.Collections.Generic.IList<R2> GetResultList<R2>() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Query q = Build();
            return q.GetResultList<T>();
        }


        public  System.Collections.Generic.ISet<T> GetResultSet<T>() {
            Net.Vpc.Upa.Query q = Build();
            return q.GetResultSet<T>();
        }


        public  R GetEntity<R>() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Build().GetEntity<R>();
        }


        public  System.Collections.Generic.IList<K> GetIdList<K>() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Build().GetIdList<K>();
        }


        public System.Collections.Generic.IList<Net.Vpc.Upa.Key> GetKeyList() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Build().GetKeyList();
        }


        public System.Collections.Generic.IList<Net.Vpc.Upa.MultiRecord> GetMultiRecordList() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Build().GetMultiRecordList();
        }


        public System.Collections.Generic.IList<Net.Vpc.Upa.Record> GetRecordList() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Build().GetRecordList();
        }


        public Net.Vpc.Upa.Persistence.ResultMetaData GetMetaData() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Build().GetMetaData();
        }

        public  System.Collections.Generic.IList<T> GetValueList<T>(int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Build().GetValueList<T>(index);
        }


        public  System.Collections.Generic.ISet<T> GetValueSet<T>(int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Build().GetValueSet<T>(index);
        }


        public  System.Collections.Generic.ISet<T> GetValueSet<T>(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Build().GetValueSet<T>(name);
        }

        public  System.Collections.Generic.IList<T> GetValueList<T>(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Build().GetValueList<T>(name);
        }

        public  System.Collections.Generic.IList<T> GetTypeList<T>(System.Type type, params string [] fields) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Build().GetTypeList<T>(type, fields);
        }

        public  System.Collections.Generic.ISet<T> GetTypeSet<T>(System.Type type, params string [] fields) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Build().GetTypeSet<T>(type, fields);
        }

        public  R GetSingleEntity<R>() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Build().GetSingleEntity<R>();
        }

        public  R GetSingleEntityOrNull<R>() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Build().GetSingleEntityOrNull<R>();
        }


        public Net.Vpc.Upa.Query SetParameter(string name, object @value) {
            if (query != null) {
                throw new System.ArgumentException ("Query is already executed");
            }
            paramsByName[name]=@value;
            return this;
        }

        public Net.Vpc.Upa.Query SetParameters(System.Collections.Generic.IDictionary<string , object> parameters) {
            if (parameters != null) {
                if (query != null) {
                    throw new System.ArgumentException ("Query is already executed");
                }
                Net.Vpc.Upa.Impl.FwkConvertUtils.PutAllMap<string,object>(paramsByName,parameters);
            }
            return this;
        }


        public Net.Vpc.Upa.Query SetParameter(int index, object @value) {
            if (query != null) {
                throw new System.ArgumentException ("Query is already executed");
            }
            paramsByIndex[index]=@value;
            return this;
        }


        public Net.Vpc.Upa.Query RemoveParameter(string name) {
            if (paramsByName != null) {
                paramsByName.Remove(name);
            }
            return this;
        }


        public Net.Vpc.Upa.Query RemoveParameter(int index) {
            if (paramsByIndex != null) {
                paramsByIndex.Remove(index);
            }
            return this;
        }

        public bool IsLazyListLoadingEnabled() {
            return lazyListLoadingEnabled;
        }

        public Net.Vpc.Upa.Query SetLazyListLoadingEnabled(bool lazyLoadingEnabled) {
            this.lazyListLoadingEnabled = lazyLoadingEnabled;
            if (query != null) {
                query.SetLazyListLoadingEnabled(lazyListLoadingEnabled);
            }
            return this;
        }

        public bool IsUpdatable() {
            return updatable;
        }

        public void SetUpdatable(bool forUpdate) {
            this.updatable = forUpdate;
            if (query != null) {
                query.SetUpdatable(forUpdate);
            }
        }

        public void UpdateCurrent() {
            if (query == null) {
                throw new System.ArgumentException ("Not yet executed");
            }
            query.UpdateCurrent();
        }

        public int ExecuteNonQuery() {
            return Build().ExecuteNonQuery();
        }

        public void Close() {
            if (query != null) {
                query.Close();
            }
        }

        public Net.Vpc.Upa.QueryBuilder ByField(string field, object @value) {
            return ByExpression(new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var(new Net.Vpc.Upa.Expressions.Var(entity.GetName()), entity.GetField(field).GetName()), new Net.Vpc.Upa.Expressions.Param(entity.GetField(field).GetName(), @value)));
        }

        public bool IsEmpty() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Build().IsEmpty();
        }

        public System.Collections.Generic.IDictionary<string , object> GetHints() {
            if (query != null) {
                return query.GetHints();
            }
            return hints;
        }

        public object GetHint(string hintName) {
            if (query != null) {
                return query.GetHint(hintName);
            }
            return hints == null ? null : Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(hints,hintName);
        }

        public object GetHint(string hintName, object defaultValue) {
            if (query != null) {
                return query.GetHint(hintName, defaultValue);
            }
            object c = hints == null ? null : Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(hints,hintName);
            return c == null ? defaultValue : c;
        }


        public Net.Vpc.Upa.Query SetHint(string key, object @value) {
            if (query != null) {
                throw new System.ArgumentException ("Query is already executed");
            }
            if (@value == null) {
                hints.Remove(key);
            } else {
                hints[key]=@value;
            }
            return this;
        }


        public Net.Vpc.Upa.Query SetHints(System.Collections.Generic.IDictionary<string , object> hints) {
            if (hints != null) {
                foreach (System.Collections.Generic.KeyValuePair<string , object> e in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,object>>(hints)) {
                    SetHint((e).Key, (e).Value);
                }
            }
            return this;
        }


        public  System.Collections.Generic.ISet<K> GetIdSet<K>() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Build().GetIdSet<K>();
        }


        public System.Collections.Generic.ISet<Net.Vpc.Upa.Key> GetKeySet() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Build().GetKeySet();
        }
    }
}
