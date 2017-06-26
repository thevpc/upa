/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.expressions;

/**
 * @author taha.bensalah@gmail.com
 */
public final class TaggedExpression {

    private Expression expression;

    private ExpressionTag tag;

    public TaggedExpression(Expression expression, ExpressionTag tag) {
        this.expression = expression;
        this.tag = tag;
    }

    public Expression getExpression() {
        return expression;
    }

    public ExpressionTag getTag() {
        return tag;
    }

}
