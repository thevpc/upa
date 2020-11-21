/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.expressions;

/**
 * @author taha.bensalah@gmail.com
 */
public class TypeExpressionFilter implements ExpressionFilter {
    private Class expressionType;

    public TypeExpressionFilter(Class type) {
        this.expressionType = type;
    }

    @Override
    public boolean accept(Expression expression) {
        return expressionType.isInstance(expression);
    }

}
