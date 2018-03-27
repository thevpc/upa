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



namespace Net.Vpc.Upa.Impl.Eval.Functions
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class CoalesceEvaluator : Net.Vpc.Upa.Function {

        public static readonly Net.Vpc.Upa.Function INSTANCE = new Net.Vpc.Upa.Impl.Eval.Functions.CoalesceEvaluator();

        public CoalesceEvaluator() {
        }


        public virtual object Eval(Net.Vpc.Upa.EvalContext evalContext) {
            foreach (object arg in evalContext.GetArguments()) {
                if (arg != null) {
                    return arg;
                }
            }
            return null;
        }
    }
}
