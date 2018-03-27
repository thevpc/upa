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



namespace Net.Vpc.Upa.Impl.Uql.Filters
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 2/3/13 9:16 PM
     */
    public class TypeExpressionFilter : Net.Vpc.Upa.Expressions.ExpressionFilter {

        private System.Type type;

        public TypeExpressionFilter(System.Type type) {
            this.type = type;
        }


        public virtual bool Accept(Net.Vpc.Upa.Expressions.Expression e) {
            return e != null && type.IsInstanceOfType(e);
        }
    }
}
