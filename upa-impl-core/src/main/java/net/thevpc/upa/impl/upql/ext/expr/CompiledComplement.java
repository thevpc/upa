package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;

public final class CompiledComplement extends CompiledUnaryOperator
        implements Cloneable {
    private static final long serialVersionUID = 1L;

    public CompiledComplement(CompiledExpressionExt expression) {
        super("~", expression);
    }
    @Override
    public CompiledExpressionExt copy() {
        CompiledComplement o=new CompiledComplement(getExpression().copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

}
