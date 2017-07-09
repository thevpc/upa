package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;

public final class CompiledNegative extends CompiledUnaryOperator
        implements Cloneable {
    private static final long serialVersionUID = 1L;

    public CompiledNegative(CompiledExpressionExt expression) {
        super("-", expression);
    }
    @Override
    public CompiledExpressionExt copy() {
        CompiledNegative o=new CompiledNegative(getExpression().copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

}
