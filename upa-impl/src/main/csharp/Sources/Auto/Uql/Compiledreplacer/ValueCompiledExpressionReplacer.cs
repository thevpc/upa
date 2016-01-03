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



namespace Net.Vpc.Upa.Impl.Uql.Compiledreplacer
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class ValueCompiledExpressionReplacer : Net.Vpc.Upa.Impl.Uql.CompiledExpressionReplacer {

        private Net.Vpc.Upa.Expressions.CompiledExpression @value;

        public ValueCompiledExpressionReplacer(Net.Vpc.Upa.Expressions.CompiledExpression @value) {
            this.@value = @value;
        }

        public virtual Net.Vpc.Upa.Expressions.CompiledExpression Update(Net.Vpc.Upa.Expressions.CompiledExpression e) {
            return @value;
        }
    }
}
