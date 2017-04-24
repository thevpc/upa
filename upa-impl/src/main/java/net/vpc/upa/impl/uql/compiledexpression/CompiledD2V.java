package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.types.DataTypeTransform;

public class CompiledD2V extends CompiledFunction {

    private static final long serialVersionUID = 1L;

    public CompiledD2V(DefaultCompiledExpression expression) {
        super("d2v");
        protectedAddArgument(expression);
    }

    public DefaultCompiledExpression getExpression() {
        return getArgument(0);
    }

    @Override
    public DataTypeTransform getTypeTransform() {
        return IdentityDataTypeTransform.STRING;
    }

    @Override
    public DefaultCompiledExpression copy() {
        CompiledD2V o = new CompiledD2V(getExpression().copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }
}
