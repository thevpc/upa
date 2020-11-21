package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.exceptions.UnsupportedUPAFeatureException;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.types.DataTypeTransform;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/16/12 Time: 11:04 PM To change
 * this template use File | Settings | File Templates.
 */
public class CompiledTypeName extends DefaultCompiledExpressionImpl {

    private DataTypeTransform dataTypeTransform;

    public CompiledTypeName(DataTypeTransform type) {
        this.dataTypeTransform = type;
    }

    @Override
    public DataTypeTransform getTypeTransform() {
        return dataTypeTransform;
    }

    @Override
    public boolean isValid() {
        return true;
    }

    @Override
    public CompiledExpressionExt copy() {
        CompiledTypeName o = new CompiledTypeName(dataTypeTransform);
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

    @Override
    public CompiledExpressionExt[] getSubExpressions() {
        return null;
    }

    @Override
    public void setSubExpression(int index, CompiledExpressionExt expression) {
        throw new UnsupportedUPAFeatureException("Not supported.");
    }

    @Override
    public String toString() {
        return String.valueOf(dataTypeTransform);
    }
    
}
