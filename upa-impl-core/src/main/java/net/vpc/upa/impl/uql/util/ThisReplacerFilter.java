/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.util;

import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.ExpressionFilter;
import net.vpc.upa.expressions.Var;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class ThisReplacerFilter implements ExpressionFilter {
    
    private final String oldAlias;

    public ThisReplacerFilter(String oldAlias) {
        this.oldAlias = oldAlias;
    }

    @Override
    public boolean accept(Expression expression) {
        if (expression instanceof Var) {
            Var v = (Var) expression;
            if (v.getApplier() == null && UQLUtils.THIS.equals(v.getName())) {
                v.setName(oldAlias);
            }
        }
        return false;
    }
    
}
