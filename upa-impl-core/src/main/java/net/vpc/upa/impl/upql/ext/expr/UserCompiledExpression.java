package net.vpc.upa.impl.upql.ext.expr;

import net.vpc.upa.exceptions.UnsupportedUPAFeatureException;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.types.DataTypeTransform;

public class UserCompiledExpression extends DefaultCompiledExpressionImpl
        implements Cloneable {

    private static final long serialVersionUID = 1L;
    private final String expression;
    private DataTypeTransform dataTypeTransform;

    public UserCompiledExpression(String qlString, DataTypeTransform type) {
        this.expression = qlString;
        this.dataTypeTransform = type;
    }

//    public String toSQL(boolean integrated, PersistenceUnitFilter database) {
//
//        return //integrated? '(' + value + ')' : value;
//        value;
//    }
    @Override
    public DataTypeTransform getTypeTransform() {
        return dataTypeTransform;
    }

    public String getExpression() {
        return expression;
    }

    @Override
    public void setTypeTransform(DataTypeTransform type) {
        this.dataTypeTransform = type;
    }

    @Override
    public CompiledExpressionExt copy() {
        UserCompiledExpression o = new UserCompiledExpression(expression, dataTypeTransform);
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

    @Override
    public String toString() {
        return String.valueOf(expression);
    }

    @Override
    public CompiledExpressionExt[] getSubExpressions() {
        return null;
    }

    @Override
    public void setSubExpression(int index, CompiledExpressionExt expression) {
        throw new UnsupportedUPAFeatureException("Not supported.");
    }
}
