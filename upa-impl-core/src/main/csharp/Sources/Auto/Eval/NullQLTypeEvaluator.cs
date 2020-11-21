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
    internal class NullQLTypeEvaluator : Net.TheVpc.Upa.QLTypeEvaluator {

        public static readonly Net.TheVpc.Upa.QLTypeEvaluator instance = new Net.TheVpc.Upa.Impl.Eval.NullQLTypeEvaluator();

        public NullQLTypeEvaluator() {
        }


        public virtual Net.TheVpc.Upa.Expressions.Expression EvalObject(Net.TheVpc.Upa.Expressions.Expression e, Net.TheVpc.Upa.QLEvaluator evaluator, object context) {
            return Net.TheVpc.Upa.Expressions.Literal.NULL;
        }
    }
}
