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

        private Net.Vpc.Upa.Query query;

        private System.Collections.Generic.Dictionary<string , object> paramsByName = new System.Collections.Generic.Dictionary<string , object>();

        private System.Collections.Generic.Dictionary<int? , object> paramsByIndex = new System.Collections.Generic.Dictionary<int? , object>();

        public DefaultQueryBuilder(Net.Vpc.Upa.Entity entity) {
            this.entity = entity;
        }

        public Net.Vpc.Upa.Entity GetEntityType() {
            return entity;
        }

        public Net.Vpc.Upa.QueryBuilder AddAndExpression(string expression) {
            return AddAndExpression(expression == null ? null : new Net.Vpc.Upa.Expressions.UserExpression(expression));
        }

        public Net.Vpc.Upa.QueryBuilder AddAndExpression(Net.Vpc.Upa.Expressions.Expression expression) {
            if (this.expression == null) {
                this.expression = expression;
            } else if (expression != null) {
                this.expression = new Net.Vpc.Upa.Expressions.And(this.expression, expression);
            }
            return this;
        }


        public Net.Vpc.Upa.QueryBuilder SetExpression(string expression) {
            this.expression = expression == null ? null : new Net.Vpc.Upa.Expressions.UserExpression(expression);
            return this;
        }


        public Net.Vpc.Upa.QueryBuilder SetExpression(Net.Vpc.Upa.Expressions.Expression expression) {
            this.expression = expression;
            return this;
        }


        public Net.Vpc.Upa.QueryBuilder SetOrder(Net.Vpc.Upa.Expressions.Order order) {
            this.order = order;
            return this;
        }


        public Net.Vpc.Upa.QueryBuilder SetFieldFilter(Net.Vpc.Upa.Filters.FieldFilter fieldFilter) {
            this.fieldFilter = fieldFilter;
            return this;
        }


        public Net.Vpc.Upa.QueryBuilder SetId(object id) {
            if (id is Net.Vpc.Upa.Key) {
                SetKey((Net.Vpc.Upa.Key) id);
            } else {
                this.id = id;
            }
            return this;
        }


        public Net.Vpc.Upa.QueryBuilder SetKey(Net.Vpc.Upa.Key key) {
            this.key = key;
            return this;
        }


        public Net.Vpc.Upa.QueryBuilder SetPrototype(object prototype) {
            this.prototype = prototype;
            return this;
        }


        public Net.Vpc.Upa.QueryBuilder SetRecordPrototype(Net.Vpc.Upa.Record prototype) {
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

        private Net.Vpc.Upa.Query Exec() {
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
                Net.Vpc.Upa.Expressions.Expression e = entity.GetBuilder().EntityToExpression(GetPrototype(), true, entityName);
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
            foreach (System.Collections.Generic.KeyValuePair<string , object> e in paramsByName) {
                query.SetParameter((e).Key, (e).Value);
            }
            foreach (System.Collections.Generic.KeyValuePair<int? , object> e in paramsByIndex) {
                query.SetParameter(((e).Key).Value, (e).Value);
            }
            query.SetUpdatable(this.IsUpdatable());
            //        }
            return query;
        }


        public Net.Vpc.Upa.Types.Temporal GetDate() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Exec().GetDate();
        }


        public string GetString() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Exec().GetString();
        }


        public object GetNumber() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Exec().GetNumber();
        }


        public object GetSingleValue() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Exec().GetString();
        }


        public object GetSingleValue(object defaultValue) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Exec().GetSingleValue(defaultValue);
        }


        public Net.Vpc.Upa.MultiRecord GetMultiRecord() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Exec().GetMultiRecord();
        }


        public Net.Vpc.Upa.Record GetRecord() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Exec().GetRecord();
        }


        public  System.Collections.Generic.IList<R2> GetEntityList<R2>() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Query exec = Exec();
            return exec.GetEntityList<R2>();
        }


        public  R GetEntity<R>() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Exec().GetEntity<R>();
        }


        public  System.Collections.Generic.IList<K> GetIdList<K>() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Exec().GetIdList<K>();
        }


        public System.Collections.Generic.IList<Net.Vpc.Upa.Key> GetKeyList() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Exec().GetKeyList();
        }


        public System.Collections.Generic.IList<Net.Vpc.Upa.MultiRecord> GetMultiRecordList() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Exec().GetMultiRecordList();
        }


        public System.Collections.Generic.IList<Net.Vpc.Upa.Record> GetRecordList() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Exec().GetRecordList();
        }


        public Net.Vpc.Upa.Persistence.ResultMetaData GetMetaData() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Exec().GetMetaData();
        }

        public  System.Collections.Generic.IList<T> GetValueList<T>(int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Exec().GetValueList<T>(index);
        }

        public  System.Collections.Generic.IList<T> GetValueList<T>(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Exec().GetValueList<T>(name);
        }

        public  System.Collections.Generic.IList<T> GetTypeList<T>(System.Type type, params string [] fields) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Exec().GetTypeList<T>(type, fields);
        }

        public  R GetSingleEntity<R>() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Exec().GetSingleEntity<R>();
        }

        public  R GetSingleEntityOrNull<R>() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Exec().GetSingleEntityOrNull<R>();
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
            return Exec().ExecuteNonQuery();
        }

        public void Close() {
            if (query != null) {
                query.Close();
            }
        }

        public Net.Vpc.Upa.QueryBuilder AddAndField(string field, object @value) {
            return AddAndExpression(new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var(new Net.Vpc.Upa.Expressions.Var(entity.GetName()), entity.GetField(field).GetName()), new Net.Vpc.Upa.Expressions.Param(entity.GetField(field).GetName(), @value)));
        }

        public bool IsEmpty() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return Exec().IsEmpty();
        }
    }
}
