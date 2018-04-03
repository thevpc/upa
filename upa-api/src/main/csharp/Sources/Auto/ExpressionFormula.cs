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



namespace Net.Vpc.Upa
{


    public sealed class ExpressionFormula : Net.Vpc.Upa.Formula {

        private Net.Vpc.Upa.Expressions.Expression expression;

        public ExpressionFormula(string expression)  : this(expression == null ? null : new Net.Vpc.Upa.Expressions.UserExpression(expression)){

        }

        public ExpressionFormula(Net.Vpc.Upa.Expressions.Expression expression) {
            if (expression == null) {
                throw new System.NullReferenceException();
            } else {
                this.expression = expression;
            }
        }

        public Net.Vpc.Upa.Expressions.Expression GetExpression() {
            return expression;
        }


        public override string ToString() {
            return System.Convert.ToString(expression);
        }
    }
}
