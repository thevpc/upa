/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.upql.ext.replacers;

import net.thevpc.upa.expressions.CompiledExpression;
import net.thevpc.upa.impl.upql.CompiledExpressionReplacer;
import net.thevpc.upa.impl.upql.ext.expr.CompiledVar;
import net.thevpc.upa.impl.upql.ext.expr.CompiledVarOrMethod;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class CompiledExpressionThis2Replacer implements CompiledExpressionReplacer {

    private CompiledVarOrMethod var;

    public CompiledExpressionThis2Replacer(CompiledVarOrMethod var) {
        this.var = var;
    }

    public CompiledExpression update(CompiledExpression e) {
        CompiledVar t = (CompiledVar) e;
        var.getDeepest().setChild(t);
        return t;
    }
}
