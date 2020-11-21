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
     * Created by IntelliJ IDEA. User: vpc Date: 22 janv. 2006 Time: 09:48:59 To
     * change this template use File | Settings | File Templates.
     */
    public class IdEnumerationExpression : Net.TheVpc.Upa.Expressions.DefaultExpression {

        private static Net.TheVpc.Upa.Expressions.DefaultTag ALIAS = new Net.TheVpc.Upa.Expressions.DefaultTag("ALIAS");

        private System.Collections.Generic.IList<object> ids;

        private Net.TheVpc.Upa.Expressions.Var alias;

        public IdEnumerationExpression(System.Collections.Generic.IList<object> ids, Net.TheVpc.Upa.Expressions.Var alias) {
            this.ids = ids;
            this.alias = alias;
        }


        public override System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> GetChildren() {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> all = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.TaggedExpression>(1);
            if (alias != null) {
                all.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(alias, ALIAS));
            }
            return all;
        }


        public override void SetChild(Net.TheVpc.Upa.Expressions.Expression e, Net.TheVpc.Upa.Expressions.ExpressionTag tag) {
            if (tag.Equals(ALIAS)) {
                this.alias = (Net.TheVpc.Upa.Expressions.Var) e;
            }
        }

        public virtual System.Collections.Generic.IList<object> GetIds() {
            return ids;
        }

        public virtual Net.TheVpc.Upa.Expressions.Var GetAlias() {
            return alias;
        }


        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            Net.TheVpc.Upa.Expressions.IdEnumerationExpression o = new Net.TheVpc.Upa.Expressions.IdEnumerationExpression(new System.Collections.Generic.List<object>(ids), alias == null ? null : (Net.TheVpc.Upa.Expressions.Var) alias.Copy());
            return o;
        }


        public override string ToString() {
            return "IdEnumerationExpression(" + "ids=" + ids + ", alias=" + alias + ')';
        }
    }
}
