package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.types.DataTypeTransform;

public abstract class CompiledUnaryOperator extends DefaultCompiledExpressionImpl
        implements Cloneable {

    private static final long serialVersionUID = 1L;
    private String operator;
    private DefaultCompiledExpression expression;

    public CompiledUnaryOperator(String operator, DefaultCompiledExpression expression) {
        this.operator = operator;
        this.expression = expression;
        prepareChildren(expression);
    }

    public int size() {
        return 1;
    }

    @Override
    public DataTypeTransform getTypeTransform() {
        return expression.getTypeTransform();
    }

    @Override
    public boolean isValid() {
        return expression.isValid();
    }

    @Override
    public void setSubExpression(int index, DefaultCompiledExpression expression) {
        if (index == 0) {
            this.expression = expression;
            prepareChildren(expression);
        } else {
            throw new IllegalArgumentException("Invalid Index");
        }
    }

    @Override
    public DefaultCompiledExpression[] getSubExpressions() {
        return new DefaultCompiledExpression[]{expression};
    }

//    public synchronized String toSQL(boolean integrated, PersistenceUnitFilter database) {
//        return operator + expression.toSQL(true, database);
//    }
    public DefaultCompiledExpression getExpression() {
        return expression;
    }

    public String getOperator() {
        return operator;
    }
}
