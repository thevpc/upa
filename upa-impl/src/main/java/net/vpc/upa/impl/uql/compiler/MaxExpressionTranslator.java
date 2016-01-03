/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.Max;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledMax;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class MaxExpressionTranslator implements ExpressionTranslator {
    private final ExpressionTranslationManager outer;

    public MaxExpressionTranslator(final ExpressionTranslationManager outer) {
        this.outer = outer;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        return compileMax((Max) o, declarations);
    }

    protected CompiledMax compileMax(Max v, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledMax s = new CompiledMax(outer.compileAny(v.getArgument(0), declarations));
        //        s.setDeclarationList(declarations);
        return s;
    }
    
}
