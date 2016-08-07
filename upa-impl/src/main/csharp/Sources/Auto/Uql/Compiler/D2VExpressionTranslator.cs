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
    public class D2VExpressionTranslator : Net.Vpc.Upa.Impl.Uql.ExpressionTranslator {

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateExpression(object o, Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            return CompileD2V((Net.Vpc.Upa.Expressions.D2V) o, manager, declarations);
        }

        protected internal virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledD2V CompileD2V(Net.Vpc.Upa.Expressions.D2V v, Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            if (v == null) {
                return null;
            }
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledD2V s = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledD2V(manager.TranslateAny(v.GetExpression(), declarations));
            //        s.setDeclarationList(declarations);
            return s;
        }
    }
}
