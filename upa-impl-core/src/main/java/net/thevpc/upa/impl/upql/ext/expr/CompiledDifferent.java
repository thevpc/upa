package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.impl.transform.IdentityDataTypeTransform;
import net.thevpc.upa.expressions.BinaryOperator;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;

public final class CompiledDifferent extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledDifferent(CompiledExpressionExt left, Object right) {
        super(BinaryOperator.DIFF, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }

    public CompiledDifferent(CompiledExpressionExt left, CompiledExpressionExt right) {
        super(BinaryOperator.DIFF, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }
}
