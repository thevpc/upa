/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.upql.ext.filters;

import net.vpc.upa.impl.upql.CompiledExpressionFilter;
import net.vpc.upa.impl.upql.ext.expr.CompiledEntityName;
import net.vpc.upa.impl.upql.ext.expr.CompiledEntityStatement;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.upql.ext.expr.CompiledVar;
import net.vpc.upa.impl.upql.util.UPQLUtils;

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
