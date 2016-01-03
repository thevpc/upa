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

    public abstract class UnaryOperatorExpression : Net.Vpc.Upa.Expressions.DefaultExpression {



        private string operatorString;

        private Net.Vpc.Upa.Expressions.UnaryOperator unaryOperator;

        private Net.Vpc.Upa.Expressions.Expression expression;

        public UnaryOperatorExpression(Net.Vpc.Upa.Expressions.UnaryOperator unaryOperator, string operatorString, Net.Vpc.Upa.Expressions.Expression expression) {
            this.operatorString = operatorString;
            this.unaryOperator = unaryOperator;
            this.expression = expression;
        }

        public virtual int Size() {
            return 1;
        }

        public override bool IsValid() {
            return expression.IsValid();
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetExpression() {
            return expression;
        }

        public virtual string GetOperatorString() {
            return operatorString;
        }

        public virtual Net.Vpc.Upa.Expressions.UnaryOperator GetOperator() {
            return unaryOperator;
        }
    }
}
