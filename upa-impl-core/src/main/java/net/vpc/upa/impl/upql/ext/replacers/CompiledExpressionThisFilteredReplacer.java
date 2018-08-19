/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.upql.ext.replacers;

import net.vpc.upa.impl.upql.ext.expr.CompiledDelete;
import net.vpc.upa.impl.upql.ext.expr.CompiledUpdate;
import net.vpc.upa.impl.upql.ext.expr.CompiledInsert;
import net.vpc.upa.impl.upql.ext.expr.CompiledVarOrMethod;
import net.vpc.upa.impl.upql.ext.expr.CompiledEntityName;
import net.vpc.upa.impl.upql.ext.expr.CompiledSelect;
import net.vpc.upa.impl.upql.ext.expr.CompiledVar;
import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.impl.upql.CompiledExpressionFilteredReplacer;
import net.vpc.upa.impl.upql.ReplaceResult;
import net.vpc.upa.impl.upql.util.UPQLUtils;

import java.util.Map;

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

    public ReplaceResult update(CompiledExpression e, Map<String, Object> updateContext) {
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
