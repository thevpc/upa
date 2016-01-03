/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql;

import java.util.List;
import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.impl.uql.compiledexpression.CompiledJoinCriteria;
import net.vpc.upa.impl.uql.compiledexpression.CompiledParam;
import net.vpc.upa.impl.uql.compiledexpression.CompiledQLFunctionExpression;
import net.vpc.upa.impl.uql.compiledexpression.CompiledQueryStatement;
import net.vpc.upa.impl.uql.compiledexpression.CompiledSelect;
import net.vpc.upa.impl.uql.compiledexpression.CompiledVar;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;
import net.vpc.upa.impl.uql.compiledexpression.IsHierarchyDescendentCompiled;

/**
 *
 * @author vpc
 */
public final class CompiledExpressionHelper {

    public static CompiledExpressionFilter PARAM_FILTER = new TypeCompiledExpressionFilter(CompiledParam.class);
    public static CompiledExpressionFilter SELECT_FILTER = new TypeCompiledExpressionFilter(CompiledSelect.class);
    public static CompiledExpressionFilter QUERY_STATEMENT_FILTER = new TypeCompiledExpressionFilter(CompiledQueryStatement.class);
    public static CompiledExpressionFilter QL_FUNCTION_FILTER = new TypeCompiledExpressionFilter(CompiledQLFunctionExpression.class);
    public static CompiledExpressionFilter DESCENDENT_FILTER = new TypeCompiledExpressionFilter(IsHierarchyDescendentCompiled.class);
    public static CompiledExpressionFilter THIS_VAR_FILTER = new CompiledExpressionFilterThisVar();

    private CompiledExpressionHelper() {
    }

    public static List<CompiledVar> findChildrenLeafVars(CompiledExpression v) {
        return ((DefaultCompiledExpression) v).findExpressionsList(CompiledExpressionFilterLeafVar.INSTANCE);
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
}
