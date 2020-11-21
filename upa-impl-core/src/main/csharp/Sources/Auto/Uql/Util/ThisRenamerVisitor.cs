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
    public class ThisRenamerVisitor : Net.TheVpc.Upa.Expressions.ExpressionVisitor {

        private Net.TheVpc.Upa.ExpressionManager expressionManager;

        private string thisName;

        public ThisRenamerVisitor(Net.TheVpc.Upa.ExpressionManager expressionManager, string thisName) {
            this.expressionManager = expressionManager;
            this.thisName = thisName;
        }


        public virtual bool Visit(Net.TheVpc.Upa.Expressions.Expression expression, Net.TheVpc.Upa.Expressions.ExpressionTag tag) {
            foreach (Net.TheVpc.Upa.Expressions.TaggedExpression cc in expression.GetChildren()) {
                Net.TheVpc.Upa.Expressions.Expression cce = cc.GetExpression();
                if (cce != null) {
                    if (cce is Net.TheVpc.Upa.Expressions.UserExpression) {
                        Net.TheVpc.Upa.Expressions.Expression rr = expressionManager.ParseExpression(cce);
                        rr.Visit(this);
                        expression.SetChild(rr, cc.GetTag());
                    } else if (cce is Net.TheVpc.Upa.Expressions.Var) {
                        Net.TheVpc.Upa.Expressions.Var v = (Net.TheVpc.Upa.Expressions.Var) cce;
                        if (v.GetApplier() == null && v.GetName().Equals("this")) {
                            v.SetName(thisName);
                        }
                    }
                }
            }
            return true;
        }
    }
}
