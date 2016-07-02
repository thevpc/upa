package net.vpc.upa.impl.uql;

import net.vpc.upa.expressions.*;

/**
 * Created by vpc on 6/26/16.
 */
class UserExpressionToExpressionVisitor implements ExpressionVisitor {
    private final UserExpression expression;

    public UserExpressionToExpressionVisitor(UserExpression expression) {
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
