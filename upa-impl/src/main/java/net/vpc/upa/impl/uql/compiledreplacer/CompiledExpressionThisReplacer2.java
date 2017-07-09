/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiledreplacer;

import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.impl.uql.CompiledExpressionReplacer;
import net.vpc.upa.impl.uql.compiledexpression.CompiledVar;
import net.vpc.upa.impl.uql.compiledexpression.CompiledVarOrMethod;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class CompiledExpressionThisReplacer2 implements CompiledExpressionReplacer {

    private CompiledVarOrMethod var;

    public CompiledExpressionThisReplacer2(CompiledVarOrMethod var) {
        this.var = var;
    }

    public CompiledExpression update(CompiledExpression e) {
        CompiledVar t = (CompiledVar) e;
        var.getDeepest().setChild(t);
        return t;
    }
}
