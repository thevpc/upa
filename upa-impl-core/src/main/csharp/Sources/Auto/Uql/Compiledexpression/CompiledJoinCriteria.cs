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


    public class CompiledJoinCriteria : Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpressionImpl {

        private Net.Vpc.Upa.Expressions.JoinType joinType;

        private Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect entity;

        private string alias;

        private Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition;

        public CompiledJoinCriteria(Net.Vpc.Upa.Expressions.JoinType joinType, Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect entity, string alias, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            this.joinType = joinType;
            this.entity = entity;
            this.alias = alias;
            SetCondition(joinType.Equals(Net.Vpc.Upa.Expressions.JoinType.CROSS_JOIN) ? null : condition);
        }

        public virtual Net.Vpc.Upa.Expressions.JoinType GetJoinType() {
            return joinType;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect GetEntity() {
            return entity;
        }

        public virtual string GetEntityName() {
            if (entity != null && entity is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName s = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) entity;
                return s.GetName();
            }
            return null;
        }

        public virtual string GetEntityAlias() {
            return alias;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetCondition() {
            return condition;
        }

        public virtual void AddCondition(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression condition) {
            if (condition != null) {
                if (this.condition == null) {
                    SetCondition(condition);
                } else {
                    this.condition.UnsetParent();
                    SetCondition(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledAnd(this.condition, condition));
                }
            }
        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions() {
            System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression> all = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression>();
            all.Add(entity);
            if (condition != null) {
                all.Add(condition);
            }
            return all.ToArray();
        }

        public virtual void SetEntity(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect expression) {
            if (this.entity != null) {
                this.entity.UnsetParent();
            }
            this.entity = expression;
            PrepareChildren(expression);
        }

        public void SetCondition(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            if (this.condition != null) {
                this.condition.UnsetParent();
            }
            this.condition = expression;
            PrepareChildren(expression);
        }


        public override void SetSubExpression(int index, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            switch(index) {
                case 0:
                    {
                        SetEntity((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect) expression);
                        return;
                    }
                case 1:
                    {
                        SetCondition(expression);
                        return;
                    }
            }
            throw new System.ArgumentException ("Invalid index");
        }

        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            return new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria(joinType, (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNameOrSelect) (entity == null ? null : entity.Copy()), alias, condition == null ? null : condition.Copy());
        }


        public override string ToString() {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            string valueString = System.Convert.ToString(entity);
            string aliasString = GetEntityAlias();
            string joinKey = "INNER JOIN";
            switch(GetJoinType()) {
                case Net.Vpc.Upa.Expressions.JoinType.INNER_JOIN:
                    joinKey = "INNER JOIN";
                    break;
                case Net.Vpc.Upa.Expressions.JoinType.FULL_JOIN:
                    joinKey = "FULL JOIN";
                    break;
                case Net.Vpc.Upa.Expressions.JoinType.LEFT_JOIN:
                    joinKey = "LEFT JOIN";
                    break;
                case Net.Vpc.Upa.Expressions.JoinType.RIGHT_JOIN:
                    joinKey = "RIGHT JOIN";
                    break;
                case Net.Vpc.Upa.Expressions.JoinType.CROSS_JOIN:
                    joinKey = "CROSS JOIN";
                    break;
            }
            sb.Append(" ").Append(joinKey).Append(" ").Append(valueString);
            if (aliasString != null && !valueString.Equals(aliasString)) {
                sb.Append(" ").Append(aliasString);
            }
            if (condition != null && condition.IsValid()) {
                sb.Append(" ON ").Append(condition);
            }
            return sb.ToString();
        }
    }
}
