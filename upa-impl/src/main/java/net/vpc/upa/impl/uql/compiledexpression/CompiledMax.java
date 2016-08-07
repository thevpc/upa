package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.types.DataTypeTransform;


public final class CompiledMax extends CompiledFunction
        implements Cloneable {
    private static final long serialVersionUID = 1L;

    public CompiledMax(DefaultCompiledExpression expression) {
        super("Max");
        protectedAddArgument(expression);
    }

   public DefaultCompiledExpression getExpression(){
        return getArgument(0);
    }
    @Override
    public DataTypeTransform getTypeTransform() {
        return getExpression().getEffectiveDataType();
    }

    @Override
    public DefaultCompiledExpression copy() {
        CompiledMax o = new CompiledMax(getExpression().copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

}
