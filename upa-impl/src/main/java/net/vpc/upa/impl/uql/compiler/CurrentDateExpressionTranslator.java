/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.CurrentDate;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledCurrentDate;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class CurrentDateExpressionTranslator implements ExpressionTranslator {
    private final ExpressionTranslationManager outer;

    public CurrentDateExpressionTranslator(final ExpressionTranslationManager outer) {
        this.outer = outer;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        return compileCurrentDate((CurrentDate) o, declarations);
    }

    protected CompiledCurrentDate compileCurrentDate(CurrentDate v, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledCurrentDate s = new CompiledCurrentDate();
        //        s.setDeclarationList(declarations);
        return s;
    }
    
}
