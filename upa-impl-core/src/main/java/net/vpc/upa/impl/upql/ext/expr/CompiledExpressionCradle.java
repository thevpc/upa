/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.upql.ext.expr;

import net.vpc.upa.exceptions.UnsupportedUPAFeatureException;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class CompiledExpressionCradle extends DefaultCompiledExpressionImpl {

    private CompiledExpressionExt expression;

    public CompiledExpressionCradle() {
    }
    public CompiledExpressionCradle(CompiledExpressionExt expression) {
        this.expression = expression;
        bindChildren(expression);
    }

    @Override
    public CompiledExpressionExt[] getSubExpressions() {
        return new CompiledExpressionExt[]{expression};
    }

    @Override
    public void setSubExpression(int index, CompiledExpressionExt expression) {
        if(index==0){
            unbindChildren(this.expression);
            this.expression=expression;
            bindChildren(expression);
        }else{
            throw new UnsupportedUPAFeatureException();
        }
    }

    public CompiledExpressionExt copy() {
        return new CompiledExpressionCradle(expression);
    }
}
