/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql;

import net.vpc.upa.QLTypeEvaluator;
import net.vpc.upa.QLEvaluator;
import java.util.HashMap;
import java.util.Map;
import net.vpc.upa.QLExpressionParser;
import net.vpc.upa.UPA;
import net.vpc.upa.expressions.BinaryOperatorExpression;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.ExpressionHelper;
import net.vpc.upa.expressions.Function;
import net.vpc.upa.expressions.If;
import net.vpc.upa.expressions.Literal;
import net.vpc.upa.expressions.Not;
import net.vpc.upa.expressions.UnaryOperatorExpression;
import net.vpc.upa.expressions.Var;
import net.vpc.upa.impl.util.XNumber;

/**
 *
 * @author vpc
 */
public class DefaultQLEvaluator implements QLEvaluator {

    private Map<Class, QLTypeEvaluator> evaluators = new HashMap<Class, QLTypeEvaluator>();
    private Map<String, QLTypeEvaluator> functionsEvaluators = new HashMap<String, QLTypeEvaluator>();
    private QLTypeEvaluator nullEvaluator = new NullQLTypeEvaluator();
    private QLTypeEvaluator notFoundEvaluator = new NotFoundEvaluatorQLTypeEvaluator();

    private QLTypeEvaluator functionDispacthEvaluator;

    public DefaultQLEvaluator() {
        functionDispacthEvaluator = new FunctionDispacthEvaluatorQLTypeEvaluator(functionsEvaluators);
        registerTypeEvaluator(null, nullEvaluator);
        registerTypeEvaluator(Function.class, functionDispacthEvaluator);
        registerTypeEvaluator(Literal.class, new LiteralExpressionEvaluator());
        registerTypeEvaluator(UnaryOperatorExpression.class, new UnaryOperatorExpressionEvaluator(this));
        registerTypeEvaluator(If.class, new IfExpressionEvaluator());
        registerTypeEvaluator(BinaryOperatorExpression.class, new BinaryOperatorExpressionEvaluator(this));
        registerTypeEvaluator(Not.class, new NotExpressionEvaluator());
        registerFunctionEvaluator("file_exists", new FileExistsExpressionEvaluator());
    }

    public Object evalString(String expression, Object context) {
        if (expression == null) {
            return null;
        }
        if (expression.length() == 0) {
            return "";
        }
        if (isVarName(expression)) {
            return getTypeEvaluator(Var.class).evalObject(new Var(expression), this, context);
        }
        QLExpressionParser parser = UPA.getBootstrapFactory().createObject(QLExpressionParser.class);
        Expression exprObj = parser.parse(expression);
        return evalObject(exprObj, context);
    }

    public void registerFunctionEvaluator(String name, QLTypeEvaluator t) {
        functionsEvaluators.put(name, t);
    }

    public void registerTypeEvaluator(Class type, QLTypeEvaluator t) {
        evaluators.put(type, t);
    }

    public QLTypeEvaluator getTypeEvaluator(Class type) {
        QLTypeEvaluator y = evaluators.get(type);
        if (y != null) {
            return y;
        }
        if (type == null) {
            return nullEvaluator;
        }
        for (Map.Entry<Class, QLTypeEvaluator> en : evaluators.entrySet()) {
            if (en.getKey() != null && en.getKey().isAssignableFrom(type)) {
                return en.getValue();
            }
        }
        return notFoundEvaluator;
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

    public Object evalObject(Expression e, Object context) {
        return getTypeEvaluator(e.getClass()).evalObject(e, this, context);
    }

    XNumber toNumber(Object o) {
        if (o == null) {
            return new XNumber(0);
        }
        if (o instanceof String) {
            return new XNumber(Double.valueOf((String) o));
        }
        return new XNumber((Number) o);
    }

    @Override
    public int hashCode() {
        int hash = 3;
        hash = 31 * hash;
        return hash;
    }

    @Override
    public boolean equals(Object obj) {
        if (obj == null) {
            return false;
        }
        if (getClass() != obj.getClass()) {
            return false;
        }
        return true;
    }

}
