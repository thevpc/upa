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
     * Created by vpc on 7/1/16.
     */
    internal class CustomUpdateQueryExecutor : Net.TheVpc.Upa.Impl.Persistence.QueryExecutor {

        private Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceStore defaultPersistenceStore;

        private readonly System.Collections.Generic.IDictionary<string , object> finalHints;

        private readonly Net.TheVpc.Upa.Expressions.Update baseExpression;

        private readonly System.Collections.Generic.IDictionary<string , object> parametersByName;

        private readonly System.Collections.Generic.IDictionary<int? , object> parametersByIndex;

        private readonly bool updatable;

        private readonly Net.TheVpc.Upa.Filters.FieldFilter defaultFieldFilter;

        private readonly Net.TheVpc.Upa.Persistence.EntityExecutionContext context;

        private readonly System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.VarVal> complexVals;

        private readonly Net.TheVpc.Upa.Entity entity;

        private readonly string entityName;

        private readonly Net.TheVpc.Upa.Persistence.ResultMetaData metadata;

        private int resultCount;

        private Net.TheVpc.Upa.Persistence.UConnection connection;

        public CustomUpdateQueryExecutor(Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceStore defaultPersistenceStore, System.Collections.Generic.IDictionary<string , object> finalHints, Net.TheVpc.Upa.Expressions.Update baseExpression, System.Collections.Generic.IDictionary<string , object> parametersByName, System.Collections.Generic.IDictionary<int? , object> parametersByIndex, bool updatable, Net.TheVpc.Upa.Filters.FieldFilter defaultFieldFilter, Net.TheVpc.Upa.Persistence.EntityExecutionContext context, System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.VarVal> complexVals, Net.TheVpc.Upa.Entity entity, string entityName, Net.TheVpc.Upa.Persistence.ResultMetaData metadata) {
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


        public virtual Net.TheVpc.Upa.Persistence.QueryResult GetQueryResult() {
            return null;
        }


        public virtual System.Collections.Generic.IDictionary<string , object> GetHints() {
            return finalHints;
        }


        public virtual int GetResultCount() {
            return resultCount;
        }


        public virtual Net.TheVpc.Upa.Impl.Persistence.QueryExecutor Execute() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            int c1 = 0;
            int c2 = 0;
            string oldAlias = baseExpression.GetEntityAlias();
            if (oldAlias == null) {
                oldAlias = entity.GetName();
            }
            bool replaceThis = !"this".Equals(oldAlias);
            if (baseExpression.CountFields() > 0) {
                if (replaceThis) {
                    Net.TheVpc.Upa.Impl.Uql.Util.UQLUtils.ReplaceThisVar(baseExpression, oldAlias, context.GetPersistenceUnit());
                }
                c1 = defaultPersistenceStore.CreateDefaultExecutor(baseExpression, parametersByName, parametersByIndex, updatable, defaultFieldFilter, context).Execute().GetResultCount();
            }
            if ((complexVals).Count > 0) {
                Net.TheVpc.Upa.Expressions.Select q = new Net.TheVpc.Upa.Expressions.Select();
                foreach (Net.TheVpc.Upa.Field primaryField in entity.GetPrimaryFields()) {
                    q.Field(primaryField.GetName());
                }
                foreach (Net.TheVpc.Upa.Expressions.VarVal f in complexVals) {
                    Net.TheVpc.Upa.Expressions.Expression fieldExpression = f.GetVal();
                    if (replaceThis) {
                        Net.TheVpc.Upa.Impl.Uql.Util.UQLUtils.ReplaceThisVar(fieldExpression, oldAlias, context.GetPersistenceUnit());
                    }
                    q.Field(fieldExpression, f.GetVar().GetName());
                }
                q.From(entity.GetName(), oldAlias);
                Net.TheVpc.Upa.Expressions.Expression cond = baseExpression.GetCondition();
                q.SetWhere(cond == null ? null : cond.Copy());
                Net.TheVpc.Upa.EntityBuilder eb = entity.GetBuilder();
                foreach (Net.TheVpc.Upa.Record record in entity.GetPersistenceUnit().CreateQuery(q).GetRecordList()) {
                    Net.TheVpc.Upa.Expressions.Update u2 = new Net.TheVpc.Upa.Expressions.Update();
                    u2.Entity(entityName);
                    foreach (Net.TheVpc.Upa.Expressions.VarVal f in complexVals) {
                        string fname = f.GetVar().GetName();
                        u2.Set(fname, record.GetObject<T>(fname));
                    }
                    Net.TheVpc.Upa.Expressions.Expression exprId = eb.ObjectToIdExpression(record, oldAlias);
                    u2.Where(exprId);
                    c2 += defaultPersistenceStore.CreateDefaultExecutor(u2, parametersByName, parametersByIndex, updatable, defaultFieldFilter, context).Execute().GetResultCount();
                }
            }
            resultCount = System.Math.Max(c1, c2);
            return this;
        }


        public virtual Net.TheVpc.Upa.Persistence.ResultMetaData GetMetaData() {
            return metadata;
        }


        public virtual Net.TheVpc.Upa.Impl.Persistence.NativeField[] GetFields() {
            return new Net.TheVpc.Upa.Impl.Persistence.NativeField[0];
        }


        public virtual Net.TheVpc.Upa.Persistence.UConnection GetConnection() {
            return connection;
        }
    }
}
