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



namespace Net.TheVpc.Upa.Impl.Uql.Compiler
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class UserExpressionExpressionTranslator : Net.TheVpc.Upa.Impl.Uql.ExpressionTranslator {

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateExpression(object o, Net.TheVpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            Net.TheVpc.Upa.Expressions.UserExpression v = (Net.TheVpc.Upa.Expressions.UserExpression) o;
            if (v == null) {
                return null;
            }
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression compiledExpression = manager.TranslateAny(manager.GetExpressionManager().ParseExpression(v), declarations);
            System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledParam> cvalues = compiledExpression.FindExpressionsList<T>(Net.TheVpc.Upa.Impl.Uql.Compiledfilters.CompiledExpressionHelper.PARAM_FILTER);
            foreach (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledParam e in cvalues) {
                if (v.ContainsParameter(e.GetName())) {
                    e.SetValue(v.GetParameter(e.GetName()));
                    e.SetUnspecified(false);
                }
            }
            return compiledExpression;
        }
    }
}
