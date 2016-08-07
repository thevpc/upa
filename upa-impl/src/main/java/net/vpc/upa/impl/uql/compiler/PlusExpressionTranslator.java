package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.Plus;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledPlus;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
* Created with IntelliJ IDEA.
* User: vpc
* Date: 7/28/13
* Time: 6:22 PM
* To change this template use File | Settings | File Templates.
*/
public class PlusExpressionTranslator implements ExpressionTranslator {
    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return compilePlus((Plus) o, manager,declarations);
    }

    protected CompiledPlus compilePlus(Plus v, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        DefaultCompiledExpression left = manager.translateAny(v.getLeft(), declarations);
        DefaultCompiledExpression right = manager.translateAny(v.getRight(), declarations);
        CompiledPlus s = new CompiledPlus(left, right);
//        s.setDeclarationList(new ExpressionDeclarationList(declarations));
        return s;
    }
}
