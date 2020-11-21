/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.upql.util;

import net.thevpc.upa.expressions.Expression;
import net.thevpc.upa.expressions.ExpressionFilter;
import net.thevpc.upa.expressions.Var;

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
            if (v.getApplier() == null && UPQLUtils.THIS.equals(v.getName())) {
                v.setName(oldAlias);
            }
        }
        return false;
    }
    
}
