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
    public class URShiftExpressionTranslator : Net.Vpc.Upa.Impl.Uql.ExpressionTranslator {

        private readonly Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager outer;

        public URShiftExpressionTranslator(Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager outer) {
            this.outer = outer;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateExpression(object o, Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager expressionTranslationManager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            return CompileURShift((Net.Vpc.Upa.Expressions.URShift) o, declarations);
        }

        protected internal virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledURShift CompileURShift(Net.Vpc.Upa.Expressions.URShift v, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            if (v == null) {
                return null;
            }
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left = outer.CompileAny(v.GetLeft(), declarations);
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression right = outer.CompileAny(v.GetRight(), declarations);
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledURShift s = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledURShift(left, right);
            //        s.setDeclarationList(new ExpressionDeclarationList(declarations));
            return s;
        }
    }
}
