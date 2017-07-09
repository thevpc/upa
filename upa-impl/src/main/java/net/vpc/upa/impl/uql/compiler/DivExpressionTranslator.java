/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.Div;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledDiv;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class DivExpressionTranslator implements ExpressionTranslator {

    public CompiledExpressionExt translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return compileDiv((Div) o, manager,declarations);
    }

    protected CompiledDiv compileDiv(Div v, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledExpressionExt left = manager.translateAny(v.getLeft(), declarations);
        CompiledExpressionExt right = manager.translateAny(v.getRight(), declarations);
        CompiledDiv s = new CompiledDiv(left, right);
//        s.setDeclarationList(new ExpressionDeclarationList(declarations));
        return s;
    }
}
