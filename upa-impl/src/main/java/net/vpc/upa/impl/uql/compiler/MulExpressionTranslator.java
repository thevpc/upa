/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.Mul;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledMul;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class MulExpressionTranslator implements ExpressionTranslator {
    private final ExpressionTranslationManager outer;

    public MulExpressionTranslator(final ExpressionTranslationManager outer) {
        this.outer = outer;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        return compileMul((Mul) o, declarations);
    }
    
    protected CompiledMul compileMul(Mul v, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        DefaultCompiledExpression left = outer.compileAny(v.getLeft(), declarations);
        DefaultCompiledExpression right = outer.compileAny(v.getRight(), declarations);
        CompiledMul s = new CompiledMul(left, right);
//        s.setDeclarationList(new ExpressionDeclarationList(declarations));
        return s;
    }
}
