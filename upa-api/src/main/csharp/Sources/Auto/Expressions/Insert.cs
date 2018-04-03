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


    public class Insert : Net.Vpc.Upa.Expressions.DefaultEntityStatement, Net.Vpc.Upa.Expressions.NonQueryStatement {

        private static readonly Net.Vpc.Upa.Expressions.DefaultTag ENTITY = new Net.Vpc.Upa.Expressions.DefaultTag("ENTITY");



        private System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.VarVal> fields;

        private Net.Vpc.Upa.Expressions.EntityName entity;

        public Insert() {
            fields = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.VarVal>();
        }

        public Insert(string entityName, string[] fields, object[] values)  : this(){

            Into(entityName);
            for (int i = 0; i < fields.Length; i++) {
                Set(fields[i], values[i]);
            }
        }

        public Insert(Net.Vpc.Upa.Expressions.Insert other)  : this(){

            AddQuery(other);
        }


        public override System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> GetChildren() {
            System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> list = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.TaggedExpression>((fields).Count + 1);
            if (entity != null) {
                list.Add(new Net.Vpc.Upa.Expressions.TaggedExpression(entity, ENTITY));
            }
            for (int i = 0; i < (fields).Count; i++) {
                list.Add(new Net.Vpc.Upa.Expressions.TaggedExpression(fields[i].GetVar(), new Net.Vpc.Upa.Expressions.IndexedTag("VAR", i)));
                list.Add(new Net.Vpc.Upa.Expressions.TaggedExpression(fields[i].GetVal(), new Net.Vpc.Upa.Expressions.IndexedTag("VAL", i)));
            }
            return list;
        }


        public override void SetChild(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.Expressions.ExpressionTag tag) {
            if (ENTITY.Equals(tag)) {
                this.entity = (Net.Vpc.Upa.Expressions.EntityName) e;
            } else {
                Net.Vpc.Upa.Expressions.IndexedTag ii = (Net.Vpc.Upa.Expressions.IndexedTag) tag;
                if (ii.GetName().Equals("VAR")) {
                    fields[ii.GetIndex()].SetVar((Net.Vpc.Upa.Expressions.Var) e);
                } else {
                    fields[ii.GetIndex()].SetVal(e);
                }
            }
        }

        public virtual Net.Vpc.Upa.Expressions.Insert Into(string entity) {
            this.entity = new Net.Vpc.Upa.Expressions.EntityName(entity);
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.EntityName GetEntity() {
            return entity;
        }

        public override string GetEntityName() {
            Net.Vpc.Upa.Expressions.EntityName e = GetEntity();
            return (e != null) ? ((Net.Vpc.Upa.Expressions.EntityName) e).GetName() : null;
        }

        public virtual int Size() {
            return 3;
        }

        public virtual Net.Vpc.Upa.Expressions.Insert AddQuery(Net.Vpc.Upa.Expressions.Insert other) {
            if (other == null) {
                return this;
            }
            if (other.entity != null) {
                entity = (Net.Vpc.Upa.Expressions.EntityName) other.entity.Copy();
            }
            for (int i = 0; i < (other.fields).Count; i++) {
                Set(other.GetField(i).GetName(), other.GetFieldValue(i).Copy());
            }
            return this;
        }

        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.Insert o = new Net.Vpc.Upa.Expressions.Insert();
            o.AddQuery(this);
            return o;
        }

        public virtual Net.Vpc.Upa.Expressions.Insert Set(string key, object @value) {
            if (@value != null && (@value is Net.Vpc.Upa.Expressions.Expression)) {
                return Set(key, (Net.Vpc.Upa.Expressions.Expression) @value);
            } else {
                return Set(key, ((Net.Vpc.Upa.Expressions.Expression) (new Net.Vpc.Upa.Expressions.Literal(@value, null))));
            }
        }

        public virtual Net.Vpc.Upa.Expressions.Insert Set(string key, Net.Vpc.Upa.Expressions.Expression @value) {
            fields.Add(new Net.Vpc.Upa.Expressions.VarVal(new Net.Vpc.Upa.Expressions.Var(key), @value));
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.Insert Set(int index, Net.Vpc.Upa.Expressions.Expression @value) {
            fields.Insert(index, new Net.Vpc.Upa.Expressions.VarVal(fields[index].GetVar(), @value));
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.Insert Set(string[] keys, object[] values) {
            for (int i = 0; i < keys.Length; i++) {
                Set(keys[i], values[i]);
            }
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.Insert Set(System.Collections.Generic.IDictionary<string , object> keysValues) {
            foreach (System.Collections.Generic.KeyValuePair<string , object> e in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,object>>(keysValues)) {
                Set((e).Key, (e).Value);
            }
            return this;
        }


        public override string ToString() {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("Insert Into " + entity);
            //        if (entityAlias != null) {
            //            sb.append(" ").append(entityAlias);
            //        }
            sb.Append("(");
            System.Text.StringBuilder sbVals = new System.Text.StringBuilder();
            bool isFirst = true;
            foreach (Net.Vpc.Upa.Expressions.VarVal varVal in fields) {
                if (isFirst) {
                    isFirst = false;
                } else {
                    sb.Append(", ");
                    sbVals.Append(", ");
                }
                sb.Append(varVal.GetVar());
                sbVals.Append(varVal.GetVal());
            }
            return sb.Append(") Values (").Append(sbVals).Append(")").ToString();
        }

        public virtual int CountFields() {
            return (fields).Count;
        }

        public virtual Net.Vpc.Upa.Expressions.Var GetField(int i) {
            return fields[i].GetVar();
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetFieldValue(int i) {
            return fields[i].GetVal();
        }


        public override bool IsValid() {
            return entity != null && (fields).Count > 0;
        }


        public override string GetEntityAlias() {
            return null;
        }
    }
}
