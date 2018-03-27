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
     * Created with IntelliJ IDEA. User: vpc Date: 8/19/12 Time: 6:14 PM To change
     * this template use File | Settings | File Templates.
     */
    public class DefaultQuery : Net.Vpc.Upa.Impl.Persistence.AbstractQuery {

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Persistence.DefaultQuery)).FullName);

        private Net.Vpc.Upa.Persistence.EntityExecutionContext context;

        private Net.Vpc.Upa.Expressions.EntityStatement query;

        private Net.Vpc.Upa.Persistence.QueryResult result;

        private Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceStore store;

        private bool lazyListLoadingEnabled = true;

        private System.Collections.Generic.IDictionary<string , object> hints = new System.Collections.Generic.Dictionary<string , object>();

        private System.Collections.Generic.IList<object> allResults = new System.Collections.Generic.List<object>();

        private Net.Vpc.Upa.Impl.Persistence.QueryExecutor lastQueryExecutor = null;

        private Net.Vpc.Upa.Impl.Persistence.DefaultQuery sessionAwareInstance;

        private System.Collections.Generic.IDictionary<string , object> parametersByName;

        private System.Collections.Generic.IDictionary<int? , object> parametersByIndex;

        protected internal DefaultQuery() {
        }

        public DefaultQuery(Net.Vpc.Upa.Expressions.EntityStatement query, Net.Vpc.Upa.Entity defaultEntity, Net.Vpc.Upa.Persistence.EntityExecutionContext context) {
            this.query = query;
            if (defaultEntity != null) {
                if (query is Net.Vpc.Upa.Expressions.Select) {
                    Net.Vpc.Upa.Expressions.Select select = (Net.Vpc.Upa.Expressions.Select) query;
                    if (select.GetEntity() == null) {
                        select.From(defaultEntity.GetName());
                    }
                } else if (query is Net.Vpc.Upa.Expressions.Insert) {
                    if (((Net.Vpc.Upa.Expressions.Insert) query).GetEntity() == null) {
                        ((Net.Vpc.Upa.Expressions.Insert) query).Into(defaultEntity.GetName());
                    }
                } else if (query is Net.Vpc.Upa.Expressions.Update) {
                    if (((Net.Vpc.Upa.Expressions.Update) query).GetEntity() == null) {
                        ((Net.Vpc.Upa.Expressions.Update) query).Entity(defaultEntity.GetName());
                    }
                } else if (query is Net.Vpc.Upa.Expressions.Delete) {
                    if (((Net.Vpc.Upa.Expressions.Delete) query).GetEntity() == null) {
                        ((Net.Vpc.Upa.Expressions.Delete) query).From(defaultEntity.GetName());
                    }
                }
            }
            this.context = context;
            //        this.cquery = (CompiledEntityStatement) query.copy();
            //        this.defaultEntity = defaultEntity;
            store = (Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceStore) context.GetPersistenceStore();
        }

        public override int ExecuteNonQuery() {
            if (!context.GetPersistenceUnit().GetPersistenceGroup().CurrentSessionExists()) {
                if (sessionAwareInstance == null) {
                    sessionAwareInstance = context.GetPersistenceUnit().GetPersistenceGroup().GetContext().MakeSessionAware<Net.Vpc.Upa.Impl.Persistence.DefaultQuery>(this);
                }
                return sessionAwareInstance.ExecuteNonQuery();
            }
            //
            Net.Vpc.Upa.Impl.Persistence.QueryExecutor queryExecutor = CreateNativeSQL(null);
            return queryExecutor.Execute().GetResultCount();
        }

        protected internal virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityStatement CreateCompiledEntityStatement() {
            Net.Vpc.Upa.Persistence.ExpressionCompilerConfig config = new Net.Vpc.Upa.Persistence.ExpressionCompilerConfig();
            string alias = null;
            string ent = null;
            if (query is Net.Vpc.Upa.Expressions.Select) {
                Net.Vpc.Upa.Expressions.Select d = (Net.Vpc.Upa.Expressions.Select) query;
                string entityAlias = d.GetEntityAlias();
                Net.Vpc.Upa.Expressions.EntityName entityName = (d.GetEntity() is Net.Vpc.Upa.Expressions.EntityName) ? ((Net.Vpc.Upa.Expressions.EntityName) d.GetEntity()) : null;
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
            return (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityStatement) context.GetPersistenceUnit().GetExpressionManager().CompileExpression(query, config);
        }


        public override  System.Collections.Generic.IList<R2> GetEntityList<R2>() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetResultList<T>();
        }


        public override System.Collections.Generic.IList<Net.Vpc.Upa.MultiRecord> GetMultiRecordList() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!context.GetPersistenceUnit().GetPersistenceGroup().CurrentSessionExists()) {
                if (sessionAwareInstance == null) {
                    sessionAwareInstance = context.GetPersistenceUnit().GetPersistenceGroup().GetContext().MakeSessionAware<Net.Vpc.Upa.Impl.Persistence.DefaultQuery>(this);
                }
                return sessionAwareInstance.GetMultiRecordList();
            }
            try {
                Net.Vpc.Upa.Impl.Persistence.QueryExecutor queryExecutor = ExecuteQuery(Net.Vpc.Upa.Impl.Util.Filters.Fields2.READ);
                Net.Vpc.Upa.Impl.Persistence.MultiRecordList r = new Net.Vpc.Upa.Impl.Persistence.MultiRecordList(queryExecutor, IsUpdatable());
                allResults.Add(r);
                if (!IsLazyListLoadingEnabled()) {
                    //force loading
                    r.LoadAll();
                }
                return r;
            } catch (System.Exception e) {
                throw new Net.Vpc.Upa.Exceptions.FindException(e, new Net.Vpc.Upa.Types.I18NString("FindFailed"));
            }
        }


        public override bool IsEmpty() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!context.GetPersistenceUnit().GetPersistenceGroup().CurrentSessionExists()) {
                if (sessionAwareInstance == null) {
                    sessionAwareInstance = context.GetPersistenceUnit().GetPersistenceGroup().GetContext().MakeSessionAware<Net.Vpc.Upa.Impl.Persistence.DefaultQuery>(this);
                }
                return sessionAwareInstance.IsEmpty();
            }
            try {
                Net.Vpc.Upa.Impl.Persistence.QueryExecutor queryExecutor = ExecuteQuery(Net.Vpc.Upa.Impl.Util.Filters.Fields2.READ);
                Net.Vpc.Upa.Persistence.QueryResult r = null;
                try {
                    r = queryExecutor.GetQueryResult();
                    return !r.HasNext();
                } finally {
                    if (r != null) {
                        r.Close();
                    }
                }
            } catch (System.Exception e) {
                throw new Net.Vpc.Upa.Exceptions.FindException(e, new Net.Vpc.Upa.Types.I18NString("FindFailed"));
            }
        }

        public override  System.Collections.Generic.IList<T> GetResultList<T>() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetResultList<T>(new Net.Vpc.Upa.Impl.Persistence.Result.ObjectOrArrayQueryResultItemBuilder());
        }

        public override  System.Collections.Generic.ISet<T> GetResultSet<T>() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.HashSet<T> set = new System.Collections.Generic.HashSet<T>();
            Net.Vpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(set, this.GetResultList<T>(new Net.Vpc.Upa.Impl.Persistence.Result.ObjectOrArrayQueryResultItemBuilder()));
            return set;
        }

        public virtual  System.Collections.Generic.IList<T> GetResultList<T>(Net.Vpc.Upa.Impl.Persistence.Result.QueryResultItemBuilder builder) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!context.GetPersistenceUnit().GetPersistenceGroup().CurrentSessionExists()) {
                if (sessionAwareInstance == null) {
                    sessionAwareInstance = context.GetPersistenceUnit().GetPersistenceGroup().GetContext().MakeSessionAware<Net.Vpc.Upa.Impl.Persistence.DefaultQuery>(this);
                }
                return sessionAwareInstance.GetResultList<T>(builder);
            }
            try {
                Net.Vpc.Upa.Impl.Persistence.QueryExecutor queryExecutor = ExecuteQuery(Net.Vpc.Upa.Impl.Util.Filters.Fields2.READ);
                Net.Vpc.Upa.QueryFetchStrategy fetchStrategy = (Net.Vpc.Upa.QueryFetchStrategy) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(queryExecutor.GetHints(),Net.Vpc.Upa.QueryHints.FETCH_STRATEGY);
                if (fetchStrategy == default(Net.Vpc.Upa.QueryFetchStrategy)) {
                    fetchStrategy = Net.Vpc.Upa.QueryFetchStrategy.JOIN;
                }
                bool itemAsRecord = builder is Net.Vpc.Upa.Impl.Persistence.Result.RecordQueryResultItemBuilder;
                bool relationAsRecord = false;
                bool supportCache = false;
                Net.Vpc.Upa.Impl.Persistence.Result.QueryResultRelationLoader loader = null;
                switch(fetchStrategy) {
                    case Net.Vpc.Upa.QueryFetchStrategy.JOIN:
                        {
                            break;
                        }
                    case Net.Vpc.Upa.QueryFetchStrategy.SELECT:
                        {
                            supportCache = true;
                            loader = new Net.Vpc.Upa.Impl.Persistence.Result.QueryRelationLoaderSelectObject();
                            break;
                        }
                }
                Net.Vpc.Upa.Impl.Persistence.QueryResultLazyList<T> r = new Net.Vpc.Upa.Impl.Persistence.Result.DefaultObjectQueryResultLazyList<T>(queryExecutor, fetchStrategy != Net.Vpc.Upa.QueryFetchStrategy.JOIN, itemAsRecord, relationAsRecord, supportCache, IsUpdatable(), loader, builder);
                allResults.Add(r);
                if (!IsLazyListLoadingEnabled()) {
                    //force loading
                    r.LoadAll();
                }
                return r;
            } catch (System.Exception e) {
                throw new Net.Vpc.Upa.Exceptions.FindException(e, new Net.Vpc.Upa.Types.I18NString("FindFailed"));
            }
        }


        public override System.Collections.Generic.IList<Net.Vpc.Upa.Record> GetRecordList() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetResultList<T>(new Net.Vpc.Upa.Impl.Persistence.Result.RecordQueryResultItemBuilder());
        }


        public override  System.Collections.Generic.IList<T> GetValueList<T>(int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!context.GetPersistenceUnit().GetPersistenceGroup().CurrentSessionExists()) {
                if (sessionAwareInstance == null) {
                    sessionAwareInstance = context.GetPersistenceUnit().GetPersistenceGroup().GetContext().MakeSessionAware<Net.Vpc.Upa.Impl.Persistence.DefaultQuery>(this);
                }
                return sessionAwareInstance.GetValueList<T>(index);
            }
            try {
                Net.Vpc.Upa.Impl.Persistence.QueryExecutor queryExecutor = ExecuteQuery(Net.Vpc.Upa.Impl.Util.Filters.Fields2.READ);
                if (index < 0 || index > (queryExecutor.GetMetaData().GetFields()).Count) {
                    throw new System.IndexOutOfRangeException("Invalid index " + index);
                }
                Net.Vpc.Upa.Impl.Persistence.ValueList<T> r = new Net.Vpc.Upa.Impl.Persistence.ValueList<T>(queryExecutor, index);
                allResults.Add(r);
                if (!IsLazyListLoadingEnabled()) {
                    //force loading
                    r.LoadAll();
                }
                return r;
            } catch (System.Exception e) {
                throw new Net.Vpc.Upa.Exceptions.FindException(e, new Net.Vpc.Upa.Types.I18NString("FindFailed"));
            }
        }


        public override  System.Collections.Generic.ISet<T> GetValueSet<T>(int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.HashSet<T> set = new System.Collections.Generic.HashSet<T>();
            Net.Vpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(set, this.GetValueList<T>(index));
            return set;
        }


        public override  System.Collections.Generic.ISet<T> GetValueSet<T>(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.HashSet<T> set = new System.Collections.Generic.HashSet<T>();
            Net.Vpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(set, this.GetValueList<T>(name));
            return set;
        }


        public override  System.Collections.Generic.IList<T> GetValueList<T>(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!context.GetPersistenceUnit().GetPersistenceGroup().CurrentSessionExists()) {
                if (sessionAwareInstance == null) {
                    sessionAwareInstance = context.GetPersistenceUnit().GetPersistenceGroup().GetContext().MakeSessionAware<Net.Vpc.Upa.Impl.Persistence.DefaultQuery>(this);
                }
                return sessionAwareInstance.GetValueList<T>(name);
            }
            try {
                Net.Vpc.Upa.Impl.Persistence.QueryExecutor queryExecutor = ExecuteQuery(Net.Vpc.Upa.Impl.Util.Filters.Fields2.READ);
                System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.ResultField> ne = queryExecutor.GetMetaData().GetFields();
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
                Net.Vpc.Upa.Impl.Persistence.ValueList<T> r = new Net.Vpc.Upa.Impl.Persistence.ValueList<T>(queryExecutor, index);
                if (!IsLazyListLoadingEnabled()) {
                    //force loading
                    r.LoadAll();
                }
                allResults.Add(r);
                return r;
            } catch (System.Exception e) {
                throw new Net.Vpc.Upa.Exceptions.FindException(e, new Net.Vpc.Upa.Types.I18NString("FindFailed"));
            }
        }

        public override  System.Collections.Generic.IList<T> GetTypeList<T>(System.Type type, params string [] fields) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!context.GetPersistenceUnit().GetPersistenceGroup().CurrentSessionExists()) {
                if (sessionAwareInstance == null) {
                    sessionAwareInstance = context.GetPersistenceUnit().GetPersistenceGroup().GetContext().MakeSessionAware<Net.Vpc.Upa.Impl.Persistence.DefaultQuery>(this);
                }
                return sessionAwareInstance.GetTypeList<T>(type, fields);
            }
            try {
                Net.Vpc.Upa.Impl.Persistence.QueryExecutor queryExecutor = ExecuteQuery(Net.Vpc.Upa.Impl.Util.Filters.Fields2.READ);
                Net.Vpc.Upa.Impl.Persistence.TypeList<T> r = new Net.Vpc.Upa.Impl.Persistence.TypeList<T>(queryExecutor, type, fields);
                allResults.Add(r);
                if (!IsLazyListLoadingEnabled()) {
                    //force loading
                    r.LoadAll();
                }
                return r;
            } catch (System.Exception e) {
                throw new Net.Vpc.Upa.Exceptions.FindException(e, new Net.Vpc.Upa.Types.I18NString("FindFailed"));
            }
        }


        public override  System.Collections.Generic.ISet<T> GetTypeSet<T>(System.Type type, params string [] fields) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.HashSet<T> set = new System.Collections.Generic.HashSet<T>();
            Net.Vpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(set, GetTypeList<T>(type, fields));
            return set;
        }


        public override System.Collections.Generic.IList<Net.Vpc.Upa.Key> GetKeyList() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!context.GetPersistenceUnit().GetPersistenceGroup().CurrentSessionExists()) {
                if (sessionAwareInstance == null) {
                    sessionAwareInstance = context.GetPersistenceUnit().GetPersistenceGroup().GetContext().MakeSessionAware<Net.Vpc.Upa.Impl.Persistence.DefaultQuery>(this);
                }
                return sessionAwareInstance.GetKeyList();
            }
            if ((query is Net.Vpc.Upa.Expressions.QueryStatement)) {
                Net.Vpc.Upa.Entity entity = ResolveDefaultEntity();
                if (entity != null) {
                    Net.Vpc.Upa.Impl.Util.ConvertedList<object , Net.Vpc.Upa.Key> r = new Net.Vpc.Upa.Impl.Util.ConvertedList<object , Net.Vpc.Upa.Key>(GetIdList<K2>(), new Net.Vpc.Upa.Impl.IdToKeyConverter<object>(entity));
                    allResults.Add(r);
                    return r;
                }
            }
            throw new Net.Vpc.Upa.Exceptions.FindException(new Net.Vpc.Upa.Types.I18NString("InvalidQuery"));
        }

        private Net.Vpc.Upa.Entity ResolveDefaultEntity() {
            string[] a = Net.Vpc.Upa.Impl.Uql.Util.UQLUtils.ResolveEntityAndAlias((Net.Vpc.Upa.Expressions.QueryStatement) query);
            Net.Vpc.Upa.Entity entity = null;
            if (a != null) {
                entity = context.GetPersistenceUnit().GetEntity(a[0]);
            }
            return entity;
        }


        public override  System.Collections.Generic.IList<K2> GetIdList<K2>() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!context.GetPersistenceUnit().GetPersistenceGroup().CurrentSessionExists()) {
                if (sessionAwareInstance == null) {
                    sessionAwareInstance = context.GetPersistenceUnit().GetPersistenceGroup().GetContext().MakeSessionAware<Net.Vpc.Upa.Impl.Persistence.DefaultQuery>(this);
                }
                return sessionAwareInstance.GetIdList<K2>();
            }
            try {
                if ((query is Net.Vpc.Upa.Expressions.QueryStatement)) {
                    Net.Vpc.Upa.Entity entity = ResolveDefaultEntity();
                    if (entity != null) {
                        Net.Vpc.Upa.Impl.Persistence.QueryExecutor queryExecutor = ExecuteQuery(Net.Vpc.Upa.Filters.Fields.Id());
                        Net.Vpc.Upa.Impl.Persistence.SingleEntityKeyList<K2> r = new Net.Vpc.Upa.Impl.Persistence.SingleEntityKeyList<K2>(queryExecutor, entity);
                        allResults.Add(r);
                        if (!IsLazyListLoadingEnabled()) {
                            //force loading
                            r.LoadAll();
                        }
                        return r;
                    }
                }
            } catch (System.Exception e) {
                throw new Net.Vpc.Upa.Exceptions.FindException(e, new Net.Vpc.Upa.Types.I18NString("FindFailed"));
            }
            throw new Net.Vpc.Upa.Exceptions.FindException(new Net.Vpc.Upa.Types.I18NString("InvalidQuery"));
        }


        public override  System.Collections.Generic.ISet<K> GetIdSet<K>() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.HashSet<K> set = new System.Collections.Generic.HashSet<K>();
            Net.Vpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(set, this.GetIdList<K>());
            return set;
        }


        public override System.Collections.Generic.ISet<Net.Vpc.Upa.Key> GetKeySet() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.HashSet<Net.Vpc.Upa.Key> set = new System.Collections.Generic.HashSet<Net.Vpc.Upa.Key>();
            Net.Vpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(set, this.GetKeyList());
            return set;
        }

        protected internal virtual Net.Vpc.Upa.Impl.Persistence.QueryExecutor ExecuteQuery(Net.Vpc.Upa.Filters.FieldFilter fieldFilter) {
            //        if (result != null) {
            //            throw new FindException("QueryAlreadyExecutedException");
            //        }
            Net.Vpc.Upa.Impl.Persistence.QueryExecutor queryExecutor = CreateNativeSQL(fieldFilter);
            //        DefaultResultMetaData m = new DefaultResultMetaData();
            //        for (NativeField x : queryExecutor.getFields()) {
            //            m.addField(x.getName(), x.getTypeTransform(), x.getField());
            //        }
            //        this.metadata = m;
            queryExecutor.Execute();
            result = queryExecutor.GetQueryResult();
            return queryExecutor;
        }

        protected internal virtual Net.Vpc.Upa.Impl.Persistence.QueryExecutor CreateNativeSQL(Net.Vpc.Upa.Filters.FieldFilter fieldFilter) {
            //        applyParameters();
            lastQueryExecutor = store.CreateExecutor(query, parametersByName, parametersByIndex, IsUpdatable(), fieldFilter, context.SetHints(GetHints()));
            Net.Vpc.Upa.Expressions.EntityStatement statement = lastQueryExecutor.GetMetaData().GetStatement();
            return lastQueryExecutor;
        }


        public override Net.Vpc.Upa.Query SetParameter(string name, object @value) {
            if (parametersByName == null) {
                parametersByName = new System.Collections.Generic.Dictionary<string , object>();
            }
            parametersByName[name]=@value;
            return this;
        }


        public override Net.Vpc.Upa.Query RemoveParameter(string name) {
            if (parametersByName != null) {
                parametersByName.Remove(name);
            }
            return this;
        }


        public override Net.Vpc.Upa.Query RemoveParameter(int index) {
            if (parametersByIndex != null) {
                parametersByIndex.Remove(index);
            }
            return this;
        }

        public override Net.Vpc.Upa.Query SetParameters(System.Collections.Generic.IDictionary<string , object> parameters) {
            if (parameters != null) {
                foreach (System.Collections.Generic.KeyValuePair<string , object> entry in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,object>>(parameters)) {
                    SetParameter((entry).Key, (entry).Value);
                }
            }
            return this;
        }


        public override Net.Vpc.Upa.Query SetParameter(int index, object @value) {
            if (parametersByIndex == null) {
                parametersByIndex = new System.Collections.Generic.Dictionary<int? , object>();
            }
            parametersByIndex[index]=@value;
            return this;
        }


        public override Net.Vpc.Upa.Persistence.ResultMetaData GetMetaData() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (lastQueryExecutor == null) {
                throw new Net.Vpc.Upa.Exceptions.UPAException("NoQueryExecutedYet");
            }
            return lastQueryExecutor.GetMetaData();
        }

        public override bool IsLazyListLoadingEnabled() {
            return lazyListLoadingEnabled;
        }

        public override Net.Vpc.Upa.Query SetLazyListLoadingEnabled(bool lazyLoadingEnabled) {
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
                Net.Vpc.Upa.Impl.Util.UPAUtils.Close(@object);
            }
            allResults.Clear();
        }


        public override Net.Vpc.Upa.Query SetHint(string key, object @value) {
            if (@value == null) {
                hints.Remove(key);
            } else {
                hints[key]=@value;
            }
            return this;
        }


        public override Net.Vpc.Upa.Query SetHints(System.Collections.Generic.IDictionary<string , object> hints) {
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
            return hints == null ? null : Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(hints,hintName);
        }

        public override object GetHint(string hintName, object defaultValue) {
            object c = hints == null ? null : Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(hints,hintName);
            return c == null ? defaultValue : c;
        }
    }
}
