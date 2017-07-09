package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.types.DataTypeTransform;

public final class CompiledSum extends CompiledFunction
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
