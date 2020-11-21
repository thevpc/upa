package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.impl.transform.IdentityDataTypeTransform;
import net.thevpc.upa.expressions.BinaryOperator;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;

public final class CompiledGreaterThan extends CompiledBinaryOperatorExpression
        implements Cloneable {
    private static final long serialVersionUID = 1L;

    public CompiledGreaterThan(CompiledExpressionExt left, Object right) {
        super(BinaryOperator.GT, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }

    public CompiledGreaterThan(CompiledExpressionExt left, CompiledExpressionExt right) {
        super(BinaryOperator.GT, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }

}
