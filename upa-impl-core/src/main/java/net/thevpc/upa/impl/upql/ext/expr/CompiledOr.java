package net.thevpc.upa.impl.upql.ext.expr;


import net.thevpc.upa.impl.transform.IdentityDataTypeTransform;
import net.thevpc.upa.expressions.BinaryOperator;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;

public final class CompiledOr extends CompiledBinaryOperatorExpression
        implements Cloneable {
    private static final long serialVersionUID = 1L;

    public CompiledOr(CompiledExpressionExt left, Object right) {
        super(BinaryOperator.OR, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }

    public CompiledOr(CompiledExpressionExt left, CompiledExpressionExt right) {
        super(BinaryOperator.OR, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }

    @Override
    public boolean isValid() {
        return (getLeft() == null || getLeft().isValid()) || (getRight() == null || getRight().isValid());
    }
}
