/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql;

import net.vpc.upa.QLEvaluator;
import net.vpc.upa.QLTypeEvaluator;
import net.vpc.upa.expressions.Expression;

/**
 *
 * @author vpc
 */
class NullQLTypeEvaluator implements QLTypeEvaluator {

    public NullQLTypeEvaluator() {
    }

    @Override
    public Object evalObject(Expression e, QLEvaluator evaluator, Object context) {
        return null;
    }
    
}
