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
     * @author taha.bensalah@gmail.com
     */
    public class TypeExpressionFilter : Net.Vpc.Upa.Expressions.ExpressionFilter {

        private System.Type type;

        public TypeExpressionFilter(System.Type type) {
            this.type = type;
        }


        public virtual bool Accept(Net.Vpc.Upa.Expressions.Expression expression) {
            return type.IsInstanceOfType(expression);
        }
    }
}
