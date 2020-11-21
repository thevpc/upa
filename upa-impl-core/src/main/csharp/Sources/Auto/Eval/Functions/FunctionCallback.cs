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
    public class FunctionCallback : Net.TheVpc.Upa.Function {

        private readonly Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback callback;

        public FunctionCallback(Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback b) {
            this.callback = b;
        }


        public virtual object Eval(Net.TheVpc.Upa.EvalContext evalContext) {
            return callback.Invoke(evalContext);
        }

        public virtual Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback GetCallback() {
            return callback;
        }
    }
}
