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
    internal class FunctionDispatchEvaluatorQLTypeEvaluator : Net.TheVpc.Upa.QLTypeEvaluator {

        private System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.QLTypeEvaluator> functionsEvaluators;

        public FunctionDispatchEvaluatorQLTypeEvaluator(System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.QLTypeEvaluator> functionsEvaluators) {
            this.functionsEvaluators = functionsEvaluators;
        }


        public virtual Net.TheVpc.Upa.Expressions.Expression EvalObject(Net.TheVpc.Upa.Expressions.Expression e, Net.TheVpc.Upa.QLEvaluator evaluator, object context) {
            Net.TheVpc.Upa.Expressions.FunctionExpression fct = (Net.TheVpc.Upa.Expressions.FunctionExpression) e;
            Net.TheVpc.Upa.QLTypeEvaluator fe = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.QLTypeEvaluator>(functionsEvaluators,fct.GetName().ToLower());
            if (fe == null) {
                throw new System.Exception("function not found " + fct.GetName());
            }
            return fe.EvalObject(fct, evaluator, context);
        }
    }
}
