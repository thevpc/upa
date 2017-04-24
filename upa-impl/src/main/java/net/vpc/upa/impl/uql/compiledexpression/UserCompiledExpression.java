package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.types.DataTypeTransform;

public class UserCompiledExpression extends DefaultCompiledExpressionImpl
        implements Cloneable {

    private static final long serialVersionUID = 1L;
    private String expression;
    private DataTypeTransform type;

    public UserCompiledExpression(String qlString, DataTypeTransform type) {
        this.expression = qlString;
        this.type = type;
    }

//    public String toSQL(boolean integrated, PersistenceUnitFilter database) {
//
//        return //integrated? '(' + value + ')' : value;
//        value;
//    }
    @Override
    public DataTypeTransform getTypeTransform() {
        return type;
    }

    public String getExpression() {
        return expression;
    }

    @Override
    public void setTypeTransform(DataTypeTransform type) {
        this.type = type;
    }

    @Override
    public DefaultCompiledExpression copy() {
        UserCompiledExpression o = new UserCompiledExpression(expression, type);
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

    @Override
    public String toString() {
        return String.valueOf(expression);
    }

    @Override
    public DefaultCompiledExpression[] getSubExpressions() {
        return null;
    }

    @Override
    public void setSubExpression(int index, DefaultCompiledExpression expression) {
        throw new UnsupportedOperationException("Not supported.");
    }
}
