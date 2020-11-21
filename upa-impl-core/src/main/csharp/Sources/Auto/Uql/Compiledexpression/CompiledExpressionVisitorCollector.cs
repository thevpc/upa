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



namespace Net.TheVpc.Upa.Impl.Uql.Compiledexpression
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class CompiledExpressionVisitorCollector : Net.TheVpc.Upa.Impl.Uql.CompiledExpressionVisitor {

        private Net.TheVpc.Upa.Impl.Uql.CompiledExpressionFilter filter;

        private System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression> expressions = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression>();

        public CompiledExpressionVisitorCollector(Net.TheVpc.Upa.Impl.Uql.CompiledExpressionFilter filter) {
            this.filter = filter;
        }

        public virtual bool Visit(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e) {
            if (filter == null || filter.Accept(e)) {
                expressions.Add(e);
            }
            return true;
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression> GetExpressions() {
            return expressions;
        }
    }
}
