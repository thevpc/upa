package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.types.DataTypeTransform;

/**
 * Created by IntelliJ IDEA. User: root Date: 22 mai 2003 Time: 12:21:56 To
 * change this template use Options | File Templates.
 */
public class CompiledCast extends CompiledFunction {

    private static final long serialVersionUID = 1L;

    public CompiledCast(DefaultCompiledExpression value, DataTypeTransform primitiveType) {
        super("Cast");
        protectedAddArgument(value);
        protectedAddArgument(new CompiledTypeName(primitiveType));
    }

    public DefaultCompiledExpression getValue() {
        return getArgument(0);
    }

    public CompiledTypeName getTargetType() {
        return ((CompiledTypeName) getArgument(1));
    }

    @Override
    public DataTypeTransform getTypeTransform() {
        return getTargetType().getTypeTransform();
    }

    @Override
    public DefaultCompiledExpression copy() {
        CompiledCast o = new CompiledCast(getValue().copy(), getTypeTransform());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }
}
