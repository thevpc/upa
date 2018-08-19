package net.vpc.upa.impl.upql.ext.expr;

import net.vpc.upa.expressions.BinaryOperator;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.types.DataTypeTransform;

public final class CompiledAnd extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public static CompiledExpressionExt tryAddCopies(CompiledExpressionExt left, CompiledExpressionExt right) {
        if (left != null) {
            left = left.copy();
        }
        if (right != null) {
            right = right.copy();
        }
        return tryAdd(left, right);
    }

    public static CompiledExpressionExt tryAdd(CompiledExpressionExt left, CompiledExpressionExt right) {
        if (left == null) {
            return right;
        }
        if (right == null) {
            return left;
        }
        return new CompiledAnd(right, left);
    }

    public CompiledAnd(CompiledExpressionExt left, Object right) {
        super(BinaryOperator.AND, left, right);
    }

    public CompiledAnd(CompiledExpressionExt left, CompiledExpressionExt right) {
        super(BinaryOperator.AND, left, right);
    }

    public DataTypeTransform getTypeTransform() {
        return IdentityDataTypeTransform.BOOLEAN;
    }

    @Override
    public boolean isValid() {
        return (getLeft() == null || getLeft().isValid()) || (getRight() == null || getRight().isValid());
    }

}
