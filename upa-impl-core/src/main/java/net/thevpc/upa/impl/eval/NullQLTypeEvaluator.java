/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.eval;

import net.thevpc.upa.QLEvaluator;
import net.thevpc.upa.QLTypeEvaluator;
import net.thevpc.upa.expressions.Expression;
import net.thevpc.upa.expressions.Literal;

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
