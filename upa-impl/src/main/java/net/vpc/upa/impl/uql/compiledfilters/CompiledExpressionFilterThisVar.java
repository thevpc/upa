/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiledfilters;

import net.vpc.upa.expressions.EntityName;
import net.vpc.upa.impl.uql.CompiledExpressionFilter;
import net.vpc.upa.impl.uql.compiledexpression.CompiledEntityName;
import net.vpc.upa.impl.uql.compiledexpression.CompiledEntityStatement;
import net.vpc.upa.impl.uql.compiledexpression.CompiledVar;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;
import net.vpc.upa.impl.uql.util.UQLUtils;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class CompiledExpressionFilterThisVar implements CompiledExpressionFilter {
    private boolean varOnly;
    public CompiledExpressionFilterThisVar(boolean varOnly) {
        this.varOnly=varOnly;
    }

    public boolean accept(DefaultCompiledExpression e) {
        if (e instanceof CompiledVar) {
            CompiledVar c = (CompiledVar) e;
            if (UQLUtils.THIS.equals(c.getName())) {
                return true;
            }
        }
        if(varOnly){
            return false;
        }
        if (e instanceof CompiledEntityName) {
            CompiledEntityName c = (CompiledEntityName) e;
            if (UQLUtils.THIS.equals(c.getName())) {
                return true;
            }
        }
        if (e instanceof CompiledEntityStatement) {
            CompiledEntityStatement c = (CompiledEntityStatement) e;
            if (UQLUtils.THIS.equals(c.getEntityAlias())) {
                return true;
            }
        }
        return false;
    }
}
