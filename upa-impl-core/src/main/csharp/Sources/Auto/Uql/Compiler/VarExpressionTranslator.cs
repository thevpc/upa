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
    public class VarExpressionTranslator : Net.TheVpc.Upa.Impl.Uql.ExpressionTranslator {

        public VarExpressionTranslator() {
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateExpression(object o, Net.TheVpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            return CompileVar((Net.TheVpc.Upa.Expressions.Var) o, manager, declarations);
        }

        protected internal virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar CompileVar(Net.TheVpc.Upa.Expressions.Var v, Net.TheVpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            if (v == null) {
                return null;
            }
            Net.TheVpc.Upa.Expressions.CompiledExpression p = null;
            if (v.GetApplier() != null) {
                p = manager.TranslateAny(v.GetApplier(), declarations);
            }
            if (p == null) {
                return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(v.GetName());
            } else {
                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar r = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(v.GetName());
                if (p is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) {
                    ((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) ((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) p).GetFinest()).SetChild(r);
                    return (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) p;
                } else {
                    throw new Net.TheVpc.Upa.Exceptions.UPAException("Unsupported");
                }
            }
        }
    }
}
