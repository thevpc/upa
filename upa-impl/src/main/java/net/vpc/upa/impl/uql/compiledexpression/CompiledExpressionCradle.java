/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiledexpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class CompiledExpressionCradle extends DefaultCompiledExpressionImpl {

    private DefaultCompiledExpression expression;

    public CompiledExpressionCradle() {
    }
    public CompiledExpressionCradle(DefaultCompiledExpression expression) {
        this.expression = expression;
        bindChildren(expression);
    }

    @Override
    public DefaultCompiledExpression[] getSubExpressions() {
        return new DefaultCompiledExpression[]{expression};
    }

    @Override
    public void setSubExpression(int index, DefaultCompiledExpression expression) {
        if(index==0){
            unbindChildren(this.expression);
            this.expression=expression;
            bindChildren(expression);
        }else{
            throw new UnsupportedOperationException();
        }
    }

    public DefaultCompiledExpression copy() {
        return new CompiledExpressionCradle(expression);
    }
}
