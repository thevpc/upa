package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.expressions.BinaryOperator;

import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;


public final class CompiledBitOr extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledBitOr(CompiledExpressionExt left, Object right) {
        super(BinaryOperator.BIT_OR, left, right);
    }

    public CompiledBitOr(CompiledExpressionExt left, CompiledExpressionExt right) {
        super(BinaryOperator.BIT_OR, left, right);
    }
}
