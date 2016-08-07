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
    public class UserExpressionParserVisitor : Net.Vpc.Upa.Expressions.ExpressionVisitor {

        private Net.Vpc.Upa.ExpressionManager expressionManager;

        public UserExpressionParserVisitor(Net.Vpc.Upa.ExpressionManager expressionManager) {
            this.expressionManager = expressionManager;
        }


        public virtual bool Visit(Net.Vpc.Upa.Expressions.Expression expression, Net.Vpc.Upa.Expressions.ExpressionTag tag) {
            foreach (Net.Vpc.Upa.Expressions.TaggedExpression cc in expression.GetChildren()) {
                Net.Vpc.Upa.Expressions.Expression cce = cc.GetExpression();
                if (cce != null) {
                    if (cce is Net.Vpc.Upa.Expressions.UserExpression) {
                        Net.Vpc.Upa.Expressions.UserExpression ucce = (Net.Vpc.Upa.Expressions.UserExpression) cce;
                        Net.Vpc.Upa.Expressions.Expression expr = expressionManager.ParseExpression(ucce.GetExpression());
                        expr.Visit(new Net.Vpc.Upa.Impl.Uql.Util.UserExpressionParametersMatcherVisitor(ucce));
                        expression.SetChild(expr, cc.GetTag());
                    }
                }
            }
            return true;
        }
    }
}
