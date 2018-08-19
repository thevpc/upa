package net.vpc.upa.impl.persistence.shared.sql;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.persistence.shared.sql.AbstractSQLProvider;
import net.vpc.upa.impl.upql.ExpressionDeclarationList;
import net.vpc.upa.impl.upql.ext.expr.CompiledBinaryOperatorExpression;
import net.vpc.upa.persistence.EntityExecutionContext;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/15/12 Time: 11:46 PM To change
 * this template use File | Settings | File Templates.
 */
public class BinaryOperatorExpressionSQLProvider extends AbstractSQLProvider {

    public BinaryOperatorExpressionSQLProvider() {
        super(CompiledBinaryOperatorExpression.class);
    }

    @Override
    public String getSQL(Object oo, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations) throws UPAException {
        CompiledBinaryOperatorExpression o=(CompiledBinaryOperatorExpression) oo;
        StringBuilder sb = new StringBuilder();
        sb.append('(');
        sb.append(sqlManager.getSQL(o.getLeft(), qlContext, declarations));
        sb.append(getOperatorString(o));
        sb.append(sqlManager.getSQL(o.getRight(), qlContext, declarations));
        sb.append(')');
        return sb.toString();
    }

    private String getOperatorString(CompiledBinaryOperatorExpression expression) {
        switch (expression.getOperator()) {
            case AND: {
                return "And";
            }
            case OR: {
                return "Or";
            }
            case BIT_AND: {
                return "&";
            }
            case LSHIFT: {
                return "<<";
            }
            case BIT_OR: {
                return "|";
            }
            case RSHIFT: {
                return ">>";
            }
            case URSHIFT: {
                return ">>>";
            }
            case XOR: {
                return "^";
            }
            case DIFF: {
                return "!=";
            }
            case EQ: {
                return "=";
            }
            case GT: {
                return ">";
            }
            case GE: {
                return ">=";
            }
            case LT: {
                return "<";
            }
            case LE: {
                return "<=";
            }
            case PLUS: {
                return "+";
            }
            case MINUS: {
                return "-";
            }
            case MUL: {
                return "*";
            }
            case DIV: {
                return "/";
            }
            default: {
                throw new UPAIllegalArgumentException("Not Supported Yet");
            }
        }
    }
}
