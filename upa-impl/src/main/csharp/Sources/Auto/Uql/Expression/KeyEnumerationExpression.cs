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



namespace Net.Vpc.Upa.Impl.Uql.Expression
{


    /**
     * Created by IntelliJ IDEA.
     * User: vpc
     * Date: 22 janv. 2006
     * Time: 09:48:59
     * To change this template use File | Settings | File Templates.
     */
    public class KeyEnumerationExpression : Net.Vpc.Upa.Expressions.DefaultExpression {

        private System.Collections.Generic.IList<object> keys;

        private Net.Vpc.Upa.Expressions.Var alias;

        public KeyEnumerationExpression(System.Collections.Generic.IList<object> keys, Net.Vpc.Upa.Expressions.Var alias) {
            this.keys = keys;
            this.alias = alias;
        }

        public virtual System.Collections.Generic.IList<object> GetKeys() {
            return keys;
        }

        public virtual Net.Vpc.Upa.Expressions.Var GetAlias() {
            return alias;
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Impl.Uql.Expression.KeyEnumerationExpression o = new Net.Vpc.Upa.Impl.Uql.Expression.KeyEnumerationExpression(new System.Collections.Generic.List<object>(keys), alias == null ? null : (Net.Vpc.Upa.Expressions.Var) alias.Copy());
            return o;
        }


        public override string ToString() {
            return "KeyEnumerationExpression(" + "keys=" + keys + ", alias=" + alias + ')';
        }
    }
}
