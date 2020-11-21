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


    public sealed class InSelection : Net.TheVpc.Upa.Expressions.OperatorExpression {



        private static readonly Net.TheVpc.Upa.Expressions.DefaultTag RIGHT = new Net.TheVpc.Upa.Expressions.DefaultTag("RIGHT");

        private Net.TheVpc.Upa.Expressions.Expression[] left;

        private Net.TheVpc.Upa.Expressions.Select query;

        public InSelection(Net.TheVpc.Upa.Expressions.Expression left, Net.TheVpc.Upa.Expressions.Select query)  : this(new Net.TheVpc.Upa.Expressions.Expression[] { left }, query){

        }


        public override System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> GetChildren() {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> list = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.TaggedExpression>(left.Length + 1);
            for (int i = 0; i < left.Length; i++) {
                Net.TheVpc.Upa.Expressions.Expression expression = left[i];
                list.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(expression, new Net.TheVpc.Upa.Expressions.IndexedTag("LEFT", i)));
            }
            if (query != null) {
                list.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(query, RIGHT));
            }
            return list;
        }


        public override void SetChild(Net.TheVpc.Upa.Expressions.Expression e, Net.TheVpc.Upa.Expressions.ExpressionTag tag) {
            if (tag is Net.TheVpc.Upa.Expressions.IndexedTag) {
                this.left[((Net.TheVpc.Upa.Expressions.IndexedTag) tag).GetIndex()] = e;
            } else {
                this.query = (Net.TheVpc.Upa.Expressions.Select) e;
            }
        }

        public InSelection(Net.TheVpc.Upa.Expressions.Expression[] left, Net.TheVpc.Upa.Expressions.Select query) {
            this.left = left;
            this.query = query;
        }

        public Net.TheVpc.Upa.Expressions.Expression[] GetLeft() {
            return left;
        }

        public Net.TheVpc.Upa.Expressions.Select GetSelection() {
            return query;
        }

        public override bool IsValid() {
            return query.IsValid();
        }


        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            Net.TheVpc.Upa.Expressions.Expression[] left2 = new Net.TheVpc.Upa.Expressions.Expression[left.Length];
            for (int i = 0; i < left2.Length; i++) {
                left2[i] = left[i].Copy();
            }
            return new Net.TheVpc.Upa.Expressions.InSelection(left2, (Net.TheVpc.Upa.Expressions.Select) query.Copy());
        }


        public override string ToString() {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (left.Length == 1) {
                sb.Append(left[0]);
            } else {
                sb.Append("(");
                for (int i = 0; i < left.Length; i++) {
                    if (i > 0) {
                        sb.Append(", ");
                    }
                    sb.Append(left[i]);
                }
                sb.Append(")");
            }
            sb.Append(" in (").Append(query).Append(")");
            return sb.ToString();
        }
    }
}
