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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class RefEqualCompiledExpressionFilter : Net.Vpc.Upa.Impl.Uql.CompiledExpressionFilter {

        private Net.Vpc.Upa.Expressions.CompiledExpression @value;

        public RefEqualCompiledExpressionFilter(Net.Vpc.Upa.Expressions.CompiledExpression @value) {
            this.@value = @value;
        }

        public virtual bool Accept(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e) {
            return e == @value;
        }
    }
}
