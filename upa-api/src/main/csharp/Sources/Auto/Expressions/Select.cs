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
namespace Net.Vpc.Upa.Expressions
{


    public class Select : Net.Vpc.Upa.Expressions.DefaultEntityStatement, Net.Vpc.Upa.Expressions.QueryStatement, Net.Vpc.Upa.Expressions.NameOrSelect {



        private int top = -1;

        private bool distinct = false;

        private Net.Vpc.Upa.Expressions.Expression where;

        private Net.Vpc.Upa.Expressions.Expression having;

        private System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.JoinCriteria> joinsEntities;

        private System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.QueryField> fields;

        private Net.Vpc.Upa.Expressions.GroupCriteria group;

        private Net.Vpc.Upa.Expressions.Order order;

        private Net.Vpc.Upa.Expressions.NameOrSelect queryEntity;

        private string queryEntityAlias;

        private System.Collections.Generic.List<Net.Vpc.Upa.QLParameter> parameters;

        public Select(Net.Vpc.Upa.Expressions.Select other)  : this(){

            AddQuery(other);
        }

        public Select() {
            joinsEntities = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.JoinCriteria>();
            fields = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.QueryField>(1);
            //        groupByList = new Vector(1);
            group = new Net.Vpc.Upa.Expressions.GroupCriteria();
            order = new Net.Vpc.Upa.Expressions.Order();
            top = -1;
        }

        public virtual Net.Vpc.Upa.Expressions.Select Field(Net.Vpc.Upa.Expressions.Expression expression) {
            return Field(expression, null);
        }

        public virtual Net.Vpc.Upa.Expressions.Select Uplet(Net.Vpc.Upa.Expressions.Expression[] expression, string alias) {
            if (expression.Length == 1) {
                return Field(expression[0], alias);
            } else {
                return Field(new Net.Vpc.Upa.Expressions.Uplet(expression), alias);
            }
        }

        public virtual Net.Vpc.Upa.Expressions.Select Uplet(params Net.Vpc.Upa.Expressions.Expression [] expression) {
            if (expression.Length == 1) {
                return Field(expression[0]);
            } else {
                return Field(new Net.Vpc.Upa.Expressions.Uplet(expression));
            }
        }

