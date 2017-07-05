/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiledfilteredreplacers;

import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.impl.uql.CompiledExpressionFilteredReplacer;
import net.vpc.upa.impl.uql.ReplaceResult;
import net.vpc.upa.impl.uql.compiledexpression.*;
import net.vpc.upa.impl.uql.util.UQLUtils;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class CompiledExpressionRefReplacer implements CompiledExpressionFilteredReplacer {

    private DefaultCompiledExpression oldRef;
    private DefaultCompiledExpression newRef;


    @Override
    public boolean isTopDown() {
        return true;
    }

    public CompiledExpressionRefReplacer(DefaultCompiledExpression oldRef, DefaultCompiledExpression newRef) {
        this.oldRef = oldRef;
        this.newRef = newRef;
    }

    public ReplaceResult update(CompiledExpression e) {
        if(oldRef==e){
            return ReplaceResult.stopWithNewObj(newRef);
        }
        return ReplaceResult.NO_UPDATES_CONTINUE;
    }

}
