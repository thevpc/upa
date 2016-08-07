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
    public class FunctionCallback : Net.Vpc.Upa.Function {

        private readonly Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback callback;

        public FunctionCallback(Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback b) {
            this.callback = b;
        }


        public virtual object Eval(Net.Vpc.Upa.EvalContext evalContext) {
            return callback.Invoke(evalContext);
        }

        public virtual Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback GetCallback() {
            return callback;
        }
    }
}
