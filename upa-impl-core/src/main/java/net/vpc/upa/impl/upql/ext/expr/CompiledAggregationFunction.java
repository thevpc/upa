package net.vpc.upa.impl.upql.ext.expr;

import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;


public abstract class CompiledAggregationFunction extends CompiledFunction
        implements Cloneable {
    private static final long serialVersionUID = 1L;

    public CompiledAggregationFunction(String name) {
        super(name);
    }

    public CompiledExpressionExt getValue() {
        return getArgument(0);
    }
}
