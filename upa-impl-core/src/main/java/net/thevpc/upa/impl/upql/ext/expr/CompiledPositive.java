package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;

public final class CompiledPositive extends CompiledUnaryOperator
        implements Cloneable {
    private static final long serialVersionUID = 1L;

    public CompiledPositive(CompiledExpressionExt expression) {
        super("+", expression);
    }

    @Override
    public CompiledExpressionExt copy() {
        CompiledPositive o=new CompiledPositive(getExpression().copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

}
