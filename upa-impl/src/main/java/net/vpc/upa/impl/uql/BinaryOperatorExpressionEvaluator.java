/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql;

import java.util.Objects;
import net.vpc.upa.QLEvaluator;
import net.vpc.upa.QLTypeEvaluator;
import net.vpc.upa.expressions.BinaryOperatorExpression;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.impl.util.Strings;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.impl.util.XNumber;

/**
 *
 * @author vpc
 */
class BinaryOperatorExpressionEvaluator implements QLTypeEvaluator {
    private final DefaultQLEvaluator outer;

    public BinaryOperatorExpressionEvaluator(final DefaultQLEvaluator outer) {
        this.outer = outer;
    }

    @Override
    public Object evalObject(Expression e, QLEvaluator evaluator, Object context) {
        BinaryOperatorExpression eq = (BinaryOperatorExpression) e;
        switch (eq.getOperator()) {
            case AND:
                {
                    Object a = evaluator.evalObject(eq.getLeft(), context);
                    if (!((Boolean) a)) {
                        return false;
                    }
                    Object b = evaluator.evalObject(eq.getRight(), context);
                    return (Boolean) b;
                }
            case OR:
                {
                    Object a = evaluator.evalObject(eq.getLeft(), context);
                    if ((Boolean) a) {
                        return true;
                    }
                    Object b = evaluator.evalObject(eq.getRight(), context);
                    return ((Boolean) a) || ((Boolean) b);
                }
            case EQ:
                {
                    Object a = evaluator.evalObject(eq.getLeft(), context);
                    Object b = evaluator.evalObject(eq.getRight(), context);
                    return UPAUtils.equals(a, b) || UPAUtils.equals(a == null ? "" : a.toString(), b == null ? "" : b.toString());
                }
            case DIFF:
                {
                    Object a = evaluator.evalObject(eq.getLeft(), context);
                    Object b = evaluator.evalObject(eq.getRight(), context);
                    return !UPAUtils.equals(a, b) && !UPAUtils.equals(a == null ? "" : a.toString(), b == null ? "" : b.toString());
                }
            case GE:
                {
                    Object a = evaluator.evalObject(eq.getLeft(), context);
                    Object b = evaluator.evalObject(eq.getRight(), context);
                    XNumber na = outer.toNumber(a);
                    XNumber nb = outer.toNumber(b);
                    return na.comparetTo(nb) >= 0;
                }
            case GT:
                {
                    Object a = evaluator.evalObject(eq.getLeft(), context);
                    Object b = evaluator.evalObject(eq.getRight(), context);
                    XNumber na = outer.toNumber(a);
                    XNumber nb = outer.toNumber(b);
                    return na.comparetTo(nb) > 0;
                }
            case LE:
                {
                    Object a = evaluator.evalObject(eq.getLeft(), context);
                    Object b = evaluator.evalObject(eq.getRight(), context);
                    XNumber na = outer.toNumber(a);
                    XNumber nb = outer.toNumber(b);
                    return na.comparetTo(nb) <= 0;
                }
            case LT:
                {
                    Object a = evaluator.evalObject(eq.getLeft(), context);
                    Object b = evaluator.evalObject(eq.getRight(), context);
                    XNumber na = outer.toNumber(a);
                    XNumber nb = outer.toNumber(b);
                    return na.comparetTo(nb) < 0;
                }
            case PLUS:
                {
                    Object a = evaluator.evalObject(eq.getLeft(), context);
                    Object b = evaluator.evalObject(eq.getRight(), context);
                    if (a instanceof String || b instanceof String) {
                        return outer.formatResult(a) + outer.formatResult(b);
                    }
                    XNumber na = outer.toNumber(a);
                    XNumber nb = outer.toNumber(b);
                    return na.add(nb).toNumber();
                }
            case MINUS:
                {
                    Object a = evaluator.evalObject(eq.getLeft(), context);
                    Object b = evaluator.evalObject(eq.getRight(), context);
                    XNumber na = outer.toNumber(a);
                    XNumber nb = outer.toNumber(b);
                    return na.subtract(nb).toNumber();
                }
            case DIV:
                {
                    Object a = evaluator.evalObject(eq.getLeft(), context);
                    Object b = evaluator.evalObject(eq.getRight(), context);
                    XNumber na = outer.toNumber(a);
                    XNumber nb = outer.toNumber(b);
                    return na.divide(nb).toNumber();
                }
            case MUL:
                {
                    Object a = evaluator.evalObject(eq.getLeft(), context);
                    Object b = evaluator.evalObject(eq.getRight(), context);
                    XNumber na = outer.toNumber(a);
                    XNumber nb = outer.toNumber(b);
                    return na.multiply(nb).toNumber();
                }
            case LIKE:
                {
                    Object a = evaluator.evalObject(eq.getLeft(), context);
                    Object b = evaluator.evalObject(eq.getRight(), context);
                    return Strings.matchesSimpleExpression((String) a, (String) b);
                }
        }
        throw new IllegalArgumentException("Not supported");
    }
    
}
