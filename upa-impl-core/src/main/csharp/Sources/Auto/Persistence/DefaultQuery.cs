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


    /**
     * Created with IntelliJ IDEA. User: vpc Date: 8/19/12 Time: 6:14 PM To change
     * this template use File | Settings | File Templates.
     */
    public class DefaultQuery : Net.TheVpc.Upa.Impl.Persistence.AbstractQuery {

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.TheVpc.Upa.Impl.Persistence.DefaultQuery)).FullName);

        private Net.TheVpc.Upa.Persistence.EntityExecutionContext context;

        private Net.TheVpc.Upa.Expressions.EntityStatement query;

        private Net.TheVpc.Upa.Persistence.QueryResult result;

        private Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceStore store;

        private bool lazyListLoadingEnabled = true;

        private System.Collections.Generic.IDictionary<string , object> hints = new System.Collections.Generic.Dictionary<string , object>();

        private System.Collections.Generic.IList<object> allResults = new System.Collections.Generic.List<object>();

        private Net.TheVpc.Upa.Impl.Persistence.QueryExecutor lastQueryExecutor = null;

        private Net.TheVpc.Upa.Impl.Persistence.DefaultQuery sessionAwareInstance;

        private System.Collections.Generic.IDictionary<string , object> parametersByName;

        private System.Collections.Generic.IDictionary<int? , object> parametersByIndex;

        protected internal DefaultQuery() {
        }

        public DefaultQuery(Net.TheVpc.Upa.Expressions.EntityStatement query, Net.TheVpc.Upa.Entity defaultEntity, Net.TheVpc.Upa.Persistence.EntityExecutionContext context) {
            this.query = query;
            if (defaultEntity != null) {
                if (query is Net.TheVpc.Upa.Expressions.Select) {
                    Net.TheVpc.Upa.Expressions.Select select = (Net.TheVpc.Upa.Expressions.Select) query;
                    if (select.GetEntity() == null) {
                        select.From(defaultEntity.GetName());
                    }
                } else if (query is Net.TheVpc.Upa.Expressions.Insert) {
                    if (((Net.TheVpc.Upa.Expressions.Insert) query).GetEntity() == null) {
                        ((Net.TheVpc.Upa.Expressions.Insert) query).Into(defaultEntity.GetName());
                    }
                } else if (query is Net.TheVpc.Upa.Expressions.Update) {
                    if (((Net.TheVpc.Upa.Expressions.Update) query).GetEntity() == null) {
                        ((Net.TheVpc.Upa.Expressions.Update) query).Entity(defaultEntity.GetName());
                    }
                } else if (query is Net.TheVpc.Upa.Expressions.Delete) {
                    if (((Net.TheVpc.Upa.Expressions.Delete) query).GetEntity() == null) {
                        ((Net.TheVpc.Upa.Expressions.Delete) query).From(defaultEntity.GetName());
                    }
                }
            }
            this.context = context;
            //        this.cquery = (CompiledEntityStatement) query.copy();
            //        this.defaultEntity = defaultEntity;
            store = (Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceStore) context.GetPersistenceStore();
        }

        public override int ExecuteNonQuery() {
            if (!context.GetPersistenceUnit().GetPersistenceGroup().CurrentSessionExists()) {
                if (sessionAwareInstance == null) {
                    sessionAwareInstance = context.GetPersistenceUnit().GetPersistenceGroup().GetContext().MakeSessionAware<Net.TheVpc.Upa.Impl.Persistence.DefaultQuery>(this);
                }
                return sessionAwareInstance.ExecuteNonQuery();
            }
            //
            Net.TheVpc.Upa.Impl.Persistence.QueryExecutor queryExecutor = CreateNativeSQL(null);
            return queryExecutor.Execute().GetResultCount();
        }

        protected internal virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityStatement CreateCompiledEntityStatement() {
            Net.TheVpc.Upa.Persistence.ExpressionCompilerConfig config = new Net.TheVpc.Upa.Persistence.ExpressionCompilerConfig();
            string alias = null;
            string ent = null;
            if (query is Net.TheVpc.Upa.Expressions.Select) {
                Net.TheVpc.Upa.Expressions.Select d = (Net.TheVpc.Upa.Expressions.Select) query;
                string entityAlias = d.GetEntityAlias();
                Net.TheVpc.Upa.Expressions.EntityName entityName = (d.GetEntity() is Net.TheVpc.Upa.Expressions.EntityName) ? ((Net.TheVpc.Upa.Expressions.EntityName) d.GetEntity()) : null;
                if (entityAlias != null) {
                    alias = entityAlias;
                    ent = entityName == null ? null : entityName.GetName();
                } else {
                    ent = entityName == null ? null : entityName.GetName();
                    alias = ent;
                }
            }
            if (alias != null) {
                config.SetThisAlias(alias);
            }
            config.SetExpandFields(false);
            config.SetExpandEntityFilter(false);
            config.SetValidate(false);
            return (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityStatement) context.GetPersistenceUnit().GetExpressionManager().CompileExpression(query, config);
        }


        public override  System.Collections.Generic.IList<R2> GetEntityList<R2>() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetResultList<T>();
        }


        public override System.Collections.Generic.IList<Net.TheVpc.Upa.MultiRecord> GetMultiRecordList() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (!context.GetPersistenceUnit().GetPersistenceGroup().CurrentSessionExists()) {
                if (sessionAwareInstance == null) {
                    sessionAwareInstance = context.GetPersistenceUnit().GetPersistenceGroup().GetContext().MakeSessionAware<Net.TheVpc.Upa.Impl.Persistence.DefaultQuery>(this);
                }
                return sessionAwareInstance.GetMultiRecordList();
            }
            try {
                Net.TheVpc.Upa.Impl.Persistence.QueryExecutor queryExecutor = ExecuteQuery(Net.TheVpc.Upa.Impl.Util.Filters.Fields2.READ);
                Net.TheVpc.Upa.Impl.Persistence.MultiRecordList r = new Net.TheVpc.Upa.Impl.Persistence.MultiRecordList(queryExecutor, IsUpdatable());
                allResults.Add(r);
                if (!IsLazyListLoadingEnabled()) {
                    //force loading
                    r.LoadAll();
                }
                return r;
            } catch (System.Exception e) {
                throw new Net.TheVpc.Upa.Exceptions.FindException(e, new Net.TheVpc.Upa.Types.I18NString("FindFailed"));
            }
        }


        public override bool IsEmpty() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (!context.GetPersistenceUnit().GetPersistenceGroup().CurrentSessionExists()) {
                if (sessionAwareInstance == null) {
                    sessionAwareInstance = context.GetPersistenceUnit().GetPersistenceGroup().GetContext().MakeSessionAware<Net.TheVpc.Upa.Impl.Persistence.DefaultQuery>(this);
                }
                return sessionAwareInstance.IsEmpty();
            }
            try {
                Net.TheVpc.Upa.Impl.Persistence.QueryExecutor queryExecutor = ExecuteQuery(Net.TheVpc.Upa.Impl.Util.Filters.Fields2.READ);
                Net.TheVpc.Upa.Persistence.QueryResult r = null;
                try {
                    r = queryExecutor.GetQueryResult();
                    return !r.HasNext();
                } finally {
                    if (r != null) {
                        r.Close();
                    }
                }
            } catch (System.Exception e) {
                throw new Net.TheVpc.Upa.Exceptions.FindException(e, new Net.TheVpc.Upa.Types.I18NString("FindFailed"));
            }
        }

        public override  System.Collections.Generic.IList<T> GetResultList<T>() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetResultList<T>(new Net.TheVpc.Upa.Impl.Persistence.Result.ObjectOrArrayQueryResultItemBuilder());
        }

        public override  System.Collections.Generic.ISet<T> GetResultSet<T>() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.HashSet<T> set = new System.Collections.Generic.HashSet<T>();
            Net.TheVpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(set, this.GetResultList<T>(new Net.TheVpc.Upa.Impl.Persistence.Result.ObjectOrArrayQueryResultItemBuilder()));
            return set;
        }

        public virtual  System.Collections.Generic.IList<T> GetResultList<T>(Net.TheVpc.Upa.Impl.Persistence.Result.QueryResultItemBuilder builder) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (!context.GetPersistenceUnit().GetPersistenceGroup().CurrentSessionExists()) {
                if (sessionAwareInstance == null) {
                    sessionAwareInstance = context.GetPersistenceUnit().GetPersistenceGroup().GetContext().MakeSessionAware<Net.TheVpc.Upa.Impl.Persistence.DefaultQuery>(this);
                }
                return sessionAwareInstance.GetResultList<T>(builder);
            }
            try {
                Net.TheVpc.Upa.Impl.Persistence.QueryExecutor queryExecutor = ExecuteQuery(Net.TheVpc.Upa.Impl.Util.Filters.Fields2.READ);
                Net.TheVpc.Upa.QueryFetchStrategy fetchStrategy = (Net.TheVpc.Upa.QueryFetchStrategy) Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(queryExecutor.GetHints(),Net.TheVpc.Upa.QueryHints.FETCH_STRATEGY);
                if (fetchStrategy == default(Net.TheVpc.Upa.QueryFetchStrategy)) {
                    fetchStrategy = Net.TheVpc.Upa.QueryFetchStrategy.JOIN;
                }
                bool itemAsRecord = builder is Net.TheVpc.Upa.Impl.Persistence.Result.RecordQueryResultItemBuilder;
                bool relationAsRecord = false;
                bool supportCache = false;
                Net.TheVpc.Upa.Impl.Persistence.Result.QueryResultRelationLoader loader = null;
                switch(fetchStrategy) {
                    case Net.TheVpc.Upa.QueryFetchStrategy.JOIN:
                        {
                            break;
                        }
                    case Net.TheVpc.Upa.QueryFetchStrategy.SELECT:
                        {
                            supportCache = true;
                            loader = new Net.TheVpc.Upa.Impl.Persistence.Result.QueryRelationLoaderSelectObject();
                            break;
                        }
                }
                Net.TheVpc.Upa.Impl.Persistence.QueryResultLazyList<T> r = new Net.TheVpc.Upa.Impl.Persistence.Result.DefaultObjectQueryResultLazyList<T>(queryExecutor, fetchStrategy != Net.TheVpc.Upa.QueryFetchStrategy.JOIN, itemAsRecord, relationAsRecord, supportCache, IsUpdatable(), loader, builder);
                allResults.Add(r);
                if (!IsLazyListLoadingEnabled()) {
                    //force loading
                    r.LoadAll();
                }
                return r;
            } catch (System.Exception e) {
                throw new Net.TheVpc.Upa.Exceptions.FindException(e, new Net.TheVpc.Upa.Types.I18NString("FindFailed"));
            }
        }


        public override System.Collections.Generic.IList<Net.TheVpc.Upa.Record> GetRecordList() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetResultList<T>(new Net.TheVpc.Upa.Impl.Persistence.Result.RecordQueryResultItemBuilder());
        }


        public override  System.Collections.Generic.IList<T> GetValueList<T>(int index) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (!context.GetPersistenceUnit().GetPersistenceGroup().CurrentSessionExists()) {
                if (sessionAwareInstance == null) {
                    sessionAwareInstance = context.GetPersistenceUnit().GetPersistenceGroup().GetContext().MakeSessionAware<Net.TheVpc.Upa.Impl.Persistence.DefaultQuery>(this);
                }
                return sessionAwareInstance.GetValueList<T>(index);
            }
            try {
                Net.TheVpc.Upa.Impl.Persistence.QueryExecutor queryExecutor = ExecuteQuery(Net.TheVpc.Upa.Impl.Util.Filters.Fields2.READ);
                if (index < 0 || index > (queryExecutor.GetMetaData().GetFields()).Count) {
                    throw new System.IndexOutOfRangeException("Invalid index " + index);
                }
                Net.TheVpc.Upa.Impl.Persistence.ValueList<T> r = new Net.TheVpc.Upa.Impl.Persistence.ValueList<T>(queryExecutor, index);
                allResults.Add(r);
                if (!IsLazyListLoadingEnabled()) {
                    //force loading
                    r.LoadAll();
                }
                return r;
            } catch (System.Exception e) {
                throw new Net.TheVpc.Upa.Exceptions.FindException(e, new Net.TheVpc.Upa.Types.I18NString("FindFailed"));
            }
        }


        public override  System.Collections.Generic.ISet<T> GetValueSet<T>(int index) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.HashSet<T> set = new System.Collections.Generic.HashSet<T>();
            Net.TheVpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(set, this.GetValueList<T>(index));
            return set;
        }


        public override  System.Collections.Generic.ISet<T> GetValueSet<T>(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.HashSet<T> set = new System.Collections.Generic.HashSet<T>();
            Net.TheVpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(set, this.GetValueList<T>(name));
            return set;
        }


        public override  System.Collections.Generic.IList<T> GetValueList<T>(string name) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (!context.GetPersistenceUnit().GetPersistenceGroup().CurrentSessionExists()) {
                if (sessionAwareInstance == null) {
                    sessionAwareInstance = context.GetPersistenceUnit().GetPersistenceGroup().GetContext().MakeSessionAware<Net.TheVpc.Upa.Impl.Persistence.DefaultQuery>(this);
                }
                return sessionAwareInstance.GetValueList<T>(name);
            }
            try {
                Net.TheVpc.Upa.Impl.Persistence.QueryExecutor queryExecutor = ExecuteQuery(Net.TheVpc.Upa.Impl.Util.Filters.Fields2.READ);
                System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.ResultField> ne = queryExecutor.GetMetaData().GetFields();
                int index = -1;
                for (int i = 0; i < (ne).Count; i++) {
                    if (name.Equals(ne[i].GetAlias())) {
                        index = i;
                        break;
                    }
                }
                if (index < 0) {
                    throw new System.Exception("Field " + name + " not found");
                }
                Net.TheVpc.Upa.Impl.Persistence.ValueList<T> r = new Net.TheVpc.Upa.Impl.Persistence.ValueList<T>(queryExecutor, index);
                if (!IsLazyListLoadingEnabled()) {
                    //force loading
                    r.LoadAll();
                }
                allResults.Add(r);
                return r;
            } catch (System.Exception e) {
                throw new Net.TheVpc.Upa.Exceptions.FindException(e, new Net.TheVpc.Upa.Types.I18NString("FindFailed"));
            }
        }

        public override  System.Collections.Generic.IList<T> GetTypeList<T>(System.Type type, params string [] fields) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (!context.GetPersistenceUnit().GetPersistenceGroup().CurrentSessionExists()) {
                if (sessionAwareInstance == null) {
                    sessionAwareInstance = context.GetPersistenceUnit().GetPersistenceGroup().GetContext().MakeSessionAware<Net.TheVpc.Upa.Impl.Persistence.DefaultQuery>(this);
                }
                return sessionAwareInstance.GetTypeList<T>(type, fields);
            }
            try {
                Net.TheVpc.Upa.Impl.Persistence.QueryExecutor queryExecutor = ExecuteQuery(Net.TheVpc.Upa.Impl.Util.Filters.Fields2.READ);
                Net.TheVpc.Upa.Impl.Persistence.TypeList<T> r = new Net.TheVpc.Upa.Impl.Persistence.TypeList<T>(queryExecutor, type, fields);
                allResults.Add(r);
                if (!IsLazyListLoadingEnabled()) {
                    //force loading
                    r.LoadAll();
                }
                return r;
            } catch (System.Exception e) {
                throw new Net.TheVpc.Upa.Exceptions.FindException(e, new Net.TheVpc.Upa.Types.I18NString("FindFailed"));
            }
        }


        public override  System.Collections.Generic.ISet<T> GetTypeSet<T>(System.Type type, params string [] fields) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.HashSet<T> set = new System.Collections.Generic.HashSet<T>();
            Net.TheVpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(set, GetTypeList<T>(type, fields));
            return set;
        }


        public override System.Collections.Generic.IList<Net.TheVpc.Upa.Key> GetKeyList() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (!context.GetPersistenceUnit().GetPersistenceGroup().CurrentSessionExists()) {
                if (sessionAwareInstance == null) {
                    sessionAwareInstance = context.GetPersistenceUnit().GetPersistenceGroup().GetContext().MakeSessionAware<Net.TheVpc.Upa.Impl.Persistence.DefaultQuery>(this);
                }
                return sessionAwareInstance.GetKeyList();
            }
            if ((query is Net.TheVpc.Upa.Expressions.QueryStatement)) {
                Net.TheVpc.Upa.Entity entity = ResolveDefaultEntity();
                if (entity != null) {
                    Net.TheVpc.Upa.Impl.Util.ConvertedList<object , Net.TheVpc.Upa.Key> r = new Net.TheVpc.Upa.Impl.Util.ConvertedList<object , Net.TheVpc.Upa.Key>(GetIdList<K2>(), new Net.TheVpc.Upa.Impl.IdToKeyConverter<object>(entity));
                    allResults.Add(r);
                    return r;
                }
            }
            throw new Net.TheVpc.Upa.Exceptions.FindException(new Net.TheVpc.Upa.Types.I18NString("InvalidQuery"));
        }

        private Net.TheVpc.Upa.Entity ResolveDefaultEntity() {
            string[] a = Net.TheVpc.Upa.Impl.Uql.Util.UQLUtils.ResolveEntityAndAlias((Net.TheVpc.Upa.Expressions.QueryStatement) query);
            Net.TheVpc.Upa.Entity entity = null;
            if (a != null) {
                entity = context.GetPersistenceUnit().GetEntity(a[0]);
            }
            return entity;
        }


        public override  System.Collections.Generic.IList<K2> GetIdList<K2>() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (!context.GetPersistenceUnit().GetPersistenceGroup().CurrentSessionExists()) {
                if (sessionAwareInstance == null) {
                    sessionAwareInstance = context.GetPersistenceUnit().GetPersistenceGroup().GetContext().MakeSessionAware<Net.TheVpc.Upa.Impl.Persistence.DefaultQuery>(this);
                }
                return sessionAwareInstance.GetIdList<K2>();
            }
            try {
                if ((query is Net.TheVpc.Upa.Expressions.QueryStatement)) {
                    Net.TheVpc.Upa.Entity entity = ResolveDefaultEntity();
                    if (entity != null) {
                        Net.TheVpc.Upa.Impl.Persistence.QueryExecutor queryExecutor = ExecuteQuery(Net.TheVpc.Upa.Filters.Fields.Id());
                        Net.TheVpc.Upa.Impl.Persistence.SingleEntityKeyList<K2> r = new Net.TheVpc.Upa.Impl.Persistence.SingleEntityKeyList<K2>(queryExecutor, entity);
                        allResults.Add(r);
                        if (!IsLazyListLoadingEnabled()) {
                            //force loading
                            r.LoadAll();
                        }
                        return r;
                    }
                }
            } catch (System.Exception e) {
                throw new Net.TheVpc.Upa.Exceptions.FindException(e, new Net.TheVpc.Upa.Types.I18NString("FindFailed"));
            }
            throw new Net.TheVpc.Upa.Exceptions.FindException(new Net.TheVpc.Upa.Types.I18NString("InvalidQuery"));
        }


        public override  System.Collections.Generic.ISet<K> GetIdSet<K>() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.HashSet<K> set = new System.Collections.Generic.HashSet<K>();
            Net.TheVpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(set, this.GetIdList<K>());
            return set;
        }


        public override System.Collections.Generic.ISet<Net.TheVpc.Upa.Key> GetKeySet() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.HashSet<Net.TheVpc.Upa.Key> set = new System.Collections.Generic.HashSet<Net.TheVpc.Upa.Key>();
            Net.TheVpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(set, this.GetKeyList());
            return set;
        }

        protected internal virtual Net.TheVpc.Upa.Impl.Persistence.QueryExecutor ExecuteQuery(Net.TheVpc.Upa.Filters.FieldFilter fieldFilter) {
            //        if (result != null) {
            //            throw new FindException("QueryAlreadyExecutedException");
            //        }
            Net.TheVpc.Upa.Impl.Persistence.QueryExecutor queryExecutor = CreateNativeSQL(fieldFilter);
            //        DefaultResultMetaData m = new DefaultResultMetaData();
            //        for (NativeField x : queryExecutor.getFields()) {
            //            m.addField(x.getName(), x.getTypeTransform(), x.getField());
            //        }
            //        this.metadata = m;
            queryExecutor.Execute();
            result = queryExecutor.GetQueryResult();
            return queryExecutor;
        }

        protected internal virtual Net.TheVpc.Upa.Impl.Persistence.QueryExecutor CreateNativeSQL(Net.TheVpc.Upa.Filters.FieldFilter fieldFilter) {
            //        applyParameters();
            lastQueryExecutor = store.CreateExecutor(query, parametersByName, parametersByIndex, IsUpdatable(), fieldFilter, context.SetHints(GetHints()));
            Net.TheVpc.Upa.Expressions.EntityStatement statement = lastQueryExecutor.GetMetaData().GetStatement();
            return lastQueryExecutor;
        }


        public override Net.TheVpc.Upa.Query SetParameter(string name, object @value) {
            if (parametersByName == null) {
                parametersByName = new System.Collections.Generic.Dictionary<string , object>();
            }
            parametersByName[name]=@value;
            return this;
        }


        public override Net.TheVpc.Upa.Query RemoveParameter(string name) {
            if (parametersByName != null) {
                parametersByName.Remove(name);
            }
            return this;
        }


        public override Net.TheVpc.Upa.Query RemoveParameter(int index) {
            if (parametersByIndex != null) {
                parametersByIndex.Remove(index);
            }
            return this;
        }

        public override Net.TheVpc.Upa.Query SetParameters(System.Collections.Generic.IDictionary<string , object> parameters) {
            if (parameters != null) {
                foreach (System.Collections.Generic.KeyValuePair<string , object> entry in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,object>>(parameters)) {
                    SetParameter((entry).Key, (entry).Value);
                }
            }
            return this;
        }


        public override Net.TheVpc.Upa.Query SetParameter(int index, object @value) {
            if (parametersByIndex == null) {
                parametersByIndex = new System.Collections.Generic.Dictionary<int? , object>();
            }
            parametersByIndex[index]=@value;
            return this;
        }


        public override Net.TheVpc.Upa.Persistence.ResultMetaData GetMetaData() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (lastQueryExecutor == null) {
                throw new Net.TheVpc.Upa.Exceptions.UPAException("NoQueryExecutedYet");
            }
            return lastQueryExecutor.GetMetaData();
        }

        public override bool IsLazyListLoadingEnabled() {
            return lazyListLoadingEnabled;
        }

        public override Net.TheVpc.Upa.Query SetLazyListLoadingEnabled(bool lazyLoadingEnabled) {
            this.lazyListLoadingEnabled = lazyLoadingEnabled;
            return this;
        }

        public override void UpdateCurrent() {
            if (!IsUpdatable()) {
                throw new System.ArgumentException ("IsForUpdateMissing");
            }
            result.UpdateCurrent();
        }

        public override void Close() {
            foreach (object @object in allResults) {
                Net.TheVpc.Upa.Impl.Util.UPAUtils.Close(@object);
            }
            allResults.Clear();
        }


        public override Net.TheVpc.Upa.Query SetHint(string key, object @value) {
            if (@value == null) {
                hints.Remove(key);
            } else {
                hints[key]=@value;
            }
            return this;
        }


        public override Net.TheVpc.Upa.Query SetHints(System.Collections.Generic.IDictionary<string , object> hints) {
            if (hints != null) {
                foreach (System.Collections.Generic.KeyValuePair<string , object> e in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,object>>(hints)) {
                    SetHint((e).Key, (e).Value);
                }
            }
            return this;
        }

        public override System.Collections.Generic.IDictionary<string , object> GetHints() {
            return hints;
        }

        public override object GetHint(string hintName) {
            return hints == null ? null : Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(hints,hintName);
        }

        public override object GetHint(string hintName, object defaultValue) {
            object c = hints == null ? null : Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(hints,hintName);
            return c == null ? defaultValue : c;
        }
    }
}
