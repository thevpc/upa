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
     * Created by vpc on 6/26/16.
     */
    public class UserExpressionParametersMatcherVisitor : Net.TheVpc.Upa.Expressions.ExpressionVisitor {

        private readonly Net.TheVpc.Upa.Expressions.UserExpression expression;

        public UserExpressionParametersMatcherVisitor(Net.TheVpc.Upa.Expressions.UserExpression expression) {
            this.expression = expression;
        }


        public virtual bool Visit(Net.TheVpc.Upa.Expressions.Expression expr, Net.TheVpc.Upa.Expressions.ExpressionTag tag) {
            if (expr is Net.TheVpc.Upa.Expressions.Param) {
                Net.TheVpc.Upa.Expressions.Param p = (Net.TheVpc.Upa.Expressions.Param) expr;
                p.SetValue(expression.GetParameter(p.GetName()));
            }
            return true;
        }
    }
}
