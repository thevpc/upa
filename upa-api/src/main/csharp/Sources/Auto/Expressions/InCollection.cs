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



using System.Linq;
namespace Net.Vpc.Upa.Expressions
{


    public class InCollection : Net.Vpc.Upa.Expressions.OperatorExpression {



        private static readonly Net.Vpc.Upa.Expressions.DefaultTag LEFT = new Net.Vpc.Upa.Expressions.DefaultTag("LEFT");

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


        public override System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> GetChildren() {
            System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> list = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.TaggedExpression>();
            if (left != null) {
                list.Add(new Net.Vpc.Upa.Expressions.TaggedExpression(left, LEFT));
            }
            for (int i = 0; i < (right).Count; i++) {
                Net.Vpc.Upa.Expressions.Expression r = right[i];
                list.Add(new Net.Vpc.Upa.Expressions.TaggedExpression(r, new Net.Vpc.Upa.Expressions.IndexedTag("RIGTH", i)));
            }
            return list;
        }


        public override void SetChild(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.Expressions.ExpressionTag tag) {
            if (tag.Equals(LEFT)) {
                this.left = e;
            } else {
                right[((Net.Vpc.Upa.Expressions.IndexedTag) tag).GetIndex()]=e;
            }
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

        public virtual Net.Vpc.Upa.Expressions.Expression[] GetRight() {
            return right.ToArray();
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
