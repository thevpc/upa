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



namespace Net.TheVpc.Upa.Impl.Uql.Compiledexpression
{


    public abstract class CompiledBinaryOperatorExpression : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpressionImpl {



        protected internal Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left;

        protected internal Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression right;

        protected internal Net.TheVpc.Upa.Expressions.BinaryOperator @operator;

        public CompiledBinaryOperatorExpression(Net.TheVpc.Upa.Expressions.BinaryOperator @operator, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left, object right)  : this(@operator, left, Net.TheVpc.Upa.Impl.Uql.CompiledExpressionFactory.ToLiteral(right)){

        }

        public CompiledBinaryOperatorExpression(Net.TheVpc.Upa.Expressions.BinaryOperator @operator, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression right) {
            this.left = left;
            this.right = right;
            Net.TheVpc.Upa.Types.DataTypeTransform leftType = null;
            Net.TheVpc.Upa.Types.DataTypeTransform rightType = null;
            if (left != null && left.GetTypeTransform() != null && !left.GetTypeTransform().GetSourceType().GetPlatformType().Equals(typeof(object))) {
                leftType = left.GetTypeTransform();
            }
            if (right != null && right.GetTypeTransform() != null && !right.GetTypeTransform().GetSourceType().GetPlatformType().Equals(typeof(object))) {
                rightType = right.GetTypeTransform();
            }
            if (leftType == null && rightType != null) {
                left.SetTypeTransform(rightType);
            } else if (rightType == null && leftType != null) {
                right.SetTypeTransform(leftType);
            }
            this.@operator = @operator;
            PrepareChildren(left, right);
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetLeft() {
            return left;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetRight() {
            return right;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetOther(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression r) {
            if (r == left) {
                return right;
            }
            if (r == right) {
                return left;
            }
            throw new System.ArgumentException ("Not a child");
        }


        public override bool IsValid() {
            return (GetLeft() == null || GetLeft().IsValid()) && (GetRight() == null || GetRight().IsValid());
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions() {
            return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] { left, right };
        }


        public override void SetSubExpression(int index, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            switch(index) {
                case 0:
                    {
                        if (left != expression) {
                            left = expression;
                            PrepareChildren(left);
                        }
                        break;
                    }
                case 1:
                    {
                        if (right != expression) {
                            right = expression;
                            PrepareChildren(right);
                        }
                        break;
                    }
                default:
                    {
                        throw new System.ArgumentException ();
                    }
            }
        }

        public virtual Net.TheVpc.Upa.Expressions.BinaryOperator GetOperator() {
            return @operator;
        }

        private string GetOperatorString() {
            switch(GetOperator()) {
                case Net.TheVpc.Upa.Expressions.BinaryOperator.AND:
                    {
                        return "AND";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.OR:
                    {
                        return "OR";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.BIT_AND:
                    {
                        return "&";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.LSHIFT:
                    {
                        return "<<";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.BIT_OR:
                    {
                        return "|";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.RSHIFT:
                    {
                        return ">>";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.URSHIFT:
                    {
                        return ">>>";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.XOR:
                    {
                        return "^";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.DIFF:
                    {
                        return "!=";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.EQ:
                    {
                        return "=";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.GT:
                    {
                        return ">";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.GE:
                    {
                        return ">=";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.LT:
                    {
                        return "<";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.LE:
                    {
                        return "<=";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.PLUS:
                    {
                        return "+";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.MINUS:
                    {
                        return "-";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.MUL:
                    {
                        return "*";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.DIV:
                    {
                        return "/";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.LIKE:
                    {
                        return " LIKE ";
                    }
                default:
                    {
                        throw new System.ArgumentException ("Not Supported Yet");
                    }
            }
        }


        public override string ToString() {
            string leftValue = "(" + System.Convert.ToString(GetLeft()) + ")";
            string rightValue = "(" + System.Convert.ToString(GetRight()) + ")";
            string s = leftValue + " " + GetOperatorString() + " " + rightValue;
            return s;
        }

        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledBinaryOperatorExpression o = Create(GetOperator(), GetLeft().Copy(), GetRight().Copy());
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }

        public static Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledBinaryOperatorExpression Create(Net.TheVpc.Upa.Expressions.BinaryOperator @operator, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression right) {
            switch(@operator) {
                case Net.TheVpc.Upa.Expressions.BinaryOperator.AND:
                    {
                        return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledAnd(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.OR:
                    {
                        return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledOr(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.BIT_AND:
                    {
                        return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledBitAnd(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.BIT_OR:
                    {
                        return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledBitOr(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.LSHIFT:
                    {
                        return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLShift(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.RSHIFT:
                    {
                        return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledRShift(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.URSHIFT:
                    {
                        return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledURShift(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.XOR:
                    {
                        return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledXOr(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.DIFF:
                    {
                        return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledDifferent(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.EQ:
                    {
                        return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEquals(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.GT:
                    {
                        return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledGreaterThan(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.GE:
                    {
                        return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledGreaterEqualThan(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.LT:
                    {
                        return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLessThan(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.LE:
                    {
                        return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLessEqualThan(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.PLUS:
                    {
                        return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledPlus(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.MINUS:
                    {
                        return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledMinus(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.MUL:
                    {
                        return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledMul(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.DIV:
                    {
                        return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledDiv(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.LIKE:
                    {
                        return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLike(left, right);
                    }
                default:
                    {
                        throw new System.ArgumentException ("Not Supported Yet");
                    }
            }
        }

        public virtual bool IsSameOperandsType() {
            return true;
        }
    }
}
