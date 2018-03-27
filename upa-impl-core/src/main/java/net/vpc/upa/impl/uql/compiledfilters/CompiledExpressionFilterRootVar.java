/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiledfilters;

import net.vpc.upa.impl.uql.CompiledExpressionFilter;
import net.vpc.upa.impl.uql.compiledexpression.CompiledVar;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;

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
