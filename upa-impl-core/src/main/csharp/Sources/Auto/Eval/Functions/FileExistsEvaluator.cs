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
     * @author taha.bensalah@gmail.com
     */
    public class FileExistsEvaluator : Net.TheVpc.Upa.Function {

        public static readonly Net.TheVpc.Upa.Function INSTANCE = new Net.TheVpc.Upa.Impl.Eval.Functions.FileExistsEvaluator();

        public FileExistsEvaluator() {
        }


        public virtual object Eval(Net.TheVpc.Upa.EvalContext evalContext) {
            object o = evalContext.GetArguments()[0];
            string file = o == null ? "" : o.ToString();
            if (file == null) {
                return Net.TheVpc.Upa.Expressions.Literal.FALSE;
            }
            return Net.TheVpc.Upa.Impl.FwkConvertUtils.FileExists((file)) ? Net.TheVpc.Upa.Expressions.Literal.TRUE : Net.TheVpc.Upa.Expressions.Literal.FALSE;
        }
    }
}
