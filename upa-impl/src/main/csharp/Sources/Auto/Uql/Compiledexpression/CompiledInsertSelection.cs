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


    public class CompiledInsertSelection : Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledEntityStatement, Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdateStatement {



        private Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement selection;

        private System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar> fields;

        private Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName entity;

        private string tableAlias;

        public CompiledInsertSelection() {
            selection = null;
            fields = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar>(1);
        }

        public CompiledInsertSelection(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledInsertSelection other)  : this(){

            AddQuery(other);
        }

        private Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledInsertSelection Into(string entity, string alias) {
            this.entity = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName(entity);
            tableAlias = alias;
            PrepareChildren(this.entity);
            ExportDeclaration(alias, Net.Vpc.Upa.Impl.Uql.DecObjectType.ENTITY, entity, alias);
            return this;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledInsertSelection Into(string entity) {
            return Into(entity, null);
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName GetEntity() {
            return entity;
        }

        public virtual string GetTableAlias() {
            return tableAlias;
        }

        public virtual int Size() {
            return 3;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledInsertSelection AddQuery(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledInsertSelection other) {
            if (other == null) {
                return this;
            }
            if (other.entity != null) {
                entity = other.entity;
                if (other.tableAlias != null) {
                    tableAlias = other.tableAlias;
                }
                PrepareChildren(this.entity);
                ExportDeclaration(tableAlias, Net.Vpc.Upa.Impl.Uql.DecObjectType.ENTITY, other.entity.GetName(), null);
            }
            for (int i = 0; i < (other.fields).Count; i++) {
                Field(other.GetField(i).GetName());
            }
            if (other.selection != null) {
                selection = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement) other.selection.Copy();
            }
            return this;
        }

        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledInsertSelection o = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledInsertSelection();
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            o.AddQuery(this);
            return o;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledInsertSelection Field(string key) {
            fields.Add(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(key));
            return this;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledInsertSelection Field(string[] keys) {
            foreach (string key in keys) {
                Field(key);
            }
            return this;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledInsertSelection From(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement selection) {
            this.selection = selection;
            return this;
        }

        public virtual int CountFields() {
            return (fields).Count;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar GetField(int i) {
            return fields[i];
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement GetSelection() {
            return selection;
        }


        public override bool IsValid() {
            return entity != null && (fields).Count > 0 && selection.IsValid();
        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions() {
            System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression> all = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression>();
            if (entity != null) {
                all.Add(entity);
            }
            /**
                     * this will not work because in C# all and fields have different types
                     */
            //all.addAll(fields);
            foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar field in fields) {
                all.Add(field);
            }
            all.Add(selection);
            return all.ToArray();
        }


        public override void SetSubExpression(int index, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            if (index == 0) {
                entity = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) expression;
            } else if (index - 1 < (fields).Count) {
                fields[index - 1]=(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) expression;
            } else {
                selection = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect) expression;
            }
        }

        protected internal override System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression> FindEntityDefinitions() {
            System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression> list = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression>();
            list.Add(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression(null, GetEntity()));
            return list;
        }
    }
}
