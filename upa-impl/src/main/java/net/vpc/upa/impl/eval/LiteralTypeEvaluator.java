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
class LiteralTypeEvaluator implements QLTypeEvaluator {
    public static final QLTypeEvaluator INSTANCE=new LiteralTypeEvaluator();
    public LiteralTypeEvaluator() {
    }

    @Override
    public Expression evalObject(Expression e, QLEvaluator evaluator, Object context) {
        return e;
    }
    
}
