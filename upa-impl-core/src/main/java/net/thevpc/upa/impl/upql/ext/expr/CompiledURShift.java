package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.expressions.BinaryOperator;

import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;

public final class CompiledURShift extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledURShift(CompiledExpressionExt left, Object right) {
        super(BinaryOperator.URSHIFT, left, right);
    }

    public CompiledURShift(CompiledExpressionExt left, CompiledExpressionExt right) {
        super(BinaryOperator.URSHIFT, left, right);
    }
}
