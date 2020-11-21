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
    public class ConcatEvaluator : Net.TheVpc.Upa.Function {

        public static readonly Net.TheVpc.Upa.Function INSTANCE = new Net.TheVpc.Upa.Impl.Eval.Functions.ConcatEvaluator();

        public ConcatEvaluator() {
        }


        public virtual object Eval(Net.TheVpc.Upa.EvalContext evalContext) {
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
