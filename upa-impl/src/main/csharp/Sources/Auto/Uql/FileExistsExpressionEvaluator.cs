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



namespace Net.Vpc.Upa.Impl.Uql
{


    /**
     *
     * @author vpc
     */
    internal class FileExistsExpressionEvaluator : Net.Vpc.Upa.QLTypeEvaluator {

        public FileExistsExpressionEvaluator() {
        }


        public virtual object EvalObject(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.QLEvaluator evaluator, object context) {
            Net.Vpc.Upa.Expressions.Function f = (Net.Vpc.Upa.Expressions.Function) e;
            if (f.GetArgumentsCount() != 1) {
                throw new System.ArgumentException ("file_exists requires 1 arg");
            }
            object oo = evaluator.EvalObject(f.GetArguments()[0], context);
            string file = oo == null ? "" : oo.ToString();
            if (file == null) {
                return false;
            }
            return (file).Exists();
        }
    }
}
