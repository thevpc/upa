/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.upql.ext.replacers;

import net.thevpc.upa.expressions.CompiledExpression;
import net.thevpc.upa.impl.upql.CompiledExpressionReplacer;
import net.thevpc.upa.impl.upql.ext.expr.CompiledVar;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class CompiledExpressionTempReplacer implements CompiledExpressionReplacer {
    private String thisAlias;

    public CompiledExpressionTempReplacer(String thisAlias) {
        this.thisAlias = thisAlias;
    }
    
    public CompiledExpression update(CompiledExpression e) {
        CompiledVar implicitParent = new CompiledVar(thisAlias);
        CompiledVar e2 = (CompiledVar) e;
        e2.unsetParent();
        implicitParent.setChild(e2);
        return implicitParent;
    }
}
