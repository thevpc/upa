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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class PasswordQLFunction : Net.TheVpc.Upa.Function {

        private Net.TheVpc.Upa.PasswordStrategy strategy;

        public PasswordQLFunction(Net.TheVpc.Upa.PasswordStrategy digest) {
            this.strategy = digest;
        }


        public virtual object Eval(Net.TheVpc.Upa.EvalContext evalContext) {
            return strategy.Encode((string) evalContext.GetArguments()[0]);
        }
    }
}
