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

        public VarExpressionTranslator() {
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateExpression(object o, Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            return CompileVar((Net.Vpc.Upa.Expressions.Var) o, manager, declarations);
        }

        protected internal virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar CompileVar(Net.Vpc.Upa.Expressions.Var v, Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            if (v == null) {
                return null;
            }
            Net.Vpc.Upa.Expressions.CompiledExpression p = null;
            if (v.GetApplier() != null) {
                p = manager.TranslateAny(v.GetApplier(), declarations);
            }
            if (p == null) {
                return new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(v.GetName());
            } else {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar r = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(v.GetName());
                if (p is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) {
                    ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) p).GetFinest()).SetChild(r);
                    return (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) p;
                } else {
                    throw new Net.Vpc.Upa.Exceptions.UPAException("Unsupported");
                }
            }
        }
    }
}
