package net.vpc.upa.impl.uql.compiledfilteredreplacers;

import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.impl.uql.CompiledExpressionFilteredReplacer;
import net.vpc.upa.impl.uql.compiledexpression.*;

/**
 * Created by vpc on 6/25/17.
 */
public class AliasEnforcerCompiledExpressionFilteredReplacer implements CompiledExpressionFilteredReplacer {

    @Override
    public boolean accept(DefaultCompiledExpression e) {
        return e instanceof CompiledEntityStatement;
    }

    @Override
    public CompiledExpression update(CompiledExpression e) {
        if (e instanceof CompiledSelect) {
            CompiledSelect q = ((CompiledSelect) e);
            if (q.getEntityAlias() == null) {
                CompiledNameOrSelect entity = q.getEntity();
                if (entity instanceof CompiledEntityName) {
                    q.setEntityAlias(((CompiledEntityName) entity).getName());
                } else {
                    //
                }
            }
            for (CompiledJoinCriteria c : q.getJoins()) {
                if (c.getEntityAlias() == null) {
                    CompiledNameOrSelect entity = q.getEntity();
                    if (entity instanceof CompiledEntityName) {
                        c.setEntityAlias(((CompiledEntityName) entity).getName());
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
        return null;
    }

}
