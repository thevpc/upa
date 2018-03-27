package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.types.DataTypeTransform;


public class CompiledI2V extends CompiledFunction {
    private static final long serialVersionUID = 1L;

    public CompiledI2V(CompiledExpressionExt expression) {
        super("i2v");
        protectedAddArgument(expression);
    }

    public CompiledExpressionExt getExpression(){
        return getArgument(0);
    }
    
    @Override
    public DataTypeTransform getTypeTransform() {
        return IdentityDataTypeTransform.STRING;
    }

    @Override
    public CompiledExpressionExt copy() {
        CompiledI2V o=new CompiledI2V(getExpression().copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

}
