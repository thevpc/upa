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
    internal class LiteralTypeEvaluator : Net.Vpc.Upa.QLTypeEvaluator {

        public static readonly Net.Vpc.Upa.QLTypeEvaluator INSTANCE = new Net.Vpc.Upa.Impl.Eval.LiteralTypeEvaluator();

        public LiteralTypeEvaluator() {
        }


        public virtual Net.Vpc.Upa.Expressions.Expression EvalObject(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.QLEvaluator evaluator, object context) {
            return e;
        }
    }
}
