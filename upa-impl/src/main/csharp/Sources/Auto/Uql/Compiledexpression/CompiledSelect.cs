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



using System.Linq;
namespace Net.Vpc.Upa.Impl.Uql.Compiledexpression
{


    public class CompiledSelect : Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledEntityStatement, Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement, Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect {



        private int top = -1;

        private bool distinct;

        private string query;

        private Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression where;

        private Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression having;

        private System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria> joinsTables;

        private System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField> fields;

        private System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression> groupByExpressions = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression>(1);

        private Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledOrder order;

        private Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect queryEntity;

        private string queryEntityAlias;

        private string title;

        private bool groupingEnabled;

        private System.Collections.Generic.List<Net.Vpc.Upa.QLParameter> parameters;


        public override Net.Vpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            if ((fields).Count == 1) {
                Net.Vpc.Upa.Types.DataTypeTransform type = fields[0].GetExpression().GetTypeTransform();
                return type == null ? Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.VOID : type;
            }
            return Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.VOID;
        }

        public CompiledSelect(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect other)  : this(){

            AddQuery(other);
        }

        public CompiledSelect() {
            query = null;
            joinsTables = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria>();
            fields = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField>(1);
            //        groupByList = new Vector(1);
            groupByExpressions = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression>();
            order = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledOrder();
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect Field(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            return Field(expression, null);
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect Uplet(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] expression, string alias) {
            if (expression.Length == 1) {
                return Field(expression[0], alias);
            } else {
                return Field(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUplet(expression), alias);
            }
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect Uplet(params Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression [] expression) {
            if (expression.Length == 1) {
                return Field(expression[0]);
            } else {
                return Field(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUplet(expression));
            }
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField AddField(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField compiledQueryField) {
            Invalidate();
            fields.Add(compiledQueryField);
            return compiledQueryField;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField AddField(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression, string alias) {
            Invalidate();
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField f = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField(alias, expression);
            fields.Add(f);
            PrepareChildren(f.GetExpression());
            return f;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField AddField(int index, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression, string alias) {
            Invalidate();
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField field = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField(alias, expression);
            fields.Insert(index, field);
            PrepareChildren(field.GetExpression());
            return field;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect Field(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression, string alias) {
            AddField(expression, alias);
            return this;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect Field(int index, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression, string alias) {
            AddField(index, expression, alias);
            return this;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect RemoveField(int index) {
            Invalidate();
            fields.RemoveAt(index);
            return this;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect RemoveAllFields() {
            Invalidate();
            fields.Clear();
            return this;
        }

        public virtual int CountFields() {
            return (fields).Count;
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField> GetFields() {
            return Net.Vpc.Upa.Impl.Util.PlatformUtils.UnmodifiableList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField>(fields);
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField GetField(int i) {
            return (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField) fields[i];
        }

        public virtual int IndexOf(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression field) {
            for (int i = 0; i < (fields).Count; i++) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField info = fields[i];
                if (field.Equals(info.GetExpression())) {
                    return i;
                }
            }
            return -1;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect From(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect queryEntity, string entityAlias) {
            Invalidate();
            //getContext().declare(alias, queryEntity);
            this.queryEntity = queryEntity;
            queryEntityAlias = entityAlias;
            PrepareChildren(queryEntity);
            ExportDeclaration(queryEntity, entityAlias);
            return this;
        }

        protected internal virtual void ExportDeclaration(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect e, string entityAlias) {
            if (e is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) {
                ExportDeclaration(entityAlias, Net.Vpc.Upa.Impl.Uql.DecObjectType.ENTITY, ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) e).GetName(), null);
            } else {
                ExportDeclaration(entityAlias, Net.Vpc.Upa.Impl.Uql.DecObjectType.SELECT, e, null);
            }
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect From(string entityName) {
            return From(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName(entityName), null);
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect From(string entityName, string alias) {
            return From(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName(entityName), alias);
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect From(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect view) {
            return From(view, null);
        }

        public virtual string GetEntityName() {
            if (queryEntity != null && queryEntity is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName s = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) queryEntity;
                return s.GetName();
            }
            return null;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect GetEntity() {
            return queryEntity;
        }

        public virtual string GetEntityAlias() {
            //        return entityAlias == null ? (entity instanceof String) ? (String) entity : null : entityAlias;
            return queryEntityAlias;
        }

        private Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect Join(Net.Vpc.Upa.Expressions.JoinType joinType, Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect entityName, string alias, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            Invalidate();
            Join(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria(joinType, entityName, alias, condition));
            //getContext().declare(alias, entityName);
            return this;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect Join(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria someJoin) {
            joinsTables.Add(someJoin);
            PrepareChildren(someJoin);
            ExportDeclaration(someJoin.GetEntity(), someJoin.GetEntityAlias());
            return this;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect Join(string entityName, string alias, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            return Join(Net.Vpc.Upa.Expressions.JoinType.INNER_JOIN, new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName(entityName), alias, condition);
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect Join(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect entityName, string alias, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            return Join(Net.Vpc.Upa.Expressions.JoinType.INNER_JOIN, entityName, alias, condition);
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect InnerJoin(string entityName, string alias, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            return Join(Net.Vpc.Upa.Expressions.JoinType.INNER_JOIN, new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName(entityName), alias, condition);
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect InnerJoin(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect entityName, string alias, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            return Join(Net.Vpc.Upa.Expressions.JoinType.INNER_JOIN, entityName, alias, condition);
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect LeftJoin(string entityName, string alias, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            return Join(Net.Vpc.Upa.Expressions.JoinType.LEFT_JOIN, new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName(entityName), alias, condition);
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect LeftJoin(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect entityName, string alias, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            return Join(Net.Vpc.Upa.Expressions.JoinType.LEFT_JOIN, entityName, alias, condition);
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect RightJoin(string entityName, string alias, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            return Join(Net.Vpc.Upa.Expressions.JoinType.RIGHT_JOIN, new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName(entityName), alias, condition);
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect RightJoin(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect entityName, string alias, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            return Join(Net.Vpc.Upa.Expressions.JoinType.RIGHT_JOIN, entityName, alias, condition);
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect FullJoin(string entityName, string alias, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            return Join(Net.Vpc.Upa.Expressions.JoinType.FULL_JOIN, new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName(entityName), alias, condition);
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect FullJoin(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect entityName, string alias, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            return Join(Net.Vpc.Upa.Expressions.JoinType.FULL_JOIN, entityName, alias, condition);
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect CrossJoin(string entityName) {
            return Join(Net.Vpc.Upa.Expressions.JoinType.CROSS_JOIN, new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName(entityName), null, null);
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect CrossJoin(string entityName, string alias) {
            return Join(Net.Vpc.Upa.Expressions.JoinType.CROSS_JOIN, new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName(entityName), alias, null);
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect CrossJoin(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect entityName, string alias) {
            return Join(Net.Vpc.Upa.Expressions.JoinType.CROSS_JOIN, entityName, alias, null);
        }

        public virtual int CountJoins() {
            return (joinsTables).Count;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria[] GetJoins() {
            System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria> values = joinsTables;
            return values.ToArray();
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria GetJoin(int i) {
            return joinsTables[i];
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect OrderBy(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledOrder order) {
            if (order != null) {
                Invalidate();
                this.order.AddOrder(order);
                for (int i = 0; i < order.Size(); i++) {
                    PrepareChildren(order.GetOrderAt(i));
                }
            }
            return this;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect OrderAscendentBy(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression field) {
            Invalidate();
            order.Ascendent(field);
            PrepareChildren(field);
            return this;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect OrderByDesc(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression field) {
            Invalidate();
            order.Descendent(field);
            PrepareChildren(field);
            return this;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect OrderBy(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression field, bool isAscending) {
            Invalidate();
            order.AddOrder(field, isAscending);
            PrepareChildren(field);
            return this;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect OrderBy(int position, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression field, bool isAscending) {
            Invalidate();
            order.InsertOrder(position, field, isAscending);
            PrepareChildren(field);
            return this;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect NoOrder() {
            Invalidate();
            //        orderAsc = true;
            order.NoOrder();
            return this;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect RemoveOrder(int index) {
            Invalidate();
            order.RemoveOrder(index);
            return this;
        }

        public virtual bool IsOrdered() {
            return order.Size() != 0;
        }

        public virtual bool IsOrderAscending(int index) {
            return order.IsAscendentAt(index);
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetOrderBy(int index) {
            return order.GetOrderAt(index);
        }

        public virtual int CountOrderByItems() {
            return order.Size();
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect GroupBy(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression field) {
            Invalidate();
            groupByExpressions.Add(field);
            PrepareChildren(field);
            return this;
        }

        public virtual bool IsGrouped() {
            return (groupByExpressions).Count > 0;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetGroupBy(int i) {
            return groupByExpressions[i];
        }

        public virtual int CountGroupByItems() {
            return (groupByExpressions).Count;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect Where(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            this.where = condition;
            PrepareChildren(condition);
            return this;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect Having(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression having) {
            this.having = having;
            PrepareChildren(having);
            return this;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetWhere() {
            return where;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetHaving() {
            return having;
        }


        public override bool IsValid() {
            return queryEntity != null && (fields).Count > 0;
        }

        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect o = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect();
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            o.AddQuery(this);
            return o;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect AddWhere(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            if (condition != null) {
                if (this.where == null) {
                    Where(condition);
                } else {
                    this.where.UnsetParent();
                    Where(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledAnd(this.where, condition));
                }
            }
            Invalidate();
            return this;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect AddHaving(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            if (condition != null) {
                if (this.where == null) {
                    Having(condition);
                } else {
                    this.where.UnsetParent();
                    Having(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledAnd(this.where, condition));
                }
            }
            Invalidate();
            return this;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect AddQuery(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect other) {
            if (other == null) {
                return this;
            }
            if (other.queryEntity != null) {
                From((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect) (other.queryEntity.Copy()), other.queryEntityAlias);
            }
            for (int i = 0; i < (other.joinsTables).Count; i++) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria j = other.GetJoin(i);
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect ee = j.GetEntity();
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression cc = j.GetCondition();
                Join(j.GetJoinType(), ee == null ? null : (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect) ee.Copy(), j.GetEntityAlias(), cc == null ? null : cc.Copy());
            }
            foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField field in other.fields) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression ee = field.GetExpression();
                AddField(ee == null ? null : ee.Copy(), field.GetAlias());
            }
            foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledOrderItem compiledOrderItem in order.GetItems()) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression ee = compiledOrderItem.GetExpression();
                OrderBy(ee == null ? null : ee.Copy(), compiledOrderItem.IsAsc());
            }
            foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e in other.groupByExpressions) {
                GroupBy(e == null ? null : e.Copy());
            }
            AddWhere(other.where == null ? null : other.where.Copy());
            AddHaving(other.having == null ? null : other.having.Copy());
            Invalidate();
            return this;
        }

        private void Invalidate() {
            query = null;
        }

        public virtual bool IsDistinct() {
            return distinct;
        }

        public virtual void SetDistinct(bool distinct) {
            this.distinct = distinct;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect Distinct() {
            Invalidate();
            SetDistinct(true);
            return this;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect All() {
            Invalidate();
            SetDistinct(false);
            return this;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect SelectTop(int count) {
            Invalidate();
            top = count;
            return this;
        }

        public virtual string GetMainTableName() {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect t = GetEntity();
            return ((GetEntity() is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) ? ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) (GetEntity())).GetName() : null);
        }

        public virtual string[] GetColumnTitles() {
            return null;
        }

        public virtual string GetQueryTitle() {
            if (title != null) {
                return title;
            }
            string d = GetQueryDescription();
            if (d == null || !d.ToUpper().StartsWith("<HTML>")) {
                return d;
            }
            return d;
        }

        public virtual void SetQueryTitle(string title) {
            this.title = title;
        }

        public virtual string GetQueryDescription() {
            return GetDescription();
        }

        public virtual void SetQueryDescription(string desc) {
            SetDescription(desc);
        }

        public virtual bool IsGroupingEnabled() {
            return groupingEnabled;
        }

        public virtual void SetGroupingEnabled(bool groupingEnabled) {
            this.groupingEnabled = groupingEnabled;
        }

        public virtual System.Collections.Generic.List<Net.Vpc.Upa.QLParameter> GetParameters() {
            return parameters;
        }

        public virtual void SetParameters(System.Collections.Generic.List<Net.Vpc.Upa.QLParameter> parameters) {
            this.parameters = parameters;
        }

        public virtual void AddParameter(Net.Vpc.Upa.QLParameter p) {
            if (parameters == null) {
                parameters = new System.Collections.Generic.List<Net.Vpc.Upa.QLParameter>();
            }
            parameters.Add(p);
        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions() {
            System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression> sub = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression>();
            if (fields != null) {
                foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField field in fields) {
                    sub.Add(field.GetExpression());
                }
            }
            if (queryEntity != null) {
                sub.Add(queryEntity);
            }
            if (joinsTables != null) {
                foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria joinCriteria in joinsTables) {
                    sub.Add(joinCriteria);
                }
            }
            if (groupByExpressions != null) {
                int size = (groupByExpressions).Count;
                for (int i = 0; i < size; i++) {
                    sub.Add(groupByExpressions[i]);
                }
            }
            if (order != null) {
                int size = order.Size();
                for (int i = 0; i < size; i++) {
                    sub.Add(order.GetOrderAt(i));
                }
            }
            if (where != null) {
                sub.Add(where);
            }
            if (having != null) {
                sub.Add(having);
            }
            return sub.ToArray();
        }


        public override void SetSubExpression(int index, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            int i = 0;
            if (fields != null) {
                foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField field in fields) {
                    if (i == index) {
                        field.SetExpression(expression);
                        return;
                    }
                    i++;
                }
            }
            if (queryEntity != null) {
                if (i == index) {
                    queryEntity = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect) expression;
                    return;
                }
                i++;
            }
            if (joinsTables != null) {
                for (int ii = 0; ii < (joinsTables).Count; ii++) {
                    if (i == index) {
                        joinsTables[ii]=(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria) expression;
                        return;
                    }
                    i++;
                }
            }
            if (groupByExpressions != null) {
                int size = (groupByExpressions).Count;
                for (int j = 0; j < size; j++) {
                    if (i == index) {
                        groupByExpressions[j]=expression;
                        return;
                    }
                    i++;
                }
            }
            if (order != null) {
                int size = order.Size();
                for (int j = 0; j < size; j++) {
                    if (i == index) {
                        order.SetOrderAt(j, expression);
                        return;
                    }
                    i++;
                }
            }
            if (where != null) {
                if (i == index) {
                    where = expression;
                }
                i++;
            }
            if (having != null) {
                if (i == index) {
                    having = expression;
                }
                i++;
            }
        }

        public virtual int GetTop() {
            return top;
        }

        public virtual void SetTop(int top) {
            this.top = top;
        }


        public override string ToString() {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("Select ");
            if (top > 0) {
                sb.Append(" TOP ").Append(top);
            }
            if (distinct) {
                sb.Append(" DISTINCT");
            }
            sb.Append(" ");
            string aliasString = null;
            string valueString = null;
            bool started = false;
            if (CountFields() == 0) {
                sb.Append("...");
            } else {
                for (int i = 0; i < CountFields(); i++) {
                    Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField fi = GetField(i);
                    Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e = fi.GetExpression();
                    valueString = System.Convert.ToString(e);
                    aliasString = fi.GetAlias();
                    if (started) {
                        sb.Append(",");
                    } else {
                        started = true;
                    }
                    if (aliasString == null || valueString.Equals(aliasString)) {
                        sb.Append(valueString);
                    } else {
                        sb.Append(valueString);
                        sb.Append(" ");
                        sb.Append(aliasString);
                    }
                }
            }
            if (GetEntity() == null) {
            } else {
                sb.Append(" From ");
                if (GetEntity() is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect) {
                    sb.Append(GetEntity().ToString());
                } else {
                    Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName entityName = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) GetEntity();
                    sb.Append(entityName);
                }
            }
            if (GetEntityAlias() != null) {
                sb.Append(" ").Append(GetEntityAlias());
            }
            for (int i = 0; i < CountJoins(); i++) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria e = GetJoin(i);
                sb.Append(" ").Append(e);
            }
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression c = GetWhere();
            if (c != null && c.IsValid()) {
                sb.Append(" Where ").Append(c);
            }
            if (CountGroupByItems() > 0) {
                sb.Append(" ");
                int maxGroups = CountGroupByItems();
                sb.Append("Group By ");
                for (int i = 0; i < maxGroups; i++) {
                    if (i > 0) {
                        sb.Append(", ");
                    }
                    sb.Append(GetGroupBy(i));
                }
            }
            int maxOrders = CountOrderByItems();
            if (maxOrders > 0) {
                sb.Append(" ");
                sb.Append("Order By ");
                for (int i = 0; i < maxOrders; i++) {
                    if (i > 0) {
                        sb.Append(", ");
                    }
                    sb.Append(GetOrderBy(i));
                    if (IsOrderAscending(i)) {
                        sb.Append(" Asc ");
                    } else {
                        sb.Append(" Desc ");
                    }
                }
            }
            return sb.ToString();
        }

        protected internal override System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression> FindEntityDefinitions() {
            System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression> list = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression>();
            list.Add(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression(GetEntityAlias(), GetEntity()));
            foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria jc in GetJoins()) {
                list.Add(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression(jc.GetEntityAlias(), jc.GetEntity()));
            }
            return list;
        }
    }
}
