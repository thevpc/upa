/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.util;

import net.vpc.upa.ExpressionManager;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.ExpressionVisitor;

/**
 *
 * @author vpc
 */
public class UQLUtils {

    public static void replaceThisVar(Expression expression, String newName, PersistenceUnit pu) {
        replaceThisVar(expression, newName, pu.getExpressionManager());
    }
    
    public static void replaceThisVar(Expression expression, String newName, ExpressionManager expressionManager) {
        ExpressionVisitor expressionVisitor = new ThisRenamerVisitor(expressionManager, newName);
        expression.visit(expressionVisitor);
    }

}
