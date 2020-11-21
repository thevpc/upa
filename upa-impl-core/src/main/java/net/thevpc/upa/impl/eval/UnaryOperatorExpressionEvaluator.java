/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.eval;

import net.thevpc.upa.impl.upql.util.UPQLUtils;
import net.thevpc.upa.impl.util.UPAUtils;
import net.thevpc.upa.impl.util.XNumber;
import net.thevpc.upa.QLEvaluator;
import net.thevpc.upa.QLTypeEvaluator;
import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.expressions.Expression;
import net.thevpc.upa.expressions.Literal;
import net.thevpc.upa.expressions.UnaryOperatorExpression;

/**
 *
 * @author taha.bensalah@gmail.com
 */
class UnaryOperatorExpressionEvaluator implements QLTypeEvaluator {
    public static final QLTypeEvaluator INSTANCE=new UnaryOperatorExpressionEvaluator();


    public UnaryOperatorExpressionEvaluator() {
    }

    @Override
    public Expression evalObject(Expression e, QLEvaluator evaluator, Object context) {
        UnaryOperatorExpression eq = (UnaryOperatorExpression) e;
        Expression expr = evaluator.evalObject(eq.getExpression(), context);
        Object a = UPAUtils.unwrapLiteral(expr);
        if(a instanceof Expression){
            return UPQLUtils.createUnaryExpr(eq.getOperator(),expr);
        }
        switch (eq.getOperator()) {
            case POSITIVE: {
                return expr;
            }
            case NEGATIVE: {
                XNumber na = UPAUtils.toNumberOrError(a);
                if(na==null){
                    return Literal.NULL;
                }
                return new Literal(na.negate().toNumber(),null);
            }
            case COMPLEMENT: {
                XNumber na = UPAUtils.toNumber(a);
                if(na==null){
                    return Literal.NULL;
                }
                return new Literal(na.complement().toNumber(),null);
            }
            case NOT: {
                if(a instanceof Boolean) {
                    return Literal.valueOf(!((Boolean) a));
                }
                if(a instanceof Number) {
                    return Literal.valueOf(((Number) a).doubleValue()==0);
                }
                if(a instanceof String) {
                    return Literal.valueOf(!((String) a).equalsIgnoreCase("true"));
                }
                return Literal.valueOf(a==null);
            }
        }
        throw new IllegalUPAArgumentException("Not supported");
    }

}
