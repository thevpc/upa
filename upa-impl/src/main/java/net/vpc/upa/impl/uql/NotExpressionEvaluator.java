/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql;

import net.vpc.upa.QLEvaluator;
import net.vpc.upa.QLTypeEvaluator;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.Not;

/**
 *
 * @author vpc
 */
class NotExpressionEvaluator implements QLTypeEvaluator {

    public NotExpressionEvaluator() {
    }

    @Override
    public Object evalObject(Expression e, QLEvaluator evaluator, Object context) {
        Not v = (Not) e;
        Expression ee = v.getNegatedExpression();
        Object o = evaluator.evalObject(ee, context);
        if (o == null) {
            return false;
        }
        if (o instanceof Boolean) {
            return !((Boolean) o);
        }
        if (o instanceof Number) {
            return ((Number) o).doubleValue() == 0;
        }
        if (o instanceof String) {
            return !Boolean.valueOf((String) o);
        }
        return false;
    }
    
}
