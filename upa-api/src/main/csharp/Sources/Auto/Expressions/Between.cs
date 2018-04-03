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


    public class Between : Net.Vpc.Upa.Expressions.OperatorExpression {

        private static readonly Net.Vpc.Upa.Expressions.DefaultTag LEFT = new Net.Vpc.Upa.Expressions.DefaultTag("Left");

        private static readonly Net.Vpc.Upa.Expressions.DefaultTag MIN = new Net.Vpc.Upa.Expressions.DefaultTag("Min");

        private static readonly Net.Vpc.Upa.Expressions.DefaultTag MAX = new Net.Vpc.Upa.Expressions.DefaultTag("Max");



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


        public override System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> GetChildren() {
            System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> list = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.TaggedExpression>(3);
            if (left != null) {
                list.Add(new Net.Vpc.Upa.Expressions.TaggedExpression(left, LEFT));
            }
            if (min != null) {
                list.Add(new Net.Vpc.Upa.Expressions.TaggedExpression(min, MIN));
            }
            if (max != null) {
                list.Add(new Net.Vpc.Upa.Expressions.TaggedExpression(max, MAX));
            }
            return list;
        }


        public override void SetChild(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.Expressions.ExpressionTag tag) {
            if (tag.Equals(LEFT)) {
                this.left = e;
            } else if (tag.Equals(MIN)) {
                this.min = e;
            } else if (tag.Equals(MAX)) {
                this.max = e;
            } else {
                throw new Net.Vpc.Upa.Exceptions.UPAIllegalArgumentException("Unsupported");
            }
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
