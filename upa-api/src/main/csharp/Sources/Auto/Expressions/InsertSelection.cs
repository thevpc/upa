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



namespace Net.Vpc.Upa.Expressions
{


    public class InsertSelection : Net.Vpc.Upa.Expressions.DefaultEntityStatement, Net.Vpc.Upa.Expressions.UpdateStatement {



        private Net.Vpc.Upa.Expressions.QueryStatement selection;

        private System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Var> fields;

        private Net.Vpc.Upa.Expressions.EntityName entity;

        private string alias;

        public InsertSelection() {
            selection = null;
            fields = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Var>(1);
        }

        public InsertSelection(Net.Vpc.Upa.Expressions.InsertSelection other)  : this(){

            AddQuery(other);
        }

        private Net.Vpc.Upa.Expressions.InsertSelection Into(string entity, string alias) {
            this.entity = new Net.Vpc.Upa.Expressions.EntityName(entity);
            this.alias = alias;
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.InsertSelection Into(string entity) {
            return Into(entity, null);
        }

        public override string GetEntityName() {
            Net.Vpc.Upa.Expressions.EntityName e = GetEntity();
            return (e != null) ? ((Net.Vpc.Upa.Expressions.EntityName) e).GetName() : null;
        }

        public virtual Net.Vpc.Upa.Expressions.EntityName GetEntity() {
            return entity;
        }

        public virtual string GetAlias() {
            return alias;
        }

        public virtual int Size() {
            return 3;
        }

        public virtual Net.Vpc.Upa.Expressions.InsertSelection AddQuery(Net.Vpc.Upa.Expressions.InsertSelection other) {
            if (other == null) {
                return this;
            }
            if (other.entity != null) {
                entity = other.entity;
            }
            if (other.alias != null) {
                alias = other.alias;
            }
            for (int i = 0; i < (other.fields).Count; i++) {
                Field(other.GetField(i).GetName());
            }
            if (other.selection != null) {
                selection = (Net.Vpc.Upa.Expressions.QueryStatement) other.selection.Copy();
            }
            return this;
        }

        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.InsertSelection o = new Net.Vpc.Upa.Expressions.InsertSelection();
            o.AddQuery(this);
            return o;
        }

        public virtual Net.Vpc.Upa.Expressions.InsertSelection Field(string key) {
            fields.Add(new Net.Vpc.Upa.Expressions.Var(key));
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.InsertSelection Field(string[] keys) {
            foreach (string key in keys) {
                Field(key);
            }
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.InsertSelection From(Net.Vpc.Upa.Expressions.QueryStatement selection) {
            this.selection = selection;
            return this;
        }

        public virtual int CountFields() {
            return (fields).Count;
        }

        public virtual Net.Vpc.Upa.Expressions.Var GetField(int i) {
            return fields[i];
        }

        public virtual Net.Vpc.Upa.Expressions.QueryStatement GetSelection() {
            return selection;
        }


        public override bool IsValid() {
            return entity != null && (fields).Count > 0 && selection.IsValid();
        }
    }
}
