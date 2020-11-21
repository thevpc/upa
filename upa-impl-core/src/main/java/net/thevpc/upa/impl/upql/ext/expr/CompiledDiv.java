package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.expressions.BinaryOperator;

import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;

public final class CompiledDiv extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledDiv(CompiledExpressionExt left, Object right) {
        super(BinaryOperator.DIV, left, right);
    }

    public CompiledDiv(CompiledExpressionExt left, CompiledExpressionExt right) {
        super(BinaryOperator.DIV, left, right);
    }
}
