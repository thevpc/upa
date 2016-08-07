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


    public class InsertSelection : Net.Vpc.Upa.Expressions.DefaultEntityStatement, Net.Vpc.Upa.Expressions.NonQueryStatement {



        private static readonly Net.Vpc.Upa.Expressions.DefaultTag ENTITY = new Net.Vpc.Upa.Expressions.DefaultTag("ENTITY");

        private static readonly Net.Vpc.Upa.Expressions.DefaultTag SELECTION = new Net.Vpc.Upa.Expressions.DefaultTag("SELECTION");

        private Net.Vpc.Upa.Expressions.QueryStatement selection;

        private System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Var> fields;

        private Net.Vpc.Upa.Expressions.EntityName entity;

        private string alias;

        public InsertSelection() {
            selection = null;
            fields = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Var>(1);
        }


        public override System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> GetChildren() {
            System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> list = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.TaggedExpression>();
            if (entity != null) {
                list.Add(new Net.Vpc.Upa.Expressions.TaggedExpression(entity, ENTITY));
            }
            for (int i = 0; i < (fields).Count; i++) {
                list.Add(new Net.Vpc.Upa.Expressions.TaggedExpression(fields[i], new Net.Vpc.Upa.Expressions.IndexedTag("FIELD", i)));
            }
            if (selection != null) {
                list.Add(new Net.Vpc.Upa.Expressions.TaggedExpression(selection, SELECTION));
            }
            return list;
        }


        public override void SetChild(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.Expressions.ExpressionTag tag) {
            if (ENTITY.Equals(tag)) {
                this.entity = (Net.Vpc.Upa.Expressions.EntityName) e;
            } else if (SELECTION.Equals(tag)) {
                this.selection = (Net.Vpc.Upa.Expressions.QueryStatement) e;
            } else {
                Net.Vpc.Upa.Expressions.IndexedTag ii = (Net.Vpc.Upa.Expressions.IndexedTag) tag;
                fields[ii.GetIndex()]=(Net.Vpc.Upa.Expressions.Var) e;
            }
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


        public override string GetEntityAlias() {
            return null;
        }
    }
}
