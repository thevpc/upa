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
     * Created with IntelliJ IDEA.
     * User: vpc
     * Date: 8/16/12
     * Time: 10:10 PM
     * To change this template use File | Settings | File Templates.
     */
    public class QueryField {

        private string alias;

        private Net.Vpc.Upa.Expressions.Expression expression;

        public QueryField(string alias, Net.Vpc.Upa.Expressions.Expression expression) {
            /*, Object relative*/
            this.expression = expression;
            this.alias = alias;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetExpression() {
            return expression;
        }

        public virtual void SetExpression(Net.Vpc.Upa.Expressions.Expression expression) {
            this.expression = expression;
        }

        public virtual string GetAlias() {
            return alias;
        }

        public virtual void SetAlias(string alias) {
            this.alias = alias;
        }


        public override string ToString() {
            Net.Vpc.Upa.Expressions.Expression e = GetExpression();
            return (alias == null ? "" : ("." + alias)) + (e == null ? "NULL" : e.ToString());
        }
    }
}
