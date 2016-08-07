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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class PasswordQLFunction : Net.Vpc.Upa.Function {

        private Net.Vpc.Upa.PasswordStrategy strategy;

        public PasswordQLFunction(Net.Vpc.Upa.PasswordStrategy digest) {
            this.strategy = digest;
        }


        public virtual object Eval(Net.Vpc.Upa.EvalContext evalContext) {
            return strategy.Encode((string) evalContext.GetArguments()[0]);
        }
    }
}
