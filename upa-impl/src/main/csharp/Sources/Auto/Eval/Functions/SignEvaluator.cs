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
     * Created by vpc on 7/3/16.
     */
    public class SignEvaluator : Net.Vpc.Upa.Function {

        public static readonly Net.Vpc.Upa.Function INSTANCE = new Net.Vpc.Upa.Impl.Eval.Functions.SignEvaluator();


        public virtual object Eval(Net.Vpc.Upa.EvalContext evalContext) {
            object obj = evalContext.GetArguments()[0];
            object n = (object) obj;
            return System.Convert.ToDouble(n) > 0 ? 1 : System.Convert.ToDouble(n) < 0 ? -1 : 0;
        }
    }
}
