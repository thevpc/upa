package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.impl.transform.IdentityDataTypeTransform;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.types.DataTypeTransform;

public final class CompiledCount extends CompiledAggregationFunction
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledCount(CompiledExpressionExt expression) {
        super("Count");
        protectedAddArgument(expression);
    }

    public CompiledExpressionExt getValue() {
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
    public CompiledExpressionExt copy() {
        CompiledCount o = new CompiledCount(getValue().copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }
}
