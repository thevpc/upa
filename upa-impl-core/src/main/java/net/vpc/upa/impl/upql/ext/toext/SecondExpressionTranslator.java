/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.upql.ext.toext;

import net.vpc.upa.expressions.DatePart;
import net.vpc.upa.expressions.DatePartType;
import net.vpc.upa.expressions.Second;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.upql.ExpressionDeclarationList;
import net.vpc.upa.impl.upql.ExpressionTranslationManager;
import net.vpc.upa.impl.upql.ExpressionTranslator;
import net.vpc.upa.impl.upql.ext.expr.CompiledDatePart;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class SecondExpressionTranslator implements ExpressionTranslator {
    public CompiledExpressionExt translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return compileDatePart((Second) o, manager,declarations);
    }

    protected CompiledDatePart compileDatePart(Second v, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledDatePart s = new CompiledDatePart(DatePartType.SECOND, manager.translateAny(v.getValue(), declarations));
        //        s.setDeclarationList(declarations);
        return s;
    }
    
}
