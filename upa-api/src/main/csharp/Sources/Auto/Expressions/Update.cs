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



namespace Net.Vpc.Upa.Expressions
{


    public sealed class Update : Net.Vpc.Upa.Expressions.DefaultEntityStatement, Net.Vpc.Upa.Expressions.NonQueryStatement {

        private static readonly Net.Vpc.Upa.Expressions.DefaultTag ENTITY = new Net.Vpc.Upa.Expressions.DefaultTag("ENTITY");

        private static readonly Net.Vpc.Upa.Expressions.DefaultTag COND = new Net.Vpc.Upa.Expressions.DefaultTag("COND");



        private System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.VarVal> fields;

        private Net.Vpc.Upa.Expressions.Expression condition;

        private Net.Vpc.Upa.Expressions.EntityName entity;

        private string entityAlias;

        public Update() {
            fields = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.VarVal>(5);
        }


        public override System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> GetChildren() {
            System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> list = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.TaggedExpression>((fields).Count + 2);
            if (entity != null) {
                list.Add(new Net.Vpc.Upa.Expressions.TaggedExpression(entity, ENTITY));
            }
            for (int i = 0; i < (fields).Count; i++) {
                list.Add(new Net.Vpc.Upa.Expressions.TaggedExpression(fields[i].GetVar(), new Net.Vpc.Upa.Expressions.IndexedTag("VAR", i)));
                list.Add(new Net.Vpc.Upa.Expressions.TaggedExpression(fields[i].GetVal(), new Net.Vpc.Upa.Expressions.IndexedTag("VAL", i)));
            }
            if (COND != null) {
                list.Add(new Net.Vpc.Upa.Expressions.TaggedExpression(condition, COND));
            }
            return list;
        }


        public override void SetChild(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.Expressions.ExpressionTag tag) {
            if (ENTITY.Equals(tag)) {
                this.entity = (Net.Vpc.Upa.Expressions.EntityName) e;
            } else if (COND.Equals(tag)) {
                this.condition = e;
            } else {
                Net.Vpc.Upa.Expressions.IndexedTag ii = (Net.Vpc.Upa.Expressions.IndexedTag) tag;
                if (ii.GetName().Equals("VAR")) {
                    fields[ii.GetIndex()].SetVar((Net.Vpc.Upa.Expressions.Var) e);
                } else {
                    fields[ii.GetIndex()].SetVal(e);
                }
            }
        }

        public System.Collections.Generic.IDictionary<Net.Vpc.Upa.Expressions.Var , Net.Vpc.Upa.Expressions.Expression> GetUpdatesMapping() {
            System.Collections.Generic.IDictionary<Net.Vpc.Upa.Expressions.Var , Net.Vpc.Upa.Expressions.Expression> m = new System.Collections.Generic.Dictionary<Net.Vpc.Upa.Expressions.Var , Net.Vpc.Upa.Expressions.Expression>();
            foreach (Net.Vpc.Upa.Expressions.VarVal f in fields) {
                m[f.GetVar()]=f.GetVal();
            }
            return m;
        }

        public Update(Net.Vpc.Upa.Expressions.Update other)  : this(){

            AddQuery(other);
        }

        private Net.Vpc.Upa.Expressions.Update Entity(string entity, string alias) {
            this.entity = new Net.Vpc.Upa.Expressions.EntityName(entity);
            entityAlias = alias;
            return this;
        }

        public override string GetEntityName() {
            Net.Vpc.Upa.Expressions.EntityName e = GetEntity();
            return (e != null) ? ((Net.Vpc.Upa.Expressions.EntityName) e).GetName() : null;
        }

        public Net.Vpc.Upa.Expressions.Update Entity(string entity) {
            return Entity(entity, null);
        }

        public Net.Vpc.Upa.Expressions.EntityName GetEntity() {
            return entity;
        }

        public override string GetEntityAlias() {
            return entityAlias;
        }

        public int Size() {
            return 3;
        }

        public Net.Vpc.Upa.Expressions.Update AddQuery(Net.Vpc.Upa.Expressions.Update other) {
            if (other == null) {
                return this;
            }
            if (other.entity != null) {
                entity = (Net.Vpc.Upa.Expressions.EntityName) other.entity.Copy();
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
                    condition = new Net.Vpc.Upa.Expressions.And(condition, other.condition.Copy());
                }
            }
            return this;
        }

        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.Update o = new Net.Vpc.Upa.Expressions.Update();
            o.AddQuery(this);
            //        o.extraFrom = extraFrom;
            return o;
        }

        public Net.Vpc.Upa.Expressions.Update Set(string key, object @value) {
            if (@value != null && (@value is Net.Vpc.Upa.Expressions.Expression)) {
                return Set(key, (Net.Vpc.Upa.Expressions.Expression) @value);
            } else {
                return Set(key, ((Net.Vpc.Upa.Expressions.Expression) (new Net.Vpc.Upa.Expressions.Literal(@value, null))));
            }
        }

        public Net.Vpc.Upa.Expressions.Update Set(string key, Net.Vpc.Upa.Expressions.Expression @value) {
            fields.Add(new Net.Vpc.Upa.Expressions.VarVal(new Net.Vpc.Upa.Expressions.Var(key), @value));
            return this;
        }

        public void RemoveFieldAt(int index) {
            fields.RemoveAt(index);
        }

        public Net.Vpc.Upa.Expressions.Update Where(Net.Vpc.Upa.Expressions.Expression condition) {
            this.condition = condition;
            return this;
        }

        public Net.Vpc.Upa.Expressions.Expression GetCondition() {
            return condition;
        }

        public int CountFields() {
            return (fields).Count;
        }

        public Net.Vpc.Upa.Expressions.VarVal GetVarVal(int i) {
            return fields[i];
        }

        public Net.Vpc.Upa.Expressions.Var GetField(int i) {
            return fields[i].GetVar();
        }

        public Net.Vpc.Upa.Expressions.Expression GetFieldValue(int i) {
            return (Net.Vpc.Upa.Expressions.Expression) fields[i].GetVal();
        }

        public System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Var> GetFields() {
            System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Var> all = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Var>((fields).Count);
            foreach (Net.Vpc.Upa.Expressions.VarVal field in fields) {
                all.Add(field.GetVar());
            }
            return all;
        }


        public override string ToString() {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("Update " + entity);
            if (entityAlias != null) {
                sb.Append(" ").Append(Net.Vpc.Upa.Expressions.ExpressionHelper.EscapeIdentifier(entityAlias));
            }
            sb.Append(" Set ");
            bool isFirst = true;
            int max = CountFields();
            for (int i = 0; i < max; i++) {
                Net.Vpc.Upa.Expressions.Var field = GetField(i);
                Net.Vpc.Upa.Expressions.Expression fieldValue = GetFieldValue(i);
                if (isFirst) {
                    isFirst = false;
                } else {
                    sb.Append(", ");
                }
                sb.Append(field);
                sb.Append("=");
                if (fieldValue is Net.Vpc.Upa.Expressions.FunctionExpression || fieldValue is Net.Vpc.Upa.Expressions.Param || fieldValue is Net.Vpc.Upa.Expressions.Literal || fieldValue is Net.Vpc.Upa.Expressions.Var || fieldValue is Net.Vpc.Upa.Expressions.Cst) {
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
