/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql;

import java.util.Map;
import java.util.NoSuchElementException;
import net.vpc.upa.QLEvaluator;
import net.vpc.upa.QLTypeEvaluator;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.Function;

/**
 *
 * @author vpc
 */
class FunctionDispacthEvaluatorQLTypeEvaluator implements QLTypeEvaluator {
    private Map<String, QLTypeEvaluator> functionsEvaluators;

    public FunctionDispacthEvaluatorQLTypeEvaluator(Map<String, QLTypeEvaluator> functionsEvaluators) {
        this.functionsEvaluators = functionsEvaluators;
    }

    @Override
    public Object evalObject(Expression e, QLEvaluator evaluator, Object context) {
        Function fct = (Function) e;
        QLTypeEvaluator fe = functionsEvaluators.get(fct.getName());
        if (fe == null) {
            throw new NoSuchElementException("function not found " + fct.getName());
        }
        return fe.evalObject(fct, evaluator, context);
    }
    
}
