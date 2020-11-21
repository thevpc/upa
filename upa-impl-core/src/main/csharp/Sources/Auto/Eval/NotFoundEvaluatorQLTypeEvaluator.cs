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
    internal class NotFoundEvaluatorQLTypeEvaluator : Net.TheVpc.Upa.QLTypeEvaluator {

        public static readonly Net.TheVpc.Upa.QLTypeEvaluator instance = new Net.TheVpc.Upa.Impl.Eval.NotFoundEvaluatorQLTypeEvaluator();

        public NotFoundEvaluatorQLTypeEvaluator() {
        }


        public virtual Net.TheVpc.Upa.Expressions.Expression EvalObject(Net.TheVpc.Upa.Expressions.Expression e, Net.TheVpc.Upa.QLEvaluator evaluator, object context) {
            return e;
        }
    }
}
