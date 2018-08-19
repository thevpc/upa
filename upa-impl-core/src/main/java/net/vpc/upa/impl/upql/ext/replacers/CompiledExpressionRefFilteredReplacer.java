/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.upql.ext.replacers;

import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.upql.CompiledExpressionFilteredReplacer;
import net.vpc.upa.impl.upql.ReplaceResult;

import java.util.Map;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class CompiledExpressionRefFilteredReplacer implements CompiledExpressionFilteredReplacer {

    private CompiledExpressionExt oldRef;
    private CompiledExpressionExt newRef;


    @Override
    public boolean isTopDown() {
        return true;
    }

    public CompiledExpressionRefFilteredReplacer(CompiledExpressionExt oldRef, CompiledExpressionExt newRef) {
        this.oldRef = oldRef;
        this.newRef = newRef;
    }

    public ReplaceResult update(CompiledExpression e, Map<String, Object> updateContext) {
        if(oldRef==e){
            return ReplaceResult.stopWithNewObj(newRef);
        }
        return ReplaceResult.NO_UPDATES_CONTINUE;
    }

}
