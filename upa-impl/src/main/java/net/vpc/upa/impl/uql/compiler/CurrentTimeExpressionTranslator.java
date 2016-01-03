/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.CurrentTime;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledCurrentTime;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class CurrentTimeExpressionTranslator implements ExpressionTranslator {
    private final ExpressionTranslationManager outer;

    public CurrentTimeExpressionTranslator(final ExpressionTranslationManager outer) {
        this.outer = outer;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        return compileCurrentTime((CurrentTime) o, declarations);
    }

    protected CompiledCurrentTime compileCurrentTime(CurrentTime v, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledCurrentTime s = new CompiledCurrentTime();
        //        s.setDeclarationList(declarations);
        return s;
    }
    
}
