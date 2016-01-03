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
    public class VarExpressionTranslator : Net.Vpc.Upa.Impl.Uql.ExpressionTranslator {

        private readonly Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager outer;

        public VarExpressionTranslator(Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager outer) {
            this.outer = outer;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateExpression(object o, Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager expressionTranslationManager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            return CompileVar((Net.Vpc.Upa.Expressions.Var) o, declarations);
        }

        protected internal virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar CompileVar(Net.Vpc.Upa.Expressions.Var v, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            if (v == null) {
                return null;
            }
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar p = null;
            if (v.GetParent() != null) {
                p = CompileVar(v.GetParent(), declarations);
            }
            if (p == null) {
                return new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(v.GetName());
            } else {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar r = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(v.GetName());
                ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) p.GetFinest()).SetChild(r);
                return p;
            }
        }
    }
}
