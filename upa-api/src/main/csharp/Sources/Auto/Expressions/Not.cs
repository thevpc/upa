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



namespace Net.Vpc.Upa.Expressions
{

    public sealed class Not : Net.Vpc.Upa.Expressions.DefaultExpression {

        private Net.Vpc.Upa.Expressions.Expression expression;



        public Not(Net.Vpc.Upa.Expressions.Expression expression) {
            this.expression = expression;
        }

        public int Size() {
            return 1;
        }

        public Net.Vpc.Upa.Expressions.Expression GetNegatedExpression() {
            return expression;
        }

        public override bool IsValid() {
            return expression.IsValid();
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.Not o = new Net.Vpc.Upa.Expressions.Not(expression.Copy());
            return o;
        }


        public override string ToString() {
            return "not(" + expression + ')';
        }
    }
}
