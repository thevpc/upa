/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.filters;

import net.vpc.upa.expressions.ExpressionFilter;
import net.vpc.upa.impl.uql.compiledexpression.*;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public final class ExpressionFilterFactory {

    public static ExpressionFilter PARAM_FILTER = new TypeExpressionFilter(CompiledParam.class);
    public static ExpressionFilter SELECT_FILTER = new TypeExpressionFilter(CompiledSelect.class);
    public static ExpressionFilter QUERY_STATEMENT_FILTER = new TypeExpressionFilter(CompiledQueryStatement.class);
    public static ExpressionFilter QL_FUNCTION_FILTER = new TypeExpressionFilter(CompiledQLFunctionExpression.class);
    public static ExpressionFilter DESCENDANT_FILTER = new TypeExpressionFilter(IsHierarchyDescendantCompiled.class);
//    public static ExpressionFilter THIS_VAR_FILTER = new TypeExpressionFilter();

    private ExpressionFilterFactory() {
    }

    public static ExpressionFilter forParam(String name) {
        return new ParamFilter(name);
    }
//    public static List<CompiledVar> findChildrenLeafVars(CompiledExpression v) {
//        return ((CompiledExpressionExt) v).findExpressionsList(CompiledExpressionFilterLeafVar.INSTANCE);
//    }
//
//    public static CompiledVar findRootVar(CompiledVar v) {
//        while (v != null) {
//            if (v.getParentExpression() instanceof CompiledVar) {
//                v = (CompiledVar) v.getParentExpression();
//            } else {
//                break;
//            }
//        }
//        return v;
//    }
//    public static CompiledQueryField findRootCompiledQueryField(CompiledVar v) {
//        CompiledExpressionExt e=v;
//        while (e != null) {
//            if(e instanceof CompiledQueryField){
//                return (CompiledQueryField) e;
//            }
//            e=e.getParentExpression();
//        }
//        return null;
//    }
//
//    public static CompiledSelect findEnclosingStatement(CompiledVar v) {
//        CompiledExpressionExt e = (CompiledExpressionExt) v;
//        CompiledVar rv = findRootVar(v);
//        while (e != null) {
//            if (e instanceof CompiledSelect) {
//                CompiledSelect s = (CompiledSelect) e;
//                String entityAlias = s.getEntityAlias();
//                if (entityAlias != null && entityAlias.length() > 0) {
//                    if (rv.getName().equals(entityAlias)) {
//                        return s;
//                    }
//                } else {
//                    if (rv.getName().equals(s.getEntityName())) {
//                        return s;
//                    }
//                }
//                for (CompiledJoinCriteria c : s.getJoins()) {
//                    String joinAlias = c.getEntityAlias();
//                    if (joinAlias != null && joinAlias.length() > 0) {
//                        if (rv.getName().equals(joinAlias)) {
//                            return s;
//                        }
//                    } else {
//                        if (rv.getName().equals(c.getEntityName())) {
//                            return s;
//                        }
//                    }
//                }
//            }
//            e = e.getParentExpression();
//        }
//        return null;
//    }
}
