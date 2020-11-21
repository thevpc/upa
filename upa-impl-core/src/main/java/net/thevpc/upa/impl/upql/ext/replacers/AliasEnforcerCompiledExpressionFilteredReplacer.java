package net.thevpc.upa.impl.upql.ext.replacers;

import net.thevpc.upa.impl.upql.ext.expr.CompiledDelete;
import net.thevpc.upa.impl.upql.ext.expr.CompiledUpdate;
import net.thevpc.upa.impl.upql.ext.expr.CompiledJoinCriteria;
import net.thevpc.upa.impl.upql.ext.expr.CompiledInsert;
import net.thevpc.upa.impl.upql.ext.expr.CompiledEntityName;
import net.thevpc.upa.impl.upql.ext.expr.CompiledEntityStatement;
import net.thevpc.upa.impl.upql.ext.expr.CompiledNameOrSelect;
import net.thevpc.upa.impl.upql.ext.expr.CompiledSelect;
import net.thevpc.upa.expressions.CompiledExpression;
import net.thevpc.upa.impl.upql.CompiledExpressionFilteredReplacer;
import net.thevpc.upa.impl.upql.ReplaceResult;

import net.thevpc.upa.impl.upql.UpdateExpressionContext;

/**
 * Created by vpc on 6/25/17.
 */
public class AliasEnforcerCompiledExpressionFilteredReplacer implements CompiledExpressionFilteredReplacer {

    @Override
    public boolean isTopDown() {
        return false;
    }

    @Override
    public ReplaceResult update(CompiledExpression e, UpdateExpressionContext updateContext) {
        if(!(e instanceof CompiledEntityStatement)){
            return ReplaceResult.NO_UPDATES_CONTINUE;
        }
        boolean changed=false;
        if (e instanceof CompiledSelect) {
            CompiledSelect q = ((CompiledSelect) e);
            if (q.getEntityAlias() == null) {
                CompiledNameOrSelect entity = q.getEntity();
                if (entity instanceof CompiledEntityName) {
                    q.setEntityAlias(((CompiledEntityName) entity).getName());
                    changed=true;
                } else {
                    //
                }
            }
            for (CompiledJoinCriteria c : q.getJoins()) {
                if (c.getEntityAlias() == null) {
                    CompiledNameOrSelect entity = q.getEntity();
                    if (entity instanceof CompiledEntityName) {
                        c.setEntityAlias(((CompiledEntityName) entity).getName());
                        changed=true;
                    } else {
                        //
                    }
                }
            }
        }else if(e instanceof CompiledUpdate){
            CompiledUpdate q = ((CompiledUpdate) e);
            if (q.getEntityAlias() == null) {
                CompiledNameOrSelect entity = q.getEntity();
                if (entity instanceof CompiledEntityName) {
                    q.setEntityAlias(((CompiledEntityName) entity).getName());
                    changed=true;
                } else {
                    //
                }
            }
        }else if(e instanceof CompiledDelete){
            CompiledDelete q = ((CompiledDelete) e);
            if (q.getEntityAlias() == null) {
                CompiledNameOrSelect entity = q.getEntity();
                if (entity instanceof CompiledEntityName) {
                    q.setEntityAlias(((CompiledEntityName) entity).getName());
                    changed=true;
                } else {
                    //
                }
            }
        }else if(e instanceof CompiledInsert){
            CompiledInsert q = ((CompiledInsert) e);
            if (q.getEntityAlias() == null) {
                CompiledNameOrSelect entity = q.getEntity();
                if (entity instanceof CompiledEntityName) {
//                    q.setEntityAlias(((CompiledEntityName) entity).getName());
                } else {
                    //
                }
            }
        }
        return changed ? ReplaceResult.UPDATE_AND_CONTINUE_CLEAN : ReplaceResult.NO_UPDATES_CONTINUE;
    }

}
