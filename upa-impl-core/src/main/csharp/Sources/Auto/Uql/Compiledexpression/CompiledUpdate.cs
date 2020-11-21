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


    public sealed class CompiledUpdate : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledEntityStatement, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdateStatement {



        private System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal> fields;

        private Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition;

        private Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName entityName;

        private string entityAlias;

        public CompiledUpdate() {
            fields = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal>();
        }

        public System.Collections.Generic.IDictionary<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar , Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression> GetUpdatesMapping() {
            System.Collections.Generic.IDictionary<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar , Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression> m = new System.Collections.Generic.Dictionary<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar , Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression>();
            foreach (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal f in fields) {
                m[f.GetVar()]=f.GetVal();
            }
            return m;
        }

        public CompiledUpdate(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdate other)  : this(){

            AddQuery(other);
        }

        private Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdate Entity(string entity, string alias) {
            this.entityName = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName(entity);
            entityAlias = alias;
            PrepareChildren(this.entityName);
            ExportDeclaration(entityAlias, Net.TheVpc.Upa.Impl.Uql.DecObjectType.ENTITY, ((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) this.entityName).GetName(), null);
            return this;
        }

        public Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdate Entity(string entity) {
            return Entity(entity, null);
        }

        public Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName GetEntity() {
            return entityName;
        }

        public string GetEntityAlias() {
            return entityAlias == null ? entityName.GetName() : entityAlias;
        }

        public int Size() {
            return 3;
        }

        public Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdate AddQuery(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdate other) {
            if (other == null) {
                return this;
            }
            if (other.entityName != null) {
                this.Entity(((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) other.entityName).GetName(), other.entityAlias);
            }
            for (int i = 0; i < (other.fields).Count; i++) {
                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar fvar = other.GetField(i);
                Net.TheVpc.Upa.Field field = (Net.TheVpc.Upa.Field) fvar.GetReferrer();
                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression fieldValue = other.GetFieldValue(i);
                Set(field, fieldValue == null ? null : fieldValue.Copy());
            }
            if (other.condition != null) {
                if (condition == null) {
                    Where(other.condition.Copy());
                } else {
                    Where(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledAnd(condition, other.condition.Copy()));
                }
            }
            return this;
        }

        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdate o = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdate();
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            o.AddQuery(this);
            //        o.extraFrom = extraFrom;
            return o;
        }

        public Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdate Set(Net.TheVpc.Upa.Field key, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression @value) {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal varVal = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(key), @value);
            fields.Add(varVal);
            PrepareChildren(varVal);
            return this;
        }

        public Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdate Where(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            this.condition = condition;
            PrepareChildren(condition);
            return this;
        }

        public Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetCondition() {
            return condition;
        }

        public int CountFields() {
            return (fields).Count;
        }

        public Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar GetField(int i) {
            return fields[i].GetVar();
        }

        public Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetFieldValue(int i) {
            return fields[i].GetVal();
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions() {
            System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression> all = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression>();
            if (entityName != null) {
                all.Add(entityName);
            }
            foreach (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal varVal in fields) {
                all.Add(varVal);
            }
            all.Add(condition);
            return all.ToArray();
        }


        public override void SetSubExpression(int index, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            if (index == 0) {
                entityName = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) expression;
                PrepareChildren(expression);
            } else if (index <= (fields).Count) {
                fields[index - 1]=(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal) expression;
                PrepareChildren(expression);
            } else {
                condition = expression;
                PrepareChildren(expression);
            }
        }

        public System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar> GetFields() {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar> all = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar>((fields).Count);
            foreach (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal field in fields) {
                all.Add(field.GetVar());
            }
            return all;
        }

        protected internal override System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression> FindEntityDefinitions() {
            System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression> list = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression>();
            list.Add(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression(GetEntityAlias(), GetEntity()));
            return list;
        }
    }
}
