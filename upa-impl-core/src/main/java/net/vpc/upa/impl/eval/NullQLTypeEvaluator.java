/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.eval;

import net.vpc.upa.QLEvaluator;
import net.vpc.upa.QLTypeEvaluator;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.Literal;

/**
 *
 * @author taha.bensalah@gmail.com
 */
class NullQLTypeEvaluator implements QLTypeEvaluator {
    public static final QLTypeEvaluator instance=new NullQLTypeEvaluator();

    public NullQLTypeEvaluator() {
    }

    @Override
    public Expression evalObject(Expression e, QLEvaluator evaluator, Object context) {
        return Literal.NULL;
    }
    
}
