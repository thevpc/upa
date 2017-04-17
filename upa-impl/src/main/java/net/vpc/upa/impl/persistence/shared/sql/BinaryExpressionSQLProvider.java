package net.vpc.upa.impl.persistence.shared.sql;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.persistence.shared.sql.AbstractSQLProvider;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.compiledexpression.CompiledBinaryOperatorExpression;
import net.vpc.upa.impl.uql.compiledexpression.CompiledSelect;
import net.vpc.upa.persistence.EntityExecutionContext;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/15/12
 * Time: 11:46 PM
 * To change this template use File | Settings | File Templates.
 */
public class BinaryExpressionSQLProvider extends AbstractSQLProvider {
    public BinaryExpressionSQLProvider() {
        super(CompiledBinaryOperatorExpression.class);
    }
    @Override
    public String getSQL(Object oo, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations) throws UPAException{
        CompiledBinaryOperatorExpression o=(CompiledBinaryOperatorExpression) oo;
        String leftValue=o.getLeft() != null ? sqlManager.getSQL(o.getLeft(), qlContext, declarations) : "NULL";
        if(o.getLeft() instanceof CompiledSelect){
            leftValue="("+leftValue+")";
        }
        String rightValue=o.getRight() != null ? sqlManager.getSQL(o.getRight(), qlContext, declarations) : "NULL";
        if(o.getRight() instanceof CompiledSelect){
            rightValue="("+rightValue+")";
        }
        String s =null;
        switch (o.getOperator()){
            case AND:{
                s=leftValue+" And "+rightValue;
                break;
            }
            case OR:{
                s=leftValue+" Or "+rightValue;
                break;
            }
            case BIT_AND:{
                s=leftValue+" & "+rightValue;
                break;
            }
            case LSHIFT:{
                s=leftValue+" << "+rightValue;
                break;
            }
            case BIT_OR:{
                s=leftValue+" | "+rightValue;
                break;
            }
            case RSHIFT:{
                s=leftValue+" >> "+rightValue;
                break;
            }
            case URSHIFT:{
                s=leftValue+" >>> "+rightValue;
                break;
            }
            case XOR:{
                s=leftValue+" ^ "+rightValue;
                break;
            }
            case DIFF:{
                if("NULL".equalsIgnoreCase(rightValue)){
                    s=leftValue+" IS NOT "+rightValue;
                }else{
                    s=leftValue+" <> "+rightValue;
                }
                break;
            }
            case EQ:{
                if("NULL".equalsIgnoreCase(rightValue)){
                    s=leftValue+" IS "+rightValue;
                }else{
                    s=leftValue+" = "+rightValue;
                }
                break;
            }
            case GT:{
                s=leftValue+" > "+rightValue;
                break;
            }
            case GE:{
                s=leftValue+" >= "+rightValue;
                break;
            }
            case LT:{
                s=leftValue+" < "+rightValue;
                break;
            }
            case LE:{
                s=leftValue+" < "+rightValue;
                break;
            }
            case PLUS:{
                s=leftValue+" + "+rightValue;
                break;
            }
            case MINUS:{
                s=leftValue+" - "+rightValue;
                break;
            }
            case MUL:{
                s=leftValue+" * "+rightValue;
                break;
            }
            case DIV:{
                s=leftValue+" - "+rightValue;
                break;
            }
            case REM:{
                s="{fn mod("+leftValue+","+rightValue+" )}";
                break;
            }
            case LIKE:{
                //escape seems to be not supported with '*' wildcard
                //s=leftValue+" Like "+rightValue+" {escape '*'} ";
                s=leftValue+" Like "+rightValue+" ";
                break;
            }
            default:{
                throw new IllegalArgumentException("Not Supported Yet");
            }
        }
        return "(" + s + ")" ;
    }
}
