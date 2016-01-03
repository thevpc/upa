/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.Min;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledMin;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class MinExpressionTranslator implements ExpressionTranslator {
    private final ExpressionTranslationManager outer;

    public MinExpressionTranslator(final ExpressionTranslationManager outer) {
        this.outer = outer;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        return compileMin((Min) o, declarations);
    }

    protected CompiledMin compileMin(Min v, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledMin s = new CompiledMin(outer.compileAny(v.getArgument(0), declarations));
        //        s.setDeclarationList(declarations);
        return s;
    }
    
}
