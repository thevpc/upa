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
    public class DecodeEvaluator : Net.TheVpc.Upa.Function {

        public static readonly Net.TheVpc.Upa.Function INSTANCE = new Net.TheVpc.Upa.Impl.Eval.Functions.DecodeEvaluator();

        public DecodeEvaluator() {
        }


        public virtual object Eval(Net.TheVpc.Upa.EvalContext evalContext) {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            object[] args = evalContext.GetArguments();
            int i = 1;
            while (i < args.Length) {
                if (i < args.Length - 1) {
                    if (Net.TheVpc.Upa.Impl.FwkConvertUtils.ObjectEquals(args[0],args[i])) {
                        return args[i + 1];
                    }
                    i++;
                } else {
                    return args[i];
                }
                i++;
            }
            return null;
        }
    }
}
