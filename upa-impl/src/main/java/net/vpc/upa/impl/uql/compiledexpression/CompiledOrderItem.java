package net.vpc.upa.impl.uql.compiledexpression;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/8/13 12:14 AM
*/
public class CompiledOrderItem {
    private DefaultCompiledExpression expression;
    private boolean asc;

    CompiledOrderItem(DefaultCompiledExpression expression, boolean asc) {
        this.setExpression(expression);
        this.setAsc(asc);
    }

    public DefaultCompiledExpression getExpression() {
        return expression;
    }

    public void setExpression(DefaultCompiledExpression expression) {
        this.expression = expression;
    }

    public boolean isAsc() {
        return asc;
    }

    public void setAsc(boolean asc) {
        this.asc = asc;
    }
    
    public CompiledOrderItem copy(){
        return new CompiledOrderItem(expression.copy(), asc);
    }
}
