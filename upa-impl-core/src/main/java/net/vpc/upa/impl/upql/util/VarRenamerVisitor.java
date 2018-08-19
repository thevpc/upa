/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.upql.util;

import net.vpc.upa.ExpressionManager;
import net.vpc.upa.expressions.*;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class VarRenamerVisitor implements ExpressionVisitor {

    private ExpressionManager expressionManager;
    private String oldName;
    private String newName;

    public VarRenamerVisitor(ExpressionManager expressionManager, String oldName,String newName) {
        this.expressionManager = expressionManager;
        this.oldName = oldName;
        this.newName = newName;
    }

    @Override
    public boolean visit(Expression expression, ExpressionTag tag) {
        if (expression instanceof Var) {
            Var v = (Var) expression;
            if (v.getApplier() == null && oldName.equals(v.getName())) {
                v.setName(newName);
            }
        }else if (expression instanceof IdExpression){
            IdExpression v = (IdExpression) expression;
            if (oldName.equals(v.getAlias())) {
                v.setAlias(newName);
            }
        }else {
            for (TaggedExpression cc : expression.getChildren()) {
                Expression cce = cc.getExpression();
                if (cce != null) {
                    if (cce instanceof UserExpression) {
                        Expression rr = expressionManager.parseExpression(cce);
                        rr.visit(this);
                        expression.setChild(rr, cc.getTag());
                    } else if (cce instanceof Var) {
                        Var v = (Var) cce;
                        if (v.getApplier() == null && oldName.equals(v.getName())) {
                            v.setName(newName);
                        }
                    }
                }
            }
        }
        return true;
    }

}
