/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.upql.ext.toext;

import net.vpc.upa.expressions.Not;
import net.vpc.upa.impl.upql.ExpressionDeclarationList;
import net.vpc.upa.impl.upql.ExpressionTranslationManager;
import net.vpc.upa.impl.upql.ExpressionTranslator;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.upql.ext.expr.CompiledNot;

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
