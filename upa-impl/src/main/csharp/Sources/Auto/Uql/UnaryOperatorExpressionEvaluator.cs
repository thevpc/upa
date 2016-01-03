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



namespace Net.Vpc.Upa.Impl.Uql
{


    /**
     *
     * @author vpc
     */
    internal class UnaryOperatorExpressionEvaluator : Net.Vpc.Upa.QLTypeEvaluator {

        private readonly Net.Vpc.Upa.Impl.Uql.DefaultQLEvaluator outer;

        public UnaryOperatorExpressionEvaluator(Net.Vpc.Upa.Impl.Uql.DefaultQLEvaluator outer) {
            this.outer = outer;
        }


        public virtual object EvalObject(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.QLEvaluator evaluator, object context) {
            Net.Vpc.Upa.Expressions.UnaryOperatorExpression eq = (Net.Vpc.Upa.Expressions.UnaryOperatorExpression) e;
            switch(eq.GetOperator()) {
                case Net.Vpc.Upa.Expressions.UnaryOperator.POSITIVE:
                    {
                        return evaluator.EvalObject(eq.GetExpression(), context);
                    }
                case Net.Vpc.Upa.Expressions.UnaryOperator.NEGATIVE:
                    {
                        object a = evaluator.EvalObject(eq.GetExpression(), context);
                        Net.Vpc.Upa.Impl.Util.XNumber na = outer.ToNumber(a);
                        return na.Negate().ToNumber();
                    }
                case Net.Vpc.Upa.Expressions.UnaryOperator.COMPLEMENT:
                    {
                        object a = evaluator.EvalObject(eq.GetExpression(), context);
                        Net.Vpc.Upa.Impl.Util.XNumber na = outer.ToNumber(a);
                        return na.Complement().ToNumber();
                    }
            }
            throw new System.ArgumentException ("Not supported");
        }
    }
}
