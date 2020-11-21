package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.expressions.BinaryOperator;

import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;


public final class CompiledRShift extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledRShift(CompiledExpressionExt left, Object right) {
        super(BinaryOperator.RSHIFT, left, right);
    }

    public CompiledRShift(CompiledExpressionExt left, CompiledExpressionExt right) {
        super(BinaryOperator.RSHIFT, left, right);
    }
}
