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

    public abstract class BinaryOperatorExpression : Net.Vpc.Upa.Expressions.DefaultExpression {



        protected internal Net.Vpc.Upa.Expressions.Expression left;

        protected internal Net.Vpc.Upa.Expressions.Expression right;

        protected internal Net.Vpc.Upa.Expressions.BinaryOperator @operator;

        public BinaryOperatorExpression(Net.Vpc.Upa.Expressions.BinaryOperator @operator, Net.Vpc.Upa.Expressions.Expression left, object right)  : this(@operator, left, Net.Vpc.Upa.Expressions.ExpressionFactory.ToLiteral(right)){

        }

        public BinaryOperatorExpression(Net.Vpc.Upa.Expressions.BinaryOperator @operator, Net.Vpc.Upa.Expressions.Expression left, Net.Vpc.Upa.Expressions.Expression right) {
            this.left = left;
            this.right = right;
            this.@operator = @operator;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetLeft() {
            return left;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetRight() {
            return right;
        }


        public override bool IsValid() {
            return (left == null || left.IsValid()) && (right == null || right.IsValid());
        }

        public virtual Net.Vpc.Upa.Expressions.BinaryOperator GetOperator() {
            return @operator;
        }

        private string GetOperatorString() {
            switch(GetOperator()) {
                case Net.Vpc.Upa.Expressions.BinaryOperator.AND:
                    {
                        return "And";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.OR:
                    {
                        return "Or";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.BIT_AND:
                    {
                        return "&";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.LSHIFT:
                    {
                        return "<<";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.BIT_OR:
                    {
                        return "|";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.RSHIFT:
                    {
                        return ">>";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.URSHIFT:
                    {
                        return ">>>";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.XOR:
                    {
                        return "^";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.DIFF:
                    {
                        return "!=";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.EQ:
                    {
                        return "=";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.GT:
                    {
                        return ">";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.GE:
                    {
                        return ">=";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.LT:
                    {
                        return "<";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.LE:
                    {
                        return "<=";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.PLUS:
                    {
                        return "+";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.MINUS:
                    {
                        return "-";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.MUL:
                    {
                        return "*";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.DIV:
                    {
                        return "/";
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.LIKE:
                    {
                        return "Like";
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

        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.BinaryOperatorExpression o = Create(GetOperator(), GetLeft().Copy(), GetRight().Copy());
            return o;
        }

        public static Net.Vpc.Upa.Expressions.BinaryOperatorExpression Create(Net.Vpc.Upa.Expressions.BinaryOperator @operator, Net.Vpc.Upa.Expressions.Expression left, Net.Vpc.Upa.Expressions.Expression right) {
            switch(@operator) {
                case Net.Vpc.Upa.Expressions.BinaryOperator.AND:
                    {
                        return new Net.Vpc.Upa.Expressions.And(left, right);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.OR:
                    {
                        return new Net.Vpc.Upa.Expressions.Or(left, right);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.BIT_AND:
                    {
                        return new Net.Vpc.Upa.Expressions.BitAnd(left, right);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.BIT_OR:
                    {
                        return new Net.Vpc.Upa.Expressions.BitOr(left, right);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.LSHIFT:
                    {
                        return new Net.Vpc.Upa.Expressions.LShift(left, right);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.RSHIFT:
                    {
                        return new Net.Vpc.Upa.Expressions.RShift(left, right);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.URSHIFT:
                    {
                        return new Net.Vpc.Upa.Expressions.URShift(left, right);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.XOR:
                    {
                        return new Net.Vpc.Upa.Expressions.XOr(left, right);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.DIFF:
                    {
                        return new Net.Vpc.Upa.Expressions.Different(left, right);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.EQ:
                    {
                        return new Net.Vpc.Upa.Expressions.Equals(left, right);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.GT:
                    {
                        return new Net.Vpc.Upa.Expressions.GreaterThan(left, right);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.GE:
                    {
                        return new Net.Vpc.Upa.Expressions.GreaterEqualThan(left, right);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.LT:
                    {
                        return new Net.Vpc.Upa.Expressions.LessThan(left, right);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.LE:
                    {
                        return new Net.Vpc.Upa.Expressions.LessEqualThan(left, right);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.PLUS:
                    {
                        return new Net.Vpc.Upa.Expressions.Plus(left, right);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.MINUS:
                    {
                        return new Net.Vpc.Upa.Expressions.Minus(left, right);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.MUL:
                    {
                        return new Net.Vpc.Upa.Expressions.Mul(left, right);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.DIV:
                    {
                        return new Net.Vpc.Upa.Expressions.Div(left, right);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.LIKE:
                    {
                        return new Net.Vpc.Upa.Expressions.Like(left, right);
                    }
                default:
                    {
                        throw new System.ArgumentException ("Not Supported Yet");
                    }
            }
        }
    }
}
