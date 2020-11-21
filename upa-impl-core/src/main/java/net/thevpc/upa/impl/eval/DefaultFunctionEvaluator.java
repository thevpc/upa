/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.eval;

import net.thevpc.upa.Function;
import net.thevpc.upa.impl.upql.parser.syntax.UPQLFunctionsFactory;
import net.thevpc.upa.impl.util.UPAUtils;
import net.thevpc.upa.FunctionEvalContext;
import net.thevpc.upa.QLEvaluator;
import net.thevpc.upa.QLTypeEvaluator;
import net.thevpc.upa.expressions.Expression;
import net.thevpc.upa.expressions.FunctionExpression;
import net.thevpc.upa.expressions.Literal;

import java.util.Arrays;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class DefaultFunctionEvaluator implements QLTypeEvaluator {

    private Function evaluator;

    public DefaultFunctionEvaluator(Function evaluator) {
        this.evaluator = evaluator;
    }

    @Override
    public final Expression evalObject(Expression e, QLEvaluator evaluator, Object context) {
        FunctionExpression f = (FunctionExpression) e;
        Expression[] arguments = f.getArguments();
        Object[] oarguments = new Object[arguments.length];
        boolean evaluatable = true;
        for (int i = 0; i < arguments.length; i++) {
            Expression expr = evaluator.evalObject(arguments[i], context);
            arguments[i] = expr;
            Object oo = UPAUtils.unwrapLiteral(expr);
            if (oo instanceof Expression) {
                evaluatable = false;
            } else {
                oarguments[i] = oo;
            }
        }
        if (!evaluatable) {
            return UPQLFunctionsFactory.createFunction(f.getName(), Arrays.asList(arguments));
        }
        Object v = this.evaluator.eval(new FunctionEvalContext(f.getName(), oarguments, null, null));
        return new Literal(v, null);
    }

}
