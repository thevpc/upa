/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.upql.ext.filters;

import net.thevpc.upa.impl.upql.CompiledExpressionFilter;
import net.thevpc.upa.impl.upql.ext.expr.CompiledVar;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class CompiledExpressionFilterRootVar implements CompiledExpressionFilter {
    public static final CompiledExpressionFilter INSTANCE=new CompiledExpressionFilterRootVar();
    public boolean accept(CompiledExpressionExt e) {
        if (!(e != null && CompiledVar.class.isInstance(e))) {
            return false;
        }
        CompiledVar v = (CompiledVar) e;
        return v.getParentExpression() == null || ! (v.getParentExpression() instanceof CompiledVar);

    }
}
