package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.impl.uql.CompiledExpressionFactory;
import net.vpc.upa.types.DataTypeTransform;

public class CompiledBetween extends DefaultCompiledExpressionImpl
        implements Cloneable {

    private static final long serialVersionUID = 1L;
    private DefaultCompiledExpression left;
    private DefaultCompiledExpression min;
    private DefaultCompiledExpression max;

    private CompiledBetween() {
    }

    public CompiledBetween(DefaultCompiledExpression expression, Object min, Object max) {
        this(expression, CompiledExpressionFactory.toLiteral(min), CompiledExpressionFactory.toLiteral(max));
    }

    @Override
    public DataTypeTransform getTypeTransform() {
        return IdentityDataTypeTransform.BOOLEAN;
    }

    public CompiledBetween(DefaultCompiledExpression expression, DefaultCompiledExpression min, DefaultCompiledExpression max) {
        this.left = expression;
        this.min = min;
        this.max = max;
        prepareChildren(left, min, max);
    }

    public DefaultCompiledExpression getLeft() {
        return left;
    }

    public DefaultCompiledExpression getMin() {
        return min;
    }

    public DefaultCompiledExpression getMax() {
        return max;
    }

    @Override
    public boolean isValid() {
        return (left != null && left.isValid()) && (min != null && min.isValid()) && (max != null && max.isValid());
    }

    @Override
    public DefaultCompiledExpression[] getSubExpressions() {
        return new DefaultCompiledExpression[]{left, min, max};
    }

    @Override
    public void setSubExpression(int index, DefaultCompiledExpression expression) {
        switch (index) {
            case 0: {
                left = expression;
                prepareChildren(expression);
                break;
            }
            case 1: {
                min = expression;
                prepareChildren(expression);
                break;
            }
            case 2: {
                max = expression;
                prepareChildren(expression);
                break;
            }
            default: {
                throw new IllegalArgumentException("Invalid index");
            }
        }
    }

//    public synchronized String toSQL(boolean integrated, PersistenceUnitFilter database) {
//        String s = getLeft().toSQL(true, database) + " between " + getMin().toSQL(true, database) +" and "+getMax().toSQL(true, database);
//        return integrated ? "(" + s + ")" : s;
//    }
    public DefaultCompiledExpression copy() {
        CompiledBetween o = new CompiledBetween();
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        o.left = left.copy();
        o.min = min.copy();
        o.max = max.copy();
        return o;
    }
}
