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
    public class CurrentDateEvaluator : Net.TheVpc.Upa.Function {

        public static readonly Net.TheVpc.Upa.Function INSTANCE = new Net.TheVpc.Upa.Impl.Eval.Functions.CurrentDateEvaluator();


        public virtual object Eval(Net.TheVpc.Upa.EvalContext evalContext) {
            return new Net.TheVpc.Upa.Types.Date();
        }
    }
}
