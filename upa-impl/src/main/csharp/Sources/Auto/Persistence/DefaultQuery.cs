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

        private Net.Vpc.Upa.Entity defaultEntity;

        private Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityStatement query;

        private Net.Vpc.Upa.Impl.Persistence.DefaultResultMetaData metadata;

        private Net.Vpc.Upa.Persistence.QueryResult result;

        private Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceStore puManager;

        private bool lazyListLoadingEnabled = true;

        private static readonly Net.Vpc.Upa.Filters.FieldFilter ID = Net.Vpc.Upa.Filters.Fields.Regular().And(Net.Vpc.Upa.Filters.Fields.ByModifiersAllOf(Net.Vpc.Upa.FieldModifier.ID));

        private static readonly Net.Vpc.Upa.Filters.FieldFilter READABLE = Net.Vpc.Upa.Filters.Fields.Regular().And(Net.Vpc.Upa.Filters.Fields.ByModifiersAnyOf(Net.Vpc.Upa.FieldModifier.SELECT_DEFAULT, Net.Vpc.Upa.FieldModifier.SELECT_COMPILED, Net.Vpc.Upa.FieldModifier.SELECT_LIVE)).AndNot(Net.Vpc.Upa.Filters.Fields.ByAllAccessLevel(Net.Vpc.Upa.AccessLevel.PRIVATE));

        private System.Collections.Generic.IList<object> allResults = new System.Collections.Generic.List<object>();

        private System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.Impl.Persistence.NativeSQL> precompiledNativeSQLMap = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Impl.Persistence.NativeSQL>();

        private Net.Vpc.Upa.Impl.Persistence.DefaultQuery sessionAwareInstance;

        protected internal DefaultQuery() {
        }

        public DefaultQuery(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityStatement query, Net.Vpc.Upa.Entity defaultEntity, Net.Vpc.Upa.Persistence.EntityExecutionContext context) {
            this.context = context;
            this.query = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityStatement) query.Copy();
            this.defaultEntity = defaultEntity;
            puManager = (Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceStore) context.GetPersistenceStore();
        }

        public override int ExecuteNonQuery() {
            if (!context.GetPersistenceUnit().GetPersistenceGroup().CurrentSessionExists()) {
                if (sessionAwareInstance == null) {
                    sessionAwareInstance = context.GetPersistenceUnit().GetPersistenceGroup().GetContext().MakeSessionAware<Net.Vpc.Upa.Impl.Persistence.DefaultQuery>(this);
                }
                return sessionAwareInstance.ExecuteNonQuery();
            }
            //
            Net.Vpc.Upa.Impl.Persistence.NativeSQL nativeSQL = CreateNativeSQL(null, null);
            Net.Vpc.Upa.Impl.Persistence.DefaultResultMetaData m = new Net.Vpc.Upa.Impl.Persistence.DefaultResultMetaData();
            m.AddField("result", Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.INT, null);
            this.metadata = m;
            nativeSQL.Execute();
            return nativeSQL.GetResultCount();
        }


        public override  System.Collections.Generic.IList<R2> GetEntityList<R2>() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!context.GetPersistenceUnit().GetPersistenceGroup().CurrentSessionExists()) {
                if (sessionAwareInstance == null) {
                    sessionAwareInstance = context.GetPersistenceUnit().GetPersistenceGroup().GetContext().MakeSessionAware<Net.Vpc.Upa.Impl.Persistence.DefaultQuery>(this);
                }
                return sessionAwareInstance.GetEntityList<R2>();
            }
            try {
                string aliasName = null;
                if (query is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUnion) {
                    System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement> queryStatements = ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUnion) query).GetQueryStatements();
                    if ((queryStatements.Count==0)) {
                        throw new System.ArgumentException ("Empty Union");
                    }
                    System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration> declarations = queryStatements[0].GetExportedDeclarations();
                    foreach (Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration d in declarations) {
                        if (d.GetReferrerType() == Net.Vpc.Upa.Impl.Uql.DecObjectType.ENTITY) {
                            aliasName = d.GetValidName();
                            break;
                        }
                    }
                } else {
                    // select
                    System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration> declarations = query.GetExportedDeclarations();
                    foreach (Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration d in declarations) {
                        if (d.GetReferrerType() == Net.Vpc.Upa.Impl.Uql.DecObjectType.ENTITY) {
                            aliasName = d.GetValidName();
                            break;
                        }
                    }
                }
                Net.Vpc.Upa.Impl.Persistence.NativeSQL nativeSQL = ExecuteQuery("READABLE", READABLE);
                Net.Vpc.Upa.Impl.Persistence.SingleEntityQueryResult<R2> r = new Net.Vpc.Upa.Impl.Persistence.SingleEntityQueryResult<R2>(nativeSQL, aliasName);
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


        public override System.Collections.Generic.IList<Net.Vpc.Upa.MultiRecord> GetMultiRecordList() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!context.GetPersistenceUnit().GetPersistenceGroup().CurrentSessionExists()) {
                if (sessionAwareInstance == null) {
                    sessionAwareInstance = context.GetPersistenceUnit().GetPersistenceGroup().GetContext().MakeSessionAware<Net.Vpc.Upa.Impl.Persistence.DefaultQuery>(this);
                }
                return sessionAwareInstance.GetMultiRecordList();
            }
            try {
                Net.Vpc.Upa.Impl.Persistence.NativeSQL nativeSQL = ExecuteQuery("READABLE", READABLE);
                Net.Vpc.Upa.Impl.Persistence.MultiRecordList r = new Net.Vpc.Upa.Impl.Persistence.MultiRecordList(nativeSQL, IsUpdatable());
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
                Net.Vpc.Upa.Impl.Persistence.NativeSQL nativeSQL = ExecuteQuery("READABLE", READABLE);
                Net.Vpc.Upa.Persistence.QueryResult r = null;
                try {
                    r = nativeSQL.GetQueryResult();
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


        public override System.Collections.Generic.IList<Net.Vpc.Upa.Record> GetRecordList() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!context.GetPersistenceUnit().GetPersistenceGroup().CurrentSessionExists()) {
                if (sessionAwareInstance == null) {
                    sessionAwareInstance = context.GetPersistenceUnit().GetPersistenceGroup().GetContext().MakeSessionAware<Net.Vpc.Upa.Impl.Persistence.DefaultQuery>(this);
                }
                return sessionAwareInstance.GetRecordList();
            }
            try {
                Net.Vpc.Upa.Impl.Persistence.NativeSQL nativeSQL = ExecuteQuery("READABLE", READABLE);
                Net.Vpc.Upa.Impl.Persistence.MergedRecordList r = new Net.Vpc.Upa.Impl.Persistence.MergedRecordList(nativeSQL, context.GetPersistenceUnit());
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

        public override  System.Collections.Generic.IList<T> GetValueList<T>(int index) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!context.GetPersistenceUnit().GetPersistenceGroup().CurrentSessionExists()) {
                if (sessionAwareInstance == null) {
                    sessionAwareInstance = context.GetPersistenceUnit().GetPersistenceGroup().GetContext().MakeSessionAware<Net.Vpc.Upa.Impl.Persistence.DefaultQuery>(this);
                }
                return sessionAwareInstance.GetValueList<T>(index);
            }
            try {
                Net.Vpc.Upa.Impl.Persistence.NativeSQL nativeSQL = ExecuteQuery("READABLE", READABLE);
                if (index < 0 || index > nativeSQL.GetFields().Length) {
                    throw new System.IndexOutOfRangeException("Invalid inex " + index);
                }
                Net.Vpc.Upa.Impl.Persistence.ValueList<T> r = new Net.Vpc.Upa.Impl.Persistence.ValueList<T>(nativeSQL, index);
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

        public override  System.Collections.Generic.IList<T> GetValueList<T>(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!context.GetPersistenceUnit().GetPersistenceGroup().CurrentSessionExists()) {
                if (sessionAwareInstance == null) {
                    sessionAwareInstance = context.GetPersistenceUnit().GetPersistenceGroup().GetContext().MakeSessionAware<Net.Vpc.Upa.Impl.Persistence.DefaultQuery>(this);
                }
                return sessionAwareInstance.GetValueList<T>(name);
            }
            try {
                Net.Vpc.Upa.Impl.Persistence.NativeSQL nativeSQL = ExecuteQuery("READABLE", READABLE);
                Net.Vpc.Upa.Impl.Persistence.NativeField[] ne = nativeSQL.GetFields();
                int index = -1;
                for (int i = 0; i < ne.Length; i++) {
                    if (name.Equals(ne[i].GetName())) {
                        index = i;
                        break;
                    }
                }
                if (index < 0) {
                    throw new System.Exception("Field " + name + " not found");
                }
                Net.Vpc.Upa.Impl.Persistence.ValueList<T> r = new Net.Vpc.Upa.Impl.Persistence.ValueList<T>(nativeSQL, index);
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
                Net.Vpc.Upa.Impl.Persistence.NativeSQL nativeSQL = ExecuteQuery("READABLE", READABLE);
                Net.Vpc.Upa.Impl.Persistence.TypeList<T> r = new Net.Vpc.Upa.Impl.Persistence.TypeList<T>(nativeSQL, type, fields);
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


        public override System.Collections.Generic.IList<Net.Vpc.Upa.Key> GetKeyList() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!context.GetPersistenceUnit().GetPersistenceGroup().CurrentSessionExists()) {
                if (sessionAwareInstance == null) {
                    sessionAwareInstance = context.GetPersistenceUnit().GetPersistenceGroup().GetContext().MakeSessionAware<Net.Vpc.Upa.Impl.Persistence.DefaultQuery>(this);
                }
                return sessionAwareInstance.GetKeyList();
            }
            Net.Vpc.Upa.Impl.Util.ConvertedList<object , Net.Vpc.Upa.Key> r = new Net.Vpc.Upa.Impl.Util.ConvertedList<object , Net.Vpc.Upa.Key>(GetIdList<object>(), new Net.Vpc.Upa.Impl.IdToKeyConverter<object>(defaultEntity));
            allResults.Add(r);
            return r;
        }


        public override  System.Collections.Generic.IList<K2> GetIdList<K2>() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!context.GetPersistenceUnit().GetPersistenceGroup().CurrentSessionExists()) {
                if (sessionAwareInstance == null) {
                    sessionAwareInstance = context.GetPersistenceUnit().GetPersistenceGroup().GetContext().MakeSessionAware<Net.Vpc.Upa.Impl.Persistence.DefaultQuery>(this);
                }
                return sessionAwareInstance.GetIdList<K2>();
            }
            try {
                Net.Vpc.Upa.Entity entity = null;
                if (query is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUnion) {
                    System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement> queryStatements = ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUnion) query).GetQueryStatements();
                    if ((queryStatements.Count==0)) {
                        throw new System.ArgumentException ("Empty Union");
                    }
                    System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration> declarations = queryStatements[0].GetExportedDeclarations();
                    foreach (Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration d in declarations) {
                        if (d.GetReferrerType() == Net.Vpc.Upa.Impl.Uql.DecObjectType.ENTITY) {
                            entity = puManager.GetPersistenceUnit().GetEntity((string) d.GetReferrerName());
                            break;
                        }
                    }
                } else {
                    // select
                    System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration> declarations = query.GetExportedDeclarations();
                    foreach (Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration d in declarations) {
                        if (d.GetReferrerType() == Net.Vpc.Upa.Impl.Uql.DecObjectType.ENTITY) {
                            entity = puManager.GetPersistenceUnit().GetEntity((string) d.GetReferrerName());
                            break;
                        }
                    }
                }
                if (entity == null) {
                    entity = GetDefaultEntity();
                }
                Net.Vpc.Upa.Impl.Persistence.NativeSQL nativeSQL = ExecuteQuery("ID", ID);
                Net.Vpc.Upa.Impl.Persistence.SingleEntityKeyList<K2> r = new Net.Vpc.Upa.Impl.Persistence.SingleEntityKeyList<K2>(nativeSQL, entity);
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

        public override Net.Vpc.Upa.Entity GetDefaultEntity() {
            if (defaultEntity == null) {
                throw new System.ArgumentException ("No Default Entity is associated to this Find Query");
            }
            return defaultEntity;
        }

        protected internal virtual Net.Vpc.Upa.Impl.Persistence.NativeSQL ExecuteQuery(string filterdKey, Net.Vpc.Upa.Filters.FieldFilter fieldFilter) {
            //        if (result != null) {
            //            throw new FindException("QueryAlreadyExecutedException");
            //        }
            Net.Vpc.Upa.Impl.Persistence.NativeSQL nativeSQL = CreateNativeSQL(filterdKey, fieldFilter);
            Net.Vpc.Upa.Impl.Persistence.DefaultResultMetaData m = new Net.Vpc.Upa.Impl.Persistence.DefaultResultMetaData();
            foreach (Net.Vpc.Upa.Impl.Persistence.NativeField x in nativeSQL.GetFields()) {
                m.AddField(x.GetName(), x.GetTypeTransform(), x.GetField());
            }
            this.metadata = m;
            nativeSQL.SetUpdatable(IsUpdatable());
            nativeSQL.Execute();
            result = nativeSQL.GetQueryResult();
            return nativeSQL;
        }

        protected internal virtual Net.Vpc.Upa.Impl.Persistence.NativeSQL CreateNativeSQL(string key, Net.Vpc.Upa.Filters.FieldFilter fieldFilter) {
            Net.Vpc.Upa.Impl.Persistence.NativeSQL s = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Impl.Persistence.NativeSQL>(precompiledNativeSQLMap,key);
            if (s == null) {
                s = puManager.NativeSQL(query, fieldFilter, context);
                precompiledNativeSQLMap[key]=s;
            }
            return s;
        }


        public override Net.Vpc.Upa.Query SetParameter(string name, object @value) {
            System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam> @params = query.FindExpressionsList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam>(new Net.Vpc.Upa.Impl.Persistence.CompiledParamFilter(name));
            if ((@params.Count==0)) {
                throw new System.ArgumentException ("Parameter not found " + name);
            }
            foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam p in @params) {
                p.SetObject(@value);
                p.SetUnspecified(false);
            }
            return this;
        }

        public override Net.Vpc.Upa.Query SetParameters(System.Collections.Generic.IDictionary<string , object> parameters) {
            if (parameters != null) {
                foreach (System.Collections.Generic.KeyValuePair<string , object> entry in parameters) {
                    SetParameter((entry).Key, (entry).Value);
                }
            }
            return this;
        }


        public override Net.Vpc.Upa.Query SetParameter(int index, object @value) {
            System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam> @params = query.FindExpressionsList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam>(Net.Vpc.Upa.Impl.Uql.CompiledExpressionHelper.PARAM_FILTER);
            if ((@params).Count <= index) {
                throw new System.ArgumentException ("Parameter not found " + index);
            }
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam p = @params[index];
            if (p == null) {
                throw new System.ArgumentException ("Parameter not found " + index);
            }
            p.SetObject(@value);
            p.SetUnspecified(false);
            return this;
        }


        public override Net.Vpc.Upa.Persistence.ResultMetaData GetMetaData() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (metadata == null) {
                Net.Vpc.Upa.Impl.Persistence.DefaultResultMetaData m = new Net.Vpc.Upa.Impl.Persistence.DefaultResultMetaData();
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityStatement query2 = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityStatement) puManager.GetPersistenceUnit().GetExpressionManager().CompileExpression(query, new Net.Vpc.Upa.Persistence.ExpressionCompilerConfig().SetValidate(true));
                if (query2 is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement) {
                    Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement qs = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement) query2;
                    for (int i = 0; i < qs.CountFields(); i++) {
                        Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField field = qs.GetField(i);
                        Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression = field.GetExpression();
                        string validName = field.GetName() != null ? field.GetName() : expression.ToString();
                        if (validName == null) {
                            validName = "#" + i;
                        }
                        Net.Vpc.Upa.Field f = null;
                        if (expression is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) {
                            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar v = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) expression;
                            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod finest = v.GetFinest();
                            if (finest != null && finest.GetReferrer() is Net.Vpc.Upa.Field) {
                                f = (Net.Vpc.Upa.Field) finest.GetReferrer();
                            }
                        }
                        m.AddField(validName, expression.GetTypeTransform(), f);
                    }
                }
                this.metadata = m;
            }
            return metadata;
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
    }
}
