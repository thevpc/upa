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


    public class IdEnumerationExpressionCompiler : Net.Vpc.Upa.Impl.Uql.ExpressionTranslator {


        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateExpression(object x, Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            Net.Vpc.Upa.Expressions.IdEnumerationExpression o = (Net.Vpc.Upa.Expressions.IdEnumerationExpression) x;
            System.Collections.Generic.IList<object> keys = o.GetIds();
            Net.Vpc.Upa.Expressions.Var tableAlias = o.GetAlias();
            return new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledKeyEnumerationExpression(keys, (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) manager.TranslateAny(tableAlias, declarations));
        }
    }
}
