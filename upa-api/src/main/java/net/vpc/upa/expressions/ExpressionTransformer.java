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
public interface ExpressionTransformer {

    /**
     * visit an expression as relative 'tag'
     *
     * @param expression visited expression
     * @return transformation result
     */
    ExpressionTransformerResult transform(Expression expression);
}
