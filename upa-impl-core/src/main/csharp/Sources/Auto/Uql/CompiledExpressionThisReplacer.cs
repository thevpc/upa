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



namespace Net.TheVpc.Upa.Impl.Uql
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class CompiledExpressionThisReplacer : Net.TheVpc.Upa.Impl.Uql.CompiledExpressionReplacer {

        private string thisAlias;

        public CompiledExpressionThisReplacer(string thisAlias) {
            this.thisAlias = thisAlias;
        }

        public virtual Net.TheVpc.Upa.Expressions.CompiledExpression Update(Net.TheVpc.Upa.Expressions.CompiledExpression e) {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar t = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) e;
            t.SetName(thisAlias);
            return t;
        }
    }
}
