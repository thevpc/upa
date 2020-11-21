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



namespace Net.TheVpc.Upa.Impl.Uql.Util
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class ThisReplacerFilter : Net.TheVpc.Upa.Expressions.ExpressionFilter {

        private readonly string oldAlias;

        public ThisReplacerFilter(string oldAlias) {
            this.oldAlias = oldAlias;
        }


        public virtual bool Accept(Net.TheVpc.Upa.Expressions.Expression expression) {
            if (expression is Net.TheVpc.Upa.Expressions.Var) {
                Net.TheVpc.Upa.Expressions.Var v = (Net.TheVpc.Upa.Expressions.Var) expression;
                if (v.GetApplier() == null && "this".Equals(v.GetName())) {
                    v.SetName(oldAlias);
                }
            }
            return false;
        }
    }
}
