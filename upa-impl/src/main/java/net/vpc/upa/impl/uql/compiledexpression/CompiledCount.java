package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.types.DataTypeTransform;

public final class CompiledCount extends CompiledFunction
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledCount(DefaultCompiledExpression expression) {
        super("Count");
        protectedAddArgument(expression);
    }

    public DefaultCompiledExpression getValue() {
        return getArgument(0);
    }

    @Override
    public DataTypeTransform getTypeTransform() {
        return IdentityDataTypeTransform.LONG;
    }

//    public synchronized String toSQL(boolean integrated, PersistenceUnitFilter database) {
//        return "Count(" + expression.toSQL(database) + ")";
//    }
    @Override
    public DefaultCompiledExpression copy() {
        CompiledCount o = new CompiledCount(getValue().copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }
}
