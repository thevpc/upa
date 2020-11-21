package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.types.DataTypeTransform;

public final class CompiledMin extends CompiledAggregationFunction
        implements Cloneable {

    private static final long serialVersionUID = 1L;

//    public Min(String fieldName,DataType type) {
//        this(new Var(fieldName,type));
//    }
    public CompiledMin(CompiledExpressionExt expression) {
        super("Min");
        protectedAddArgument(expression);
    }

    public CompiledExpressionExt getExpression() {
        return getArgument(0);
    }

    @Override
    public DataTypeTransform getTypeTransform() {
        return getExpression().getEffectiveDataType();
    }

    @Override
    public CompiledExpressionExt copy() {
        CompiledMin o = new CompiledMin(getExpression().copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }
}
