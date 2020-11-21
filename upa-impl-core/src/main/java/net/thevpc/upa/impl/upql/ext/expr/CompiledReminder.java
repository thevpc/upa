package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.expressions.BinaryOperator;

import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;

public final class CompiledReminder extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledReminder(CompiledExpressionExt left, Object right) {
        super(BinaryOperator.REM, left, right);
    }

    public CompiledReminder(CompiledExpressionExt left, CompiledExpressionExt right) {
        super(BinaryOperator.REM, left, right);
    }
}
