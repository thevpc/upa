package net.vpc.upa.impl.upql.ext.expr;

import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.types.DataTypeTransform;


public final class CompiledDistinct extends CompiledFunction
        implements Cloneable {
    private static final long serialVersionUID = 1L;

    public CompiledDistinct(CompiledExpressionExt expression) {
        super("Distinct");
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
        CompiledDistinct o = new CompiledDistinct(getExpression().copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

}
