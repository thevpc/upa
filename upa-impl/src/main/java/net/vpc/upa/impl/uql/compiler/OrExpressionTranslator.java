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
    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return compileOr((Or) o, manager,declarations);
    }

    protected CompiledOr compileOr(Or v, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        DefaultCompiledExpression left = manager.translateAny(v.getLeft(), declarations);
        DefaultCompiledExpression right = manager.translateAny(v.getRight(), declarations);
        CompiledOr s = new CompiledOr(left, right);
//        s.setDeclarationList(new ExpressionDeclarationList(declarations));
        return s;
    }
}
