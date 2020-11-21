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
    public class UserExpressionParserVisitor : Net.TheVpc.Upa.Expressions.ExpressionVisitor {

        private Net.TheVpc.Upa.ExpressionManager expressionManager;

        public UserExpressionParserVisitor(Net.TheVpc.Upa.ExpressionManager expressionManager) {
            this.expressionManager = expressionManager;
        }


        public virtual bool Visit(Net.TheVpc.Upa.Expressions.Expression expression, Net.TheVpc.Upa.Expressions.ExpressionTag tag) {
            foreach (Net.TheVpc.Upa.Expressions.TaggedExpression cc in expression.GetChildren()) {
                Net.TheVpc.Upa.Expressions.Expression cce = cc.GetExpression();
                if (cce != null) {
                    if (cce is Net.TheVpc.Upa.Expressions.UserExpression) {
                        Net.TheVpc.Upa.Expressions.UserExpression ucce = (Net.TheVpc.Upa.Expressions.UserExpression) cce;
                        Net.TheVpc.Upa.Expressions.Expression expr = expressionManager.ParseExpression(ucce.GetExpression());
                        expr.Visit(new Net.TheVpc.Upa.Impl.Uql.Util.UserExpressionParametersMatcherVisitor(ucce));
                        expression.SetChild(expr, cc.GetTag());
                    }
                }
            }
            return true;
        }
    }
}
