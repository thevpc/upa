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
namespace Net.TheVpc.Upa.Impl.Uql.Compiledexpression
{


    public class CompiledInCollection : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpressionImpl {



        private Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left;

        protected internal System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression> right;

        public CompiledInCollection(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left)  : this(left, (System.Collections.Generic.ICollection<object>) null){

        }


        public override Net.TheVpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform.BOOLEAN;
        }

        public CompiledInCollection(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] left)  : this(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUplet(left), (System.Collections.Generic.ICollection<object>) null){

        }

        public CompiledInCollection(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] left, System.Collections.Generic.ICollection<object> collection)  : this(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUplet(left), collection){

        }

        public CompiledInCollection(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left, object[] collection)  : this(left, collection != null ? new System.Collections.Generic.List<object>(collection) : null){

        }

        public CompiledInCollection(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left, System.Collections.Generic.ICollection<object> collection) {
            this.left = left;
            PrepareChildren(left);
            this.right = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression>(1);
            if (collection != null) {
                foreach (object aCollection in collection) {
                    Add(aCollection);
                }
            }
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions() {
            System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression> all = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression>();
            all.Add(GetLeft());
            Net.TheVpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(all, right);
            return all.ToArray();
        }


        public override void SetSubExpression(int index, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            if (index == 0) {
                left = expression;
                PrepareChildren(expression);
            } else {
                right[index - 1]=expression;
                PrepareChildren(expression);
            }
        }

        public virtual int Size() {
            return (right).Count + 1;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetLeft() {
            return left;
        }

        public virtual void Add(object e) {
            Add(Net.TheVpc.Upa.Impl.Uql.CompiledExpressionFactory.ToExpression(e, typeof(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral)));
        }

        public virtual void Add(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e) {
            right.Add(e);
            PrepareChildren(e);
        }

        public virtual void Add(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] e) {
            Add(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUplet(e));
        }

        public virtual int GetRightSize() {
            return (right).Count;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetRight(int i) {
            return right[i];
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInCollection o = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInCollection(left.Copy());
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            foreach (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression in right) {
                o.Add(expression.Copy());
            }
            return o;
        }
    }
}
