package net.vpc.upa.impl.uql.compiledexpression;


import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;

public final class CompiledCst extends DefaultCompiledExpressionImpl
        implements Cloneable {
    private static final long serialVersionUID = 1L;

    private Object value;
    public CompiledCst(Object value) {
        this.value = value;
    }

    @Override
    public boolean isValid() {
        return true;
    }

    public Object getValue() {
        return value;
    }
 
    public CompiledExpressionExt copy() {
        return new CompiledCst(value);
    }

    @Override
    public CompiledExpressionExt[] getSubExpressions() {
        return null;
    }

    @Override
    public void setSubExpression(int index, CompiledExpressionExt expression) {
        throw new UnsupportedOperationException("Not supported.");
    }

    @Override
    public String toString() {
        return String.valueOf(value);
    }

    
}
