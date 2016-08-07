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
 * @author taha.bensalah@gmail.com
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
    public static Expression createUnaryExpr(UnaryOperator op,Expression a){
        switch (op){
            case COMPLEMENT:{
                return new Complement(a);
            }
            case NEGATIVE:{
                return new Negative(a);
            }
            case POSITIVE:{
                return new Positive(a);
            }
        }
        throw new RuntimeException("Unsupported");
    }

    public static Expression createBinaryExpr(BinaryOperator op,Expression r,Expression n){
        switch (op){
            case EQ: { return new Equals(r,n); }
            case DIFF: { return new Different(r,n); }
            case LT: { return new LessThan(r,n); }
            case LE: { return new LessEqualThan(r,n); }
            case GT: { return new GreaterThan(r,n); }
            case GE: { return new GreaterEqualThan(r,n); }
            case LIKE: { return new Like(r,n); }

            case AND: { return new And(r,n); }
            case OR: { return new Or(r,n); }
            case XOR: { return new XOr(r,n); }

            case BIT_AND: { return new BitAnd(r,n); }
            case BIT_OR: { return new BitOr(r,n); }
            case LSHIFT: { return new LShift(r,n); }
            case RSHIFT: { return new RShift(r,n); }
            case URSHIFT: { return new URShift(r,n); }

            case MINUS: { return new Minus(r,n); }
            case PLUS: { return new Plus(r,n); }
            case MUL: { return new Mul(r,n); }
            case DIV: { return new Div(r,n); }
            case REM: { return new Reminder(r,n); }
        }
        throw new RuntimeException("Unsupported");
    }
}
