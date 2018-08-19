package net.vpc.upa.impl.upql.ext.expr;

import net.vpc.upa.expressions.BinaryOperator;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;

public final class CompiledLike extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledLike(CompiledExpressionExt left, Object right) {
        super(BinaryOperator.LIKE, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }

    public CompiledLike(CompiledExpressionExt left, CompiledExpressionExt right) {
        super(BinaryOperator.LIKE, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }
}
