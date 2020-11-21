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
    internal class LiteralTypeEvaluator : Net.TheVpc.Upa.QLTypeEvaluator {

        public static readonly Net.TheVpc.Upa.QLTypeEvaluator INSTANCE = new Net.TheVpc.Upa.Impl.Eval.LiteralTypeEvaluator();

        public LiteralTypeEvaluator() {
        }


        public virtual Net.TheVpc.Upa.Expressions.Expression EvalObject(Net.TheVpc.Upa.Expressions.Expression e, Net.TheVpc.Upa.QLEvaluator evaluator, object context) {
            return e;
        }
    }
}
