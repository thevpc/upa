package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.impl.uql.CompiledExpressionFactory;

import java.util.List;
import net.vpc.upa.types.DataTypeTransform;

public final class CompiledCoalesce extends CompiledFunction
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledCoalesce() {
        super("Coalesce");
    }

    public CompiledCoalesce(List<DefaultCompiledExpression> expressions) {
        this();
        for (DefaultCompiledExpression expression : expressions) {
            add(expression);
        }
    }

    public CompiledCoalesce(DefaultCompiledExpression... expressions) {
        this();
        for (DefaultCompiledExpression expression : expressions) {
            add(expression);
        }
    }

    public CompiledCoalesce add(Object varName) {
        return add(CompiledExpressionFactory.toVar(varName));
    }

    public CompiledCoalesce add(DefaultCompiledExpression expression) {
        protectedAddArgument(expression);
        return this;
    }

//    public synchronized String toSQL(boolean integrated, PersistenceUnitFilter database) {
//        StringBuffer sb = new StringBuffer("Coalesce(");
//        int max = size();
//        boolean started = false;
//        for (int i = 0; i < max; i++) {
//            Expression e = get(i);
//            if (e.isValid()) {
//                if (started){
//                    sb.append(", ");
//                }else{
//                    started = true;
//                }
//                sb.append(e.toSQL(true, database));
//            }
//        }
//        sb.append(')');
//        return sb.toString();
//    }
    public DefaultCompiledExpression copy() {
        CompiledCoalesce o = new CompiledCoalesce();
        protectedCopyTo(o);
        return o;
    }

    @Override
    public DataTypeTransform getTypeTransform() {
        for (DefaultCompiledExpression a : getArguments()) {
            DataTypeTransform t = a.getEffectiveDataType();
            if (t != null && !t.getTargetType().getPlatformType().equals(Object.class)) {
                return t;
            }
        }
        return super.getTypeTransform();
    }

}
