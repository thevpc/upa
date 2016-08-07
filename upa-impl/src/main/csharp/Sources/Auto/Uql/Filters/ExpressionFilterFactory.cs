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



namespace Net.Vpc.Upa.Impl.Uql.Filters
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public sealed class ExpressionFilterFactory {

        public static Net.Vpc.Upa.Expressions.ExpressionFilter PARAM_FILTER = new Net.Vpc.Upa.Impl.Uql.Filters.TypeExpressionFilter(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam));

        public static Net.Vpc.Upa.Expressions.ExpressionFilter SELECT_FILTER = new Net.Vpc.Upa.Impl.Uql.Filters.TypeExpressionFilter(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect));

        public static Net.Vpc.Upa.Expressions.ExpressionFilter QUERY_STATEMENT_FILTER = new Net.Vpc.Upa.Impl.Uql.Filters.TypeExpressionFilter(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement));

        public static Net.Vpc.Upa.Expressions.ExpressionFilter QL_FUNCTION_FILTER = new Net.Vpc.Upa.Impl.Uql.Filters.TypeExpressionFilter(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression));

        public static Net.Vpc.Upa.Expressions.ExpressionFilter DESCENDENT_FILTER = new Net.Vpc.Upa.Impl.Uql.Filters.TypeExpressionFilter(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.IsHierarchyDescendentCompiled));

        private ExpressionFilterFactory() {
        }

        public static Net.Vpc.Upa.Expressions.ExpressionFilter ForParam(string name) {
            return new Net.Vpc.Upa.Impl.Uql.Filters.ParamFilter(name);
        }
    }
}
