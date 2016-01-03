/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql;

import java.util.NoSuchElementException;
import net.vpc.upa.QLEvaluator;
import net.vpc.upa.QLTypeEvaluator;
import net.vpc.upa.expressions.Expression;

/**
 *
 * @author vpc
 */
class NotFoundEvaluatorQLTypeEvaluator implements QLTypeEvaluator {

    public NotFoundEvaluatorQLTypeEvaluator() {
    }

    @Override
    public Object evalObject(Expression e, QLEvaluator evaluator, Object context) {
        throw new NoSuchElementException("No evaluator for " + e);
    }
    
}
