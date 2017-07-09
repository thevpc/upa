package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/8/13 12:14 AM
*/
public class CompiledOrderItem {
    private CompiledExpressionExt expression;
    private boolean asc;

    CompiledOrderItem(CompiledExpressionExt expression, boolean asc) {
        this.setExpression(expression);
        this.setAsc(asc);
    }

    public CompiledExpressionExt getExpression() {
        return expression;
    }

    public void setExpression(CompiledExpressionExt expression) {
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
