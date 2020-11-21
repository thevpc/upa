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



namespace Net.TheVpc.Upa.Impl.Eval.Functions
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class CoalesceEvaluator : Net.TheVpc.Upa.Function {

        public static readonly Net.TheVpc.Upa.Function INSTANCE = new Net.TheVpc.Upa.Impl.Eval.Functions.CoalesceEvaluator();

        public CoalesceEvaluator() {
        }


        public virtual object Eval(Net.TheVpc.Upa.EvalContext evalContext) {
            foreach (object arg in evalContext.GetArguments()) {
                if (arg != null) {
                    return arg;
                }
            }
            return null;
        }
    }
}
