/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.expressions;

/**
 *
 * @author vpc
 */
public class TypeExpressionFilter implements ExpressionFilter{
    private Class type;

    public TypeExpressionFilter(Class type) {
        this.type = type;
    }

    @Override
    public boolean accept(Expression expression) {
        return type.isInstance(expression);
    }
    
}
