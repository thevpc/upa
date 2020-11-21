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
     * @author taha.bensalah@gmail.com
     */
    public class TypeExpressionFilter : Net.TheVpc.Upa.Expressions.ExpressionFilter {

        private System.Type type;

        public TypeExpressionFilter(System.Type type) {
            this.type = type;
        }


        public virtual bool Accept(Net.TheVpc.Upa.Expressions.Expression expression) {
            return type.IsInstanceOfType(expression);
        }
    }
}
