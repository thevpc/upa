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



namespace Net.Vpc.Upa.Impl.Uql.Expression
{


    public class KeyExpression : Net.Vpc.Upa.Expressions.DefaultExpression {



        private object key;

        private string entityName;

        private string alias;

        private Net.Vpc.Upa.Entity entity;

        public KeyExpression(Net.Vpc.Upa.Entity entity, object key, string alias) {
            if (key == null) {
                throw new System.ArgumentException ("Key could not be null");
            }
            //        entity.getIdType().cast(key);
            this.key = key;
            entityName = entity.GetName();
            this.alias = alias;
            this.entity = entity;
        }

        public virtual object GetKey() {
            return key;
        }

        public virtual Net.Vpc.Upa.Entity GetEntity() {
            return entity;
        }

        public virtual string GetAlias() {
            return alias;
        }

        public virtual string GetEntityName() {
            return entityName;
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Impl.Uql.Expression.KeyExpression o = new Net.Vpc.Upa.Impl.Uql.Expression.KeyExpression(entity, key, alias);
            return o;
        }


        public override string ToString() {
            return "Key(" + entityName + "," + alias + "," + key + ")";
        }
    }
}
