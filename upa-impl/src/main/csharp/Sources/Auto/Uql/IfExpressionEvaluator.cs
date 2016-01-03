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
    internal class IfExpressionEvaluator : Net.Vpc.Upa.QLTypeEvaluator {

        public IfExpressionEvaluator() {
        }


        public virtual object EvalObject(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.QLEvaluator evaluator, object context) {
            Net.Vpc.Upa.Expressions.If ife = (Net.Vpc.Upa.Expressions.If) e;
            int count = ife.GetArgumentsCount();
            int i = 0;
            while (i < count) {
                Net.Vpc.Upa.Expressions.Expression ee = ife.GetArgument(i);
                bool? exprVal = (bool?) evaluator.EvalObject(ee, context);
                if ((exprVal).Value) {
                    Net.Vpc.Upa.Expressions.Expression thenExpr = ife.GetArgument(i + 1);
                    return evaluator.EvalObject(thenExpr, context);
                } else {
                    if (i + 2 == count - 1) {
                        //the else
                        Net.Vpc.Upa.Expressions.Expression elseExpr = ife.GetArgument(i + 2);
                        return evaluator.EvalObject(elseExpr, context);
                    }
                    i += 2;
                }
            }
            return null;
        }
    }
}
