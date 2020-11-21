/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.upql.ext.filters;

import net.thevpc.upa.impl.upql.CompiledExpressionFilter;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.impl.upql.ext.expr.CompiledVar;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class CompiledExpressionFilterLeafVar implements CompiledExpressionFilter {
    public static final CompiledExpressionFilter INSTANCE=new CompiledExpressionFilterLeafVar(); 
    public boolean accept(CompiledExpressionExt e) {
        if (!(e != null && CompiledVar.class.isInstance(e))) {
            return false;
        }
        CompiledVar v = (CompiledVar) e;
        return v.getChild() == null;

    }
}
