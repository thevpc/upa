package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.impl.transform.IdentityDataTypeTransform;
import net.thevpc.upa.expressions.BinaryOperator;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;

public final class CompiledLessThan extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledLessThan(CompiledExpressionExt left, Object right) {
        super(BinaryOperator.LT, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }

    public CompiledLessThan(CompiledExpressionExt left, CompiledExpressionExt right) {
        super(BinaryOperator.LT, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }
}
