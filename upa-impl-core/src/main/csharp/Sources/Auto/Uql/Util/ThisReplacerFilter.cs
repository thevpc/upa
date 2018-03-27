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



namespace Net.Vpc.Upa.Impl.Uql.Util
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class ThisReplacerFilter : Net.Vpc.Upa.Expressions.ExpressionFilter {

        private readonly string oldAlias;

        public ThisReplacerFilter(string oldAlias) {
            this.oldAlias = oldAlias;
        }


        public virtual bool Accept(Net.Vpc.Upa.Expressions.Expression expression) {
            if (expression is Net.Vpc.Upa.Expressions.Var) {
                Net.Vpc.Upa.Expressions.Var v = (Net.Vpc.Upa.Expressions.Var) expression;
                if (v.GetApplier() == null && "this".Equals(v.GetName())) {
                    v.SetName(oldAlias);
                }
            }
            return false;
        }
    }
}
