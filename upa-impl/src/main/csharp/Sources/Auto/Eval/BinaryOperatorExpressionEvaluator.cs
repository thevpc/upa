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



namespace Net.Vpc.Upa.Impl.Eval
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    internal class BinaryOperatorExpressionEvaluator : Net.Vpc.Upa.QLTypeEvaluator {

        public static readonly Net.Vpc.Upa.QLTypeEvaluator INSTANCE = new Net.Vpc.Upa.Impl.Eval.BinaryOperatorExpressionEvaluator();

        public BinaryOperatorExpressionEvaluator() {
        }


        public virtual Net.Vpc.Upa.Expressions.Expression EvalObject(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.QLEvaluator evaluator, object context) {
            Net.Vpc.Upa.Expressions.BinaryOperatorExpression eq = (Net.Vpc.Upa.Expressions.BinaryOperatorExpression) e;
            Net.Vpc.Upa.Expressions.Expression a0 = evaluator.EvalObject(eq.GetLeft(), context);
            Net.Vpc.Upa.Expressions.Expression b0 = evaluator.EvalObject(eq.GetRight(), context);
            object a = Net.Vpc.Upa.Impl.Util.UPAUtils.UnwrapLiteral(a0);
            object b = Net.Vpc.Upa.Impl.Util.UPAUtils.UnwrapLiteral(b0);
            if ((a is Net.Vpc.Upa.Expressions.Expression) || (b is Net.Vpc.Upa.Expressions.Expression)) {
                //could not simplify
                //            if(!(a instanceof Expression)){
                //                a=new Literal(a,null);
                //            }
                //            if(!(b instanceof Expression)){
                //                b=new Literal(a,null);
                //            }
                return Net.Vpc.Upa.Impl.Uql.Util.UQLUtils.CreateBinaryExpr(eq.GetOperator(), a0, b0);
            }
            switch(eq.GetOperator()) {
                case Net.Vpc.Upa.Expressions.BinaryOperator.AND:
                    {
                        if ((!(((bool?) a)).Value).Value) {
                            return Net.Vpc.Upa.Expressions.Literal.FALSE;
                        }
                        return ((bool?) b) ? Net.Vpc.Upa.Expressions.Literal.TRUE : Net.Vpc.Upa.Expressions.Literal.FALSE;
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.OR:
                    {
                        if ((((bool?) a)).Value) {
                            return Net.Vpc.Upa.Expressions.Literal.TRUE;
                        }
                        return ((bool?) b) ? Net.Vpc.Upa.Expressions.Literal.TRUE : Net.Vpc.Upa.Expressions.Literal.FALSE;
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.EQ:
                    {
                        return (Net.Vpc.Upa.Impl.Util.UPAUtils.Equals(a, b) || Net.Vpc.Upa.Impl.Util.UPAUtils.Equals(a == null ? "" : a.ToString(), b == null ? "" : b.ToString())) ? Net.Vpc.Upa.Expressions.Literal.TRUE : Net.Vpc.Upa.Expressions.Literal.FALSE;
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.DIFF:
                    {
                        return (!Net.Vpc.Upa.Impl.Util.UPAUtils.Equals(a, b) && !Net.Vpc.Upa.Impl.Util.UPAUtils.Equals(a == null ? "" : a.ToString(), b == null ? "" : b.ToString())) ? Net.Vpc.Upa.Expressions.Literal.TRUE : Net.Vpc.Upa.Expressions.Literal.FALSE;
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.GE:
                    {
                        Net.Vpc.Upa.Impl.Util.XNumber na = Net.Vpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(a);
                        Net.Vpc.Upa.Impl.Util.XNumber nb = Net.Vpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(b);
                        return (Net.Vpc.Upa.Impl.Util.XNumber.Compare(na, nb) >= 0) ? Net.Vpc.Upa.Expressions.Literal.TRUE : Net.Vpc.Upa.Expressions.Literal.FALSE;
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.GT:
                    {
                        Net.Vpc.Upa.Impl.Util.XNumber na = Net.Vpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(a);
                        Net.Vpc.Upa.Impl.Util.XNumber nb = Net.Vpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(b);
                        return (Net.Vpc.Upa.Impl.Util.XNumber.Compare(na, nb) > 0) ? Net.Vpc.Upa.Expressions.Literal.TRUE : Net.Vpc.Upa.Expressions.Literal.FALSE;
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.LE:
                    {
                        Net.Vpc.Upa.Impl.Util.XNumber na = Net.Vpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(a);
                        Net.Vpc.Upa.Impl.Util.XNumber nb = Net.Vpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(b);
                        return (Net.Vpc.Upa.Impl.Util.XNumber.Compare(na, nb) <= 0) ? Net.Vpc.Upa.Expressions.Literal.TRUE : Net.Vpc.Upa.Expressions.Literal.FALSE;
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.LT:
                    {
                        Net.Vpc.Upa.Impl.Util.XNumber na = Net.Vpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(a);
                        Net.Vpc.Upa.Impl.Util.XNumber nb = Net.Vpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(b);
                        return (Net.Vpc.Upa.Impl.Util.XNumber.Compare(na, nb) < 0) ? Net.Vpc.Upa.Expressions.Literal.TRUE : Net.Vpc.Upa.Expressions.Literal.FALSE;
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.PLUS:
                    {
                        if (a is string || b is string) {
                            return new Net.Vpc.Upa.Expressions.Literal(FormatResult(a) + FormatResult(b));
                        }
                        Net.Vpc.Upa.Impl.Util.XNumber na = Net.Vpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(a);
                        Net.Vpc.Upa.Impl.Util.XNumber nb = Net.Vpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(b);
                        if (na == null) {
                            return new Net.Vpc.Upa.Expressions.Literal(nb, null);
                        }
                        if (nb == null) {
                            return new Net.Vpc.Upa.Expressions.Literal(na, null);
                        }
                        return new Net.Vpc.Upa.Expressions.Literal(na.Add(nb).ToNumber(), null);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.MINUS:
                    {
                        Net.Vpc.Upa.Impl.Util.XNumber na = Net.Vpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(a);
                        Net.Vpc.Upa.Impl.Util.XNumber nb = Net.Vpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(b);
                        if (na == null) {
                            return new Net.Vpc.Upa.Expressions.Literal(nb.Negate(), null);
                        }
                        if (nb == null) {
                            return new Net.Vpc.Upa.Expressions.Literal(na, null);
                        }
                        return new Net.Vpc.Upa.Expressions.Literal(na.Subtract(nb).ToNumber(), null);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.DIV:
                    {
                        Net.Vpc.Upa.Impl.Util.XNumber na = Net.Vpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(a);
                        Net.Vpc.Upa.Impl.Util.XNumber nb = Net.Vpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(b);
                        if (na == null) {
                            return Net.Vpc.Upa.Expressions.Literal.ZERO;
                        }
                        if (nb == null) {
                            return new Net.Vpc.Upa.Expressions.Literal(System.Double.NaN);
                        }
                        return new Net.Vpc.Upa.Expressions.Literal(na.Divide(nb).ToNumber(), null);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.MUL:
                    {
                        Net.Vpc.Upa.Impl.Util.XNumber na = Net.Vpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(a);
                        Net.Vpc.Upa.Impl.Util.XNumber nb = Net.Vpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(b);
                        if (na == null) {
                            return Net.Vpc.Upa.Expressions.Literal.ZERO;
                        }
                        if (nb == null) {
                            return Net.Vpc.Upa.Expressions.Literal.ZERO;
                        }
                        return new Net.Vpc.Upa.Expressions.Literal(na.Multiply(nb).ToNumber(), null);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.LIKE:
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
                        return Net.Vpc.Upa.Impl.Util.StringUtils.MatchesSimpleExpression(val, pattern, Net.Vpc.Upa.Impl.Util.PatternType.ANY) ? Net.Vpc.Upa.Expressions.Literal.TRUE : Net.Vpc.Upa.Expressions.Literal.FALSE;
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
