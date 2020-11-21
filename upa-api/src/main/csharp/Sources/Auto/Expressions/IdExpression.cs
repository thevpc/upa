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


    public class IdExpression : Net.TheVpc.Upa.Expressions.DefaultExpression {



        private object id;

        private string entityName;

        private string alias;

        private Net.TheVpc.Upa.Entity entity;

        public IdExpression(Net.TheVpc.Upa.Entity entity, object id, string alias) {
            if (id == null) {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("Id could not be null");
            }
            //        entity.getIdType().cast(key);
            this.id = id;
            this.entityName = entity.GetName();
            this.alias = alias;
            this.entity = entity;
        }

        public virtual void SetId(object id) {
            this.id = id;
        }

        public virtual void SetEntityName(string entityName) {
            this.entityName = entityName;
        }

        public virtual void SetAlias(string alias) {
            this.alias = alias;
        }

        public virtual void SetEntity(Net.TheVpc.Upa.Entity entity) {
            this.entity = entity;
        }


        public override System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> GetChildren() {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> list = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.TaggedExpression>(1);
            return list;
        }


        public override void SetChild(Net.TheVpc.Upa.Expressions.Expression e, Net.TheVpc.Upa.Expressions.ExpressionTag tag) {
            throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("Insupported");
        }

        public virtual object GetId() {
            return id;
        }

        public virtual Net.TheVpc.Upa.Entity GetEntity() {
            return entity;
        }

        public virtual string GetAlias() {
            return alias;
        }

        public virtual string GetEntityName() {
            return entityName;
        }


        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            Net.TheVpc.Upa.Expressions.IdExpression o = new Net.TheVpc.Upa.Expressions.IdExpression(entity, id, alias);
            return o;
        }


        public override string ToString() {
            return "Key(" + entityName + "," + alias + "," + id + ")";
        }


        public override int GetHashCode() {
            int hash = 7;
            hash = 97 * hash + (this.id != null ? this.id.GetHashCode() : 0);
            hash = 97 * hash + (this.entityName != null ? this.entityName.GetHashCode() : 0);
            hash = 97 * hash + (this.alias != null ? this.alias.GetHashCode() : 0);
            hash = 97 * hash + (this.entity != null ? this.entity.GetHashCode() : 0);
            return hash;
        }


        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (GetType() != obj.GetType()) {
                return false;
            }
            Net.TheVpc.Upa.Expressions.IdExpression other = (Net.TheVpc.Upa.Expressions.IdExpression) obj;
            if (this.id != other.id && (this.id == null || !this.id.Equals(other.id))) {
                return false;
            }
            if ((this.entityName == null) ? (other.entityName != null) : !this.entityName.Equals(other.entityName)) {
                return false;
            }
            if ((this.alias == null) ? (other.alias != null) : !this.alias.Equals(other.alias)) {
                return false;
            }
            if (this.entity != other.entity && (this.entity == null || !this.entity.Equals(other.entity))) {
                return false;
            }
            return true;
        }
    }
}
