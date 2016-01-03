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
    * Created with IntelliJ IDEA.
    * User: vpc
    * Date: 7/28/13
    * Time: 6:20 PM
    * To change this template use File | Settings | File Templates.*/
    public class OrExpressionTranslator : Net.Vpc.Upa.Impl.Uql.ExpressionTranslator {

        private Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager expressionTranslationManager;

        public OrExpressionTranslator(Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager expressionTranslationManager) {
            this.expressionTranslationManager = expressionTranslationManager;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateExpression(object o, Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager expressionTranslationManager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            return CompileOr((Net.Vpc.Upa.Expressions.Or) o, declarations);
        }

        protected internal virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledOr CompileOr(Net.Vpc.Upa.Expressions.Or v, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            if (v == null) {
                return null;
            }
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left = expressionTranslationManager.CompileAny(v.GetLeft(), declarations);
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression right = expressionTranslationManager.CompileAny(v.GetRight(), declarations);
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledOr s = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledOr(left, right);
            //        s.setDeclarationList(new ExpressionDeclarationList(declarations));
            return s;
        }
    }
}
