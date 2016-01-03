/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.DateTrunc;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledDateTrunc;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class DateTruncExpressionTranslator implements ExpressionTranslator {
    private final ExpressionTranslationManager outer;

    public DateTruncExpressionTranslator(final ExpressionTranslationManager outer) {
        this.outer = outer;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        return compileDateTrunc((DateTrunc) o, declarations);
    }

    protected CompiledDateTrunc compileDateTrunc(DateTrunc v, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledDateTrunc s = new CompiledDateTrunc(v.getDatePartType(), outer.compileAny(v.getValue(), declarations));
        //        s.setDeclarationList(declarations);
        return s;
    }
    
}
