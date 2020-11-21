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
     * Created by vpc on 7/3/16.
     */
    public class SignEvaluator : Net.TheVpc.Upa.Function {

        public static readonly Net.TheVpc.Upa.Function INSTANCE = new Net.TheVpc.Upa.Impl.Eval.Functions.SignEvaluator();


        public virtual object Eval(Net.TheVpc.Upa.EvalContext evalContext) {
            object obj = evalContext.GetArguments()[0];
            object n = (object) obj;
            return System.Convert.ToDouble(n) > 0 ? 1 : System.Convert.ToDouble(n) < 0 ? -1 : 0;
        }
    }
}
