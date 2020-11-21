/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



using System.Linq;
namespace Net.TheVpc.Upa.Expressions
{


    public class Select : Net.TheVpc.Upa.Expressions.DefaultEntityStatement, Net.TheVpc.Upa.Expressions.QueryStatement {

        private static readonly Net.TheVpc.Upa.Expressions.DefaultTag ENTITY = new Net.TheVpc.Upa.Expressions.DefaultTag("ENTITY");

        private static readonly Net.TheVpc.Upa.Expressions.DefaultTag WEHRE = new Net.TheVpc.Upa.Expressions.DefaultTag("WEHRE");

        private static readonly Net.TheVpc.Upa.Expressions.DefaultTag HAVING = new Net.TheVpc.Upa.Expressions.DefaultTag("HAVING");



        private int top = -1;

        private bool distinct = false;

        private Net.TheVpc.Upa.Expressions.Expression where;

        private Net.TheVpc.Upa.Expressions.Expression having;

        private System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.JoinCriteria> joinsEntities;

        private System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.QueryField> fields;

        private Net.TheVpc.Upa.Expressions.GroupCriteria group;

        private Net.TheVpc.Upa.Expressions.Order order;

        private Net.TheVpc.Upa.Expressions.NameOrQuery queryEntity;

        private string queryEntityAlias;

        private System.Collections.Generic.List<Net.TheVpc.Upa.QLParameter> parameters;

        public Select(Net.TheVpc.Upa.Expressions.Select other)  : this(){

            AddQuery(other);
        }


        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.QueryField> GetFields() {
            return new System.Collections.Generic.List<E>(fields);
        }

        public Select() {
            joinsEntities = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.JoinCriteria>(3);
            fields = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.QueryField>(5);
            //        groupByList = new Vector(1);
            group = new Net.TheVpc.Upa.Expressions.GroupCriteria();
            order = new Net.TheVpc.Upa.Expressions.Order();
            top = -1;
        }


