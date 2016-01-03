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
    public class MaxExpressionTranslator : Net.Vpc.Upa.Impl.Uql.ExpressionTranslator {

        private readonly Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager outer;

        public MaxExpressionTranslator(Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager outer) {
            this.outer = outer;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateExpression(object o, Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager expressionTranslationManager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            return CompileMax((Net.Vpc.Upa.Expressions.Max) o, declarations);
        }

        protected internal virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledMax CompileMax(Net.Vpc.Upa.Expressions.Max v, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            if (v == null) {
                return null;
            }
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledMax s = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledMax(outer.CompileAny(v.GetArgument(0), declarations));
            //        s.setDeclarationList(declarations);
            return s;
        }
    }
}