        public virtual Net.Vpc.Upa.Expressions.Select Field(Net.Vpc.Upa.Expressions.Expression expression, string alias) {
            fields.Add(new Net.Vpc.Upa.Expressions.QueryField(alias, expression));
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.Select Field(string expression) {
            return Field(expression, null);
        }

        public virtual Net.Vpc.Upa.Expressions.Select Field(string expression, string alias) {
            fields.Add(new Net.Vpc.Upa.Expressions.QueryField(alias, new Net.Vpc.Upa.Expressions.UserExpression(expression)));
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.Select Field(int index, Net.Vpc.Upa.Expressions.Expression expression, string alias) {
            fields.Insert(index, new Net.Vpc.Upa.Expressions.QueryField(alias, expression));
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.Select RemoveField(int index) {
            fields.RemoveAt(index);
            return this;
        }

        public virtual int CountFields() {
            return (fields).Count;
        }

        public virtual Net.Vpc.Upa.Expressions.QueryField GetField(int i) {
            return (Net.Vpc.Upa.Expressions.QueryField) fields[i];
        }

        public virtual int IndexOf(Net.Vpc.Upa.Expressions.Expression field) {
            for (int i = 0; i < (fields).Count; i++) {
                Net.Vpc.Upa.Expressions.QueryField info = fields[i];
                if (field.Equals(info.GetExpression())) {
                    return i;
                }
            }
            return -1;
        }

        public virtual Net.Vpc.Upa.Expressions.Select From(Net.Vpc.Upa.Expressions.NameOrSelect queryEntity, string alias) {
            //getContext().declare(alias, queryEntity);
            this.queryEntity = queryEntity;
            queryEntityAlias = alias;
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.Select From(string entityName) {
            return From(new Net.Vpc.Upa.Expressions.EntityName(entityName), null);
        }

        public virtual Net.Vpc.Upa.Expressions.Select From(string entityName, string alias) {
            return From(new Net.Vpc.Upa.Expressions.EntityName(entityName), alias);
        }

        public virtual Net.Vpc.Upa.Expressions.Select From(Net.Vpc.Upa.Expressions.Select view) {
            return From(view, null);
        }

        public virtual Net.Vpc.Upa.Expressions.NameOrSelect GetEntity() {
            return queryEntity;
        }

        public override string GetEntityName() {
            Net.Vpc.Upa.Expressions.NameOrSelect e = GetEntity();
            return (e != null && (e is Net.Vpc.Upa.Expressions.EntityName)) ? ((Net.Vpc.Upa.Expressions.EntityName) e).GetName() : null;
        }

        public virtual string GetEntityAlias() {
            //        return entityAlias == null ? (entity instanceof String) ? (String) entity : null : entityAlias;
            return queryEntityAlias;
        }

        private Net.Vpc.Upa.Expressions.Select Join(Net.Vpc.Upa.Expressions.JoinType joinType, Net.Vpc.Upa.Expressions.NameOrSelect entity, string alias, Net.Vpc.Upa.Expressions.Expression condition) {
            joinsEntities.Add(new Net.Vpc.Upa.Expressions.JoinCriteria(joinType, entity, alias, condition));
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.Select Join(Net.Vpc.Upa.Expressions.JoinCriteria someJoin) {
            Join(someJoin.GetJoinType(), someJoin.GetEntity(), someJoin.GetEntityAlias(), someJoin.GetCondition());
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.Select Join(string entity, string alias, Net.Vpc.Upa.Expressions.Expression condition) {
            return Join(Net.Vpc.Upa.Expressions.JoinType.INNER_JOIN, new Net.Vpc.Upa.Expressions.EntityName(entity), alias, condition);
        }

        public virtual Net.Vpc.Upa.Expressions.Select Join(Net.Vpc.Upa.Expressions.Select entity, string alias, Net.Vpc.Upa.Expressions.Expression condition) {
            return Join(Net.Vpc.Upa.Expressions.JoinType.INNER_JOIN, entity, alias, condition);
        }

        public virtual Net.Vpc.Upa.Expressions.Select InnerJoin(string entity, string alias, Net.Vpc.Upa.Expressions.Expression condition) {
            return Join(Net.Vpc.Upa.Expressions.JoinType.INNER_JOIN, new Net.Vpc.Upa.Expressions.EntityName(entity), alias, condition);
        }

        public virtual Net.Vpc.Upa.Expressions.Select InnerJoin(Net.Vpc.Upa.Expressions.Select entity, string alias, Net.Vpc.Upa.Expressions.Expression condition) {
            return Join(Net.Vpc.Upa.Expressions.JoinType.INNER_JOIN, entity, alias, condition);
        }

        public virtual Net.Vpc.Upa.Expressions.Select LeftJoin(string entity, string alias, Net.Vpc.Upa.Expressions.Expression condition) {
            return Join(Net.Vpc.Upa.Expressions.JoinType.LEFT_JOIN, new Net.Vpc.Upa.Expressions.EntityName(entity), alias, condition);
        }

        public virtual Net.Vpc.Upa.Expressions.Select LeftJoin(Net.Vpc.Upa.Expressions.Select entity, string alias, Net.Vpc.Upa.Expressions.Expression condition) {
            return Join(Net.Vpc.Upa.Expressions.JoinType.LEFT_JOIN, entity, alias, condition);
        }

        public virtual Net.Vpc.Upa.Expressions.Select RightJoin(string entity, string alias, Net.Vpc.Upa.Expressions.Expression condition) {
            return Join(Net.Vpc.Upa.Expressions.JoinType.RIGHT_JOIN, new Net.Vpc.Upa.Expressions.EntityName(entity), alias, condition);
        }

        public virtual Net.Vpc.Upa.Expressions.Select RightJoin(Net.Vpc.Upa.Expressions.Select entity, string alias, Net.Vpc.Upa.Expressions.Expression condition) {
            return Join(Net.Vpc.Upa.Expressions.JoinType.RIGHT_JOIN, entity, alias, condition);
        }

        public virtual Net.Vpc.Upa.Expressions.Select FullJoin(string entity, string alias, Net.Vpc.Upa.Expressions.Expression condition) {
            return Join(Net.Vpc.Upa.Expressions.JoinType.FULL_JOIN, new Net.Vpc.Upa.Expressions.EntityName(entity), alias, condition);
        }

        public virtual Net.Vpc.Upa.Expressions.Select FullJoin(Net.Vpc.Upa.Expressions.Select entity, string alias, Net.Vpc.Upa.Expressions.Expression condition) {
            return Join(Net.Vpc.Upa.Expressions.JoinType.FULL_JOIN, entity, alias, condition);
        }

        public virtual Net.Vpc.Upa.Expressions.Select CrossJoin(string entity) {
            return Join(Net.Vpc.Upa.Expressions.JoinType.CROSS_JOIN, new Net.Vpc.Upa.Expressions.EntityName(entity), null, null);
        }

        public virtual Net.Vpc.Upa.Expressions.Select CrossJoin(string entity, string alias) {
            return Join(Net.Vpc.Upa.Expressions.JoinType.CROSS_JOIN, new Net.Vpc.Upa.Expressions.EntityName(entity), alias, null);
        }

        public virtual Net.Vpc.Upa.Expressions.Select CrossJoin(Net.Vpc.Upa.Expressions.Select entity, string alias) {
            return Join(Net.Vpc.Upa.Expressions.JoinType.CROSS_JOIN, entity, alias, null);
        }

        public virtual int CountJoins() {
            return (joinsEntities).Count;
        }

        public virtual Net.Vpc.Upa.Expressions.JoinCriteria[] GetJoins() {
            System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.JoinCriteria> values = joinsEntities;
            return (Net.Vpc.Upa.Expressions.JoinCriteria[]) values.ToArray();
        }

        public virtual Net.Vpc.Upa.Expressions.JoinCriteria GetJoin(int i) {
            return (Net.Vpc.Upa.Expressions.JoinCriteria) joinsEntities[i];
        }

        public virtual Net.Vpc.Upa.Expressions.Select OrderBy(Net.Vpc.Upa.Expressions.Order order) {
            if (order != null) {
                this.order.AddOrder(order);
            }
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.Select OrderAscendentBy(Net.Vpc.Upa.Expressions.Expression field) {
            order.Ascendent(field);
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.Select OrderByDesc(Net.Vpc.Upa.Expressions.Expression field) {
            order.Descendent(field);
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.Select OrderBy(Net.Vpc.Upa.Expressions.Expression field, bool isAscending) {
            order.AddOrder(field, isAscending);
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.Select OrderBy(int position, Net.Vpc.Upa.Expressions.Expression field, bool isAscending) {
            order.InsertOrder(position, field, isAscending);
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.Select NoOrder() {
            //        orderAsc = true;
            order.NoOrder();
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.Select RemoveOrder(int index) {
            order.RemoveOrder(index);
            return this;
        }

        public virtual bool IsOrdered() {
            return order.Size() != 0;
        }

        public virtual bool IsOrderAscending(int index) {
            return order.IsAscendentAt(index);
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetOrderBy(int index) {
            return order.GetOrderAt(index);
        }

        public virtual int CountOrderByItems() {
            return order.Size();
        }

        public virtual Net.Vpc.Upa.Expressions.Select GroupBy(Net.Vpc.Upa.Expressions.Expression field) {
            group.AddGroup(field);
            return this;
        }

        public virtual bool IsGrouped() {
            return group.Size() > 0;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetGroupBy(int i) {
            return group.GetGroupAt(i);
        }

        public virtual int CountGroupByItems() {
            return group.Size();
        }

        /**
             * add where condition appending to existing condition using AND operator
             *
             * @param condition add where condition appending to existing condition
             * using AND operator
             * @return this Selection instance
             */
        public virtual Net.Vpc.Upa.Expressions.Select Where(Net.Vpc.Upa.Expressions.Expression condition) {
            if (condition != null) {
                if (GetWhere() == null) {
                    SetWhere(condition);
                } else {
                    SetWhere(new Net.Vpc.Upa.Expressions.And(GetWhere(), condition));
                }
            }
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.Select UpdateWhere(Net.Vpc.Upa.Expressions.Expression where) {
            SetWhere(where);
            return this;
        }

        public virtual void SetWhere(Net.Vpc.Upa.Expressions.Expression where) {
            this.where = where;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetWhere() {
            return where;
        }

        public virtual Net.Vpc.Upa.Expressions.Select Having(Net.Vpc.Upa.Expressions.Expression having) {
            if (having != null) {
                if (GetHaving() == null) {
                    SetHaving(having);
                } else {
                    SetHaving(new Net.Vpc.Upa.Expressions.And(GetHaving(), having));
                }
            }
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.Select UpdateHaving(Net.Vpc.Upa.Expressions.Expression having) {
            SetHaving(having);
            return this;
        }

        public virtual void SetHaving(Net.Vpc.Upa.Expressions.Expression having) {
            this.having = having;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetHaving() {
            return having;
        }


        public override bool IsValid() {
            return queryEntity != null && (fields).Count > 0;
        }

        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.Select o = new Net.Vpc.Upa.Expressions.Select();
            o.AddQuery(this);
            return o;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        public virtual Net.Vpc.Upa.Expressions.Select AddQuery(Net.Vpc.Upa.Expressions.Select other) {
            if (other == null) {
                return this;
            }
            if (other.queryEntity != null) {
                queryEntity = other.queryEntity;
            }
            if (other.queryEntityAlias != null) {
                queryEntityAlias = other.queryEntityAlias;
            }
            for (int i = 0; i < (other.joinsEntities).Count; i++) {
                Net.Vpc.Upa.Expressions.JoinCriteria j = other.GetJoin(i);
                Join(j.GetJoinType(), j.GetEntity(), j.GetEntityAlias(), j.GetCondition());
            }
            foreach (Net.Vpc.Upa.Expressions.QueryField field in other.fields) {
                fields.Add(new Net.Vpc.Upa.Expressions.QueryField(field.GetAlias(), field.GetExpression().Copy()));
            }
            order.AddOrder(other.order.Copy());
            group.AddGroup(other.group.Copy());
            this.where = (other.where != null) ? other.where.Copy() : null;
            this.having = (other.having != null) ? other.having.Copy() : null;
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.Select Distinct() {
            distinct = true;
            return this;
        }

        public virtual bool IsDistinct() {
            return distinct;
        }

        public virtual Net.Vpc.Upa.Expressions.Select UpdateDistinct(bool distinct) {
            SetDistinct(distinct);
            return this;
        }

        public virtual void SetDistinct(bool distinct) {
            this.distinct = distinct;
        }

        public virtual string GetMainEntityName() {
            Net.Vpc.Upa.Expressions.NameOrSelect t = GetEntity();
            return ((t is Net.Vpc.Upa.Expressions.EntityName) ? ((Net.Vpc.Upa.Expressions.EntityName) t).GetName() : null);
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

        public virtual int GetTop() {
            return top;
        }

        public virtual Net.Vpc.Upa.Expressions.Select Top(int top) {
            SetTop(top);
            return this;
        }

        public virtual void SetTop(int top) {
            this.top = top <= 0 ? -1 : top;
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
                    Net.Vpc.Upa.Expressions.QueryField fi = GetField(i);
                    Net.Vpc.Upa.Expressions.Expression e = fi.GetExpression();
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
                        sb.Append(Net.Vpc.Upa.Expressions.ExpressionHelper.EscapeIdentifier(aliasString));
                    }
                }
            }
            if (GetEntity() == null) {
            } else {
                sb.Append(" From ");
                if (GetEntity() is Net.Vpc.Upa.Expressions.Select) {
                    sb.Append(GetEntity().ToString());
                } else {
                    Net.Vpc.Upa.Expressions.EntityName entityName = (Net.Vpc.Upa.Expressions.EntityName) GetEntity();
                    sb.Append(entityName);
                }
            }
            if (GetEntityAlias() != null) {
                sb.Append(" ").Append(Net.Vpc.Upa.Expressions.ExpressionHelper.EscapeIdentifier(GetEntityAlias()));
            }
            for (int i = 0; i < CountJoins(); i++) {
                Net.Vpc.Upa.Expressions.JoinCriteria e = GetJoin(i);
                sb.Append(" ").Append(e);
            }
            Net.Vpc.Upa.Expressions.Expression c = GetWhere();
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
    }
}
