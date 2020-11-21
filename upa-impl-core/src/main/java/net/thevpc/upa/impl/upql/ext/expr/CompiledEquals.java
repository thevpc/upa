package net.thevpc.upa.impl.upql.ext.expr;
//            BinaryExpression, Expression

import net.thevpc.upa.impl.transform.IdentityDataTypeTransform;
import net.thevpc.upa.expressions.BinaryOperator;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;

public final class CompiledEquals extends CompiledBinaryOperatorExpression
        implements Cloneable {
    private static final long serialVersionUID = 1L;

    public CompiledEquals(CompiledExpressionExt left, Object right) {
        super(BinaryOperator.EQ, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }

    public CompiledEquals(CompiledExpressionExt left, CompiledExpressionExt right) {
        super(BinaryOperator.EQ, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }
}
