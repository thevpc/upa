/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.eval;

import net.vpc.upa.QLEvaluator;
import net.vpc.upa.QLTypeEvaluator;
import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.Literal;
import net.vpc.upa.expressions.UnaryOperatorExpression;
import net.vpc.upa.impl.uql.util.UQLUtils;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.impl.util.XNumber;

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
            return UQLUtils.createUnaryExpr(eq.getOperator(),expr);
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
        throw new UPAIllegalArgumentException("Not supported");
    }

}
