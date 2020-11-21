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


    public class JoinCriteria : System.ICloneable {

        private Net.TheVpc.Upa.Expressions.JoinType type;

        private Net.TheVpc.Upa.Expressions.NameOrQuery entity;

        private string alias;

        private Net.TheVpc.Upa.Expressions.Expression condition;

        public virtual Net.TheVpc.Upa.Expressions.JoinType GetJoinType() {
            return type;
        }

        public virtual string GetEntityName() {
            if (entity is Net.TheVpc.Upa.Expressions.EntityName) {
                return ((Net.TheVpc.Upa.Expressions.EntityName) entity).GetName();
            }
            return null;
        }

        public virtual Net.TheVpc.Upa.Expressions.NameOrQuery GetEntity() {
            return entity;
        }

        public virtual void SetEntity(Net.TheVpc.Upa.Expressions.NameOrQuery entity) {
            this.entity = entity;
        }

        public virtual void SetCondition(Net.TheVpc.Upa.Expressions.Expression condition) {
            this.condition = condition;
        }

        public virtual string GetEntityAlias() {
            return alias;
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetCondition() {
            return condition;
        }

        public JoinCriteria(Net.TheVpc.Upa.Expressions.JoinType type, Net.TheVpc.Upa.Expressions.NameOrQuery entity, string alias, Net.TheVpc.Upa.Expressions.Expression condition) {
            this.type = type;
            this.entity = entity;
            this.alias = alias;
            this.condition = condition;
            if (type.Equals(Net.TheVpc.Upa.Expressions.JoinType.CROSS_JOIN)) {
                this.condition = null;
            }
        }


        public override string ToString() {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            string valueString = System.Convert.ToString(entity);
            string aliasString = GetEntityAlias();
            string joinKey = "Inner Join";
            switch(GetJoinType()) {
                case Net.TheVpc.Upa.Expressions.JoinType.INNER_JOIN:
                    joinKey = "Inner Join";
                    break;
                case Net.TheVpc.Upa.Expressions.JoinType.FULL_JOIN:
                    joinKey = "Full Join";
                    break;
                case Net.TheVpc.Upa.Expressions.JoinType.LEFT_JOIN:
                    joinKey = "Left Join";
                    break;
                case Net.TheVpc.Upa.Expressions.JoinType.RIGHT_JOIN:
                    joinKey = "Right Join";
                    break;
                case Net.TheVpc.Upa.Expressions.JoinType.CROSS_JOIN:
                    joinKey = "Cross Join";
                    break;
            }
            sb.Append(" ").Append(joinKey).Append(" ").Append(valueString);
            if (aliasString != null && !valueString.Equals(aliasString)) {
                sb.Append(" ").Append(aliasString);
            }
            if (condition != null && condition.IsValid()) {
                sb.Append(" On ").Append(condition);
            }
            return sb.ToString();
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        virtual public object Clone() { return base.MemberwiseClone();}
    }
}
