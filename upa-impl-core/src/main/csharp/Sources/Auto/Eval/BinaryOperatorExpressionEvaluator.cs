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



namespace Net.TheVpc.Upa.Impl.Eval
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    internal class BinaryOperatorExpressionEvaluator : Net.TheVpc.Upa.QLTypeEvaluator {

        public static readonly Net.TheVpc.Upa.QLTypeEvaluator INSTANCE = new Net.TheVpc.Upa.Impl.Eval.BinaryOperatorExpressionEvaluator();

        public BinaryOperatorExpressionEvaluator() {
        }


        public virtual Net.TheVpc.Upa.Expressions.Expression EvalObject(Net.TheVpc.Upa.Expressions.Expression e, Net.TheVpc.Upa.QLEvaluator evaluator, object context) {
            Net.TheVpc.Upa.Expressions.BinaryOperatorExpression eq = (Net.TheVpc.Upa.Expressions.BinaryOperatorExpression) e;
            Net.TheVpc.Upa.Expressions.Expression a0 = evaluator.EvalObject(eq.GetLeft(), context);
            Net.TheVpc.Upa.Expressions.Expression b0 = evaluator.EvalObject(eq.GetRight(), context);
            object a = Net.TheVpc.Upa.Impl.Util.UPAUtils.UnwrapLiteral(a0);
            object b = Net.TheVpc.Upa.Impl.Util.UPAUtils.UnwrapLiteral(b0);
            if ((a is Net.TheVpc.Upa.Expressions.Expression) || (b is Net.TheVpc.Upa.Expressions.Expression)) {
                //could not simplify
                //            if(!(a instanceof Expression)){
                //                a=new Literal(a,null);
                //            }
                //            if(!(b instanceof Expression)){
                //                b=new Literal(a,null);
                //            }
                return Net.TheVpc.Upa.Impl.Uql.Util.UQLUtils.CreateBinaryExpr(eq.GetOperator(), a0, b0);
            }
            switch(eq.GetOperator()) {
                case Net.TheVpc.Upa.Expressions.BinaryOperator.AND:
                    {
                        if ((!(((bool?) a)).Value).Value) {
                            return Net.TheVpc.Upa.Expressions.Literal.FALSE;
                        }
                        return ((bool?) b) ? Net.TheVpc.Upa.Expressions.Literal.TRUE : Net.TheVpc.Upa.Expressions.Literal.FALSE;
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.OR:
                    {
                        if ((((bool?) a)).Value) {
                            return Net.TheVpc.Upa.Expressions.Literal.TRUE;
                        }
                        return ((bool?) b) ? Net.TheVpc.Upa.Expressions.Literal.TRUE : Net.TheVpc.Upa.Expressions.Literal.FALSE;
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.EQ:
                    {
                        return (Net.TheVpc.Upa.Impl.Util.UPAUtils.Equals(a, b) || Net.TheVpc.Upa.Impl.Util.UPAUtils.Equals(a == null ? "" : a.ToString(), b == null ? "" : b.ToString())) ? Net.TheVpc.Upa.Expressions.Literal.TRUE : Net.TheVpc.Upa.Expressions.Literal.FALSE;
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.DIFF:
                    {
                        return (!Net.TheVpc.Upa.Impl.Util.UPAUtils.Equals(a, b) && !Net.TheVpc.Upa.Impl.Util.UPAUtils.Equals(a == null ? "" : a.ToString(), b == null ? "" : b.ToString())) ? Net.TheVpc.Upa.Expressions.Literal.TRUE : Net.TheVpc.Upa.Expressions.Literal.FALSE;
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.GE:
                    {
                        Net.TheVpc.Upa.Impl.Util.XNumber na = Net.TheVpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(a);
                        Net.TheVpc.Upa.Impl.Util.XNumber nb = Net.TheVpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(b);
                        return (Net.TheVpc.Upa.Impl.Util.XNumber.Compare(na, nb) >= 0) ? Net.TheVpc.Upa.Expressions.Literal.TRUE : Net.TheVpc.Upa.Expressions.Literal.FALSE;
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.GT:
                    {
                        Net.TheVpc.Upa.Impl.Util.XNumber na = Net.TheVpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(a);
                        Net.TheVpc.Upa.Impl.Util.XNumber nb = Net.TheVpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(b);
                        return (Net.TheVpc.Upa.Impl.Util.XNumber.Compare(na, nb) > 0) ? Net.TheVpc.Upa.Expressions.Literal.TRUE : Net.TheVpc.Upa.Expressions.Literal.FALSE;
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.LE:
                    {
                        Net.TheVpc.Upa.Impl.Util.XNumber na = Net.TheVpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(a);
                        Net.TheVpc.Upa.Impl.Util.XNumber nb = Net.TheVpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(b);
                        return (Net.TheVpc.Upa.Impl.Util.XNumber.Compare(na, nb) <= 0) ? Net.TheVpc.Upa.Expressions.Literal.TRUE : Net.TheVpc.Upa.Expressions.Literal.FALSE;
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.LT:
                    {
                        Net.TheVpc.Upa.Impl.Util.XNumber na = Net.TheVpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(a);
                        Net.TheVpc.Upa.Impl.Util.XNumber nb = Net.TheVpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(b);
                        return (Net.TheVpc.Upa.Impl.Util.XNumber.Compare(na, nb) < 0) ? Net.TheVpc.Upa.Expressions.Literal.TRUE : Net.TheVpc.Upa.Expressions.Literal.FALSE;
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.PLUS:
                    {
                        if (a is string || b is string) {
                            return new Net.TheVpc.Upa.Expressions.Literal(FormatResult(a) + FormatResult(b));
                        }
                        Net.TheVpc.Upa.Impl.Util.XNumber na = Net.TheVpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(a);
                        Net.TheVpc.Upa.Impl.Util.XNumber nb = Net.TheVpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(b);
                        if (na == null) {
                            return new Net.TheVpc.Upa.Expressions.Literal(nb, null);
                        }
                        if (nb == null) {
                            return new Net.TheVpc.Upa.Expressions.Literal(na, null);
                        }
                        return new Net.TheVpc.Upa.Expressions.Literal(na.Add(nb).ToNumber(), null);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.MINUS:
                    {
                        Net.TheVpc.Upa.Impl.Util.XNumber na = Net.TheVpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(a);
                        Net.TheVpc.Upa.Impl.Util.XNumber nb = Net.TheVpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(b);
                        if (na == null) {
                            return new Net.TheVpc.Upa.Expressions.Literal(nb.Negate(), null);
                        }
                        if (nb == null) {
                            return new Net.TheVpc.Upa.Expressions.Literal(na, null);
                        }
                        return new Net.TheVpc.Upa.Expressions.Literal(na.Subtract(nb).ToNumber(), null);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.DIV:
                    {
                        Net.TheVpc.Upa.Impl.Util.XNumber na = Net.TheVpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(a);
                        Net.TheVpc.Upa.Impl.Util.XNumber nb = Net.TheVpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(b);
                        if (na == null) {
                            return Net.TheVpc.Upa.Expressions.Literal.ZERO;
                        }
                        if (nb == null) {
                            return new Net.TheVpc.Upa.Expressions.Literal(System.Double.NaN);
                        }
                        return new Net.TheVpc.Upa.Expressions.Literal(na.Divide(nb).ToNumber(), null);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.MUL:
                    {
                        Net.TheVpc.Upa.Impl.Util.XNumber na = Net.TheVpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(a);
                        Net.TheVpc.Upa.Impl.Util.XNumber nb = Net.TheVpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(b);
                        if (na == null) {
                            return Net.TheVpc.Upa.Expressions.Literal.ZERO;
                        }
                        if (nb == null) {
                            return Net.TheVpc.Upa.Expressions.Literal.ZERO;
                        }
                        return new Net.TheVpc.Upa.Expressions.Literal(na.Multiply(nb).ToNumber(), null);
                    }
                case Net.TheVpc.Upa.Expressions.BinaryOperator.LIKE:
                    {
                        if (a == null) {
                            a = "";
                        }
                        if (b == null) {
                            b = "";
                        }
                        a = FormatResult(a);
                        b = FormatResult(b);
                        string val = (string) a;
                        string pattern = ((string) b).Replace('%', '*');
                        return Net.TheVpc.Upa.Impl.Util.StringUtils.MatchesSimpleExpression(val, pattern, Net.TheVpc.Upa.Impl.Util.PatternType.ANY) ? Net.TheVpc.Upa.Expressions.Literal.TRUE : Net.TheVpc.Upa.Expressions.Literal.FALSE;
                    }
            }
            //TODO other binary operators
            throw new System.ArgumentException ("Not supported");
        }

        public virtual string FormatResult(object result) {
            return result == null ? "" : result.ToString();
        }
    }
}
