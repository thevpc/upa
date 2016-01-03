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


    public class CompiledDelete : Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledEntityStatement, Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdateStatement {



        protected internal Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition;

        protected internal Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName entity;

        protected internal string entityAlias;

        public CompiledDelete(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledDelete other)  : this(){

            AddQuery(other);
        }

        public CompiledDelete() {
            entity = null;
            entityAlias = null;
        }

        private Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledDelete From(string entityName, string alias) {
            this.entity = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName(entityName);
            entityAlias = alias;
            ExportDeclaration(alias, Net.Vpc.Upa.Impl.Uql.DecObjectType.ENTITY, entityName, null);
            PrepareChildren(entity);
            return this;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledDelete From(string table) {
            return From(table, null);
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName GetEntity() {
            return entity;
        }

        public virtual string GetEntityAlias() {
            return entityAlias;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledDelete Where(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            this.condition = condition;
            PrepareChildren(condition);
            return this;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetCondition() {
            return condition;
        }

        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledDelete o = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledDelete();
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            o.AddQuery(this);
            return o;
        }

        public virtual int Size() {
            return 3;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledDelete AddQuery(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledDelete other) {
            if (other == null) {
                return this;
            }
            if (other.entity != null) {
                From(other.entity.GetName(), other.entityAlias);
            }
            if (other.condition != null) {
                if (condition == null) {
                    Where(condition.Copy());
                } else {
                    Where(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledAnd(condition, other.condition.Copy()));
                }
            }
            return this;
        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions() {
            System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression> all = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression>();
            if (entity != null) {
                all.Add(entity);
            }
            if (condition != null) {
                all.Add(condition);
            }
            return all.ToArray();
        }


        public override void SetSubExpression(int index, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            int i = 0;
            if (entity != null) {
                if (i == index) {
                    entity = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) expression;
                }
                i++;
            }
            if (condition != null) {
                if (i == index) {
                    condition = expression;
                }
                i++;
            }
        }

        protected internal override System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression> FindEntityDefinitions() {
            System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression> list = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression>();
            list.Add(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression(GetEntityAlias() == null ? GetEntity().GetName() : GetEntityAlias(), GetEntity()));
            return list;
        }
    }
}
