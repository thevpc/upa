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
    public class CompiledExpressionReplacerTemp : Net.TheVpc.Upa.Impl.Uql.CompiledExpressionReplacer {

        private string thisAlias;

        public CompiledExpressionReplacerTemp(string thisAlias) {
            this.thisAlias = thisAlias;
        }

        public virtual Net.TheVpc.Upa.Expressions.CompiledExpression Update(Net.TheVpc.Upa.Expressions.CompiledExpression e) {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar implicitParent = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(thisAlias);
            //                        e2 = (CompiledVar) ((CompiledVar) e).copy();
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar e2 = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) e;
            e2.UnsetParent();
            implicitParent.SetChild(e2);
            return implicitParent;
        }
    }
}
