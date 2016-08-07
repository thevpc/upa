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
     * @author taha.bensalah@gmail.com
     */
    public class FileExistsEvaluator : Net.Vpc.Upa.Function {

        public static readonly Net.Vpc.Upa.Function INSTANCE = new Net.Vpc.Upa.Impl.Eval.Functions.FileExistsEvaluator();

        public FileExistsEvaluator() {
        }


        public virtual object Eval(Net.Vpc.Upa.EvalContext evalContext) {
            object o = evalContext.GetArguments()[0];
            string file = o == null ? "" : o.ToString();
            if (file == null) {
                return Net.Vpc.Upa.Expressions.Literal.FALSE;
            }
            return Net.Vpc.Upa.Impl.FwkConvertUtils.FileExists((file)) ? Net.Vpc.Upa.Expressions.Literal.TRUE : Net.Vpc.Upa.Expressions.Literal.FALSE;
        }
    }
}
