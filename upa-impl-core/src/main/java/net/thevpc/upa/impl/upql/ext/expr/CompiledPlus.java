package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.expressions.BinaryOperator;

import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;

public final class CompiledPlus extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledPlus(CompiledExpressionExt left, Object right) {
        super(BinaryOperator.PLUS, left, right);
    }

    public CompiledPlus(CompiledExpressionExt left, CompiledExpressionExt right) {
        super(BinaryOperator.PLUS, left, right);
    }

}
