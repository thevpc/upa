package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.types.DataType;
import net.vpc.upa.types.DataTypeTransform;

public final class CompiledMin extends CompiledFunction
        implements Cloneable {

    private static final long serialVersionUID = 1L;

//    public Min(String fieldName,DataType type) {
//        this(new Var(fieldName,type));
//    }
    public CompiledMin(DefaultCompiledExpression expression) {
        super("Min");
        protectedAddArgument(expression);
    }

    public DefaultCompiledExpression getExpression() {
        return getArgument(0);
    }

    @Override
    public DataTypeTransform getTypeTransform() {
        return getExpression().getEffectiveDataType();
    }

    @Override
    public DefaultCompiledExpression copy() {
        CompiledMin o = new CompiledMin(getExpression().copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }
}
