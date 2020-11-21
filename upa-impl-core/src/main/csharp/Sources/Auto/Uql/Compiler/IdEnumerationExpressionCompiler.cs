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


    public class IdEnumerationExpressionCompiler : Net.TheVpc.Upa.Impl.Uql.ExpressionTranslator {


        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateExpression(object x, Net.TheVpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            Net.TheVpc.Upa.Expressions.IdEnumerationExpression o = (Net.TheVpc.Upa.Expressions.IdEnumerationExpression) x;
            System.Collections.Generic.IList<object> keys = o.GetIds();
            Net.TheVpc.Upa.Expressions.Var tableAlias = o.GetAlias();
            return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledKeyEnumerationExpression(keys, (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) manager.TranslateAny(tableAlias, declarations));
        }
    }
}
