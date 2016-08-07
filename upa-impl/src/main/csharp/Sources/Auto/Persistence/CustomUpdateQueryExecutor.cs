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
     * Created by vpc on 7/1/16.
     */
    internal class CustomUpdateQueryExecutor : Net.Vpc.Upa.Impl.Persistence.QueryExecutor {

        private Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceStore defaultPersistenceStore;

        private readonly System.Collections.Generic.IDictionary<string , object> finalHints;

        private readonly Net.Vpc.Upa.Expressions.Update baseExpression;

        private readonly System.Collections.Generic.IDictionary<string , object> parametersByName;

        private readonly System.Collections.Generic.IDictionary<int? , object> parametersByIndex;

        private readonly bool updatable;

        private readonly Net.Vpc.Upa.Filters.FieldFilter defaultFieldFilter;

        private readonly Net.Vpc.Upa.Persistence.EntityExecutionContext context;

        private readonly System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.VarVal> complexVals;

        private readonly Net.Vpc.Upa.Entity entity;

        private readonly string entityName;

        private readonly Net.Vpc.Upa.Persistence.ResultMetaData metadata;

        private int resultCount;

        private Net.Vpc.Upa.Persistence.UConnection connection;

        public CustomUpdateQueryExecutor(Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceStore defaultPersistenceStore, System.Collections.Generic.IDictionary<string , object> finalHints, Net.Vpc.Upa.Expressions.Update baseExpression, System.Collections.Generic.IDictionary<string , object> parametersByName, System.Collections.Generic.IDictionary<int? , object> parametersByIndex, bool updatable, Net.Vpc.Upa.Filters.FieldFilter defaultFieldFilter, Net.Vpc.Upa.Persistence.EntityExecutionContext context, System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.VarVal> complexVals, Net.Vpc.Upa.Entity entity, string entityName, Net.Vpc.Upa.Persistence.ResultMetaData metadata) {
            this.defaultPersistenceStore = defaultPersistenceStore;
            this.finalHints = finalHints;
            this.baseExpression = baseExpression;
            this.parametersByName = parametersByName;
            this.parametersByIndex = parametersByIndex;
            this.updatable = updatable;
            this.defaultFieldFilter = defaultFieldFilter;
            this.context = context;
            this.complexVals = complexVals;
            this.entity = entity;
            this.entityName = entityName;
            this.metadata = metadata;
            this.connection = context.GetConnection();
        }


        public virtual Net.Vpc.Upa.Persistence.QueryResult GetQueryResult() {
            return null;
        }


        public virtual System.Collections.Generic.IDictionary<string , object> GetHints() {
            return finalHints;
        }


        public virtual int GetResultCount() {
            return resultCount;
        }


        public virtual Net.Vpc.Upa.Impl.Persistence.QueryExecutor Execute() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            int c1 = 0;
            int c2 = 0;
            string oldAlias = baseExpression.GetEntityAlias();
            if (oldAlias == null) {
                oldAlias = entity.GetName();
            }
            bool replaceThis = !"this".Equals(oldAlias);
            if (baseExpression.CountFields() > 0) {
                if (replaceThis) {
                    Net.Vpc.Upa.Impl.Uql.Util.UQLUtils.ReplaceThisVar(baseExpression, oldAlias, context.GetPersistenceUnit());
                }
                c1 = defaultPersistenceStore.CreateDefaultExecutor(baseExpression, parametersByName, parametersByIndex, updatable, defaultFieldFilter, context).Execute().GetResultCount();
            }
            if ((complexVals).Count > 0) {
                Net.Vpc.Upa.Expressions.Select q = new Net.Vpc.Upa.Expressions.Select();
                foreach (Net.Vpc.Upa.Field primaryField in entity.GetPrimaryFields()) {
                    q.Field(primaryField.GetName());
                }
                foreach (Net.Vpc.Upa.Expressions.VarVal f in complexVals) {
                    Net.Vpc.Upa.Expressions.Expression fieldExpression = f.GetVal();
                    if (replaceThis) {
                        Net.Vpc.Upa.Impl.Uql.Util.UQLUtils.ReplaceThisVar(fieldExpression, oldAlias, context.GetPersistenceUnit());
                    }
                    q.Field(fieldExpression, f.GetVar().GetName());
                }
                q.From(entity.GetName(), oldAlias);
                Net.Vpc.Upa.Expressions.Expression cond = baseExpression.GetCondition();
                q.SetWhere(cond == null ? null : cond.Copy());
                Net.Vpc.Upa.EntityBuilder eb = entity.GetBuilder();
                foreach (Net.Vpc.Upa.Record record in entity.GetPersistenceUnit().CreateQuery(q).GetRecordList()) {
                    Net.Vpc.Upa.Expressions.Update u2 = new Net.Vpc.Upa.Expressions.Update();
                    u2.Entity(entityName);
                    foreach (Net.Vpc.Upa.Expressions.VarVal f in complexVals) {
                        string fname = f.GetVar().GetName();
                        u2.Set(fname, record.GetObject<T>(fname));
                    }
                    Net.Vpc.Upa.Expressions.Expression exprId = eb.ObjectToIdExpression(record, oldAlias);
                    u2.Where(exprId);
                    c2 += defaultPersistenceStore.CreateDefaultExecutor(u2, parametersByName, parametersByIndex, updatable, defaultFieldFilter, context).Execute().GetResultCount();
                }
            }
            resultCount = System.Math.Max(c1, c2);
            return this;
        }


        public virtual Net.Vpc.Upa.Persistence.ResultMetaData GetMetaData() {
            return metadata;
        }


        public virtual Net.Vpc.Upa.Impl.Persistence.NativeField[] GetFields() {
            return new Net.Vpc.Upa.Impl.Persistence.NativeField[0];
        }


        public virtual Net.Vpc.Upa.Persistence.UConnection GetConnection() {
            return connection;
        }
    }
}
