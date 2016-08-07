/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.eval;

import net.vpc.upa.QLEvaluator;
import net.vpc.upa.QLTypeEvaluator;
import net.vpc.upa.expressions.*;
import net.vpc.upa.impl.uql.util.UQLUtils;
import net.vpc.upa.impl.util.PatternType;
import net.vpc.upa.impl.util.StringUtils;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.impl.util.XNumber;

/**
 *
 * @author taha.bensalah@gmail.com
 */
class BinaryOperatorExpressionEvaluator implements QLTypeEvaluator {
    public static final QLTypeEvaluator INSTANCE=new BinaryOperatorExpressionEvaluator();

    public BinaryOperatorExpressionEvaluator() {
    }

    @Override
    public Expression evalObject(Expression e, QLEvaluator evaluator, Object context) {
        BinaryOperatorExpression eq = (BinaryOperatorExpression) e;
        Expression a0 = evaluator.evalObject(eq.getLeft(), context);
        Expression b0 = evaluator.evalObject(eq.getRight(), context);
        Object a = UPAUtils.unwrapLiteral(a0);
        Object b = UPAUtils.unwrapLiteral(b0);
        if((a instanceof Expression) || (b instanceof Expression)){
            //could not simplify
//            if(!(a instanceof Expression)){
//                a=new Literal(a,null);
//            }
//            if(!(b instanceof Expression)){
//                b=new Literal(a,null);
//            }
            return UQLUtils.createBinaryExpr(eq.getOperator(),a0,b0);
        }
        switch (eq.getOperator()) {
            case AND:
                {
                    if (!((Boolean) a)) {
                        return Literal.FALSE;
                    }
                    return ((Boolean) b)?Literal.TRUE:Literal.FALSE;
                }
            case OR:
                {
                    if (((Boolean) a)) {
                        return Literal.TRUE;
                    }
                    return ((Boolean) b)?Literal.TRUE:Literal.FALSE;
                }
            case EQ:
                {
                    return (UPAUtils.equals(a, b) || UPAUtils.equals(a == null ? "" : a.toString(), b == null ? "" : b.toString()))
                            ?Literal.TRUE:Literal.FALSE;
                }
            case DIFF:
                {
                    return (!UPAUtils.equals(a, b) && !UPAUtils.equals(a == null ? "" : a.toString(), b == null ? "" : b.toString()))
                            ?Literal.TRUE:Literal.FALSE;
                }
            case GE:
                {
                    XNumber na = UPAUtils.toNumberOrError(a);
                    XNumber nb = UPAUtils.toNumberOrError(b);
                    return (XNumber.compare(na,nb) >= 0)?Literal.TRUE:Literal.FALSE;
                }
            case GT:
                {
                    XNumber na = UPAUtils.toNumberOrError(a);
                    XNumber nb = UPAUtils.toNumberOrError(b);
                    return (XNumber.compare(na, nb) > 0)?Literal.TRUE:Literal.FALSE;
                }
            case LE:
                {
                    XNumber na = UPAUtils.toNumberOrError(a);
                    XNumber nb = UPAUtils.toNumberOrError(b);
                    return (XNumber.compare(na, nb) <= 0)?Literal.TRUE:Literal.FALSE;
                }
            case LT:
                {
                    XNumber na = UPAUtils.toNumberOrError(a);
                    XNumber nb = UPAUtils.toNumberOrError(b);
                    return (XNumber.compare(na, nb) < 0)?Literal.TRUE:Literal.FALSE;
                }
            case PLUS:
                {
                    if (a instanceof String || b instanceof String) {
                        return new Literal(formatResult(a) + formatResult(b));
                    }
                    XNumber na = UPAUtils.toNumberOrError(a);
                    XNumber nb = UPAUtils.toNumberOrError(b);
                    if(na==null){
                        return new Literal(nb,null);
                    }
                    if(nb==null){
                        return new Literal(na,null);
                    }
                    return new Literal(na.add(nb).toNumber(),null);
                }
            case MINUS:
                {
                    XNumber na = UPAUtils.toNumberOrError(a);
                    XNumber nb = UPAUtils.toNumberOrError(b);
                    if(na==null){
                        return new Literal(nb.negate(),null);
                    }
                    if(nb==null){
                        return new Literal(na,null);
                    }
                    return new Literal(na.subtract(nb).toNumber(),null);
                }
            case DIV:
                {
                    XNumber na = UPAUtils.toNumberOrError(a);
                    XNumber nb = UPAUtils.toNumberOrError(b);
                    if(na==null){
                        return Literal.ZERO;
                    }
                    if(nb==null){
                        return new Literal(Double.NaN);
                    }
                    return new Literal(na.divide(nb).toNumber(),null);
                }
            case MUL:
                {
                    XNumber na = UPAUtils.toNumberOrError(a);
                    XNumber nb = UPAUtils.toNumberOrError(b);
                    if(na==null){
                        return Literal.ZERO;
                    }
                    if(nb==null){
                        return Literal.ZERO;
                    }
                    return new Literal(na.multiply(nb).toNumber(),null);
                }
            case LIKE:
                {
                    if(a==null){
                        a="";
                    }
                    if(b==null){
                        b="";
                    }
                    a=formatResult(a);
                    b=formatResult(b);
                    String val = (String) a;
                    String pattern = ((String) b).replace('%','*');
                    return StringUtils.matchesSimpleExpression(val, pattern, PatternType.ANY)?Literal.TRUE:Literal.FALSE;
                }
        }
        //TODO other binary operators
        throw new IllegalArgumentException("Not supported");
    }

    public String formatResult(Object result) {
        return result == null ? "" : result.toString();
    }

}
