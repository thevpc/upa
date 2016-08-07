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
     * Created by vpc on 6/26/16.
     */
    public class UserExpressionParametersMatcherVisitor : Net.Vpc.Upa.Expressions.ExpressionVisitor {

        private readonly Net.Vpc.Upa.Expressions.UserExpression expression;

        public UserExpressionParametersMatcherVisitor(Net.Vpc.Upa.Expressions.UserExpression expression) {
            this.expression = expression;
        }


        public virtual bool Visit(Net.Vpc.Upa.Expressions.Expression expr, Net.Vpc.Upa.Expressions.ExpressionTag tag) {
            if (expr is Net.Vpc.Upa.Expressions.Param) {
                Net.Vpc.Upa.Expressions.Param p = (Net.Vpc.Upa.Expressions.Param) expr;
                p.SetValue(expression.GetParameter(p.GetName()));
            }
            return true;
        }
    }
}
