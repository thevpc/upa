/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql;

import net.vpc.upa.QLEvaluator;
import net.vpc.upa.QLTypeEvaluator;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.If;

/**
 *
 * @author vpc
 */
class IfExpressionEvaluator implements QLTypeEvaluator {

    public IfExpressionEvaluator() {
    }

    @Override
    public Object evalObject(Expression e, QLEvaluator evaluator, Object context) {
        If ife = (If) e;
        int count = ife.getArgumentsCount();
        int i = 0;
        while (i < count) {
            Expression ee = ife.getArgument(i);
            Boolean exprVal = (Boolean) evaluator.evalObject(ee, context);
            if (exprVal) {
                Expression thenExpr = ife.getArgument(i + 1);
                return evaluator.evalObject(thenExpr, context);
            } else {
                if (i + 2 == count - 1) {
                    //the else
                    Expression elseExpr = ife.getArgument(i + 2);
                    return evaluator.evalObject(elseExpr, context);
                }
                i += 2;
            }
        }
        return null;
    }
    
}
