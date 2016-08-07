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


    /**
     * Created by IntelliJ IDEA. User: root Date: 10 juin 2003 Time: 16:29:33 To
     * change this template use Options | File Templates.
     */
    public class Uplet : Net.Vpc.Upa.Expressions.DefaultExpression {



        private Net.Vpc.Upa.Expressions.Expression[] expressions;

        public Uplet(Net.Vpc.Upa.Expressions.Expression[] expressions)  : base(){

            this.expressions = expressions;
        }


        public override System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> GetChildren() {
            System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> all = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.TaggedExpression>();
            for (int i = 0; i < expressions.Length; i++) {
                all.Add(new Net.Vpc.Upa.Expressions.TaggedExpression(expressions[i], new Net.Vpc.Upa.Expressions.IndexedTag("#", i)));
            }
            return all;
        }


        public override void SetChild(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.Expressions.ExpressionTag tag) {
            expressions[((Net.Vpc.Upa.Expressions.IndexedTag) tag).GetIndex()] = e;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression[] GetExpressions() {
            return expressions;
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.Expression[] expressions2 = new Net.Vpc.Upa.Expressions.Expression[expressions.Length];
            for (int i = 0; i < expressions2.Length; i++) {
                expressions2[i] = expressions[i].Copy();
            }
            Net.Vpc.Upa.Expressions.Uplet o = new Net.Vpc.Upa.Expressions.Uplet(expressions2);
            return o;
        }
    }
}
