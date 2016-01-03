/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.Avg;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledAvg;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class AvgExpressionTranslator implements ExpressionTranslator {
    private final ExpressionTranslationManager outer;

    public AvgExpressionTranslator(final ExpressionTranslationManager outer) {
        this.outer = outer;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        return compileAvg((Avg) o, declarations);
    }

    protected CompiledAvg compileAvg(Avg v, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledAvg s = new CompiledAvg(outer.compileAny(v.getArgument(0), declarations));
        //        s.setDeclarationList(declarations);
        return s;
    }
    
}
