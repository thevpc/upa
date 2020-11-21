package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.types.DataTypeTransform;

public final class CompiledSum extends CompiledAggregationFunction
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledSum(CompiledExpressionExt expression) {
        super("Sum");
        protectedAddArgument(expression);
    }

    public CompiledExpressionExt getExpression() {
        return getArgument(0);
    }

    public DataTypeTransform getTypeTransform() {
        return getExpression().getEffectiveDataType();
    }

    @Override
    public CompiledExpressionExt copy() {
        CompiledSum o = new CompiledSum(getExpression().copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }
}
