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



namespace Net.Vpc.Upa.Impl.Uql.Compiler
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class UserExpressionExpressionTranslator : Net.Vpc.Upa.Impl.Uql.ExpressionTranslator {

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateExpression(object o, Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            Net.Vpc.Upa.Expressions.UserExpression v = (Net.Vpc.Upa.Expressions.UserExpression) o;
            if (v == null) {
                return null;
            }
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression compiledExpression = manager.TranslateAny(manager.GetExpressionManager().ParseExpression(v), declarations);
            System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam> cvalues = compiledExpression.FindExpressionsList<T>(Net.Vpc.Upa.Impl.Uql.Compiledfilters.CompiledExpressionHelper.PARAM_FILTER);
            foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam e in cvalues) {
                if (v.ContainsParameter(e.GetName())) {
                    e.SetValue(v.GetParameter(e.GetName()));
                    e.SetUnspecified(false);
                }
            }
            return compiledExpression;
        }
    }
}
