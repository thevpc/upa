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



namespace Net.TheVpc.Upa.Impl.Uql.Compiledfilters
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public sealed class CompiledExpressionHelper {

        public static Net.TheVpc.Upa.Impl.Uql.CompiledExpressionFilter PARAM_FILTER = new Net.TheVpc.Upa.Impl.Uql.Compiledfilters.TypeCompiledExpressionFilter(typeof(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledParam));

        public static Net.TheVpc.Upa.Impl.Uql.CompiledExpressionFilter SELECT_FILTER = new Net.TheVpc.Upa.Impl.Uql.Compiledfilters.TypeCompiledExpressionFilter(typeof(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect));

        public static Net.TheVpc.Upa.Impl.Uql.CompiledExpressionFilter QUERY_STATEMENT_FILTER = new Net.TheVpc.Upa.Impl.Uql.Compiledfilters.TypeCompiledExpressionFilter(typeof(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement));

        public static Net.TheVpc.Upa.Impl.Uql.CompiledExpressionFilter QL_FUNCTION_FILTER = new Net.TheVpc.Upa.Impl.Uql.Compiledfilters.TypeCompiledExpressionFilter(typeof(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression));

        public static Net.TheVpc.Upa.Impl.Uql.CompiledExpressionFilter DESCENDENT_FILTER = new Net.TheVpc.Upa.Impl.Uql.Compiledfilters.TypeCompiledExpressionFilter(typeof(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.IsHierarchyDescendentCompiled));

        public static Net.TheVpc.Upa.Impl.Uql.CompiledExpressionFilter THIS_VAR_FILTER = new Net.TheVpc.Upa.Impl.Uql.Compiledfilters.CompiledExpressionFilterThisVar();

        private CompiledExpressionHelper() {
        }

        public static System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar> FindChildrenLeafVars(Net.TheVpc.Upa.Expressions.CompiledExpression v) {
            return ((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) v).FindExpressionsList<T>(Net.TheVpc.Upa.Impl.Uql.Compiledfilters.CompiledExpressionFilterLeafVar.INSTANCE);
        }

        public static Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar FindRootVar(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar v) {
            while (v != null) {
                if (v.GetParentExpression() is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) {
                    v = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) v.GetParentExpression();
                } else {
                    break;
                }
            }
            return v;
        }

        public static Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField FindRootCompiledQueryField(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar v) {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e = v;
            while (e != null) {
                if (e is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField) {
                    return (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField) e;
                }
                e = e.GetParentExpression();
            }
            return null;
        }

        public static Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect FindEnclosingSelect(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar v) {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) v;
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar rv = FindRootVar(v);
            while (e != null) {
                if (e is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect) {
                    Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect s = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect) e;
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
                    foreach (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledJoinCriteria c in s.GetJoins()) {
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
