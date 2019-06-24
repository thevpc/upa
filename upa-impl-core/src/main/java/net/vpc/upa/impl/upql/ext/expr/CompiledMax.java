package net.vpc.upa.impl.upql.ext.expr;

import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.types.DataTypeTransform;


public final class CompiledMax extends CompiledAggregationFunction
        implements Cloneable {
    private static final long serialVersionUID = 1L;

    public CompiledMax(CompiledExpressionExt expression) {
        super("Max");
        protectedAddArgument(expression);
    }

   public CompiledExpressionExt getExpression(){
        return getArgument(0);
    }
    @Override
    public DataTypeTransform getTypeTransform() {
        return getExpression().getEffectiveDataType();
    }

    @Override
    public CompiledExpressionExt copy() {
        CompiledMax o = new CompiledMax(getExpression().copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

}
