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
    public class IsHierarchyDescendentExpressionTranslator : Net.Vpc.Upa.Impl.Uql.ExpressionTranslator {

        private readonly Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager outer;

        public IsHierarchyDescendentExpressionTranslator(Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager outer) {
            this.outer = outer;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateExpression(object o, Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager expressionTranslationManager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            Net.Vpc.Upa.Expressions.IsHierarchyDescendent v = (Net.Vpc.Upa.Expressions.IsHierarchyDescendent) o;
            return new Net.Vpc.Upa.Impl.Uql.Compiledexpression.IsHierarchyDescendentCompiled(expressionTranslationManager.CompileAny(v.GetAncestorExpression(), declarations), expressionTranslationManager.CompileAny(v.GetChildExpression(), declarations), (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) expressionTranslationManager.CompileAny(v.GetEntityName(), declarations));
        }
    }
}
