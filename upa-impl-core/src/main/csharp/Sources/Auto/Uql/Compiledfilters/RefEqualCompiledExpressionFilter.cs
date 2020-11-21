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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class RefEqualCompiledExpressionFilter : Net.TheVpc.Upa.Impl.Uql.CompiledExpressionFilter {

        private Net.TheVpc.Upa.Expressions.CompiledExpression @value;

        public RefEqualCompiledExpressionFilter(Net.TheVpc.Upa.Expressions.CompiledExpression @value) {
            this.@value = @value;
        }

        public virtual bool Accept(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e) {
            return e == @value;
        }
    }
}
