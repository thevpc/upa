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


    public sealed class InSelection : Net.Vpc.Upa.Expressions.OperatorExpression {



        private static readonly Net.Vpc.Upa.Expressions.DefaultTag RIGHT = new Net.Vpc.Upa.Expressions.DefaultTag("RIGHT");

        private Net.Vpc.Upa.Expressions.Expression[] left;

        private Net.Vpc.Upa.Expressions.Select query;

        public InSelection(Net.Vpc.Upa.Expressions.Expression left, Net.Vpc.Upa.Expressions.Select query)  : this(new Net.Vpc.Upa.Expressions.Expression[] { left }, query){

        }


        public override System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> GetChildren() {
            System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> list = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.TaggedExpression>(left.Length + 1);
            for (int i = 0; i < left.Length; i++) {
                Net.Vpc.Upa.Expressions.Expression expression = left[i];
                list.Add(new Net.Vpc.Upa.Expressions.TaggedExpression(expression, new Net.Vpc.Upa.Expressions.IndexedTag("LEFT", i)));
            }
            if (query != null) {
                list.Add(new Net.Vpc.Upa.Expressions.TaggedExpression(query, RIGHT));
            }
            return list;
        }


        public override void SetChild(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.Expressions.ExpressionTag tag) {
            if (tag is Net.Vpc.Upa.Expressions.IndexedTag) {
                this.left[((Net.Vpc.Upa.Expressions.IndexedTag) tag).GetIndex()] = e;
            } else {
                this.query = (Net.Vpc.Upa.Expressions.Select) e;
            }
        }

        public InSelection(Net.Vpc.Upa.Expressions.Expression[] left, Net.Vpc.Upa.Expressions.Select query) {
            this.left = left;
            this.query = query;
        }

        public Net.Vpc.Upa.Expressions.Expression[] GetLeft() {
            return left;
        }

        public Net.Vpc.Upa.Expressions.Select GetSelection() {
            return query;
        }

        public override bool IsValid() {
            return query.IsValid();
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.Expression[] left2 = new Net.Vpc.Upa.Expressions.Expression[left.Length];
            for (int i = 0; i < left2.Length; i++) {
                left2[i] = left[i].Copy();
            }
            return new Net.Vpc.Upa.Expressions.InSelection(left2, (Net.Vpc.Upa.Expressions.Select) query.Copy());
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
