package net.vpc.upa.impl.uql.compiledexpression;


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
 
    public DefaultCompiledExpression copy() {
        return new CompiledCst(value);
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
        return String.valueOf(value);
    }

    
}
