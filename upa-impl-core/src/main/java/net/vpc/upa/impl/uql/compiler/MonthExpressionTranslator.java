/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.DatePart;
import net.vpc.upa.expressions.DatePartType;
import net.vpc.upa.expressions.Month;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledDatePart;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class MonthExpressionTranslator implements ExpressionTranslator {
    public CompiledExpressionExt translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return compileDatePart((Month) o, manager,declarations);
    }

    protected CompiledDatePart compileDatePart(Month v, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledDatePart s = new CompiledDatePart(DatePartType.MONTH, manager.translateAny(v.getValue(), declarations));
        //        s.setDeclarationList(declarations);
        return s;
    }
    
}
