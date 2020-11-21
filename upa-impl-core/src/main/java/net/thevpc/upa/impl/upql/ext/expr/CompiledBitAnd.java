package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.expressions.BinaryOperator;

import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;


public final class CompiledBitAnd extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledBitAnd(CompiledExpressionExt left, Object right) {
        super(BinaryOperator.BIT_AND, left, right);
    }

    public CompiledBitAnd(CompiledExpressionExt left, CompiledExpressionExt right) {
        super(BinaryOperator.BIT_AND, left, right);
    }
}
