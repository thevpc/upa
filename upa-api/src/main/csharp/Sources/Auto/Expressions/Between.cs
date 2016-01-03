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

    public class Between : Net.Vpc.Upa.Expressions.DefaultExpression {



        private Net.Vpc.Upa.Expressions.Expression left;

        private Net.Vpc.Upa.Expressions.Expression min;

        private Net.Vpc.Upa.Expressions.Expression max;

        private Between() {
        }

        public Between(Net.Vpc.Upa.Expressions.Expression expression, object min, object max)  : this(expression, Net.Vpc.Upa.Expressions.ExpressionFactory.ToLiteral(min), Net.Vpc.Upa.Expressions.ExpressionFactory.ToLiteral(max)){

        }

        public Between(Net.Vpc.Upa.Expressions.Expression expression, Net.Vpc.Upa.Expressions.Expression min, Net.Vpc.Upa.Expressions.Expression max) {
            left = expression;
            this.min = min;
            this.max = max;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetLeft() {
            return left;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetMin() {
            return min;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetMax() {
            return max;
        }

        public override bool IsValid() {
            return (left != null && left.IsValid()) && (min != null && min.IsValid()) && (max != null && max.IsValid());
        }

        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.Between o = new Net.Vpc.Upa.Expressions.Between();
            o.left = left.Copy();
            o.min = min.Copy();
            o.max = max.Copy();
            return o;
        }
    }
}
