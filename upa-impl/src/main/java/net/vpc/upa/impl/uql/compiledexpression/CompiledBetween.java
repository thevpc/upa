package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.impl.uql.CompiledExpressionFactory;
import net.vpc.upa.types.DataTypeTransform;

public class CompiledBetween extends DefaultCompiledExpressionImpl
        implements Cloneable {

    private static final long serialVersionUID = 1L;
    private CompiledExpressionExt left;
    private CompiledExpressionExt min;
    private CompiledExpressionExt max;

    private CompiledBetween() {
    }

    public CompiledBetween(CompiledExpressionExt expression, Object min, Object max) {
        this(expression, CompiledExpressionFactory.toLiteral(min), CompiledExpressionFactory.toLiteral(max));
    }

    @Override
    public DataTypeTransform getTypeTransform() {
        return IdentityDataTypeTransform.BOOLEAN;
    }

    public CompiledBetween(CompiledExpressionExt expression, CompiledExpressionExt min, CompiledExpressionExt max) {
        this.left = expression;
        this.min = min;
        this.max = max;
        bindChildren(left, min, max);
    }

    public CompiledExpressionExt getLeft() {
        return left;
    }

    public CompiledExpressionExt getMin() {
        return min;
    }

    public CompiledExpressionExt getMax() {
        return max;
    }

    @Override
    public boolean isValid() {
        return (left != null && left.isValid()) && (min != null && min.isValid()) && (max != null && max.isValid());
    }

    @Override
    public CompiledExpressionExt[] getSubExpressions() {
        return new CompiledExpressionExt[]{left, min, max};
    }

    @Override
    public void setSubExpression(int index, CompiledExpressionExt expression) {
        switch (index) {
            case 0: {
                unbindChildren(this.left);
                left = expression;
                bindChildren(expression);
                break;
            }
            case 1: {
                unbindChildren(this.min);
                min = expression;
                bindChildren(expression);
                break;
            }
            case 2: {
                unbindChildren(this.max);
                max = expression;
                bindChildren(expression);
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
    public CompiledExpressionExt copy() {
        CompiledBetween o = new CompiledBetween();
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        o.left = left.copy();
        o.min = min.copy();
        o.max = max.copy();
        return o;
    }
}
