/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.DateDiff;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledDateDiff;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class DateDiffExpressionTranslator implements ExpressionTranslator {
    private final ExpressionTranslationManager outer;

    public DateDiffExpressionTranslator(final ExpressionTranslationManager outer) {
        this.outer = outer;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        return compileDateDiff((DateDiff) o, declarations);
    }

    protected CompiledDateDiff compileDateDiff(DateDiff v, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledDateDiff s = new CompiledDateDiff(v.getDatePartType(), outer.compileAny(v.getStart(), declarations), outer.compileAny(v.getEnd(), declarations));
        //        s.setDeclarationList(declarations);
        return s;
    }
    
}
