/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.TheVpc.Upa
{


    public sealed class ExpressionFormula : Net.TheVpc.Upa.Formula {

        private Net.TheVpc.Upa.Expressions.Expression expression;

        public ExpressionFormula(string expression)  : this(expression == null ? null : new Net.TheVpc.Upa.Expressions.UserExpression(expression)){

        }

        public ExpressionFormula(Net.TheVpc.Upa.Expressions.Expression expression) {
            if (expression == null) {
                throw new System.NullReferenceException();
            } else {
                this.expression = expression;
            }
        }

        public Net.TheVpc.Upa.Expressions.Expression GetExpression() {
            return expression;
        }


        public override string ToString() {
            return System.Convert.ToString(expression);
        }
    }
}
