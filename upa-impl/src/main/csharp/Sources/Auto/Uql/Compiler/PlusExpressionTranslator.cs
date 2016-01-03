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
    * Time: 6:22 PM
    * To change this template use File | Settings | File Templates.*/
    public class PlusExpressionTranslator : Net.Vpc.Upa.Impl.Uql.ExpressionTranslator {

        private Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager expressionTranslationManager;

        public PlusExpressionTranslator(Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager expressionTranslationManager) {
            this.expressionTranslationManager = expressionTranslationManager;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateExpression(object o, Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager expressionTranslationManager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            return CompilePlus((Net.Vpc.Upa.Expressions.Plus) o, declarations);
        }

        protected internal virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledPlus CompilePlus(Net.Vpc.Upa.Expressions.Plus v, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            if (v == null) {
                return null;
            }
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left = expressionTranslationManager.CompileAny(v.GetLeft(), declarations);
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression right = expressionTranslationManager.CompileAny(v.GetRight(), declarations);
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledPlus s = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledPlus(left, right);
            //        s.setDeclarationList(new ExpressionDeclarationList(declarations));
            return s;
        }
    }
}
