/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.eval;

import net.vpc.upa.QLEvaluator;
import net.vpc.upa.QLEvaluatorRegistry;
import net.vpc.upa.QLExpressionParser;
import net.vpc.upa.UPA;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.ExpressionHelper;
import net.vpc.upa.expressions.Literal;
import net.vpc.upa.expressions.Var;

/**
 * @author taha.bensalah@gmail.com
 */
public class DefaultQLEvaluator implements QLEvaluator {
    private QLEvaluatorRegistry registry;

    public DefaultQLEvaluator() {
        registry = new DefaultQLEvaluatorRegistry();
    }

    public DefaultQLEvaluator(QLEvaluatorRegistry registry) {
        this.registry = registry;
    }

    public Expression evalString(String expression, Object context) {
        if (expression == null) {
            return null;
        }
        if (expression.length() == 0) {
            return new Literal("");
        }
        if (isVarName(expression)) {
            return getRegistry().getTypeEvaluator(Var.class).evalObject(new Var(expression), this, context);
        }
        QLExpressionParser parser = UPA.getBootstrap().getFactory().createObject(QLExpressionParser.class);
        Expression exprObj = parser.parse(expression);
        return evalObject(exprObj, context);
    }


    public String evalFormatted(String expr, Object context) {
        return formatResult(evalString(expr, context));
    }

    public String formatResult(Object result) {
        return result == null ? "" : result.toString();
    }

    public boolean isVarName(String s) {
        if (s == null || s.length() == 0) {
            return false;
        }
        char[] chars = s.toCharArray();
        for (int i = 0; i < chars.length; i++) {
            char c = chars[i];
            if (i == 0) {
                if (!(ExpressionHelper.isIdentifierStart(c))) {
                    return false;
                }
            } else if (!(ExpressionHelper.isIdentifierPart(c) || c == '.')) {
                return false;
            }
        }
        return true;
    }

    public Expression evalObject(Expression e, Object context) {
        return getRegistry().getTypeEvaluator(e.getClass()).evalObject(e, this, context);
    }


    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof DefaultQLEvaluator)) return false;

        DefaultQLEvaluator that = (DefaultQLEvaluator) o;

        return !(registry != null ? !registry.equals(that.registry) : that.registry != null);

    }

    @Override
    public int hashCode() {
        return registry != null ? registry.hashCode() : 0;
    }

    @Override
    public QLEvaluatorRegistry getRegistry() {
        return registry;
    }
}
