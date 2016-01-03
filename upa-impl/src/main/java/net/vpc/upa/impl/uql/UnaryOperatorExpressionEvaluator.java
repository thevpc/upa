/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql;

import net.vpc.upa.QLEvaluator;
import net.vpc.upa.QLTypeEvaluator;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.UnaryOperatorExpression;
import net.vpc.upa.impl.util.XNumber;

/**
 *
 * @author vpc
 */
class UnaryOperatorExpressionEvaluator implements QLTypeEvaluator {

    private final DefaultQLEvaluator outer;

    public UnaryOperatorExpressionEvaluator(final DefaultQLEvaluator outer) {
        this.outer = outer;
    }

    @Override
    public Object evalObject(Expression e, QLEvaluator evaluator, Object context) {
        UnaryOperatorExpression eq = (UnaryOperatorExpression) e;
        switch (eq.getOperator()) {
            case POSITIVE: {
                return evaluator.evalObject(eq.getExpression(), context);
            }
            case NEGATIVE: {
                Object a = evaluator.evalObject(eq.getExpression(), context);
                XNumber na = outer.toNumber(a);
                return na.negate().toNumber();
            }
            case COMPLEMENT: {
                Object a = evaluator.evalObject(eq.getExpression(), context);
                XNumber na = outer.toNumber(a);
                return na.complement().toNumber();
            }
        }
        throw new IllegalArgumentException("Not supported");
    }

}
