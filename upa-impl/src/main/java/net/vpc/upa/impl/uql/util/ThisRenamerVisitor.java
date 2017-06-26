/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.util;

import net.vpc.upa.ExpressionManager;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.ExpressionTag;
import net.vpc.upa.expressions.ExpressionVisitor;
import net.vpc.upa.expressions.TaggedExpression;
import net.vpc.upa.expressions.UserExpression;
import net.vpc.upa.expressions.Var;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class ThisRenamerVisitor implements ExpressionVisitor {

    private ExpressionManager expressionManager;
    private String thisName;

    public ThisRenamerVisitor(ExpressionManager expressionManager, String thisName) {
        this.expressionManager = expressionManager;
        this.thisName = thisName;
    }

    @Override
    public boolean visit(Expression expression, ExpressionTag tag) {
        for (TaggedExpression cc : expression.getChildren()) {
            Expression cce = cc.getExpression();
            if (cce != null) {
                if (cce instanceof UserExpression) {
                    Expression rr = expressionManager.parseExpression(cce);
                    rr.visit(this);
                    expression.setChild(rr, cc.getTag());
                } else if (cce instanceof Var) {
                    Var v = (Var) cce;
                    if (v.getApplier() == null && UQLUtils.THIS.equals(v.getName())) {
                        v.setName(thisName);
                    }
                }
            }
        }
        return true;
    }

}
