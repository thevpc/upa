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
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class DivExpressionTranslator implements ExpressionTranslator {

    private final ExpressionTranslationManager outer;

    public DivExpressionTranslator(final ExpressionTranslationManager outer) {
        this.outer = outer;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        return compileDiv((Div) o, declarations);
    }

    protected CompiledDiv compileDiv(Div v, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        DefaultCompiledExpression left = outer.compileAny(v.getLeft(), declarations);
        DefaultCompiledExpression right = outer.compileAny(v.getRight(), declarations);
        CompiledDiv s = new CompiledDiv(left, right);
//        s.setDeclarationList(new ExpressionDeclarationList(declarations));
        return s;
    }
}
