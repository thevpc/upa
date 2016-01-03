package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.types.DataTypeTransform;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/16/12 Time: 11:04 PM To change
 * this template use File | Settings | File Templates.
 */
public class CompiledTypeName extends DefaultCompiledExpressionImpl {

    private DataTypeTransform type;

    public CompiledTypeName(DataTypeTransform type) {
        this.type = type;
    }

    @Override
    public DataTypeTransform getTypeTransform() {
        return type;
    }

    @Override
    public boolean isValid() {
        return true;
    }

    @Override
    public DefaultCompiledExpression copy() {
        CompiledTypeName o = new CompiledTypeName(type);
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

    @Override
    public DefaultCompiledExpression[] getSubExpressions() {
        return null;
    }

    @Override
    public void setSubExpression(int index, DefaultCompiledExpression expression) {
        throw new UnsupportedOperationException("Not supported.");
    }

    @Override
    public String toString() {
        return String.valueOf(type);
    }
    
}
