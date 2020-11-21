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
namespace Net.TheVpc.Upa.Impl.Uql.Compiledexpression
{


    public class CompiledSelect : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledEntityStatement, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect {



        private int top = -1;

        private bool distinct;

        private string query;

        private Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression where;

        private Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression having;

        private System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria> joinsTables;

        private System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField> fields;

        private System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression> groupByExpressions = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression>(1);

        private Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledOrder order;

        private Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect queryEntity;

        private string queryEntityAlias;

        private string title;

        private bool groupingEnabled;

        private System.Collections.Generic.List<Net.TheVpc.Upa.QLParameter> parameters;


        public override Net.TheVpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            if ((fields).Count == 1) {
                Net.TheVpc.Upa.Types.DataTypeTransform type = fields[0].GetExpression().GetTypeTransform();
                return type == null ? Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform.VOID : type;
            }
            return Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform.VOID;
        }

        public CompiledSelect(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect other)  : this(){

            AddQuery(other);
        }

        public CompiledSelect() {
            query = null;
            joinsTables = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria>();
            fields = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField>(1);
            //        groupByList = new Vector(1);
            groupByExpressions = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression>();
            order = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledOrder();
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect Field(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            return Field(expression, null);
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect Uplet(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] expression, string alias) {
            if (expression.Length == 1) {
                return Field(expression[0], alias);
            } else {
                return Field(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUplet(expression), alias);
            }
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect Uplet(params Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression [] expression) {
            if (expression.Length == 1) {
                return Field(expression[0]);
            } else {
                return Field(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUplet(expression));
            }
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField AddField(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField compiledQueryField) {
            Invalidate();
            fields.Add(compiledQueryField);
            return compiledQueryField;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField AddField(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression, string alias) {
            Invalidate();
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField f = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField(alias, expression);
            fields.Add(f);
            PrepareChildren(f.GetExpression());
            return f;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField AddField(int index, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression, string alias) {
            Invalidate();
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField field = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField(alias, expression);
            fields.Insert(index, field);
            PrepareChildren(field.GetExpression());
            return field;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect Field(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression, string alias) {
            AddField(expression, alias);
            return this;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect Field(int index, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression, string alias) {
            AddField(index, expression, alias);
            return this;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect RemoveField(int index) {
            Invalidate();
            fields.RemoveAt(index);
            return this;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect RemoveAllFields() {
            Invalidate();
            fields.Clear();
            return this;
        }

        public virtual int CountFields() {
            return (fields).Count;
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField> GetFields() {
            return Net.TheVpc.Upa.Impl.Util.PlatformUtils.UnmodifiableList<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField>(fields);
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField GetField(int i) {
            return (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField) fields[i];
        }

        public virtual int IndexOf(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression field) {
            for (int i = 0; i < (fields).Count; i++) {
                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField info = fields[i];
                if (field.Equals(info.GetExpression())) {
                    return i;
                }
            }
            return -1;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect From(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect queryEntity, string entityAlias) {
            Invalidate();
            //getContext().declare(alias, queryEntity);
            this.queryEntity = queryEntity;
            queryEntityAlias = entityAlias;
            PrepareChildren(queryEntity);
            ExportDeclaration(queryEntity, entityAlias);
            return this;
        }

        protected internal virtual void ExportDeclaration(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect e, string entityAlias) {
            if (e is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) {
                ExportDeclaration(entityAlias, Net.TheVpc.Upa.Impl.Uql.DecObjectType.ENTITY, ((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) e).GetName(), null);
            } else {
                ExportDeclaration(entityAlias, Net.TheVpc.Upa.Impl.Uql.DecObjectType.SELECT, e, null);
            }
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect From(string entityName) {
            return From(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName(entityName), null);
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect From(string entityName, string alias) {
            return From(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName(entityName), alias);
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect From(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect view) {
            return From(view, null);
        }

        public virtual string GetEntityName() {
            if (queryEntity != null && queryEntity is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) {
                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName s = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) queryEntity;
                return s.GetName();
            }
            return null;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect GetEntity() {
            return queryEntity;
        }

        public virtual string GetEntityAlias() {
            //        return entityAlias == null ? (entity instanceof String) ? (String) entity : null : entityAlias;
            return queryEntityAlias;
        }

        private Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect Join(Net.TheVpc.Upa.Expressions.JoinType joinType, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect entityName, string alias, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            Invalidate();
            Join(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria(joinType, entityName, alias, condition));
            //getContext().declare(alias, entityName);
            return this;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect Join(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria someJoin) {
            joinsTables.Add(someJoin);
            PrepareChildren(someJoin);
            ExportDeclaration(someJoin.GetEntity(), someJoin.GetEntityAlias());
            return this;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect Join(string entityName, string alias, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            return Join(Net.TheVpc.Upa.Expressions.JoinType.INNER_JOIN, new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName(entityName), alias, condition);
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect Join(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect entityName, string alias, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            return Join(Net.TheVpc.Upa.Expressions.JoinType.INNER_JOIN, entityName, alias, condition);
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect InnerJoin(string entityName, string alias, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            return Join(Net.TheVpc.Upa.Expressions.JoinType.INNER_JOIN, new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName(entityName), alias, condition);
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect InnerJoin(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect entityName, string alias, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            return Join(Net.TheVpc.Upa.Expressions.JoinType.INNER_JOIN, entityName, alias, condition);
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect LeftJoin(string entityName, string alias, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            return Join(Net.TheVpc.Upa.Expressions.JoinType.LEFT_JOIN, new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName(entityName), alias, condition);
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect LeftJoin(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect entityName, string alias, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            return Join(Net.TheVpc.Upa.Expressions.JoinType.LEFT_JOIN, entityName, alias, condition);
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect RightJoin(string entityName, string alias, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            return Join(Net.TheVpc.Upa.Expressions.JoinType.RIGHT_JOIN, new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName(entityName), alias, condition);
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect RightJoin(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect entityName, string alias, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            return Join(Net.TheVpc.Upa.Expressions.JoinType.RIGHT_JOIN, entityName, alias, condition);
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect FullJoin(string entityName, string alias, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            return Join(Net.TheVpc.Upa.Expressions.JoinType.FULL_JOIN, new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName(entityName), alias, condition);
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect FullJoin(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect entityName, string alias, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            return Join(Net.TheVpc.Upa.Expressions.JoinType.FULL_JOIN, entityName, alias, condition);
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect CrossJoin(string entityName) {
            return Join(Net.TheVpc.Upa.Expressions.JoinType.CROSS_JOIN, new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName(entityName), null, null);
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect CrossJoin(string entityName, string alias) {
            return Join(Net.TheVpc.Upa.Expressions.JoinType.CROSS_JOIN, new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName(entityName), alias, null);
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect CrossJoin(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect entityName, string alias) {
            return Join(Net.TheVpc.Upa.Expressions.JoinType.CROSS_JOIN, entityName, alias, null);
        }

        public virtual int CountJoins() {
            return (joinsTables).Count;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria[] GetJoins() {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria> values = joinsTables;
            return values.ToArray();
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria GetJoin(int i) {
            return joinsTables[i];
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect OrderBy(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledOrder order) {
            if (order != null) {
                Invalidate();
                this.order.AddOrder(order);
                for (int i = 0; i < order.Size(); i++) {
                    PrepareChildren(order.GetOrderAt(i));
                }
            }
            return this;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect OrderAscendentBy(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression field) {
            Invalidate();
            order.Ascendent(field);
            PrepareChildren(field);
            return this;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect OrderByDesc(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression field) {
            Invalidate();
            order.Descendent(field);
            PrepareChildren(field);
            return this;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect OrderBy(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression field, bool isAscending) {
            Invalidate();
            order.AddOrder(field, isAscending);
            PrepareChildren(field);
            return this;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect OrderBy(int position, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression field, bool isAscending) {
            Invalidate();
            order.InsertOrder(position, field, isAscending);
            PrepareChildren(field);
            return this;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect NoOrder() {
            Invalidate();
            //        orderAsc = true;
            order.NoOrder();
            return this;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect RemoveOrder(int index) {
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

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetOrderBy(int index) {
            return order.GetOrderAt(index);
        }

        public virtual int CountOrderByItems() {
            return order.Size();
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect GroupBy(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression field) {
            Invalidate();
            groupByExpressions.Add(field);
            PrepareChildren(field);
            return this;
        }

        public virtual bool IsGrouped() {
            return (groupByExpressions).Count > 0;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetGroupBy(int i) {
            return groupByExpressions[i];
        }

        public virtual int CountGroupByItems() {
            return (groupByExpressions).Count;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect Where(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            this.where = condition;
            PrepareChildren(condition);
            return this;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect Having(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression having) {
            this.having = having;
            PrepareChildren(having);
            return this;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetWhere() {
            return where;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetHaving() {
            return having;
        }


        public override bool IsValid() {
            return queryEntity != null && (fields).Count > 0;
        }

        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect o = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect();
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            o.AddQuery(this);
            return o;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect AddWhere(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            if (condition != null) {
                if (this.where == null) {
                    Where(condition);
                } else {
                    this.where.UnsetParent();
                    Where(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledAnd(this.where, condition));
                }
            }
            Invalidate();
            return this;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect AddHaving(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            if (condition != null) {
                if (this.where == null) {
                    Having(condition);
                } else {
                    this.where.UnsetParent();
                    Having(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledAnd(this.where, condition));
                }
            }
            Invalidate();
            return this;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect AddQuery(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect other) {
            if (other == null) {
                return this;
            }
            if (other.queryEntity != null) {
                From((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect) (other.queryEntity.Copy()), other.queryEntityAlias);
            }
            for (int i = 0; i < (other.joinsTables).Count; i++) {
                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria j = other.GetJoin(i);
                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect ee = j.GetEntity();
                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression cc = j.GetCondition();
                Join(j.GetJoinType(), ee == null ? null : (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect) ee.Copy(), j.GetEntityAlias(), cc == null ? null : cc.Copy());
            }
            foreach (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField field in other.fields) {
                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression ee = field.GetExpression();
                AddField(ee == null ? null : ee.Copy(), field.GetAlias());
            }
            foreach (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledOrderItem compiledOrderItem in other.order.GetItems()) {
                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression ee = compiledOrderItem.GetExpression();
                OrderBy(ee == null ? null : ee.Copy(), compiledOrderItem.IsAsc());
            }
            foreach (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e in other.groupByExpressions) {
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

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect Distinct() {
            Invalidate();
            SetDistinct(true);
            return this;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect All() {
            Invalidate();
            SetDistinct(false);
            return this;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect SelectTop(int count) {
            Invalidate();
            top = count;
            return this;
        }

        public virtual string GetMainTableName() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect t = GetEntity();
            return ((GetEntity() is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) ? ((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) (GetEntity())).GetName() : null);
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

        public virtual System.Collections.Generic.List<Net.TheVpc.Upa.QLParameter> GetParameters() {
            return parameters;
        }

        public virtual void SetParameters(System.Collections.Generic.List<Net.TheVpc.Upa.QLParameter> parameters) {
            this.parameters = parameters;
        }

        public virtual void AddParameter(Net.TheVpc.Upa.QLParameter p) {
            if (parameters == null) {
                parameters = new System.Collections.Generic.List<Net.TheVpc.Upa.QLParameter>();
            }
            parameters.Add(p);
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions() {
            System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression> sub = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression>();
            if (fields != null) {
                foreach (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField field in fields) {
                    sub.Add(field.GetExpression());
                }
            }
            if (queryEntity != null) {
                sub.Add(queryEntity);
            }
            if (joinsTables != null) {
                foreach (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria joinCriteria in joinsTables) {
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


        public override void SetSubExpression(int index, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            int i = 0;
            if (fields != null) {
                foreach (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField field in fields) {
                    if (i == index) {
                        field.SetExpression(expression);
                        if (expression != null) {
                            expression.SetParentExpression(this);
                        }
                        return;
                    }
                    i++;
                }
            }
            if (queryEntity != null) {
                if (i == index) {
                    queryEntity = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect) expression;
                    if (expression != null) {
                        expression.SetParentExpression(this);
                    }
                    return;
                }
                i++;
            }
            if (joinsTables != null) {
                for (int ii = 0; ii < (joinsTables).Count; ii++) {
                    if (i == index) {
                        joinsTables[ii]=(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria) expression;
                        if (expression != null) {
                            expression.SetParentExpression(this);
                        }
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
                        if (expression != null) {
                            expression.SetParentExpression(this);
                        }
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
                        if (expression != null) {
                            expression.SetParentExpression(this);
                        }
                        return;
                    }
                    i++;
                }
            }
            if (where != null) {
                if (i == index) {
                    where = expression;
                    if (expression != null) {
                        expression.SetParentExpression(this);
                    }
                }
                i++;
            }
            if (having != null) {
                if (i == index) {
                    having = expression;
                    if (expression != null) {
                        expression.SetParentExpression(this);
                    }
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
                    Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField fi = GetField(i);
                    Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e = fi.GetExpression();
                    valueString = System.Convert.ToString(e);
                    if (!(e is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) && !(e is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledParam) && !(e is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledFunction) && !(e is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral)) {
                        valueString = "(" + valueString + ")";
                    }
                    aliasString = fi.GetAlias();
                    if (started) {
                        sb.Append(",");
                    } else {
                        started = true;
                    }
                    if (aliasString == null) {
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
                if (GetEntity() is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect) {
                    sb.Append(GetEntity().ToString());
                } else {
                    Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName entityName = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) GetEntity();
                    sb.Append(entityName);
                }
            }
            if (GetEntityAlias() != null) {
                sb.Append(" ").Append(GetEntityAlias());
            }
            for (int i = 0; i < CountJoins(); i++) {
                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria e = GetJoin(i);
                sb.Append(" ").Append(e);
            }
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression c = GetWhere();
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

        protected internal override System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression> FindEntityDefinitions() {
            System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression> list = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression>();
            list.Add(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression(GetEntityAlias(), GetEntity()));
            foreach (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria jc in GetJoins()) {
                list.Add(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression(jc.GetEntityAlias(), jc.GetEntity()));
            }
            return list;
        }
    }
}
