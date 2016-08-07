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


    public class Delete : Net.Vpc.Upa.Expressions.DefaultEntityStatement, Net.Vpc.Upa.Expressions.NonQueryStatement {

        private static readonly Net.Vpc.Upa.Expressions.DefaultTag ENTITY = new Net.Vpc.Upa.Expressions.DefaultTag("ENTITY");

        private static readonly Net.Vpc.Upa.Expressions.DefaultTag COND = new Net.Vpc.Upa.Expressions.DefaultTag("COND");



        protected internal Net.Vpc.Upa.Expressions.Expression condition;

        protected internal Net.Vpc.Upa.Expressions.EntityName entity;

        protected internal string entityAlias;

        public Delete(Net.Vpc.Upa.Expressions.Delete other)  : this(){

            AddQuery(other);
        }

        public Delete() {
            entity = null;
            entityAlias = null;
        }

        private Net.Vpc.Upa.Expressions.Delete From(string entity, string alias) {
            this.entity = new Net.Vpc.Upa.Expressions.EntityName(entity);
            entityAlias = alias;
            return this;
        }


        public override System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> GetChildren() {
            System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> all = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.TaggedExpression>();
            if (entity != null) {
                all.Add(new Net.Vpc.Upa.Expressions.TaggedExpression(entity, ENTITY));
            }
            if (condition != null) {
                all.Add(new Net.Vpc.Upa.Expressions.TaggedExpression(condition, COND));
            }
            return all;
        }


        public override void SetChild(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.Expressions.ExpressionTag tag) {
            if (ENTITY.Equals(tag)) {
                this.entity = (Net.Vpc.Upa.Expressions.EntityName) e;
            } else if (COND.Equals(tag)) {
                this.condition = e;
            }
        }

        public virtual Net.Vpc.Upa.Expressions.Delete From(string entity) {
            return From(entity, null);
        }

        public virtual Net.Vpc.Upa.Expressions.EntityName GetEntity() {
            return entity;
        }

        public override string GetEntityName() {
            Net.Vpc.Upa.Expressions.EntityName e = GetEntity();
            return (e != null) ? ((Net.Vpc.Upa.Expressions.EntityName) e).GetName() : null;
        }

        public override string GetEntityAlias() {
            return entityAlias == null ? entity.GetName() : entityAlias;
        }

        public virtual Net.Vpc.Upa.Expressions.Delete Where(Net.Vpc.Upa.Expressions.Expression condition) {
            this.condition = condition;
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetCondition() {
            return condition;
        }

        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.Delete o = new Net.Vpc.Upa.Expressions.Delete();
            o.AddQuery(this);
            return o;
        }


        public override string ToString() {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("Delete From " + entity);
            if (entityAlias != null) {
                sb.Append(" ").Append(Net.Vpc.Upa.Expressions.ExpressionHelper.EscapeIdentifier(entityAlias));
            }
            if (condition != null && condition.IsValid()) {
                sb.Append(" Where ").Append(GetCondition().ToString());
            }
            return sb.ToString();
        }

        public virtual int Size() {
            return 3;
        }

        public virtual Net.Vpc.Upa.Expressions.Delete AddQuery(Net.Vpc.Upa.Expressions.Delete other) {
            if (other == null) {
                return this;
            }
            if (other.entity != null) {
                entity = (Net.Vpc.Upa.Expressions.EntityName) other.entity.Copy();
            }
            if (other.entityAlias != null) {
                entityAlias = other.entityAlias;
            }
            other.condition = condition.Copy();
            return this;
        }
    }
}
