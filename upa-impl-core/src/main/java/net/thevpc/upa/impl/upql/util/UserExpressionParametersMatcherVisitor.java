package net.thevpc.upa.impl.upql.util;

import net.thevpc.upa.expressions.*;
import net.thevpc.upa.expressions.*;

/**
 * Created by vpc on 6/26/16.
 */
public class UserExpressionParametersMatcherVisitor implements ExpressionVisitor {
    private final UserExpression expression;

    public UserExpressionParametersMatcherVisitor(UserExpression expression) {
        this.expression = expression;
    }

    @Override
    public boolean visit(Expression expr, ExpressionTag tag) {
        if (expr instanceof Param) {
            Param p = (Param) expr;
            p.setValue(expression.getParameter(p.getName()));
        }
        return true;
    }
}
