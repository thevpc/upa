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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 12/24/12 1:24 AM
     */
    internal class OrderItem {

        private Net.Vpc.Upa.Expressions.Expression expression;

        private bool asc;

        public OrderItem(Net.Vpc.Upa.Expressions.Expression expression, bool asc) {
            this.expression = expression;
            this.asc = asc;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetExpression() {
            return expression;
        }

        public virtual bool IsAsc() {
            return asc;
        }
    }
}
