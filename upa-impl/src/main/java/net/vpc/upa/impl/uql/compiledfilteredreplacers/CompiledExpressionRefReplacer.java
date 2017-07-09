/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiledfilteredreplacers;

import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.uql.CompiledExpressionFilteredReplacer;
import net.vpc.upa.impl.uql.ReplaceResult;

import java.util.Map;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class CompiledExpressionRefReplacer implements CompiledExpressionFilteredReplacer {

    private CompiledExpressionExt oldRef;
    private CompiledExpressionExt newRef;


    @Override
    public boolean isTopDown() {
        return true;
    }

    public CompiledExpressionRefReplacer(CompiledExpressionExt oldRef, CompiledExpressionExt newRef) {
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
