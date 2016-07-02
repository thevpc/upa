/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.util;

import net.vpc.upa.ExpressionManager;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.expressions.*;

import java.util.Arrays;

/**
 *
 * @author vpc
 */
public class UQLUtils {

    public static Expression parseUserExpressions(Expression expression, PersistenceUnit pu) {
        if(expression instanceof UserExpression){
            return pu.getExpressionManager().parseExpression((UserExpression) expression);
        }
        UserExpressionParserVisitor v=new UserExpressionParserVisitor(pu.getExpressionManager());
        expression.visit(v);
        return expression;
    }

    public static void replaceThisVar(Expression expression, String newName, PersistenceUnit pu) {
        replaceThisVar(expression, newName, pu.getExpressionManager());
    }
    
    public static void replaceThisVar(Expression expression, String newName, ExpressionManager expressionManager) {
        ExpressionVisitor expressionVisitor = new ThisRenamerVisitor(expressionManager, newName);
        expression.visit(expressionVisitor);
    }

    public static String[] resolveEntityAndAlias(Select select) {
        String e = select.getEntityName();
        if(e!=null){
            return new String[]{e,select.getEntityAlias()};
        }
        return null;
    }

    public static String[] resolveEntityAndAlias(QueryStatement select) {
        if(select instanceof Select){
            return resolveEntityAndAlias((Select) select);
        }
        if(select instanceof Union){
            Union u=(Union) select;
            String[] last=null;
            for (QueryStatement queryStatement : u.getQueryStatements()) {
                String[] s = resolveEntityAndAlias(queryStatement);
                if(s==null) {
                    return null;
                }else if(last==null){
                    last=s;
                }else{
                    if(!Arrays.equals(last,s)){
                        return null;
                    }
                }
            }
            return last;
        }
        return null;
    }

}
