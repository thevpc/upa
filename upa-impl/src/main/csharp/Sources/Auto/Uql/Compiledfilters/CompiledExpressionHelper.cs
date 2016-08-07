/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE AS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa.Impl.Uql.Compiledfilters
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public sealed class CompiledExpressionHelper {

        public static Net.Vpc.Upa.Impl.Uql.CompiledExpressionFilter PARAM_FILTER = new Net.Vpc.Upa.Impl.Uql.Compiledfilters.TypeCompiledExpressionFilter(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam));

        public static Net.Vpc.Upa.Impl.Uql.CompiledExpressionFilter SELECT_FILTER = new Net.Vpc.Upa.Impl.Uql.Compiledfilters.TypeCompiledExpressionFilter(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect));

        public static Net.Vpc.Upa.Impl.Uql.CompiledExpressionFilter QUERY_STATEMENT_FILTER = new Net.Vpc.Upa.Impl.Uql.Compiledfilters.TypeCompiledExpressionFilter(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement));

        public static Net.Vpc.Upa.Impl.Uql.CompiledExpressionFilter QL_FUNCTION_FILTER = new Net.Vpc.Upa.Impl.Uql.Compiledfilters.TypeCompiledExpressionFilter(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression));

        public static Net.Vpc.Upa.Impl.Uql.CompiledExpressionFilter DESCENDENT_FILTER = new Net.Vpc.Upa.Impl.Uql.Compiledfilters.TypeCompiledExpressionFilter(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.IsHierarchyDescendentCompiled));

        public static Net.Vpc.Upa.Impl.Uql.CompiledExpressionFilter THIS_VAR_FILTER = new Net.Vpc.Upa.Impl.Uql.Compiledfilters.CompiledExpressionFilterThisVar();

        private CompiledExpressionHelper() {
        }

        public static System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar> FindChildrenLeafVars(Net.Vpc.Upa.Expressions.CompiledExpression v) {
            return ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) v).FindExpressionsList<T>(Net.Vpc.Upa.Impl.Uql.Compiledfilters.CompiledExpressionFilterLeafVar.INSTANCE);
        }

        public static Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar FindRootVar(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar v) {
            while (v != null) {
                if (v.GetParentExpression() is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) {
                    v = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) v.GetParentExpression();
                } else {
                    break;
                }
            }
            return v;
        }

        public static Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField FindRootCompiledQueryField(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar v) {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e = v;
            while (e != null) {
                if (e is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField) {
                    return (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField) e;
                }
                e = e.GetParentExpression();
            }
            return null;
        }

        public static Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect FindEnclosingSelect(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar v) {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) v;
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar rv = FindRootVar(v);
            while (e != null) {
                if (e is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect) {
                    Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect s = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect) e;
                    string entityAlias = s.GetEntityAlias();
                    if (entityAlias != null && (entityAlias).Length > 0) {
                        if (rv.GetName().Equals(entityAlias)) {
                            return s;
                        }
                    } else {
                        if (rv.GetName().Equals(s.GetEntityName())) {
                            return s;
                        }
                    }
                    foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria c in s.GetJoins()) {
                        string joinAlias = c.GetEntityAlias();
                        if (joinAlias != null && (joinAlias).Length > 0) {
                            if (rv.GetName().Equals(joinAlias)) {
                                return s;
                            }
                        } else {
                            if (rv.GetName().Equals(c.GetEntityName())) {
                                return s;
                            }
                        }
                    }
                }
                e = e.GetParentExpression();
            }
            return null;
        }
    }
}
