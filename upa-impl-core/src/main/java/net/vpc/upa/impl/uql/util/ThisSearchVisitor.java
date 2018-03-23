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
 * @author taha.bensalah@gmail.com
 */
public class ThisSearchVisitor implements ExpressionVisitor {

    private ExpressionManager expressionManager;
    private boolean found;

    public ThisSearchVisitor(ExpressionManager expressionManager) {
        this.expressionManager = expressionManager;
    }

    public boolean isFound() {
        return found;
    }

    @Override
    public boolean visit(Expression expression, ExpressionTag tag) {
        if (expression instanceof Var) {
            Var v = (Var) expression;
            if (v.getApplier() == null && UQLUtils.THIS.equals(v.getName())) {
                found=true;
                return false;
            }
        }else if (expression instanceof IdExpression){
            IdExpression v = (IdExpression) expression;
            if (UQLUtils.THIS.equals(v.getAlias())) {
                found=true;
                return false;
            }
        }else if (expression instanceof UserExpression){
            Expression rr = expressionManager.parseExpression(((UserExpression) expression).getExpression());
            rr.visit(this);
            if(found){
                return false;
            }
//        }else {
//            for (TaggedExpression cc : expression.getChildren()) {
//                Expression cce = cc.getExpression();
//                if (cce != null) {
//                    if (cce instanceof UserExpression) {
//                        Expression rr = expressionManager.parseExpression(cce);
//                        rr.visit(this);
//                        if(found){
//                            return false;
//                        }
//                    } else if (cce instanceof Var) {
//                        Var v = (Var) cce;
//                        if (v.getApplier() == null && UQLUtils.THIS.equals(v.getName())) {
//                            found=true;
//                            return false;
//                        }
//                    }
//                }
//            }
        }
        return true;
    }

}
