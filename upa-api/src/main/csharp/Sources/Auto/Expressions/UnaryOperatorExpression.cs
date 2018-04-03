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



namespace Net.Vpc.Upa.Expressions
{


    public abstract class UnaryOperatorExpression : Net.Vpc.Upa.Expressions.OperatorExpression {

        private static readonly Net.Vpc.Upa.Expressions.DefaultTag EXPR = new Net.Vpc.Upa.Expressions.DefaultTag("Expr");



        private string operatorString;

        private Net.Vpc.Upa.Expressions.UnaryOperator unaryOperator;

        private Net.Vpc.Upa.Expressions.Expression expression;

        public UnaryOperatorExpression(Net.Vpc.Upa.Expressions.UnaryOperator unaryOperator, string operatorString, Net.Vpc.Upa.Expressions.Expression expression) {
            this.operatorString = operatorString;
            this.unaryOperator = unaryOperator;
            this.expression = expression;
        }


        public override System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> GetChildren() {
            System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> list = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.TaggedExpression>(1);
            if (expression != null) {
                list.Add(new Net.Vpc.Upa.Expressions.TaggedExpression(expression, EXPR));
            }
            return list;
        }


        public override void SetChild(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.Expressions.ExpressionTag tag) {
            if (tag.Equals(EXPR)) {
                this.expression = e;
            } else {
                throw new Net.Vpc.Upa.Exceptions.UPAIllegalArgumentException("Unsupported");
            }
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
