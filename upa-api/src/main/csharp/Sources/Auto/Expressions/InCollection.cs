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


    public class InCollection : Net.Vpc.Upa.Expressions.DefaultExpression {



        private Net.Vpc.Upa.Expressions.Expression left;

        protected internal System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Expression> right;

        public InCollection(Net.Vpc.Upa.Expressions.Expression left)  : this(left, (System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Expression>) null){

        }

        public InCollection(Net.Vpc.Upa.Expressions.Expression[] left)  : this(new Net.Vpc.Upa.Expressions.Uplet(left), (System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Expression>) null){

        }

        public InCollection(Net.Vpc.Upa.Expressions.Expression[] left, System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Expression> collection)  : this(new Net.Vpc.Upa.Expressions.Uplet(left), collection){

        }

        public InCollection(Net.Vpc.Upa.Expressions.Expression left, Net.Vpc.Upa.Expressions.Expression[] collection)  : this(left, collection != null ? new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression>(collection) : null){

        }

        public InCollection(Net.Vpc.Upa.Expressions.Expression left, System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Expression> collection) {
            this.left = left;
            right = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression>(1);
            if (collection != null) {
                foreach (object aCollection in collection) {
                    Add(aCollection);
                }
            }
        }

        public virtual int Size() {
            return 2;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetLeft() {
            return left;
        }

        public virtual void Add(object e) {
            right.Add(Net.Vpc.Upa.Expressions.ExpressionFactory.ToExpression(e, typeof(Net.Vpc.Upa.Expressions.Literal)));
        }

        public virtual void Add(Net.Vpc.Upa.Expressions.Expression e) {
            right.Add(e);
        }

        public virtual void Add(Net.Vpc.Upa.Expressions.Expression[] e) {
            right.Add(new Net.Vpc.Upa.Expressions.Uplet(e));
        }

        public virtual int GetRightSize() {
            return (right).Count;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetRight(int i) {
            return right[i];
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.InCollection o = new Net.Vpc.Upa.Expressions.InCollection(left.Copy());
            foreach (Net.Vpc.Upa.Expressions.Expression expression in right) {
                o.Add(expression);
            }
            return o;
        }
    }
}
