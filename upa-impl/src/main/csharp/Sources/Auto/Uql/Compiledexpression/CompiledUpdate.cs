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


    public sealed class CompiledUpdate : Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledEntityStatement, Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdateStatement {



        private System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal> fields;

        private Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition;

        private Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName entityName;

        private string entityAlias;

        public CompiledUpdate() {
            fields = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal>();
        }

        public System.Collections.Generic.IDictionary<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar , Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression> GetUpdatesMapping() {
            System.Collections.Generic.IDictionary<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar , Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression> m = new System.Collections.Generic.Dictionary<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar , Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression>();
            foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal f in fields) {
                m[f.GetVar()]=f.GetVal();
            }
            return m;
        }

        public CompiledUpdate(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdate other)  : this(){

            AddQuery(other);
        }

        private Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdate Entity(string entity, string alias) {
            this.entityName = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName(entity);
            entityAlias = alias;
            PrepareChildren(this.entityName);
            ExportDeclaration(entityAlias, Net.Vpc.Upa.Impl.Uql.DecObjectType.ENTITY, ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) this.entityName).GetName(), null);
            return this;
        }

        public Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdate Entity(string entity) {
            return Entity(entity, null);
        }

        public Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName GetEntity() {
            return entityName;
        }

        public string GetEntityAlias() {
            return entityAlias == null ? entityName.GetName() : entityAlias;
        }

        public int Size() {
            return 3;
        }

        public Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdate AddQuery(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdate other) {
            if (other == null) {
                return this;
            }
            if (other.entityName != null) {
                this.Entity(((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) other.entityName).GetName(), other.entityAlias);
            }
            for (int i = 0; i < (other.fields).Count; i++) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar fvar = other.GetField(i);
                Net.Vpc.Upa.Field field = (Net.Vpc.Upa.Field) fvar.GetReferrer();
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression fieldValue = other.GetFieldValue(i);
                Set(field, fieldValue == null ? null : fieldValue.Copy());
            }
            if (other.condition != null) {
                if (condition == null) {
                    Where(other.condition.Copy());
                } else {
                    Where(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledAnd(condition, other.condition.Copy()));
                }
            }
            return this;
        }

        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdate o = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdate();
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            o.AddQuery(this);
            //        o.extraFrom = extraFrom;
            return o;
        }

        public Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdate Set(Net.Vpc.Upa.Field key, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression @value) {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal varVal = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(key), @value);
            fields.Add(varVal);
            PrepareChildren(varVal);
            return this;
        }

        public Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdate Where(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            this.condition = condition;
            PrepareChildren(condition);
            return this;
        }

        public Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetCondition() {
            return condition;
        }

        public int CountFields() {
            return (fields).Count;
        }

        public Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar GetField(int i) {
            return fields[i].GetVar();
        }

        public Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetFieldValue(int i) {
            return fields[i].GetVal();
        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions() {
            System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression> all = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression>();
            if (entityName != null) {
                all.Add(entityName);
            }
            foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal varVal in fields) {
                all.Add(varVal);
            }
            all.Add(condition);
            return all.ToArray();
        }


        public override void SetSubExpression(int index, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            if (index == 0) {
                entityName = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) expression;
                PrepareChildren(expression);
            } else if (index <= (fields).Count) {
                fields[index - 1]=(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal) expression;
                PrepareChildren(expression);
            } else {
                condition = expression;
                PrepareChildren(expression);
            }
        }

        public System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar> GetFields() {
            System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar> all = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar>((fields).Count);
            foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal field in fields) {
                all.Add(field.GetVar());
            }
            return all;
        }

        protected internal override System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression> FindEntityDefinitions() {
            System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression> list = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression>();
            list.Add(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression(GetEntityAlias(), GetEntity()));
            return list;
        }
    }
}
