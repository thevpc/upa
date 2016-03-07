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
public interface ExpressionVisitor {

    /**
     * visit an expression as relative 'tag'
     *
     * @param expression visited expression
     * @param tag associated tag
     * @return true to continue visiting or false to stop visit
     */
    boolean visit(Expression expression, ExpressionTag tag);
}
