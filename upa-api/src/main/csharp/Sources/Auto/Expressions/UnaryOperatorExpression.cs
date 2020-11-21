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



namespace Net.TheVpc.Upa.Expressions
{


    public abstract class UnaryOperatorExpression : Net.TheVpc.Upa.Expressions.OperatorExpression {

        private static readonly Net.TheVpc.Upa.Expressions.DefaultTag EXPR = new Net.TheVpc.Upa.Expressions.DefaultTag("Expr");



        private string operatorString;

        private Net.TheVpc.Upa.Expressions.UnaryOperator unaryOperator;

        private Net.TheVpc.Upa.Expressions.Expression expression;

        public UnaryOperatorExpression(Net.TheVpc.Upa.Expressions.UnaryOperator unaryOperator, string operatorString, Net.TheVpc.Upa.Expressions.Expression expression) {
            this.operatorString = operatorString;
            this.unaryOperator = unaryOperator;
            this.expression = expression;
        }


        public override System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> GetChildren() {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> list = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.TaggedExpression>(1);
            if (expression != null) {
                list.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(expression, EXPR));
            }
            return list;
        }


        public override void SetChild(Net.TheVpc.Upa.Expressions.Expression e, Net.TheVpc.Upa.Expressions.ExpressionTag tag) {
            if (tag.Equals(EXPR)) {
                this.expression = e;
            } else {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("Unsupported");
            }
        }

        public virtual int Size() {
            return 1;
        }


        public override bool IsValid() {
            return expression.IsValid();
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetExpression() {
            return expression;
        }

        public virtual string GetOperatorString() {
            return operatorString;
        }

        public virtual Net.TheVpc.Upa.Expressions.UnaryOperator GetOperator() {
            return unaryOperator;
        }
    }
}
