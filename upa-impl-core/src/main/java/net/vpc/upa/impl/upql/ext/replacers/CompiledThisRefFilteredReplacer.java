/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.upql.ext.replacers;

import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.impl.upql.CompiledExpressionFilteredReplacer;
import net.vpc.upa.impl.upql.ReplaceResult;
import net.vpc.upa.impl.upql.ext.expr.CompiledVar;
import net.vpc.upa.impl.upql.ext.expr.CompiledVarOrMethod;
import net.vpc.upa.impl.upql.util.UPQLUtils;

import java.util.Map;

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

    public ReplaceResult update(CompiledExpression e, Map<String, Object> updateContext) {
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
