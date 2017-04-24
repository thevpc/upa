/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.expressions;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public interface ExpressionFilter {
    boolean accept(Expression expression);
}
