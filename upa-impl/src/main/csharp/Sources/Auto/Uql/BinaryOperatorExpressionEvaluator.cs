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
    internal class BinaryOperatorExpressionEvaluator : Net.Vpc.Upa.QLTypeEvaluator {

        private readonly Net.Vpc.Upa.Impl.Uql.DefaultQLEvaluator outer;

        public BinaryOperatorExpressionEvaluator(Net.Vpc.Upa.Impl.Uql.DefaultQLEvaluator outer) {
            this.outer = outer;
        }


        public virtual object EvalObject(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.QLEvaluator evaluator, object context) {
            Net.Vpc.Upa.Expressions.BinaryOperatorExpression eq = (Net.Vpc.Upa.Expressions.BinaryOperatorExpression) e;
            switch(eq.GetOperator()) {
                case Net.Vpc.Upa.Expressions.BinaryOperator.AND:
                    {
                        object a = evaluator.EvalObject(eq.GetLeft(), context);
                        if ((!((bool?) a)).Value) {
                            return false;
                        }
                        object b = evaluator.EvalObject(eq.GetRight(), context);
                        return (bool?) b;
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.OR:
                    {
                        object a = evaluator.EvalObject(eq.GetLeft(), context);
                        if (((bool?) a).Value) {
                            return true;
                        }
                        object b = evaluator.EvalObject(eq.GetRight(), context);
                        return ((bool?) a) || ((bool?) b);
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.EQ:
                    {
                        object a = evaluator.EvalObject(eq.GetLeft(), context);
                        object b = evaluator.EvalObject(eq.GetRight(), context);
                        return Net.Vpc.Upa.Impl.Util.UPAUtils.Equals(a, b) || Net.Vpc.Upa.Impl.Util.UPAUtils.Equals(a == null ? "" : a.ToString(), b == null ? "" : b.ToString());
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.DIFF:
                    {
                        object a = evaluator.EvalObject(eq.GetLeft(), context);
                        object b = evaluator.EvalObject(eq.GetRight(), context);
                        return !Net.Vpc.Upa.Impl.Util.UPAUtils.Equals(a, b) && !Net.Vpc.Upa.Impl.Util.UPAUtils.Equals(a == null ? "" : a.ToString(), b == null ? "" : b.ToString());
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.GE:
                    {
                        object a = evaluator.EvalObject(eq.GetLeft(), context);
                        object b = evaluator.EvalObject(eq.GetRight(), context);
                        Net.Vpc.Upa.Impl.Util.XNumber na = outer.ToNumber(a);
                        Net.Vpc.Upa.Impl.Util.XNumber nb = outer.ToNumber(b);
                        return na.ComparetTo(nb) >= 0;
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.GT:
                    {
                        object a = evaluator.EvalObject(eq.GetLeft(), context);
                        object b = evaluator.EvalObject(eq.GetRight(), context);
                        Net.Vpc.Upa.Impl.Util.XNumber na = outer.ToNumber(a);
                        Net.Vpc.Upa.Impl.Util.XNumber nb = outer.ToNumber(b);
                        return na.ComparetTo(nb) > 0;
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.LE:
                    {
                        object a = evaluator.EvalObject(eq.GetLeft(), context);
                        object b = evaluator.EvalObject(eq.GetRight(), context);
                        Net.Vpc.Upa.Impl.Util.XNumber na = outer.ToNumber(a);
                        Net.Vpc.Upa.Impl.Util.XNumber nb = outer.ToNumber(b);
                        return na.ComparetTo(nb) <= 0;
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.LT:
                    {
                        object a = evaluator.EvalObject(eq.GetLeft(), context);
                        object b = evaluator.EvalObject(eq.GetRight(), context);
                        Net.Vpc.Upa.Impl.Util.XNumber na = outer.ToNumber(a);
                        Net.Vpc.Upa.Impl.Util.XNumber nb = outer.ToNumber(b);
                        return na.ComparetTo(nb) < 0;
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.PLUS:
                    {
                        object a = evaluator.EvalObject(eq.GetLeft(), context);
                        object b = evaluator.EvalObject(eq.GetRight(), context);
                        if (a is string || b is string) {
                            return outer.FormatResult(a) + outer.FormatResult(b);
                        }
                        Net.Vpc.Upa.Impl.Util.XNumber na = outer.ToNumber(a);
                        Net.Vpc.Upa.Impl.Util.XNumber nb = outer.ToNumber(b);
                        return na.Add(nb).ToNumber();
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.MINUS:
                    {
                        object a = evaluator.EvalObject(eq.GetLeft(), context);
                        object b = evaluator.EvalObject(eq.GetRight(), context);
                        Net.Vpc.Upa.Impl.Util.XNumber na = outer.ToNumber(a);
                        Net.Vpc.Upa.Impl.Util.XNumber nb = outer.ToNumber(b);
                        return na.Subtract(nb).ToNumber();
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.DIV:
                    {
                        object a = evaluator.EvalObject(eq.GetLeft(), context);
                        object b = evaluator.EvalObject(eq.GetRight(), context);
                        Net.Vpc.Upa.Impl.Util.XNumber na = outer.ToNumber(a);
                        Net.Vpc.Upa.Impl.Util.XNumber nb = outer.ToNumber(b);
                        return na.Divide(nb).ToNumber();
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.MUL:
                    {
                        object a = evaluator.EvalObject(eq.GetLeft(), context);
                        object b = evaluator.EvalObject(eq.GetRight(), context);
                        Net.Vpc.Upa.Impl.Util.XNumber na = outer.ToNumber(a);
                        Net.Vpc.Upa.Impl.Util.XNumber nb = outer.ToNumber(b);
                        return na.Multiply(nb).ToNumber();
                    }
                case Net.Vpc.Upa.Expressions.BinaryOperator.LIKE:
                    {
                        object a = evaluator.EvalObject(eq.GetLeft(), context);
                        object b = evaluator.EvalObject(eq.GetRight(), context);
                        return Net.Vpc.Upa.Impl.Util.Strings.MatchesSimpleExpression((string) a, (string) b);
                    }
            }
            throw new System.ArgumentException ("Not supported");
        }
    }
}
