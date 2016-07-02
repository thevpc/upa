/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.util;

import net.vpc.upa.ExpressionManager;
import net.vpc.upa.expressions.*;

/**
 *
 * @author vpc
 */
public class UserExpressionParserVisitor implements ExpressionVisitor {

    private ExpressionManager expressionManager;

    public UserExpressionParserVisitor(ExpressionManager expressionManager) {
        this.expressionManager = expressionManager;
    }

    @Override
    public boolean visit(Expression expression, ExpressionTag tag) {
        for (TaggedExpression cc : expression.getChildren()) {
            Expression cce = cc.getExpression();
            if (cce != null) {
                if (cce instanceof UserExpression) {
                    Expression rr = expressionManager.parseExpression((UserExpression) cce);
                    rr.visit(this);
                    expression.setChild(rr, cc.getTag());
                }
            }
        }
        return true;
    }

}
