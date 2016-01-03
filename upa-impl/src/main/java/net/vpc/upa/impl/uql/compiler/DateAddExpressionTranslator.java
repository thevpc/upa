/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.DateAdd;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledDateAdd;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class DateAddExpressionTranslator implements ExpressionTranslator {
    private final ExpressionTranslationManager outer;

    public DateAddExpressionTranslator(final ExpressionTranslationManager outer) {
        this.outer = outer;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        return compileDateAdd((DateAdd) o, declarations);
    }

    protected CompiledDateAdd compileDateAdd(DateAdd v, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledDateAdd s = new CompiledDateAdd(v.getDatePartType(), outer.compileAny(v.getCount(), declarations), outer.compileAny(v.getDate(), declarations));
        //        s.setDeclarationList(declarations);
        return s;
    }
    
}
