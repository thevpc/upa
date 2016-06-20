/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql;

import net.vpc.upa.QLEvaluator;
import net.vpc.upa.QLTypeEvaluator;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.Literal;

/**
 *
 * @author vpc
 */
class LiteralExpressionEvaluator implements QLTypeEvaluator {

    public LiteralExpressionEvaluator() {
    }

    @Override
    public Object evalObject(Expression e, QLEvaluator evaluator, Object context) {
        return ((Literal) e).getValue();
    }
    
}
