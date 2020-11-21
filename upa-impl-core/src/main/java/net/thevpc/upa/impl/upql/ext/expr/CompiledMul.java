package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.expressions.BinaryOperator;

import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;

public final class CompiledMul extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledMul(CompiledExpressionExt left, Object right) {
        super(BinaryOperator.MUL, left, right);
    }

    public CompiledMul(CompiledExpressionExt left, CompiledExpressionExt right) {
        super(BinaryOperator.MUL, left, right);
    }
}
