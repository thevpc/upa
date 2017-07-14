/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiledfilteredreplacers;

import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.impl.uql.CompiledExpressionFilteredReplacer;
import net.vpc.upa.impl.uql.ReplaceResult;
import net.vpc.upa.impl.uql.compiledexpression.CompiledParam;
import net.vpc.upa.impl.uql.compiledexpression.CompiledVar;
import net.vpc.upa.impl.uql.compiledexpression.CompiledVarOrMethod;
import net.vpc.upa.impl.uql.util.UQLCompiledUtils;
import net.vpc.upa.impl.uql.util.UQLUtils;

import java.util.Map;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class CompiledParamRefReplacer implements CompiledExpressionFilteredReplacer {

    private String name;
    private CompiledExpression newRef;


    @Override
    public boolean isTopDown() {
        return true;
    }

    public CompiledParamRefReplacer(String name,CompiledExpression newRef) {
        this.newRef = newRef;
        this.name = name;
    }

    public ReplaceResult update(CompiledExpression e, Map<String, Object> updateContext) {
        if(e instanceof CompiledParam && name.equals(((CompiledParam) e).getName())){
            return ReplaceResult.stopWithNewObj(UQLCompiledUtils.cast(newRef).copy());
        }
        return ReplaceResult.NO_UPDATES_CONTINUE;
    }

}
