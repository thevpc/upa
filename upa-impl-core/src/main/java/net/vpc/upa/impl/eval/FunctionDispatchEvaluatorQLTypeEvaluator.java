/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.eval;

import java.util.Map;
import net.vpc.upa.QLEvaluator;
import net.vpc.upa.QLTypeEvaluator;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.FunctionExpression;

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
            throw new net.vpc.upa.exceptions.NoSuchUPAElementException("NoSuchFunction", fct.getName());
        }
        return fe.evalObject(fct, evaluator, context);
    }

}
