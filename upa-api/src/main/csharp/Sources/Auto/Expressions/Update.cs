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



namespace Net.TheVpc.Upa.Expressions
{


    public sealed class Update : Net.TheVpc.Upa.Expressions.DefaultEntityStatement, Net.TheVpc.Upa.Expressions.NonQueryStatement {

        private static readonly Net.TheVpc.Upa.Expressions.DefaultTag ENTITY = new Net.TheVpc.Upa.Expressions.DefaultTag("ENTITY");

        private static readonly Net.TheVpc.Upa.Expressions.DefaultTag COND = new Net.TheVpc.Upa.Expressions.DefaultTag("COND");



        private System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.VarVal> fields;

        private Net.TheVpc.Upa.Expressions.Expression condition;

        private Net.TheVpc.Upa.Expressions.EntityName entity;

        private string entityAlias;

        public Update() {
            fields = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.VarVal>(5);
        }


        public override System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> GetChildren() {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> list = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.TaggedExpression>((fields).Count + 2);
            if (entity != null) {
                list.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(entity, ENTITY));
            }
            for (int i = 0; i < (fields).Count; i++) {
                list.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(fields[i].GetVar(), new Net.TheVpc.Upa.Expressions.IndexedTag("VAR", i)));
                list.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(fields[i].GetVal(), new Net.TheVpc.Upa.Expressions.IndexedTag("VAL", i)));
            }
            if (COND != null) {
                list.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(condition, COND));
            }
            return list;
        }


        public override void SetChild(Net.TheVpc.Upa.Expressions.Expression e, Net.TheVpc.Upa.Expressions.ExpressionTag tag) {
            if (ENTITY.Equals(tag)) {
                this.entity = (Net.TheVpc.Upa.Expressions.EntityName) e;
            } else if (COND.Equals(tag)) {
                this.condition = e;
            } else {
                Net.TheVpc.Upa.Expressions.IndexedTag ii = (Net.TheVpc.Upa.Expressions.IndexedTag) tag;
                if (ii.GetName().Equals("VAR")) {
                    fields[ii.GetIndex()].SetVar((Net.TheVpc.Upa.Expressions.Var) e);
                } else {
                    fields[ii.GetIndex()].SetVal(e);
                }
            }
        }

        public System.Collections.Generic.IDictionary<Net.TheVpc.Upa.Expressions.Var , Net.TheVpc.Upa.Expressions.Expression> GetUpdatesMapping() {
            System.Collections.Generic.IDictionary<Net.TheVpc.Upa.Expressions.Var , Net.TheVpc.Upa.Expressions.Expression> m = new System.Collections.Generic.Dictionary<Net.TheVpc.Upa.Expressions.Var , Net.TheVpc.Upa.Expressions.Expression>();
            foreach (Net.TheVpc.Upa.Expressions.VarVal f in fields) {
                m[f.GetVar()]=f.GetVal();
            }
            return m;
        }

        public Update(Net.TheVpc.Upa.Expressions.Update other)  : this(){

            AddQuery(other);
        }

        private Net.TheVpc.Upa.Expressions.Update Entity(string entity, string alias) {
            this.entity = new Net.TheVpc.Upa.Expressions.EntityName(entity);
            entityAlias = alias;
            return this;
        }

        public override string GetEntityName() {
            Net.TheVpc.Upa.Expressions.EntityName e = GetEntity();
            return (e != null) ? ((Net.TheVpc.Upa.Expressions.EntityName) e).GetName() : null;
        }

        public Net.TheVpc.Upa.Expressions.Update Entity(string entity) {
            return Entity(entity, null);
        }

        public Net.TheVpc.Upa.Expressions.EntityName GetEntity() {
            return entity;
        }

        public override string GetEntityAlias() {
            return entityAlias;
        }

        public int Size() {
            return 3;
        }

        public Net.TheVpc.Upa.Expressions.Update AddQuery(Net.TheVpc.Upa.Expressions.Update other) {
            if (other == null) {
                return this;
            }
            if (other.entity != null) {
                entity = (Net.TheVpc.Upa.Expressions.EntityName) other.entity.Copy();
            }
            if (other.entityAlias != null) {
                entityAlias = other.entityAlias;
            }
            for (int i = 0; i < (other.fields).Count; i++) {
                Set(other.GetField(i).GetName(), other.GetFieldValue(i));
            }
            if (other.condition != null) {
                if (condition == null) {
                    condition = other.condition.Copy();
                } else {
                    condition = new Net.TheVpc.Upa.Expressions.And(condition, other.condition.Copy());
                }
            }
            return this;
        }

        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            Net.TheVpc.Upa.Expressions.Update o = new Net.TheVpc.Upa.Expressions.Update();
            o.AddQuery(this);
            //        o.extraFrom = extraFrom;
            return o;
        }

        public Net.TheVpc.Upa.Expressions.Update Set(string key, object @value) {
            if (@value != null && (@value is Net.TheVpc.Upa.Expressions.Expression)) {
                return Set(key, (Net.TheVpc.Upa.Expressions.Expression) @value);
            } else {
                return Set(key, ((Net.TheVpc.Upa.Expressions.Expression) (new Net.TheVpc.Upa.Expressions.Literal(@value, null))));
            }
        }

        public Net.TheVpc.Upa.Expressions.Update Set(string key, Net.TheVpc.Upa.Expressions.Expression @value) {
            fields.Add(new Net.TheVpc.Upa.Expressions.VarVal(new Net.TheVpc.Upa.Expressions.Var(key), @value));
            return this;
        }

        public void RemoveFieldAt(int index) {
            fields.RemoveAt(index);
        }

        public Net.TheVpc.Upa.Expressions.Update Where(Net.TheVpc.Upa.Expressions.Expression condition) {
            this.condition = condition;
            return this;
        }

        public Net.TheVpc.Upa.Expressions.Expression GetCondition() {
            return condition;
        }

        public int CountFields() {
            return (fields).Count;
        }

        public Net.TheVpc.Upa.Expressions.VarVal GetVarVal(int i) {
            return fields[i];
        }

        public Net.TheVpc.Upa.Expressions.Var GetField(int i) {
            return fields[i].GetVar();
        }

        public Net.TheVpc.Upa.Expressions.Expression GetFieldValue(int i) {
            return (Net.TheVpc.Upa.Expressions.Expression) fields[i].GetVal();
        }

        public System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.Var> GetFields() {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.Var> all = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Var>((fields).Count);
            foreach (Net.TheVpc.Upa.Expressions.VarVal field in fields) {
                all.Add(field.GetVar());
            }
            return all;
        }


        public override string ToString() {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("Update " + entity);
            if (entityAlias != null) {
                sb.Append(" ").Append(Net.TheVpc.Upa.Expressions.ExpressionHelper.EscapeIdentifier(entityAlias));
            }
            sb.Append(" Set ");
            bool isFirst = true;
            int max = CountFields();
            for (int i = 0; i < max; i++) {
                Net.TheVpc.Upa.Expressions.Var field = GetField(i);
                Net.TheVpc.Upa.Expressions.Expression fieldValue = GetFieldValue(i);
                if (isFirst) {
                    isFirst = false;
                } else {
                    sb.Append(", ");
                }
                sb.Append(field);
                sb.Append("=");
                if (fieldValue is Net.TheVpc.Upa.Expressions.FunctionExpression || fieldValue is Net.TheVpc.Upa.Expressions.Param || fieldValue is Net.TheVpc.Upa.Expressions.Literal || fieldValue is Net.TheVpc.Upa.Expressions.Var || fieldValue is Net.TheVpc.Upa.Expressions.Cst) {
                    sb.Append(fieldValue);
                } else {
                    sb.Append("(");
                    sb.Append(fieldValue);
                    sb.Append(")");
                }
            }
            if (GetCondition() != null && GetCondition().IsValid()) {
                sb.Append(" Where ").Append(GetCondition());
            }
            //            if (extraFrom != null)
            return sb.ToString();
        }
    }
}
