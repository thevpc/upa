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
    internal class NotFoundEvaluatorQLTypeEvaluator : Net.Vpc.Upa.QLTypeEvaluator {

        public static readonly Net.Vpc.Upa.QLTypeEvaluator instance = new Net.Vpc.Upa.Impl.Eval.NotFoundEvaluatorQLTypeEvaluator();

        public NotFoundEvaluatorQLTypeEvaluator() {
        }


        public virtual Net.Vpc.Upa.Expressions.Expression EvalObject(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.QLEvaluator evaluator, object context) {
            return e;
        }
    }
}
