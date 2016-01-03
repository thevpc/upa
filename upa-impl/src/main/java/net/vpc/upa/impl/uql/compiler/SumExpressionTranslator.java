/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.Sum;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledSum;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class SumExpressionTranslator implements ExpressionTranslator {
    private final ExpressionTranslationManager outer;

    public SumExpressionTranslator(final ExpressionTranslationManager outer) {
        this.outer = outer;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        return compileSum((Sum) o, declarations);
    }

    protected CompiledSum compileSum(Sum v, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledSum s = new CompiledSum(outer.compileAny(v.getArgument(0), declarations));
        //        s.setDeclarationList(declarations);
        return s;
    }
    
}
