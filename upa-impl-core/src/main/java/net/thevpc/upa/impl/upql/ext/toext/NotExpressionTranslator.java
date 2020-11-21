/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.upql.ext.toext;

import net.thevpc.upa.expressions.Not;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ExpressionTranslationManager;
import net.thevpc.upa.impl.upql.ExpressionTranslator;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.impl.upql.ext.expr.CompiledNot;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class NotExpressionTranslator implements ExpressionTranslator {

    public CompiledExpressionExt translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        Not v = (Not) o;
        if (v == null) {
            return null;
        }
        CompiledExpressionExt left = manager.translateAny(v.getExpression(), declarations);
        CompiledNot s = new CompiledNot(left);
        //        s.setDeclarationList(new ExpressionDeclarationList(declarations));
        return s;
    }
}
