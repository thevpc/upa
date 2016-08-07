package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.types.DataTypeTransform;


// Referenced classes of package net.vpc.lib.pheromone.ariana.database.sql:
//            Expression

public class CompiledI2V extends CompiledFunction {
    private static final long serialVersionUID = 1L;

    public CompiledI2V(DefaultCompiledExpression expression) {
        super("i2v");
        protectedAddArgument(expression);
    }

    public DefaultCompiledExpression getExpression(){
        return getArgument(0);
    }
    
    @Override
    public DataTypeTransform getTypeTransform() {
        return IdentityDataTypeTransform.STRING;
    }

    @Override
    public DefaultCompiledExpression copy() {
        CompiledI2V o=new CompiledI2V(getExpression().copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

}
