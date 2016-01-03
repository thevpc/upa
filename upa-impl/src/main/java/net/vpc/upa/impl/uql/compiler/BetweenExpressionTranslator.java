/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.Between;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledBetween;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class BetweenExpressionTranslator implements ExpressionTranslator {
    private final ExpressionTranslationManager outer;

    public BetweenExpressionTranslator(final ExpressionTranslationManager outer) {
        this.outer = outer;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        return compileBetween((Between) o, declarations);
    }

    protected CompiledBetween compileBetween(Between v, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledBetween s = new CompiledBetween(outer.compileAny(v.getLeft(), declarations), outer.compileAny(v.getMin(), declarations), outer.compileAny(v.getMax(), declarations));
        //        s.setDeclarationList(declarations);
        return s;
    }
    
}
