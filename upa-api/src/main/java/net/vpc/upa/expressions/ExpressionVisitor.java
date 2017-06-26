/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.expressions;

/**
 * @author taha.bensalah@gmail.com
 */
public interface ExpressionVisitor {

    /**
     * visit an expression as relative 'tag'
     *
     * @param expression visited expression
     * @param tag        associated tag
     * @return true to continue visiting or false to stop visit
     */
    boolean visit(Expression expression, ExpressionTag tag);
}
