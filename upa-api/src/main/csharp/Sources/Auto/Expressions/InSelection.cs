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

    public sealed class InSelection : Net.Vpc.Upa.Expressions.DefaultExpression {



        private Net.Vpc.Upa.Expressions.Expression[] left;

        private Net.Vpc.Upa.Expressions.Select query;

        public InSelection(Net.Vpc.Upa.Expressions.Expression left, Net.Vpc.Upa.Expressions.Select query)  : this(new Net.Vpc.Upa.Expressions.Expression[] { left }, query){

        }

        public InSelection(Net.Vpc.Upa.Expressions.Expression[] left, Net.Vpc.Upa.Expressions.Select query) {
            this.left = left;
            this.query = query;
        }

        public int Size() {
            return 2;
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
                left2[i] = left2[i].Copy();
            }
            return new Net.Vpc.Upa.Expressions.InSelection(left2, (Net.Vpc.Upa.Expressions.Select) query.Copy());
        }
    }
}
