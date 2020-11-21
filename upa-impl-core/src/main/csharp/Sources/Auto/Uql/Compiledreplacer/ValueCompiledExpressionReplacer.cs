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



namespace Net.TheVpc.Upa.Impl.Uql.Compiledreplacer
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class ValueCompiledExpressionReplacer : Net.TheVpc.Upa.Impl.Uql.CompiledExpressionReplacer {

        private Net.TheVpc.Upa.Expressions.CompiledExpression @value;

        public ValueCompiledExpressionReplacer(Net.TheVpc.Upa.Expressions.CompiledExpression @value) {
            this.@value = @value;
        }

        public virtual Net.TheVpc.Upa.Expressions.CompiledExpression Update(Net.TheVpc.Upa.Expressions.CompiledExpression e) {
            return @value;
        }
    }
}
