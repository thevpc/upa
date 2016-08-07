/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql;

import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.impl.uql.compiledexpression.CompiledVar;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class CompiledExpressionThisReplacer implements CompiledExpressionReplacer {

    private String thisAlias;

    public CompiledExpressionThisReplacer(String thisAlias) {
        this.thisAlias = thisAlias;
    }

    public CompiledExpression update(CompiledExpression e) {
        CompiledVar t = (CompiledVar) e;
        t.setName(thisAlias);
        return t;
    }
}
