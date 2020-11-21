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


    public class Between : Net.TheVpc.Upa.Expressions.OperatorExpression {

        private static readonly Net.TheVpc.Upa.Expressions.DefaultTag LEFT = new Net.TheVpc.Upa.Expressions.DefaultTag("Left");

        private static readonly Net.TheVpc.Upa.Expressions.DefaultTag MIN = new Net.TheVpc.Upa.Expressions.DefaultTag("Min");

        private static readonly Net.TheVpc.Upa.Expressions.DefaultTag MAX = new Net.TheVpc.Upa.Expressions.DefaultTag("Max");



        private Net.TheVpc.Upa.Expressions.Expression left;

        private Net.TheVpc.Upa.Expressions.Expression min;

        private Net.TheVpc.Upa.Expressions.Expression max;

        private Between() {
        }

        public Between(Net.TheVpc.Upa.Expressions.Expression expression, object min, object max)  : this(expression, Net.TheVpc.Upa.Expressions.ExpressionFactory.ToLiteral(min), Net.TheVpc.Upa.Expressions.ExpressionFactory.ToLiteral(max)){

        }

        public Between(Net.TheVpc.Upa.Expressions.Expression expression, Net.TheVpc.Upa.Expressions.Expression min, Net.TheVpc.Upa.Expressions.Expression max) {
            left = expression;
            this.min = min;
            this.max = max;
        }


        public override System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> GetChildren() {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> list = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.TaggedExpression>(3);
            if (left != null) {
                list.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(left, LEFT));
            }
            if (min != null) {
                list.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(min, MIN));
            }
            if (max != null) {
                list.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(max, MAX));
            }
            return list;
        }


        public override void SetChild(Net.TheVpc.Upa.Expressions.Expression e, Net.TheVpc.Upa.Expressions.ExpressionTag tag) {
            if (tag.Equals(LEFT)) {
                this.left = e;
            } else if (tag.Equals(MIN)) {
                this.min = e;
            } else if (tag.Equals(MAX)) {
                this.max = e;
            } else {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("Unsupported");
            }
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetLeft() {
            return left;
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetMin() {
            return min;
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetMax() {
            return max;
        }

        public override bool IsValid() {
            return (left != null && left.IsValid()) && (min != null && min.IsValid()) && (max != null && max.IsValid());
        }

        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            Net.TheVpc.Upa.Expressions.Between o = new Net.TheVpc.Upa.Expressions.Between();
            o.left = left.Copy();
            o.min = min.Copy();
            o.max = max.Copy();
            return o;
        }
    }
}
