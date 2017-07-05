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
public class CompiledExpressionThisReplacer implements CompiledExpressionFilteredReplacer {

    private boolean varOnly;
    private String thisAlias;

    @Override
    public boolean isTopDown() {
        return false;
    }

    public CompiledExpressionThisReplacer(String thisAlias) {
        this(thisAlias,false);
    }

    public CompiledExpressionThisReplacer(String thisAlias,boolean varOnly) {
        this.thisAlias = thisAlias;
        this.varOnly = varOnly;
    }

    public ReplaceResult update(CompiledExpression e) {
        if (e instanceof CompiledVar) {
            CompiledVar c = (CompiledVar) e;
            if (UQLUtils.THIS.equals(c.getName())) {
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
            if (UQLUtils.THIS.equals(c.getName())) {
                c.setName(thisAlias);
                return ReplaceResult.UPDATE_AND_CONTINUE_CLEAN;
            }
        }
        if (e instanceof CompiledSelect) {
            CompiledSelect c = (CompiledSelect) e;
            if (UQLUtils.THIS.equals(c.getEntityAlias())) {
                c.setEntityAlias(thisAlias);
                return ReplaceResult.UPDATE_AND_CONTINUE_CLEAN;
            }
        }
        if (e instanceof CompiledUpdate) {
            CompiledUpdate c = (CompiledUpdate) e;
            if (UQLUtils.THIS.equals(c.getEntityAlias())) {
                c.setEntityAlias(thisAlias);
                return ReplaceResult.UPDATE_AND_CONTINUE_CLEAN;
            }
        }
        if (e instanceof CompiledDelete) {
            CompiledDelete c = (CompiledDelete) e;
            if (UQLUtils.THIS.equals(c.getEntityAlias())) {
                c.setEntityAlias(thisAlias);
                return ReplaceResult.UPDATE_AND_CONTINUE_CLEAN;
            }
        }
        if (e instanceof CompiledInsert) {
            CompiledInsert c = (CompiledInsert) e;
            if (UQLUtils.THIS.equals(c.getEntityAlias())) {
//                c.setEntityAlias(thisAlias);
//                return ReplaceResult.UPDATE_AND_CONTINUE;
            }
        }
        return ReplaceResult.NO_UPDATES_CONTINUE;
    }

}
