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



namespace Net.Vpc.Upa.Impl.Uql
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class CompiledExpressionThisReplacer : Net.Vpc.Upa.Impl.Uql.CompiledExpressionReplacer {

        private string thisAlias;

        public CompiledExpressionThisReplacer(string thisAlias) {
            this.thisAlias = thisAlias;
        }

        public virtual Net.Vpc.Upa.Expressions.CompiledExpression Update(Net.Vpc.Upa.Expressions.CompiledExpression e) {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar t = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) e;
            t.SetName(thisAlias);
            return t;
        }
    }
}
