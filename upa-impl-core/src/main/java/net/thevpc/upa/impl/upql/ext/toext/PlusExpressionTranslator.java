package net.thevpc.upa.impl.upql.ext.toext;

import net.thevpc.upa.expressions.Plus;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ExpressionTranslationManager;
import net.thevpc.upa.impl.upql.ExpressionTranslator;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.impl.upql.ext.expr.CompiledPlus;

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
