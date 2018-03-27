package net.vpc.upa.impl.uql.compiledexpression;


import net.vpc.upa.expressions.BinaryOperator;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;

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
