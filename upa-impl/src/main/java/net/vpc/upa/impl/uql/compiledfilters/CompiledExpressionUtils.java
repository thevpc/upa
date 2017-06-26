/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiledfilters;

import java.util.List;
import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.expressions.VarVal;
import net.vpc.upa.impl.uql.CompiledExpressionFilter;
import net.vpc.upa.impl.uql.CompiledExpressionFilteredReplacer;
import net.vpc.upa.impl.uql.compiledfilteredreplacers.AliasEnforcerCompiledExpressionFilteredReplacer;
import net.vpc.upa.impl.uql.compiledreplacer.CompiledExpressionThisReplacer;
import net.vpc.upa.impl.uql.compiledreplacer.CompiledExpressionThisReplacer2;
import net.vpc.upa.impl.uql.compiledexpression.*;
import net.vpc.upa.impl.uql.compiledreplacer.CompiledExpressionThisRemover;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public final class CompiledExpressionUtils {

    public static CompiledExpressionFilter PARAM_FILTER = new TypeCompiledExpressionFilter(CompiledParam.class);
    public static CompiledExpressionFilter SELECT_FILTER = new TypeCompiledExpressionFilter(CompiledSelect.class);
    public static CompiledExpressionFilter QUERY_STATEMENT_FILTER = new TypeCompiledExpressionFilter(CompiledQueryStatement.class);
    public static CompiledExpressionFilter THIS_VAR_FILTER = new CompiledExpressionFilterThisVar(true);
    public static CompiledExpressionFilter THIS_VAR_OR_ALIAS_FILTER = new CompiledExpressionFilterThisVar(false);
    public static CompiledExpressionFilteredReplacer ALIAS_ENFORCER = new AliasEnforcerCompiledExpressionFilteredReplacer();

    private CompiledExpressionUtils() {
    }

    public static List<CompiledVar> findChildrenLeafVars(CompiledExpression v) {
        return ((DefaultCompiledExpression) v).findExpressionsList(CompiledExpressionFilterLeafVar.INSTANCE);
    }

    public static CompiledVar findThisVar(CompiledExpression v) {
        return ((DefaultCompiledExpression)v).findFirstExpression(THIS_VAR_FILTER);
    }

    public static DefaultCompiledExpression findThisVarOrAlias(CompiledExpression v) {
        return ((DefaultCompiledExpression)v).findFirstExpression(THIS_VAR_OR_ALIAS_FILTER);
    }

    public static CompiledVar findRootVar(CompiledVar v) {
        while (v != null) {
            if (v.getParentExpression() instanceof CompiledVar) {
                v = (CompiledVar) v.getParentExpression();
            } else {
                break;
            }
        }
        return v;
    }

    public static CompiledUpdate findRootCompiledUpdate(CompiledVar v) {
        DefaultCompiledExpression e=v;
        while (e != null) {
            if(e instanceof CompiledUpdate){
                return (CompiledUpdate) e;
            }
            e=e.getParentExpression();
        }
        return null;
    }

    public static CompiledVarVal findRootCompiledVarVal(CompiledVar v) {
        DefaultCompiledExpression e=v;
        while (e != null) {
            if(e instanceof CompiledVarVal){
                return (CompiledVarVal) e;
            }
            e=e.getParentExpression();
        }
        return null;
    }

    public static CompiledQueryField findRootCompiledQueryField(CompiledVar v) {
        DefaultCompiledExpression e=v;
        while (e != null) {
            if(e instanceof CompiledQueryField){
                return (CompiledQueryField) e;
            }
            e=e.getParentExpression();
        }
        return null;
    }

    public static CompiledSelect findEnclosingSelect(CompiledVar v) {
        DefaultCompiledExpression e = (DefaultCompiledExpression) v;
        CompiledVar rv = findRootVar(v);
        while (e != null) {
            if (e instanceof CompiledSelect) {
                CompiledSelect s = (CompiledSelect) e;
                String entityAlias = s.getEntityAlias();
                if (entityAlias != null && entityAlias.length() > 0) {
                    if (rv.getName().equals(entityAlias)) {
                        return s;
                    }
                } else {
                    if (rv.getName().equals(s.getEntityName())) {
                        return s;
                    }
                }
                for (CompiledJoinCriteria c : s.getJoins()) {
                    String joinAlias = c.getEntityAlias();
                    if (joinAlias != null && joinAlias.length() > 0) {
                        if (rv.getName().equals(joinAlias)) {
                            return s;
                        }
                    } else {
                        if (rv.getName().equals(c.getEntityName())) {
                            return s;
                        }
                    }
                }
            }
            e = e.getParentExpression();
        }
        return null;
    }

    public static DefaultCompiledExpression cast(CompiledExpression expression) {
        return (DefaultCompiledExpression) expression;
    }

    public static DefaultCompiledExpression replaceThisVar(CompiledExpression expression, String newName) {
        return cast(expression).replaceExpressions(THIS_VAR_OR_ALIAS_FILTER, new CompiledExpressionThisReplacer(newName));
    }

    public static DefaultCompiledExpression replaceThisVar(CompiledExpression expression, CompiledVarOrMethod newExpr) {
        return cast(expression).replaceExpressions(THIS_VAR_FILTER, new CompiledExpressionThisReplacer2(newExpr));
    }

    public static DefaultCompiledExpression removeThisVar(CompiledExpression expression) {
        return cast(expression).replaceExpressions(THIS_VAR_FILTER, new CompiledExpressionThisRemover());
    }

}
