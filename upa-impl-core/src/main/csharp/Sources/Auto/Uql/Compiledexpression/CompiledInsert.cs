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


    public class CompiledInsert : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledEntityStatement, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdateStatement {



        private System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal> fields;

        private Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName entity;

        public CompiledInsert() {
            fields = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal>();
        }

        public CompiledInsert(string tabName, string[] fields, object[] values)  : this(){

            Into(tabName);
            for (int i = 0; i < fields.Length; i++) {
                Set(fields[i], values[i]);
            }
        }

        public CompiledInsert(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInsert other)  : this(){

            AddQuery(other);
        }

        private Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInsert Into(string entity, string alias) {
            this.entity = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName(entity);
            PrepareChildren(this.entity);
            ExportDeclaration(alias, Net.TheVpc.Upa.Impl.Uql.DecObjectType.ENTITY, entity, alias);
            return this;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInsert Into(string entity) {
            return Into(entity, null);
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName GetEntity() {
            return entity;
        }

        public virtual int Size() {
            return 3;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInsert AddQuery(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInsert other) {
            if (other == null) {
                return this;
            }
            if (other.entity != null) {
                entity = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) other.entity.Copy();
                ExportDeclaration(null, Net.TheVpc.Upa.Impl.Uql.DecObjectType.ENTITY, entity.GetName(), null);
                PrepareChildren(entity);
            }
            for (int i = 0; i < (other.fields).Count; i++) {
                Set(other.GetField(i).GetName(), other.GetFieldValue(i).Copy());
            }
            return this;
        }

        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInsert o = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInsert();
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            o.AddQuery(this);
            return o;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInsert Set(string key, object @value) {
            if (@value != null && (@value is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression)) {
                return Set(key, (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) @value);
            } else {
                return Set(key, ((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) (new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral(@value, null))));
            }
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInsert Set(string key, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression @value) {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar fName = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(key);
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal varVal = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal(fName, @value);
            fields.Add(varVal);
            PrepareChildren(varVal);
            return this;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInsert Set(int index, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression @value) {
            if (index < (fields).Count) {
                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal varVal = fields[index];
                varVal.SetSubExpression(1, @value);
            } else {
                Set(null, @value);
            }
            return this;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInsert Set(string[] keys, object[] values) {
            for (int i = 0; i < keys.Length; i++) {
                Set(keys[i], values[i]);
            }
            return this;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInsert Set(System.Collections.Generic.IDictionary<string , object> keysValues) {
            foreach (System.Collections.Generic.KeyValuePair<string , object> e in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,object>>(keysValues)) {
                Set((e).Key, (e).Value);
            }
            return this;
        }


        public override string ToString() {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("Insert Into ");
            if (GetEntity() != null) {
                sb.Append(" ").Append(GetEntity());
            }
            sb.Append("(");
            System.Text.StringBuilder sbVals = new System.Text.StringBuilder();
            bool isFirst = true;
            foreach (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal v in fields) {
                if (isFirst) {
                    isFirst = false;
                } else {
                    sb.Append(", ");
                    sbVals.Append(", ");
                }
                sb.Append(v.GetVar());
                sbVals.Append(v.GetVal());
            }
            return sb.Append(") Values (").Append(sbVals).Append(")").ToString();
        }

        public virtual int CountFields() {
            return (fields).Count;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar GetField(int i) {
            return fields[i].GetVar();
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetFieldValue(int i) {
            return fields[i].GetVal();
        }


        public override bool IsValid() {
            return entity != null && (fields).Count > 0;
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions() {
            System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression> all = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression>();
            if (entity != null) {
                all.Add(entity);
            }
            foreach (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal e in fields) {
                all.Add(e);
            }
            return all.ToArray();
        }


        public override void SetSubExpression(int index, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            if (index == 0) {
                entity = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) expression;
                PrepareChildren(expression);
            } else {
                fields[index - 1]=(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal) expression;
                PrepareChildren(expression);
            }
        }

        protected internal override System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression> FindEntityDefinitions() {
            System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression> list = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression>();
            list.Add(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression(null, GetEntity()));
            return list;
        }
    }
}
