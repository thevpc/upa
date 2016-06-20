/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.expressions;

/**
 *
 * @author vpc
 */
public interface ExpressionFilter {
    public boolean accept(Expression expression);
}
