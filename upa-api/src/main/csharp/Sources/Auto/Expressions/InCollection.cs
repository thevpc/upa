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



using System.Linq;
namespace Net.TheVpc.Upa.Expressions
{


    public class InCollection : Net.TheVpc.Upa.Expressions.OperatorExpression {



        private static readonly Net.TheVpc.Upa.Expressions.DefaultTag LEFT = new Net.TheVpc.Upa.Expressions.DefaultTag("LEFT");

        private Net.TheVpc.Upa.Expressions.Expression left;

        protected internal System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.Expression> right;

        public InCollection(Net.TheVpc.Upa.Expressions.Expression left)  : this(left, (System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.Expression>) null){

        }

        public InCollection(Net.TheVpc.Upa.Expressions.Expression[] left)  : this(new Net.TheVpc.Upa.Expressions.Uplet(left), (System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.Expression>) null){

        }

        public InCollection(Net.TheVpc.Upa.Expressions.Expression[] left, System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.Expression> collection)  : this(new Net.TheVpc.Upa.Expressions.Uplet(left), collection){

        }

        public InCollection(Net.TheVpc.Upa.Expressions.Expression left, Net.TheVpc.Upa.Expressions.Expression[] collection)  : this(left, collection != null ? new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Expression>(collection) : null){

        }

        public InCollection(Net.TheVpc.Upa.Expressions.Expression left, System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.Expression> collection) {
            this.left = left;
            right = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Expression>(1);
            if (collection != null) {
                foreach (object aCollection in collection) {
                    Add(aCollection);
                }
            }
        }


        public override System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> GetChildren() {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> list = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.TaggedExpression>((right).Count + 1);
            if (left != null) {
                list.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(left, LEFT));
            }
            for (int i = 0; i < (right).Count; i++) {
                Net.TheVpc.Upa.Expressions.Expression r = right[i];
                list.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(r, new Net.TheVpc.Upa.Expressions.IndexedTag("RIGHT", i)));
            }
            return list;
        }


        public override void SetChild(Net.TheVpc.Upa.Expressions.Expression e, Net.TheVpc.Upa.Expressions.ExpressionTag tag) {
            if (tag.Equals(LEFT)) {
                this.left = e;
            } else {
                right[((Net.TheVpc.Upa.Expressions.IndexedTag) tag).GetIndex()]=e;
            }
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetLeft() {
            return left;
        }

        public virtual void Add(object e) {
            right.Add(Net.TheVpc.Upa.Expressions.ExpressionFactory.ToExpression(e, typeof(Net.TheVpc.Upa.Expressions.Literal)));
        }

        public virtual void Add(Net.TheVpc.Upa.Expressions.Expression e) {
            right.Add(e);
        }

        public virtual void Add(Net.TheVpc.Upa.Expressions.Expression[] e) {
            right.Add(new Net.TheVpc.Upa.Expressions.Uplet(e));
        }

        public virtual int GetRightSize() {
            return (right).Count;
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetRight(int i) {
            return right[i];
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression[] GetRight() {
            return right.ToArray();
        }


        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            Net.TheVpc.Upa.Expressions.InCollection o = new Net.TheVpc.Upa.Expressions.InCollection(left.Copy());
            foreach (Net.TheVpc.Upa.Expressions.Expression expression in right) {
                o.Add(expression);
            }
            return o;
        }
    }
}
