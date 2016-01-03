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
    public class BitAndExpressionTranslator : Net.Vpc.Upa.Impl.Uql.ExpressionTranslator {

        private readonly Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager outer;

        public BitAndExpressionTranslator(Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager outer) {
            this.outer = outer;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateExpression(object o, Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager expressionTranslationManager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            return CompileBitAnd((Net.Vpc.Upa.Expressions.BitAnd) o, declarations);
        }

        protected internal virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledBitAnd CompileBitAnd(Net.Vpc.Upa.Expressions.BitAnd v, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            if (v == null) {
                return null;
            }
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left = outer.CompileAny(v.GetLeft(), declarations);
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression right = outer.CompileAny(v.GetRight(), declarations);
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledBitAnd s = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledBitAnd(left, right);
            //        s.setDeclarationList(new ExpressionDeclarationList(declarations));
            return s;
        }
    }
}
