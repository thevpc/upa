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

    /**
     * @author taha.bensalah@gmail.com
     */
    public sealed class TaggedExpression {

        private Net.TheVpc.Upa.Expressions.Expression expression;

        private Net.TheVpc.Upa.Expressions.ExpressionTag tag;

        public TaggedExpression(Net.TheVpc.Upa.Expressions.Expression expression, Net.TheVpc.Upa.Expressions.ExpressionTag tag) {
            this.expression = expression;
            this.tag = tag;
        }

        public Net.TheVpc.Upa.Expressions.Expression GetExpression() {
            return expression;
        }

        public Net.TheVpc.Upa.Expressions.ExpressionTag GetTag() {
            return tag;
        }
    }
}
