package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.expressions.BinaryOperator;

import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;

public final class CompiledMinus extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledMinus(CompiledExpressionExt left, Object right) {
        super(BinaryOperator.MINUS, left, right);
    }

    public CompiledMinus(CompiledExpressionExt left, CompiledExpressionExt right) {
        super(BinaryOperator.MINUS, left, right);
    }
}
