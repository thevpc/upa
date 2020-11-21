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



namespace Net.TheVpc.Upa.Expressions
{


    public class Delete : Net.TheVpc.Upa.Expressions.DefaultEntityStatement, Net.TheVpc.Upa.Expressions.NonQueryStatement {

        private static readonly Net.TheVpc.Upa.Expressions.DefaultTag ENTITY = new Net.TheVpc.Upa.Expressions.DefaultTag("ENTITY");

        private static readonly Net.TheVpc.Upa.Expressions.DefaultTag COND = new Net.TheVpc.Upa.Expressions.DefaultTag("COND");



        protected internal Net.TheVpc.Upa.Expressions.Expression condition;

        protected internal Net.TheVpc.Upa.Expressions.EntityName entity;

        protected internal string entityAlias;

        public Delete(Net.TheVpc.Upa.Expressions.Delete other)  : this(){

            AddQuery(other);
        }

        public Delete() {
            entity = null;
            entityAlias = null;
        }

        public virtual Net.TheVpc.Upa.Expressions.Delete From(string entity, string alias) {
            this.entity = new Net.TheVpc.Upa.Expressions.EntityName(entity);
            entityAlias = alias;
            return this;
        }


        public override System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> GetChildren() {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> all = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.TaggedExpression>(2);
            if (entity != null) {
                all.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(entity, ENTITY));
            }
            if (condition != null) {
                all.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(condition, COND));
            }
            return all;
        }


        public override void SetChild(Net.TheVpc.Upa.Expressions.Expression e, Net.TheVpc.Upa.Expressions.ExpressionTag tag) {
            if (ENTITY.Equals(tag)) {
                this.entity = (Net.TheVpc.Upa.Expressions.EntityName) e;
            } else if (COND.Equals(tag)) {
                this.condition = e;
            }
        }

        public virtual Net.TheVpc.Upa.Expressions.Delete From(string entity) {
            return From(entity, null);
        }

        public virtual Net.TheVpc.Upa.Expressions.EntityName GetEntity() {
            return entity;
        }

        public override string GetEntityName() {
            Net.TheVpc.Upa.Expressions.EntityName e = GetEntity();
            return (e != null) ? ((Net.TheVpc.Upa.Expressions.EntityName) e).GetName() : null;
        }

        public override string GetEntityAlias() {
            return entityAlias;
        }

        public virtual Net.TheVpc.Upa.Expressions.Delete Where(Net.TheVpc.Upa.Expressions.Expression condition) {
            this.condition = condition;
            return this;
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetCondition() {
            return condition;
        }

        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            Net.TheVpc.Upa.Expressions.Delete o = new Net.TheVpc.Upa.Expressions.Delete();
            o.AddQuery(this);
            return o;
        }


        public override string ToString() {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("Delete From " + entity);
            if (entityAlias != null) {
                sb.Append(" ").Append(Net.TheVpc.Upa.Expressions.ExpressionHelper.EscapeIdentifier(entityAlias));
            }
            if (condition != null && condition.IsValid()) {
                sb.Append(" Where ").Append(GetCondition().ToString());
            }
            return sb.ToString();
        }

        public virtual int Size() {
            return 3;
        }

        public virtual Net.TheVpc.Upa.Expressions.Delete AddQuery(Net.TheVpc.Upa.Expressions.Delete other) {
            if (other == null) {
                return this;
            }
            if (other.entity != null) {
                entity = (Net.TheVpc.Upa.Expressions.EntityName) other.entity.Copy();
            }
            if (other.entityAlias != null) {
                entityAlias = other.entityAlias;
            }
            other.condition = condition.Copy();
            return this;
        }
    }
}
