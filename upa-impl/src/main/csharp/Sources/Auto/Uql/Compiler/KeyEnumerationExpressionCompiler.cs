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


    public class KeyEnumerationExpressionCompiler : Net.Vpc.Upa.Impl.Uql.ExpressionTranslator {


        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateExpression(object x, Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager expressionTranslationManager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            Net.Vpc.Upa.Impl.Uql.Expression.KeyEnumerationExpression o = (Net.Vpc.Upa.Impl.Uql.Expression.KeyEnumerationExpression) x;
            System.Collections.Generic.IList<object> keys = o.GetKeys();
            Net.Vpc.Upa.Expressions.Var tableAlias = o.GetAlias();
            return new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledKeyEnumerationExpression(keys, (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) expressionTranslationManager.CompileAny(tableAlias, declarations));
        }
    }
}
