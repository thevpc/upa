/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.upql.ext.toext;

import net.thevpc.upa.expressions.GreaterEqualThan;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ExpressionTranslationManager;
import net.thevpc.upa.impl.upql.ExpressionTranslator;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.impl.upql.ext.expr.CompiledGreaterEqualThan;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class GreaterEqualThanExpressionTranslator implements ExpressionTranslator {
    public CompiledExpressionExt translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return compileGreaterEqualThan((GreaterEqualThan) o, manager,declarations);
    }

    protected CompiledGreaterEqualThan compileGreaterEqualThan(GreaterEqualThan v, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledExpressionExt left = manager.translateAny(v.getLeft(), declarations);
        CompiledExpressionExt right = manager.translateAny(v.getRight(), declarations);
        CompiledGreaterEqualThan s = new CompiledGreaterEqualThan(left, right);
        //        s.setDeclarationList(declarations);
        return s;
    }
    
}