        public override System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> GetChildren() {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> list = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.TaggedExpression>((fields).Count + (joinsEntities).Count + group.Size() + order.Size() + 3);
            //    private Expression where;
            //    private Expression having;
            //    private Order order;
            if (queryEntity != null) {
                list.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(queryEntity, ENTITY));
            }
            for (int i = 0; i < (fields).Count; i++) {
                list.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(fields[i].GetExpression(), new Net.TheVpc.Upa.Expressions.IndexedTag("FIELD", i)));
            }
            for (int i = 0; i < (joinsEntities).Count; i++) {
                Net.TheVpc.Upa.Expressions.JoinCriteria get = joinsEntities[i];
                list.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(get.GetEntity(), new Net.TheVpc.Upa.Expressions.IndexedTag("JOIN_ENTITY", i)));
                list.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(get.GetCondition(), new Net.TheVpc.Upa.Expressions.IndexedTag("JOIN_COND", i)));
            }
            if (where != null) {
                list.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(where, WEHRE));
            }
            for (int i = 0; i < group.Size(); i++) {
                Net.TheVpc.Upa.Expressions.Expression ee = group.GetGroupAt(i);
                list.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(ee, new Net.TheVpc.Upa.Expressions.IndexedTag("GROUP", i)));
            }
            if (having != null) {
                list.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(having, HAVING));
            }
            for (int i = 0; i < order.Size(); i++) {
                Net.TheVpc.Upa.Expressions.Expression ee = order.GetOrderAt(i);
                list.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(ee, new Net.TheVpc.Upa.Expressions.IndexedTag("ORDER", i)));
            }
            return list;
        }


        public override void SetChild(Net.TheVpc.Upa.Expressions.Expression e, Net.TheVpc.Upa.Expressions.ExpressionTag tag) {
            if (ENTITY.Equals(tag)) {
                this.queryEntity = (Net.TheVpc.Upa.Expressions.NameOrQuery) e;
            } else if (WEHRE.Equals(tag)) {
                this.where = e;
            } else if (HAVING.Equals(tag)) {
                this.having = e;
            } else {
                Net.TheVpc.Upa.Expressions.IndexedTag ii = (Net.TheVpc.Upa.Expressions.IndexedTag) tag;
                string en = ii.GetName();
                if (en.Equals("FIELD")) {
                    fields[ii.GetIndex()].SetExpression(e);
                } else if (en.Equals("JOIN_ENTITY")) {
                    joinsEntities[ii.GetIndex()].SetEntity((Net.TheVpc.Upa.Expressions.NameOrQuery) e);
                } else if (en.Equals("JOIN_COND")) {
                    joinsEntities[ii.GetIndex()].SetCondition(e);
                } else if (en.Equals("GROUP")) {
                    group.SetGroupAt(ii.GetIndex(), e);
                } else if (en.Equals("ORDER")) {
                    order.SetOrderAt(ii.GetIndex(), e);
                }
            }
        }

        public virtual Net.TheVpc.Upa.Expressions.Select Field(Net.TheVpc.Upa.Expressions.Expression expression) {
            return Field(expression, null);
        }

        public virtual Net.TheVpc.Upa.Expressions.Select Uplet(Net.TheVpc.Upa.Expressions.Expression[] expression, string alias) {
            if (expression.Length == 1) {
                return Field(expression[0], alias);
            } else {
                return Field(new Net.TheVpc.Upa.Expressions.Uplet(expression), alias);
            }
        }

        public virtual Net.TheVpc.Upa.Expressions.Select Uplet(params Net.TheVpc.Upa.Expressions.Expression [] expression) {
            if (expression.Length == 1) {
                return Field(expression[0]);
            } else {
                return Field(new Net.TheVpc.Upa.Expressions.Uplet(expression));
            }
        }

        public virtual Net.TheVpc.Upa.Expressions.Select Field(Net.TheVpc.Upa.Expressions.Expression expression, string alias) {
            Field(new Net.TheVpc.Upa.Expressions.QueryField(alias, expression));
            return this;
        }

        public virtual Net.TheVpc.Upa.Expressions.Select Field(Net.TheVpc.Upa.Expressions.QueryField queryField) {
            fields.Add(queryField);
            return this;
        }

        public virtual Net.TheVpc.Upa.Expressions.Select Field(string expression) {
            return Field(expression, null);
        }

        public virtual Net.TheVpc.Upa.Expressions.Select Field(string expression, string alias) {
            fields.Add(new Net.TheVpc.Upa.Expressions.QueryField(alias, new Net.TheVpc.Upa.Expressions.UserExpression(expression)));
            return this;
        }

        public virtual Net.TheVpc.Upa.Expressions.Select Field(int index, Net.TheVpc.Upa.Expressions.Expression expression, string alias) {
            fields.Insert(index, new Net.TheVpc.Upa.Expressions.QueryField(alias, expression));
            return this;
        }

        public virtual Net.TheVpc.Upa.Expressions.Select ClearFields() {
            fields.Clear();
            return this;
        }

        public virtual Net.TheVpc.Upa.Expressions.Select RemoveField(int index) {
            fields.RemoveAt(index);
            return this;
        }

        public virtual int CountFields() {
            return (fields).Count;
        }

        public virtual Net.TheVpc.Upa.Expressions.QueryField GetField(int i) {
            return (Net.TheVpc.Upa.Expressions.QueryField) fields[i];
        }

        public virtual int IndexOf(Net.TheVpc.Upa.Expressions.Expression field) {
            for (int i = 0; i < (fields).Count; i++) {
                Net.TheVpc.Upa.Expressions.QueryField info = fields[i];
                if (field.Equals(info.GetExpression())) {
                    return i;
                }
            }
            return -1;
        }

        public virtual Net.TheVpc.Upa.Expressions.Select From(Net.TheVpc.Upa.Expressions.NameOrQuery queryEntity, string alias) {
            //getContext().declare(alias, queryEntity);
            this.queryEntity = queryEntity;
            queryEntityAlias = alias;
            return this;
        }

        public virtual Net.TheVpc.Upa.Expressions.Select From(string entityName) {
            return From(new Net.TheVpc.Upa.Expressions.EntityName(entityName), null);
        }

        public virtual Net.TheVpc.Upa.Expressions.Select From(string entityName, string alias) {
            return From(new Net.TheVpc.Upa.Expressions.EntityName(entityName), alias);
        }

        public virtual Net.TheVpc.Upa.Expressions.Select From(Net.TheVpc.Upa.Expressions.Select view) {
            return From(view, null);
        }

        public virtual Net.TheVpc.Upa.Expressions.NameOrQuery GetEntity() {
            return queryEntity;
        }

        public override string GetEntityName() {
            Net.TheVpc.Upa.Expressions.NameOrQuery e = GetEntity();
            return (e != null && (e is Net.TheVpc.Upa.Expressions.EntityName)) ? ((Net.TheVpc.Upa.Expressions.EntityName) e).GetName() : null;
        }

        public override string GetEntityAlias() {
            //        return entityAlias == null ? (entity instanceof String) ? (String) entity : null : entityAlias;
            return queryEntityAlias;
        }

        private Net.TheVpc.Upa.Expressions.Select Join(Net.TheVpc.Upa.Expressions.JoinType joinType, Net.TheVpc.Upa.Expressions.NameOrQuery entity, string alias, Net.TheVpc.Upa.Expressions.Expression condition) {
            joinsEntities.Add(new Net.TheVpc.Upa.Expressions.JoinCriteria(joinType, entity, alias, condition));
            return this;
        }

        public virtual Net.TheVpc.Upa.Expressions.Select Join(Net.TheVpc.Upa.Expressions.JoinCriteria someJoin) {
            Join(someJoin.GetJoinType(), someJoin.GetEntity(), someJoin.GetEntityAlias(), someJoin.GetCondition());
            return this;
        }

        public virtual Net.TheVpc.Upa.Expressions.Select Join(string entity, string alias, Net.TheVpc.Upa.Expressions.Expression condition) {
            return Join(Net.TheVpc.Upa.Expressions.JoinType.INNER_JOIN, new Net.TheVpc.Upa.Expressions.EntityName(entity), alias, condition);
        }

        public virtual Net.TheVpc.Upa.Expressions.Select Join(Net.TheVpc.Upa.Expressions.Select entity, string alias, Net.TheVpc.Upa.Expressions.Expression condition) {
            return Join(Net.TheVpc.Upa.Expressions.JoinType.INNER_JOIN, entity, alias, condition);
        }

        public virtual Net.TheVpc.Upa.Expressions.Select InnerJoin(string entity, string alias, Net.TheVpc.Upa.Expressions.Expression condition) {
            return Join(Net.TheVpc.Upa.Expressions.JoinType.INNER_JOIN, new Net.TheVpc.Upa.Expressions.EntityName(entity), alias, condition);
        }

        public virtual Net.TheVpc.Upa.Expressions.Select InnerJoin(Net.TheVpc.Upa.Expressions.Select entity, string alias, Net.TheVpc.Upa.Expressions.Expression condition) {
            return Join(Net.TheVpc.Upa.Expressions.JoinType.INNER_JOIN, entity, alias, condition);
        }

        public virtual Net.TheVpc.Upa.Expressions.Select LeftJoin(string entity, string alias, Net.TheVpc.Upa.Expressions.Expression condition) {
            return Join(Net.TheVpc.Upa.Expressions.JoinType.LEFT_JOIN, new Net.TheVpc.Upa.Expressions.EntityName(entity), alias, condition);
        }

        public virtual Net.TheVpc.Upa.Expressions.Select LeftJoin(Net.TheVpc.Upa.Expressions.Select entity, string alias, Net.TheVpc.Upa.Expressions.Expression condition) {
            return Join(Net.TheVpc.Upa.Expressions.JoinType.LEFT_JOIN, entity, alias, condition);
        }

        public virtual Net.TheVpc.Upa.Expressions.Select RightJoin(string entity, string alias, Net.TheVpc.Upa.Expressions.Expression condition) {
            return Join(Net.TheVpc.Upa.Expressions.JoinType.RIGHT_JOIN, new Net.TheVpc.Upa.Expressions.EntityName(entity), alias, condition);
        }

        public virtual Net.TheVpc.Upa.Expressions.Select RightJoin(Net.TheVpc.Upa.Expressions.Select entity, string alias, Net.TheVpc.Upa.Expressions.Expression condition) {
            return Join(Net.TheVpc.Upa.Expressions.JoinType.RIGHT_JOIN, entity, alias, condition);
        }

        public virtual Net.TheVpc.Upa.Expressions.Select FullJoin(string entity, string alias, Net.TheVpc.Upa.Expressions.Expression condition) {
            return Join(Net.TheVpc.Upa.Expressions.JoinType.FULL_JOIN, new Net.TheVpc.Upa.Expressions.EntityName(entity), alias, condition);
        }

        public virtual Net.TheVpc.Upa.Expressions.Select FullJoin(Net.TheVpc.Upa.Expressions.Select entity, string alias, Net.TheVpc.Upa.Expressions.Expression condition) {
            return Join(Net.TheVpc.Upa.Expressions.JoinType.FULL_JOIN, entity, alias, condition);
        }

        public virtual Net.TheVpc.Upa.Expressions.Select CrossJoin(string entity) {
            return Join(Net.TheVpc.Upa.Expressions.JoinType.CROSS_JOIN, new Net.TheVpc.Upa.Expressions.EntityName(entity), null, null);
        }

        public virtual Net.TheVpc.Upa.Expressions.Select CrossJoin(string entity, string alias) {
            return Join(Net.TheVpc.Upa.Expressions.JoinType.CROSS_JOIN, new Net.TheVpc.Upa.Expressions.EntityName(entity), alias, null);
        }

        public virtual Net.TheVpc.Upa.Expressions.Select CrossJoin(Net.TheVpc.Upa.Expressions.Select entity, string alias) {
            return Join(Net.TheVpc.Upa.Expressions.JoinType.CROSS_JOIN, entity, alias, null);
        }

        public virtual int CountJoins() {
            return (joinsEntities).Count;
        }

        public virtual Net.TheVpc.Upa.Expressions.JoinCriteria[] GetJoins() {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.JoinCriteria> values = joinsEntities;
            return (Net.TheVpc.Upa.Expressions.JoinCriteria[]) values.ToArray();
        }

        public virtual Net.TheVpc.Upa.Expressions.JoinCriteria GetJoin(int i) {
            return (Net.TheVpc.Upa.Expressions.JoinCriteria) joinsEntities[i];
        }

        public virtual Net.TheVpc.Upa.Expressions.Select OrderBy(Net.TheVpc.Upa.Expressions.Order order) {
            if (order != null) {
                this.order.AddOrder(order);
            }
            return this;
        }

        public virtual Net.TheVpc.Upa.Expressions.Select OrderAscendentBy(Net.TheVpc.Upa.Expressions.Expression field) {
            order.Ascendant(field);
            return this;
        }

        public virtual Net.TheVpc.Upa.Expressions.Select OrderByDesc(Net.TheVpc.Upa.Expressions.Expression field) {
            order.Descendant(field);
            return this;
        }

        public virtual Net.TheVpc.Upa.Expressions.Select OrderBy(Net.TheVpc.Upa.Expressions.Expression field, bool isAscending) {
            order.AddOrder(field, isAscending);
            return this;
        }

        public virtual Net.TheVpc.Upa.Expressions.Select OrderBy(int position, Net.TheVpc.Upa.Expressions.Expression field, bool isAscending) {
            order.InsertOrder(position, field, isAscending);
            return this;
        }

        public virtual Net.TheVpc.Upa.Expressions.Select NoOrder() {
            //        orderAsc = true;
            order.NoOrder();
            return this;
        }

        public virtual Net.TheVpc.Upa.Expressions.Select RemoveOrder(int index) {
            order.RemoveOrder(index);
            return this;
        }

        public virtual bool IsOrdered() {
            return order.Size() != 0;
        }

        public virtual bool IsOrderAscending(int index) {
            return order.IsAscendentAt(index);
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetOrderBy(int index) {
            return order.GetOrderAt(index);
        }

        public virtual int CountOrderByItems() {
            return order.Size();
        }

        public virtual Net.TheVpc.Upa.Expressions.Order GetOrder() {
            return order;
        }

        public virtual Net.TheVpc.Upa.Expressions.Select GroupBy(Net.TheVpc.Upa.Expressions.Expression field) {
            group.AddGroup(field);
            return this;
        }

        public virtual bool IsGrouped() {
            return group.Size() > 0;
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetGroupBy(int i) {
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
        public virtual Net.TheVpc.Upa.Expressions.Select Where(Net.TheVpc.Upa.Expressions.Expression condition) {
            if (condition != null) {
                Net.TheVpc.Upa.Expressions.Expression where = GetWhere();
                if (where == null) {
                    SetWhere(condition);
                } else {
                    SetWhere(new Net.TheVpc.Upa.Expressions.And(where, condition));
                }
            }
            return this;
        }

        public virtual Net.TheVpc.Upa.Expressions.Select UpdateWhere(Net.TheVpc.Upa.Expressions.Expression where) {
            SetWhere(where);
            return this;
        }

        public virtual void SetWhere(Net.TheVpc.Upa.Expressions.Expression where) {
            this.where = where;
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetWhere() {
            return where;
        }

        public virtual Net.TheVpc.Upa.Expressions.Select Having(Net.TheVpc.Upa.Expressions.Expression having) {
            if (having != null) {
                if (GetHaving() == null) {
                    SetHaving(having);
                } else {
                    SetHaving(new Net.TheVpc.Upa.Expressions.And(GetHaving(), having));
                }
            }
            return this;
        }

        public virtual Net.TheVpc.Upa.Expressions.Select UpdateHaving(Net.TheVpc.Upa.Expressions.Expression having) {
            SetHaving(having);
            return this;
        }

        public virtual void SetHaving(Net.TheVpc.Upa.Expressions.Expression having) {
            this.having = having;
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetHaving() {
            return having;
        }


        public override bool IsValid() {
            return queryEntity != null && (fields).Count > 0;
        }

        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            Net.TheVpc.Upa.Expressions.Select o = new Net.TheVpc.Upa.Expressions.Select();
            o.AddQuery(this);
            return o;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        public virtual Net.TheVpc.Upa.Expressions.Select AddQuery(Net.TheVpc.Upa.Expressions.Select other) {
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
                Net.TheVpc.Upa.Expressions.JoinCriteria j = other.GetJoin(i);
                Join(j.GetJoinType(), j.GetEntity(), j.GetEntityAlias(), j.GetCondition());
            }
            foreach (Net.TheVpc.Upa.Expressions.QueryField field in other.fields) {
                fields.Add(new Net.TheVpc.Upa.Expressions.QueryField(field.GetAlias(), field.GetExpression().Copy()));
            }
            order.AddOrder(other.order.Copy());
            group.AddGroup(other.group.Copy());
            this.where = (other.where != null) ? other.where.Copy() : null;
            this.having = (other.having != null) ? other.having.Copy() : null;
            return this;
        }

        public virtual Net.TheVpc.Upa.Expressions.Select Distinct() {
            distinct = true;
            return this;
        }

        public virtual bool IsDistinct() {
            return distinct;
        }

        public virtual Net.TheVpc.Upa.Expressions.Select UpdateDistinct(bool distinct) {
            SetDistinct(distinct);
            return this;
        }

        public virtual void SetDistinct(bool distinct) {
            this.distinct = distinct;
        }

        public virtual string GetMainEntityName() {
            Net.TheVpc.Upa.Expressions.NameOrQuery t = GetEntity();
            return ((t is Net.TheVpc.Upa.Expressions.EntityName) ? ((Net.TheVpc.Upa.Expressions.EntityName) t).GetName() : null);
        }

        public virtual System.Collections.Generic.List<Net.TheVpc.Upa.QLParameter> GetParameters() {
            return parameters;
        }

        public virtual void SetParameters(System.Collections.Generic.List<Net.TheVpc.Upa.QLParameter> parameters) {
            this.parameters = parameters;
        }

        public virtual void AddParameter(Net.TheVpc.Upa.QLParameter p) {
            if (parameters == null) {
                parameters = new System.Collections.Generic.List<Net.TheVpc.Upa.QLParameter>(5);
            }
            parameters.Add(p);
        }

        public virtual int GetTop() {
            return top;
        }

        public virtual Net.TheVpc.Upa.Expressions.Select Top(int top) {
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
                    Net.TheVpc.Upa.Expressions.QueryField fi = GetField(i);
                    Net.TheVpc.Upa.Expressions.Expression e = fi.GetExpression();
                    valueString = System.Convert.ToString(e);
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
                        sb.Append(Net.TheVpc.Upa.Expressions.ExpressionHelper.EscapeIdentifier(aliasString));
                    }
                }
            }
            if (GetEntity() == null) {
            } else {
                sb.Append(" From ");
                if (GetEntity() is Net.TheVpc.Upa.Expressions.Select) {
                    sb.Append(GetEntity().ToString());
                } else {
                    Net.TheVpc.Upa.Expressions.EntityName entityName = (Net.TheVpc.Upa.Expressions.EntityName) GetEntity();
                    sb.Append(entityName);
                }
            }
            if (GetEntityAlias() != null) {
                sb.Append(" ").Append(Net.TheVpc.Upa.Expressions.ExpressionHelper.EscapeIdentifier(GetEntityAlias()));
            }
            for (int i = 0; i < CountJoins(); i++) {
                Net.TheVpc.Upa.Expressions.JoinCriteria e = GetJoin(i);
                sb.Append(" ").Append(e);
            }
            Net.TheVpc.Upa.Expressions.Expression c = GetWhere();
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
