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


    public abstract class BinaryOperatorExpression : Net.TheVpc.Upa.Expressions.OperatorExpression {

        private static readonly Net.TheVpc.Upa.Expressions.DefaultTag LEFT = new Net.TheVpc.Upa.Expressions.DefaultTag("Left");

        private static readonly Net.TheVpc.Upa.Expressions.DefaultTag RIGHT = new Net.TheVpc.Upa.Expressions.DefaultTag("Right");



        protected internal Net.TheVpc.Upa.Expressions.Expression left;

        protected internal Net.TheVpc.Upa.Expressions.Expression right;

        protected internal Net.TheVpc.Upa.Expressions.BinaryOperator @operator;

        public BinaryOperatorExpression(Net.TheVpc.Upa.Expressions.BinaryOperator @operator, Net.TheVpc.Upa.Expressions.Expression left, object right)  : this(@operator, left, Net.TheVpc.Upa.Expressions.ExpressionFactory.ToLiteral(right)){

        }

        public BinaryOperatorExpression(Net.TheVpc.Upa.Expressions.BinaryOperator @operator, Net.TheVpc.Upa.Expressions.Expression left, Net.TheVpc.Upa.Expressions.Expression right) {
            this.left = left;
            this.right = right;
            this.@operator = @operator;
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetLeft() {
            return left;
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetRight() {
            return right;
        }


        public override System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> GetChildren() {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> list = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.TaggedExpression>(2);
            if (left != null) {
                list.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(left, LEFT));
            }
            if (right != null) {
                list.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(right, RIGHT));
            }
            return list;
        }


        public override void SetChild(Net.TheVpc.Upa.Expressions.Expression e, Net.TheVpc.Upa.Expressions.ExpressionTag tag) {
            if (tag.Equals(LEFT)) {
                this.left = e;
            } else if (tag.Equals(RIGHT)) {
                this.right = e;
            } else {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("Insuppoerted");
            }
        }


        public override bool IsValid() {
            return (left == null || left.IsValid()) && (right == null || right.IsValid());
        }

        public virtual Net.TheVpc.Upa.Expressions.BinaryOperator GetOperator() {
            return @operator;
        }

        private string GetOperatorString() {
            switch(GetOperator()) {
                case Net.TheVpc.Upa.Expressions.BinaryOperator.AND:
                    {
                        return "And";
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.OR:
                    {
                        return "Or";
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
                        return "Like";
                    }
                default:
                    {
                        throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("Not Supported Yet");
                    }
            }
        }


        public override string ToString() {
            string leftValue = "(" + System.Convert.ToString(GetLeft()) + ")";
            string rightValue = "(" + System.Convert.ToString(GetRight()) + ")";
            string s = leftValue + " " + GetOperatorString() + " " + rightValue;
            return s;
        }

        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            Net.TheVpc.Upa.Expressions.BinaryOperatorExpression o = Create(GetOperator(), GetLeft().Copy(), GetRight().Copy());
            return o;
        }

        public static Net.TheVpc.Upa.Expressions.BinaryOperatorExpression Create(Net.TheVpc.Upa.Expressions.BinaryOperator @operator, Net.TheVpc.Upa.Expressions.Expression left, Net.TheVpc.Upa.Expressions.Expression right) {
            switch(@operator) {
                case Net.TheVpc.Upa.Expressions.BinaryOperator.AND:
                    {
                        return new Net.TheVpc.Upa.Expressions.And(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.OR:
                    {
                        return new Net.TheVpc.Upa.Expressions.Or(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.BIT_AND:
                    {
                        return new Net.TheVpc.Upa.Expressions.BitAnd(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.BIT_OR:
                    {
                        return new Net.TheVpc.Upa.Expressions.BitOr(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.LSHIFT:
                    {
                        return new Net.TheVpc.Upa.Expressions.LShift(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.RSHIFT:
                    {
                        return new Net.TheVpc.Upa.Expressions.RShift(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.URSHIFT:
                    {
                        return new Net.TheVpc.Upa.Expressions.URShift(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.XOR:
                    {
                        return new Net.TheVpc.Upa.Expressions.XOr(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.DIFF:
                    {
                        return new Net.TheVpc.Upa.Expressions.Different(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.EQ:
                    {
                        return new Net.TheVpc.Upa.Expressions.Equals(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.GT:
                    {
                        return new Net.TheVpc.Upa.Expressions.GreaterThan(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.GE:
                    {
                        return new Net.TheVpc.Upa.Expressions.GreaterEqualThan(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.LT:
                    {
                        return new Net.TheVpc.Upa.Expressions.LessThan(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.LE:
                    {
                        return new Net.TheVpc.Upa.Expressions.LessEqualThan(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.PLUS:
                    {
                        return new Net.TheVpc.Upa.Expressions.Plus(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.MINUS:
                    {
                        return new Net.TheVpc.Upa.Expressions.Minus(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.MUL:
                    {
                        return new Net.TheVpc.Upa.Expressions.Mul(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.DIV:
                    {
                        return new Net.TheVpc.Upa.Expressions.Div(left, right);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.LIKE:
                    {
                        return new Net.TheVpc.Upa.Expressions.Like(left, right);
                    }
                default:
                    {
                        throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("Not Supported Yet");
                    }
            }
        }
    }
}
