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
    public class CurrentDateEvaluator : Net.Vpc.Upa.Function {

        public static readonly Net.Vpc.Upa.Function INSTANCE = new Net.Vpc.Upa.Impl.Eval.Functions.CurrentDateEvaluator();


        public virtual object Eval(Net.Vpc.Upa.EvalContext evalContext) {
            return new Net.Vpc.Upa.Types.Date();
        }
    }
}
