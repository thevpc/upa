package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.impl.transform.IdentityDataTypeTransform;
import net.thevpc.upa.expressions.BinaryOperator;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;

public final class CompiledLessEqualThan extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledLessEqualThan(CompiledExpressionExt left, Object right) {
        super(BinaryOperator.LE, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }

    public CompiledLessEqualThan(CompiledExpressionExt left, CompiledExpressionExt right) {
        super(BinaryOperator.LE, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }
}
