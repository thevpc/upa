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


    /**
     * Created by IntelliJ IDEA. User: vpc Date: 22 janv. 2006 Time: 09:48:59 To
     * change this template use File | Settings | File Templates.
     */
    public class IdEnumerationExpression : Net.Vpc.Upa.Expressions.DefaultExpression {

        private static Net.Vpc.Upa.Expressions.DefaultTag ALIAS = new Net.Vpc.Upa.Expressions.DefaultTag("ALIAS");

        private System.Collections.Generic.IList<object> ids;

        private Net.Vpc.Upa.Expressions.Var alias;

        public IdEnumerationExpression(System.Collections.Generic.IList<object> ids, Net.Vpc.Upa.Expressions.Var alias) {
            this.ids = ids;
            this.alias = alias;
        }


        public override System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> GetChildren() {
            System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> all = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.TaggedExpression>(1);
            if (alias != null) {
                all.Add(new Net.Vpc.Upa.Expressions.TaggedExpression(alias, ALIAS));
            }
            return all;
        }


        public override void SetChild(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.Expressions.ExpressionTag tag) {
            if (tag.Equals(ALIAS)) {
                this.alias = (Net.Vpc.Upa.Expressions.Var) e;
            }
        }

        public virtual System.Collections.Generic.IList<object> GetIds() {
            return ids;
        }

        public virtual Net.Vpc.Upa.Expressions.Var GetAlias() {
            return alias;
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.IdEnumerationExpression o = new Net.Vpc.Upa.Expressions.IdEnumerationExpression(new System.Collections.Generic.List<object>(ids), alias == null ? null : (Net.Vpc.Upa.Expressions.Var) alias.Copy());
            return o;
        }


        public override string ToString() {
            return "IdEnumerationExpression(" + "ids=" + ids + ", alias=" + alias + ')';
        }
    }
}
