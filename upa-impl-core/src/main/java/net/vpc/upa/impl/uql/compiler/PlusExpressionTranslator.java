package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.Plus;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.uql.compiledexpression.CompiledPlus;

/**
* Created with IntelliJ IDEA.
* User: vpc
* Date: 7/28/13
* Time: 6:22 PM
* To change this template use File | Settings | File Templates.
*/
public class PlusExpressionTranslator implements ExpressionTranslator {
    public CompiledExpressionExt translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return compilePlus((Plus) o, manager,declarations);
    }

    protected CompiledPlus compilePlus(Plus v, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledExpressionExt left = manager.translateAny(v.getLeft(), declarations);
        CompiledExpressionExt right = manager.translateAny(v.getRight(), declarations);
        CompiledPlus s = new CompiledPlus(left, right);
//        s.setDeclarationList(new ExpressionDeclarationList(declarations));
        return s;
    }
}
