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
    public class ThisRenamerVisitor : Net.Vpc.Upa.Expressions.ExpressionVisitor {

        private Net.Vpc.Upa.ExpressionManager expressionManager;

        private string thisName;

        public ThisRenamerVisitor(Net.Vpc.Upa.ExpressionManager expressionManager, string thisName) {
            this.expressionManager = expressionManager;
            this.thisName = thisName;
        }


        public virtual bool Visit(Net.Vpc.Upa.Expressions.Expression expression, Net.Vpc.Upa.Expressions.ExpressionTag tag) {
            foreach (Net.Vpc.Upa.Expressions.TaggedExpression cc in expression.GetChildren()) {
                Net.Vpc.Upa.Expressions.Expression cce = cc.GetExpression();
                if (cce != null) {
                    if (cce is Net.Vpc.Upa.Expressions.UserExpression) {
                        Net.Vpc.Upa.Expressions.Expression rr = expressionManager.ParseExpression(cce);
                        rr.Visit(this);
                        expression.SetChild(rr, cc.GetTag());
                    } else if (cce is Net.Vpc.Upa.Expressions.Var) {
                        Net.Vpc.Upa.Expressions.Var v = (Net.Vpc.Upa.Expressions.Var) cce;
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
