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
    internal class FunctionDispacthEvaluatorQLTypeEvaluator : Net.Vpc.Upa.QLTypeEvaluator {

        private System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.QLTypeEvaluator> functionsEvaluators;

        public FunctionDispacthEvaluatorQLTypeEvaluator(System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.QLTypeEvaluator> functionsEvaluators) {
            this.functionsEvaluators = functionsEvaluators;
        }


        public virtual object EvalObject(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.QLEvaluator evaluator, object context) {
            Net.Vpc.Upa.Expressions.Function fct = (Net.Vpc.Upa.Expressions.Function) e;
            Net.Vpc.Upa.QLTypeEvaluator fe = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.QLTypeEvaluator>(functionsEvaluators,fct.GetName());
            if (fe == null) {
                throw new System.Exception("function not found " + fct.GetName());
            }
            return fe.EvalObject(fct, evaluator, context);
        }
    }
}
