/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.eval;

import java.util.Map;

import net.thevpc.upa.exceptions.NoSuchUPAElementException;
import net.thevpc.upa.QLEvaluator;
import net.thevpc.upa.QLTypeEvaluator;
import net.thevpc.upa.expressions.Expression;
import net.thevpc.upa.expressions.FunctionExpression;

/**
 *
 * @author taha.bensalah@gmail.com
 */
class FunctionDispatchEvaluatorQLTypeEvaluator implements QLTypeEvaluator {

    private Map<String, QLTypeEvaluator> functionsEvaluators;

    public FunctionDispatchEvaluatorQLTypeEvaluator(Map<String, QLTypeEvaluator> functionsEvaluators) {
        this.functionsEvaluators = functionsEvaluators;
    }

    @Override
    public Expression evalObject(Expression e, QLEvaluator evaluator, Object context) {
        FunctionExpression fct = (FunctionExpression) e;
        QLTypeEvaluator fe = functionsEvaluators.get(fct.getName().toLowerCase());
        if (fe == null) {
            throw new NoSuchUPAElementException("NoSuchFunction", fct.getName());
        }
        return fe.evalObject(fct, evaluator, context);
    }

}
