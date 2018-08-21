package net.vpc.upa.impl.upql.ext.expr;

import net.vpc.upa.exceptions.IllegalUPAArgumentException;
import net.vpc.upa.expressions.BinaryOperator;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.upql.CompiledExpressionFactory;
import net.vpc.upa.types.DataTypeTransform;

public abstract class CompiledBinaryOperatorExpression extends DefaultCompiledExpressionImpl
        implements Cloneable {

    private static final long serialVersionUID = 1L;
    protected CompiledExpressionExt left;
    protected CompiledExpressionExt right;
    protected BinaryOperator operator;

    public CompiledBinaryOperatorExpression(BinaryOperator operator, CompiledExpressionExt left, Object right) {
        this(operator, left, CompiledExpressionFactory.toLiteral(right));
    }

    public CompiledBinaryOperatorExpression(BinaryOperator operator, CompiledExpressionExt left, CompiledExpressionExt right) {
        this.left = left;
        this.right = right;
        DataTypeTransform leftType = null;
        DataTypeTransform rightType = null;
        if (left != null && left.getTypeTransform() != null && !left.getTypeTransform().getSourceType().getPlatformType().equals(Object.class)) {
            leftType = left.getTypeTransform();
        }
        if (right != null && right.getTypeTransform() != null && !right.getTypeTransform().getSourceType().getPlatformType().equals(Object.class)) {
            rightType = right.getTypeTransform();
        }
        if (leftType == null && rightType != null) {
            left.setTypeTransform(rightType);
        } else if (rightType == null && leftType != null) {
            right.setTypeTransform(leftType);
        }
        this.operator = operator;
        bindChildren(left, right);
    }

    public CompiledExpressionExt getLeft() {
        return left;
    }

    public CompiledExpressionExt getRight() {
        return right;
    }
    
    public CompiledExpressionExt getOther(CompiledExpressionExt r){
        if(r==left){
            return right;
        }
        if(r==right){
            return left;
        }
        throw new IllegalUPAArgumentException("Not a child");
    }

    @Override
    public boolean isValid() {
        return (getLeft() == null || getLeft().isValid()) && (getRight() == null || getRight().isValid());
    }

    @Override
    public CompiledExpressionExt[] getSubExpressions() {
        return new CompiledExpressionExt[]{left, right};
    }

    @Override
    public void setSubExpression(int index, CompiledExpressionExt expression) {
        switch (index) {
            case 0: {
                if (left != expression) {
                    unbindChildren(this.left);
                    left = expression;
                    bindChildren(left);
                }
                break;
            }
            case 1: {
                if (right != expression) {
                    unbindChildren(this.right);
                    right = expression;
                    bindChildren(right);
                }
                break;
            }
            default: {
                throw new IllegalUPAArgumentException();
            }
        }
    }

    public BinaryOperator getOperator() {
        return operator;
    }

    private String getOperatorString() {
        switch (getOperator()) {
            case AND: {
                return "AND";
            }
            case OR: {
                return "OR";
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
            case LIKE: {
                return " LIKE ";
            }
            default: {
                throw new IllegalUPAArgumentException("Not Supported Yet");
            }
        }
    }

    @Override
    public String toString() {
        String leftValue = "(" + String.valueOf(getLeft()) + ")";
        String rightValue = "(" + String.valueOf(getRight()) + ")";
        String s = leftValue + " " + getOperatorString() + " " + rightValue;
        return s;
    }

    public CompiledExpressionExt copy() {
        CompiledBinaryOperatorExpression o = create(getOperator(), getLeft().copy(), getRight().copy());
        o.setTypeTransform(getTypeTransform());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

    public static CompiledBinaryOperatorExpression create(BinaryOperator operator, CompiledExpressionExt left, CompiledExpressionExt right) {
        switch (operator) {
            case AND: {
                return new CompiledAnd(left, right);
            }
            case OR: {
                return new CompiledOr(left, right);
            }
            case BIT_AND: {
                return new CompiledBitAnd(left, right);
            }
            case BIT_OR: {
                return new CompiledBitOr(left, right);
            }
            case LSHIFT: {
                return new CompiledLShift(left, right);
            }
            case RSHIFT: {
                return new CompiledRShift(left, right);
            }
            case URSHIFT: {
                return new CompiledURShift(left, right);
            }
            case XOR: {
                return new CompiledXOr(left, right);
            }
            case DIFF: {
                return new CompiledDifferent(left, right);
            }
            case EQ: {
                return new CompiledEquals(left, right);
            }
            case GT: {
                return new CompiledGreaterThan(left, right);
            }
            case GE: {
                return new CompiledGreaterEqualThan(left, right);
            }
            case LT: {
                return new CompiledLessThan(left, right);
            }
            case LE: {
                return new CompiledLessEqualThan(left, right);
            }
            case PLUS: {
                return new CompiledPlus(left, right);
            }
            case MINUS: {
                return new CompiledMinus(left, right);
            }
            case MUL: {
                return new CompiledMul(left, right);
            }
            case DIV: {
                return new CompiledDiv(left, right);
            }
            case LIKE: {
                return new CompiledLike(left, right);
            }
            default: {
                throw new IllegalUPAArgumentException("Not Supported Yet");
            }
        }
    }
    public boolean isSameOperandsType(){
        return true;
    }
}
