/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.upql.ext.filters;

import net.thevpc.upa.impl.upql.util.UPQLUtils;
import net.thevpc.upa.impl.upql.CompiledExpressionFilter;
import net.thevpc.upa.impl.upql.ext.expr.CompiledEntityName;
import net.thevpc.upa.impl.upql.ext.expr.CompiledEntityStatement;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.impl.upql.ext.expr.CompiledVar;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class CompiledExpressionFilterThisVar implements CompiledExpressionFilter {
    private boolean varOnly;
    public CompiledExpressionFilterThisVar(boolean varOnly) {
        this.varOnly=varOnly;
    }

    public boolean accept(CompiledExpressionExt e) {
        if (e instanceof CompiledVar) {
            CompiledVar c = (CompiledVar) e;
            if (UPQLUtils.THIS.equals(c.getName())) {
                return true;
            }
        }
        if(varOnly){
            return false;
        }
        if (e instanceof CompiledEntityName) {
            CompiledEntityName c = (CompiledEntityName) e;
            if (UPQLUtils.THIS.equals(c.getName())) {
                return true;
            }
        }
        if (e instanceof CompiledEntityStatement) {
            CompiledEntityStatement c = (CompiledEntityStatement) e;
            if (UPQLUtils.THIS.equals(c.getEntityAlias())) {
                return true;
            }
        }
        return false;
    }
}
