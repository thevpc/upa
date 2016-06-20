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
 * @author vpc
 */
public class CompiledExpressionReplacerTemp implements CompiledExpressionReplacer {
    private String thisAlias;

    public CompiledExpressionReplacerTemp(String thisAlias) {
        this.thisAlias = thisAlias;
    }
    
    public CompiledExpression update(CompiledExpression e) {
        CompiledVar implicitParent = new CompiledVar(thisAlias);
//                        e2 = (CompiledVar) ((CompiledVar) e).copy();
        CompiledVar e2 = (CompiledVar) e;
        e2.unsetParent();
        implicitParent.setChild(e2);
        return implicitParent;
    }
}
