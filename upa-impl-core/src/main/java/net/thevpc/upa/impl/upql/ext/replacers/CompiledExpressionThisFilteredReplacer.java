/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.upql.ext.replacers;

import net.thevpc.upa.impl.upql.util.UPQLUtils;
import net.thevpc.upa.impl.upql.ext.expr.CompiledDelete;
import net.thevpc.upa.impl.upql.ext.expr.CompiledUpdate;
import net.thevpc.upa.impl.upql.ext.expr.CompiledInsert;
import net.thevpc.upa.impl.upql.ext.expr.CompiledVarOrMethod;
import net.thevpc.upa.impl.upql.ext.expr.CompiledEntityName;
import net.thevpc.upa.impl.upql.ext.expr.CompiledSelect;
import net.thevpc.upa.impl.upql.ext.expr.CompiledVar;
import net.thevpc.upa.expressions.CompiledExpression;
import net.thevpc.upa.impl.upql.CompiledExpressionFilteredReplacer;
import net.thevpc.upa.impl.upql.ReplaceResult;

import net.thevpc.upa.impl.upql.UpdateExpressionContext;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class CompiledExpressionThisFilteredReplacer implements CompiledExpressionFilteredReplacer {

    private boolean varOnly;
    private String thisAlias;

    @Override
    public boolean isTopDown() {
        return false;
    }

    public CompiledExpressionThisFilteredReplacer(String thisAlias) {
        this(thisAlias,false);
    }

    public CompiledExpressionThisFilteredReplacer(String thisAlias,boolean varOnly) {
        this.thisAlias = thisAlias;
        this.varOnly = varOnly;
    }

    public ReplaceResult update(CompiledExpression e, UpdateExpressionContext updateContext) {
        if (e instanceof CompiledVar) {
            CompiledVar c = (CompiledVar) e;
            if (UPQLUtils.THIS.equals(c.getName())) {
                if(thisAlias==null){
                    return ReplaceResult.continueWithNewDirtyObj(((CompiledVarOrMethod) e).getChild());
                }
                CompiledVar t = (CompiledVar) e;
                t.setName(thisAlias);
                return ReplaceResult.UPDATE_AND_CONTINUE_CLEAN;
            }
        }
        if(varOnly){
            return ReplaceResult.NO_UPDATES_CONTINUE;
        }
        if (e instanceof CompiledEntityName) {
            CompiledEntityName c = (CompiledEntityName) e;
            if (UPQLUtils.THIS.equals(c.getName())) {
                c.setName(thisAlias);
                return ReplaceResult.UPDATE_AND_CONTINUE_CLEAN;
            }
        }
        if (e instanceof CompiledSelect) {
            CompiledSelect c = (CompiledSelect) e;
            if (UPQLUtils.THIS.equals(c.getEntityAlias())) {
                c.setEntityAlias(thisAlias);
                return ReplaceResult.UPDATE_AND_CONTINUE_CLEAN;
            }
        }
        if (e instanceof CompiledUpdate) {
            CompiledUpdate c = (CompiledUpdate) e;
            if (UPQLUtils.THIS.equals(c.getEntityAlias())) {
                c.setEntityAlias(thisAlias);
                return ReplaceResult.UPDATE_AND_CONTINUE_CLEAN;
            }
        }
        if (e instanceof CompiledDelete) {
            CompiledDelete c = (CompiledDelete) e;
            if (UPQLUtils.THIS.equals(c.getEntityAlias())) {
                c.setEntityAlias(thisAlias);
                return ReplaceResult.UPDATE_AND_CONTINUE_CLEAN;
            }
        }
        if (e instanceof CompiledInsert) {
            CompiledInsert c = (CompiledInsert) e;
            if (UPQLUtils.THIS.equals(c.getEntityAlias())) {
//                c.setEntityAlias(thisAlias);
//                return ReplaceResult.UPDATE_AND_CONTINUE;
            }
        }
        return ReplaceResult.NO_UPDATES_CONTINUE;
    }

}
