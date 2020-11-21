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



namespace Net.TheVpc.Upa.Impl.Uql.Filters
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public sealed class ExpressionFilterFactory {

        public static Net.TheVpc.Upa.Expressions.ExpressionFilter PARAM_FILTER = new Net.TheVpc.Upa.Impl.Uql.Filters.TypeExpressionFilter(typeof(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledParam));

        public static Net.TheVpc.Upa.Expressions.ExpressionFilter SELECT_FILTER = new Net.TheVpc.Upa.Impl.Uql.Filters.TypeExpressionFilter(typeof(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect));

        public static Net.TheVpc.Upa.Expressions.ExpressionFilter QUERY_STATEMENT_FILTER = new Net.TheVpc.Upa.Impl.Uql.Filters.TypeExpressionFilter(typeof(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement));

        public static Net.TheVpc.Upa.Expressions.ExpressionFilter QL_FUNCTION_FILTER = new Net.TheVpc.Upa.Impl.Uql.Filters.TypeExpressionFilter(typeof(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression));

        public static Net.TheVpc.Upa.Expressions.ExpressionFilter DESCENDENT_FILTER = new Net.TheVpc.Upa.Impl.Uql.Filters.TypeExpressionFilter(typeof(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.IsHierarchyDescendentCompiled));

        private ExpressionFilterFactory() {
        }

        public static Net.TheVpc.Upa.Expressions.ExpressionFilter ForParam(string name) {
            return new Net.TheVpc.Upa.Impl.Uql.Filters.ParamFilter(name);
        }
    }
}
