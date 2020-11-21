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
    internal class UnaryOperatorExpressionEvaluator : Net.TheVpc.Upa.QLTypeEvaluator {

        public static readonly Net.TheVpc.Upa.QLTypeEvaluator INSTANCE = new Net.TheVpc.Upa.Impl.Eval.UnaryOperatorExpressionEvaluator();

        public UnaryOperatorExpressionEvaluator() {
        }


        public virtual Net.TheVpc.Upa.Expressions.Expression EvalObject(Net.TheVpc.Upa.Expressions.Expression e, Net.TheVpc.Upa.QLEvaluator evaluator, object context) {
            Net.TheVpc.Upa.Expressions.UnaryOperatorExpression eq = (Net.TheVpc.Upa.Expressions.UnaryOperatorExpression) e;
            Net.TheVpc.Upa.Expressions.Expression expr = evaluator.EvalObject(eq.GetExpression(), context);
            object a = Net.TheVpc.Upa.Impl.Util.UPAUtils.UnwrapLiteral(expr);
            if (a is Net.TheVpc.Upa.Expressions.Expression) {
                return Net.TheVpc.Upa.Impl.Uql.Util.UQLUtils.CreateUnaryExpr(eq.GetOperator(), expr);
            }
            switch(eq.GetOperator()) {
                case Net.TheVpc.Upa.Expressions.UnaryOperator.POSITIVE:
                    {
                        return expr;
                    }
                case Net.TheVpc.Upa.Expressions.UnaryOperator.NEGATIVE:
                    {
                        Net.TheVpc.Upa.Impl.Util.XNumber na = Net.TheVpc.Upa.Impl.Util.UPAUtils.ToNumberOrError(a);
                        if (na == null) {
                            return Net.TheVpc.Upa.Expressions.Literal.NULL;
                        }
                        return new Net.TheVpc.Upa.Expressions.Literal(na.Negate().ToNumber(), null);
                    }
                case Net.TheVpc.Upa.Expressions.UnaryOperator.COMPLEMENT:
                    {
                        Net.TheVpc.Upa.Impl.Util.XNumber na = Net.TheVpc.Upa.Impl.Util.UPAUtils.ToNumber(a);
                        if (na == null) {
                            return Net.TheVpc.Upa.Expressions.Literal.NULL;
                        }
                        return new Net.TheVpc.Upa.Expressions.Literal(na.Complement().ToNumber(), null);
                    }
                case Net.TheVpc.Upa.Expressions.UnaryOperator.NOT:
                    {
                        if (a is bool?) {
                            return Net.TheVpc.Upa.Expressions.Literal.ValueOf((!(((bool?) a)).Value).Value);
                        }
                        if (a is object) {
                            return Net.TheVpc.Upa.Expressions.Literal.ValueOf(System.Convert.ToDouble(((object) a)) == 0);
                        }
                        if (a is string) {
                            return Net.TheVpc.Upa.Expressions.Literal.ValueOf(!((string) a).Equals("true",System.StringComparison.InvariantCultureIgnoreCase));
                        }
                        return Net.TheVpc.Upa.Expressions.Literal.ValueOf(a == null);
                    }
            }
            throw new System.ArgumentException ("Not supported");
        }
    }
}
