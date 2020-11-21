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


    public class CompiledInsertSelection : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledEntityStatement, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdateStatement {



        private Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement selection;

        private System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar> fields;

        private Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName entity;

        private string tableAlias;

        public CompiledInsertSelection() {
            selection = null;
            fields = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar>(1);
        }

        public CompiledInsertSelection(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInsertSelection other)  : this(){

            AddQuery(other);
        }

        private Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInsertSelection Into(string entity, string alias) {
            this.entity = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName(entity);
            tableAlias = alias;
            PrepareChildren(this.entity);
            ExportDeclaration(alias, Net.TheVpc.Upa.Impl.Uql.DecObjectType.ENTITY, entity, alias);
            return this;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInsertSelection Into(string entity) {
            return Into(entity, null);
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName GetEntity() {
            return entity;
        }

        public virtual string GetTableAlias() {
            return tableAlias;
        }

        public virtual int Size() {
            return 3;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInsertSelection AddQuery(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInsertSelection other) {
            if (other == null) {
                return this;
            }
            if (other.entity != null) {
                entity = other.entity;
                if (other.tableAlias != null) {
                    tableAlias = other.tableAlias;
                }
                PrepareChildren(this.entity);
                ExportDeclaration(tableAlias, Net.TheVpc.Upa.Impl.Uql.DecObjectType.ENTITY, other.entity.GetName(), null);
            }
            for (int i = 0; i < (other.fields).Count; i++) {
                Field(other.GetField(i).GetName());
            }
            if (other.selection != null) {
                selection = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement) other.selection.Copy();
            }
            return this;
        }

        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInsertSelection o = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInsertSelection();
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            o.AddQuery(this);
            return o;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInsertSelection Field(string key) {
            fields.Add(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(key));
            return this;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInsertSelection Field(string[] keys) {
            foreach (string key in keys) {
                Field(key);
            }
            return this;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInsertSelection From(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement selection) {
            this.selection = selection;
            return this;
        }

        public virtual int CountFields() {
            return (fields).Count;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar GetField(int i) {
            return fields[i];
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement GetSelection() {
            return selection;
        }


        public override bool IsValid() {
            return entity != null && (fields).Count > 0 && selection.IsValid();
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions() {
            System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression> all = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression>();
            if (entity != null) {
                all.Add(entity);
            }
            /**
                     * this will not work because in C# all and fields have different types
                     */
            //all.addAll(fields);
            foreach (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar field in fields) {
                all.Add(field);
            }
            all.Add(selection);
            return all.ToArray();
        }


        public override void SetSubExpression(int index, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            if (index == 0) {
                entity = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) expression;
            } else if (index - 1 < (fields).Count) {
                fields[index - 1]=(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) expression;
            } else {
                selection = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect) expression;
            }
        }

        protected internal override System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression> FindEntityDefinitions() {
            System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression> list = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression>();
            list.Add(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression(null, GetEntity()));
            return list;
        }
    }
}
