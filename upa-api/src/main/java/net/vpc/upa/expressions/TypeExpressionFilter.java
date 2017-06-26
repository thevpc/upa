/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.expressions;

/**
 * @author taha.bensalah@gmail.com
 */
public class TypeExpressionFilter implements ExpressionFilter {
    private Class type;

    public TypeExpressionFilter(Class type) {
        this.type = type;
    }

    @Override
    public boolean accept(Expression expression) {
        return type.isInstance(expression);
    }

}
