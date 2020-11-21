/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.upql.ext.replacers;

import net.thevpc.upa.impl.upql.util.UPQLUtils;
import net.thevpc.upa.expressions.CompiledExpression;
import net.thevpc.upa.impl.upql.CompiledExpressionFilteredReplacer;
import net.thevpc.upa.impl.upql.ReplaceResult;
import net.thevpc.upa.impl.upql.ext.expr.CompiledVar;
import net.thevpc.upa.impl.upql.ext.expr.CompiledVarOrMethod;

import net.thevpc.upa.impl.upql.UpdateExpressionContext;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class CompiledThisRefFilteredReplacer implements CompiledExpressionFilteredReplacer {

    private CompiledVarOrMethod newRef;


    @Override
    public boolean isTopDown() {
        return true;
    }

    public CompiledThisRefFilteredReplacer(CompiledVarOrMethod newRef) {
        this.newRef = newRef;
    }

    public ReplaceResult update(CompiledExpression e, UpdateExpressionContext updateContext) {
        if(e instanceof CompiledVar && UPQLUtils.THIS.equals(((CompiledVar) e).getName())){
            CompiledVar t = (CompiledVar) e;
            CompiledVarOrMethod child = t.getChild();
            CompiledVarOrMethod c = (CompiledVarOrMethod) newRef.copy();
            if(child!=null){
                t.setChild(null);
                child.unsetParent();
                c.setChild(child);
                return ReplaceResult.stopWithNewObj(c);
            }
            return ReplaceResult.stopWithNewObj(c);
        }
        return ReplaceResult.NO_UPDATES_CONTINUE;
    }

}
