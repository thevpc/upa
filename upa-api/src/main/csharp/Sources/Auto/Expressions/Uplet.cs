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


    /**
     * Created by IntelliJ IDEA. User: root Date: 10 juin 2003 Time: 16:29:33 To
     * change this template use Options | File Templates.
     */
    public class Uplet : Net.TheVpc.Upa.Expressions.DefaultExpression {



        private Net.TheVpc.Upa.Expressions.Expression[] expressions;

        public Uplet(Net.TheVpc.Upa.Expressions.Expression[] expressions)  : base(){

            this.expressions = expressions;
        }


        public override System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> GetChildren() {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> all = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.TaggedExpression>(expressions.Length);
            for (int i = 0; i < expressions.Length; i++) {
                all.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(expressions[i], new Net.TheVpc.Upa.Expressions.IndexedTag("#", i)));
            }
            return all;
        }


        public override void SetChild(Net.TheVpc.Upa.Expressions.Expression e, Net.TheVpc.Upa.Expressions.ExpressionTag tag) {
            expressions[((Net.TheVpc.Upa.Expressions.IndexedTag) tag).GetIndex()] = e;
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression[] GetExpressions() {
            return expressions;
        }


        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            Net.TheVpc.Upa.Expressions.Expression[] expressions2 = new Net.TheVpc.Upa.Expressions.Expression[expressions.Length];
            for (int i = 0; i < expressions2.Length; i++) {
                expressions2[i] = expressions[i].Copy();
            }
            Net.TheVpc.Upa.Expressions.Uplet o = new Net.TheVpc.Upa.Expressions.Uplet(expressions2);
            return o;
        }
    }
}
