package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.Or;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledOr;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
* Created with IntelliJ IDEA.
* User: vpc
* Date: 7/28/13
* Time: 6:20 PM
* To change this template use File | Settings | File Templates.
*/
public class OrExpressionTranslator implements ExpressionTranslator {
    private ExpressionTranslationManager expressionTranslationManager;

    public OrExpressionTranslator(ExpressionTranslationManager expressionTranslationManager) {
        this.expressionTranslationManager = expressionTranslationManager;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        return compileOr((Or) o, declarations);
    }

    protected CompiledOr compileOr(Or v, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        DefaultCompiledExpression left = expressionTranslationManager.compileAny(v.getLeft(), declarations);
        DefaultCompiledExpression right = expressionTranslationManager.compileAny(v.getRight(), declarations);
        CompiledOr s = new CompiledOr(left, right);
//        s.setDeclarationList(new ExpressionDeclarationList(declarations));
        return s;
    }
}
