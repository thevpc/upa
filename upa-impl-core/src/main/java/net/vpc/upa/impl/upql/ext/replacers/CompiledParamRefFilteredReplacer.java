/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.upql.ext.replacers;

import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.impl.upql.CompiledExpressionFilteredReplacer;
import net.vpc.upa.impl.upql.ReplaceResult;
import net.vpc.upa.impl.upql.ext.expr.CompiledParam;
import net.vpc.upa.impl.upql.util.UPQLCompiledUtils;

import net.vpc.upa.impl.upql.UpdateExpressionContext;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class CompiledParamRefFilteredReplacer implements CompiledExpressionFilteredReplacer {

    private String name;
    private CompiledExpression newRef;


    @Override
    public boolean isTopDown() {
        return true;
    }

    public CompiledParamRefFilteredReplacer(String name,CompiledExpression newRef) {
        this.newRef = newRef;
        this.name = name;
    }

    public ReplaceResult update(CompiledExpression e, UpdateExpressionContext updateContext) {
        if(e instanceof CompiledParam && name.equals(((CompiledParam) e).getName())){
            return ReplaceResult.stopWithNewObj(UPQLCompiledUtils.cast(newRef).copy());
        }
        return ReplaceResult.NO_UPDATES_CONTINUE;
    }

}
