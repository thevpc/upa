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
    public class AvgExpressionTranslator : Net.Vpc.Upa.Impl.Uql.ExpressionTranslator {

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateExpression(object o, Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            return CompileAvg((Net.Vpc.Upa.Expressions.Avg) o, manager, declarations);
        }

        protected internal virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledAvg CompileAvg(Net.Vpc.Upa.Expressions.Avg v, Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            if (v == null) {
                return null;
            }
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledAvg s = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledAvg(manager.TranslateAny(v.GetArgument(0), declarations));
            //        s.setDeclarationList(declarations);
            return s;
        }
    }
}
