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


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public sealed class TaggedExpression {

        private Net.Vpc.Upa.Expressions.Expression expression;

        private Net.Vpc.Upa.Expressions.ExpressionTag tag;

        public TaggedExpression(Net.Vpc.Upa.Expressions.Expression expression, Net.Vpc.Upa.Expressions.ExpressionTag tag) {
            this.expression = expression;
            this.tag = tag;
        }

        public Net.Vpc.Upa.Expressions.Expression GetExpression() {
            return expression;
        }

        public Net.Vpc.Upa.Expressions.ExpressionTag GetTag() {
            return tag;
        }
    }
}
