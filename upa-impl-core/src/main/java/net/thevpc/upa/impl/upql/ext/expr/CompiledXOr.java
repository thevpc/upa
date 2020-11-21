package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.expressions.BinaryOperator;

import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;

public final class CompiledXOr extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledXOr(CompiledExpressionExt left, Object right) {
        super(BinaryOperator.XOR, left, right);
    }

    public CompiledXOr(CompiledExpressionExt left, CompiledExpressionExt right) {
        super(BinaryOperator.XOR, left, right);
    }
}
