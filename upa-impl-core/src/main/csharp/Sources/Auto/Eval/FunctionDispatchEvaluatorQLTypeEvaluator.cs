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
    internal class FunctionDispatchEvaluatorQLTypeEvaluator : Net.Vpc.Upa.QLTypeEvaluator {

        private System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.QLTypeEvaluator> functionsEvaluators;

        public FunctionDispatchEvaluatorQLTypeEvaluator(System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.QLTypeEvaluator> functionsEvaluators) {
            this.functionsEvaluators = functionsEvaluators;
        }


        public virtual Net.Vpc.Upa.Expressions.Expression EvalObject(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.QLEvaluator evaluator, object context) {
            Net.Vpc.Upa.Expressions.FunctionExpression fct = (Net.Vpc.Upa.Expressions.FunctionExpression) e;
            Net.Vpc.Upa.QLTypeEvaluator fe = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.QLTypeEvaluator>(functionsEvaluators,fct.GetName().ToLower());
            if (fe == null) {
                throw new System.Exception("function not found " + fct.GetName());
            }
            return fe.EvalObject(fct, evaluator, context);
        }
    }
}
