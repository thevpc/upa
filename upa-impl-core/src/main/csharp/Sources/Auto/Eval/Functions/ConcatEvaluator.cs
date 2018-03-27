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
    public class ConcatEvaluator : Net.Vpc.Upa.Function {

        public static readonly Net.Vpc.Upa.Function INSTANCE = new Net.Vpc.Upa.Impl.Eval.Functions.ConcatEvaluator();

        public ConcatEvaluator() {
        }


        public virtual object Eval(Net.Vpc.Upa.EvalContext evalContext) {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (object arg in evalContext.GetArguments()) {
                if (arg != null) {
                    sb.Append(arg);
                }
            }
            return sb.ToString();
        }
    }
}
