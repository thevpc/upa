package net.vpc.upa.impl.upql.ext.expr;

import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.types.DataTypeTransform;

public final class CompiledAvg extends CompiledFunction
        implements Cloneable {

    private static final long serialVersionUID = 1L;

//    public Average(String fieldName,DataPrimitiveType type) {
//        this(new Var(fieldName,type));
//    }
    public CompiledAvg(CompiledExpressionExt expression) {
        super("Avg");
        protectedAddArgument(expression);
    }

    @Override
    public DataTypeTransform getTypeTransform() {
        CompiledExpressionExt expression = getExpression();
        DataTypeTransform dd = expression.getEffectiveDataType();
        if (dd != null) {
            Class c = dd.getTargetType().getPlatformType();
            if (PlatformUtils.isIntAny(c)) {
                c = Double.class;
            }
            return (IdentityDataTypeTransform.ofType(c));
        } else {
            return IdentityDataTypeTransform.DOUBLE;
        }
    }

//    public synchronized String toSQL(boolean integrated, PersistenceUnitFilter database) {
//        return "Avg(" + expression.toSQL(database) + ")";
//    }
    public CompiledExpressionExt getExpression() {
        return getArgument(0);
    }

    @Override
    public CompiledExpressionExt copy() {
        CompiledAvg o = new CompiledAvg(getExpression().copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }
}
