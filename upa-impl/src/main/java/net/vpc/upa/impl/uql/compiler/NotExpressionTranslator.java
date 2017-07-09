/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.Not;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.uql.compiledexpression.CompiledNot;

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
