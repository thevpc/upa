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
    public class IsHierarchyDescendentExpressionTranslator : Net.TheVpc.Upa.Impl.Uql.ExpressionTranslator {

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateExpression(object o, Net.TheVpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            Net.TheVpc.Upa.Expressions.IsHierarchyDescendent v = (Net.TheVpc.Upa.Expressions.IsHierarchyDescendent) o;
            return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.IsHierarchyDescendentCompiled(manager.TranslateAny(v.GetAncestorExpression(), declarations), manager.TranslateAny(v.GetChildExpression(), declarations), (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) manager.TranslateAny(v.GetEntityName(), declarations));
        }
    }
}
