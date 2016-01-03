/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.Minus;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledMinus;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class MinusExpressionTranslator implements ExpressionTranslator {
    private final ExpressionTranslationManager outer;

    public MinusExpressionTranslator(final ExpressionTranslationManager outer) {
        this.outer = outer;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        return compileMinus((Minus) o, declarations);
    }
    
    protected CompiledMinus compileMinus(Minus v, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        DefaultCompiledExpression left = outer.compileAny(v.getLeft(), declarations);
        DefaultCompiledExpression right = outer.compileAny(v.getRight(), declarations);
        CompiledMinus s = new CompiledMinus(left, right);
//        s.setDeclarationList(new ExpressionDeclarationList(declarations));
        return s;
    }


}
