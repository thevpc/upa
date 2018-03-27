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
    internal class UnaryOperatorExpressionEvaluator : Net.Vpc.Upa.QLTypeEvaluator {

        public static readonly Net.Vpc.Upa.QLTypeEvaluator INSTANCE = new Net.Vpc.Upa.Impl.Eval.UnaryOperatorExpressionEvaluator();

        public UnaryOperatorExpressionEvaluator() {
        }


        public virtual Net.Vpc.Upa.Expressions.Expression EvalObject(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.QLEvaluator evaluator, object context) {
            Net.Vpc.Upa.Expressions.UnaryOperatorExpression eq = (Net.Vpc.Upa.Expressions.UnaryOperatorExpression) e;
            Net.Vpc.Upa.Expressions.Expression expr = evaluator.EvalObject(eq.GetExpression(), context);
            object a = Net.Vpc.Upa.Impl.Util.UPAUtils.UnwrapLiteral(expr);
            if (a is Net.Vpc.Upa.Expressions.Expression) {
                return Net.Vpc.Upa.Impl.Uql.Util.UQLUtils.CreateUnaryExpr(eq.GetOperator(), expr);
            }
            switch(eq.GetOperator()) {
                case Net.Vpc.Upa.Expressions.UnaryOperator.POSITIVE:
                    {
                        return expr;
                    }
                case Net.Vpc.Upa.Expressions.UnaryOperator.NEGATIVE:
                    {
                        Net.Vpc.Upa.Impl.Util.XNumber na = Net.Vpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(a);
                        if (na == null) {
                            return Net.Vpc.Upa.Expressions.Literal.NULL;
                        }
                        return new Net.Vpc.Upa.Expressions.Literal(na.Negate().ToNumber(), null);
                    }
                case Net.Vpc.Upa.Expressions.UnaryOperator.COMPLEMENT:
                    {
                        Net.Vpc.Upa.Impl.Util.XNumber na = Net.Vpc.Upa.Impl.Util.UPAUtils.ToNumber(a);
                        if (na == null) {
                            return Net.Vpc.Upa.Expressions.Literal.NULL;
                        }
                        return new Net.Vpc.Upa.Expressions.Literal(na.Complement().ToNumber(), null);
                    }
                case Net.Vpc.Upa.Expressions.UnaryOperator.NOT:
                    {
                        if (a is bool?) {
                            return Net.Vpc.Upa.Expressions.Literal.ValueOf((!(((bool?) a)).Value).Value);
                        }
                        if (a is object) {
                            return Net.Vpc.Upa.Expressions.Literal.ValueOf(System.Convert.ToDouble(((object) a)) == 0);
                        }
                        if (a is string) {
                            return Net.Vpc.Upa.Expressions.Literal.ValueOf(!((string) a).Equals("true",System.StringComparison.InvariantCultureIgnoreCase));
                        }
                        return Net.Vpc.Upa.Expressions.Literal.ValueOf(a == null);
                    }
            }
            throw new System.ArgumentException ("Not supported");
        }
    }
}
