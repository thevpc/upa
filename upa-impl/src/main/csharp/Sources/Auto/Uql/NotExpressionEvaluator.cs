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
    internal class NotExpressionEvaluator : Net.Vpc.Upa.QLTypeEvaluator {

        public NotExpressionEvaluator() {
        }


        public virtual object EvalObject(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.QLEvaluator evaluator, object context) {
            Net.Vpc.Upa.Expressions.Not v = (Net.Vpc.Upa.Expressions.Not) e;
            Net.Vpc.Upa.Expressions.Expression ee = v.GetNegatedExpression();
            object o = evaluator.EvalObject(ee, context);
            if (o == null) {
                return false;
            }
            if (o is bool?) {
                return !((bool?) o);
            }
            if (o is object) {
                return System.Convert.ToDouble(((object) o)) == 0;
            }
            if (o is string) {
                return !System.Convert.ToBoolean((string) o);
            }
            return false;
        }
    }
}
