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
    internal class LiteralExpressionEvaluator : Net.Vpc.Upa.QLTypeEvaluator {

        public LiteralExpressionEvaluator() {
        }


        public virtual object EvalObject(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.QLEvaluator evaluator, object context) {
            return ((Net.Vpc.Upa.Expressions.Literal) e).GetValue();
        }
    }
}
