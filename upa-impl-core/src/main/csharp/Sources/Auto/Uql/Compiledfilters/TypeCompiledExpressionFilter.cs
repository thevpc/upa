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



namespace Net.TheVpc.Upa.Impl.Uql.Compiledfilters
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 2/3/13 9:16 PM
     */
    public class TypeCompiledExpressionFilter : Net.TheVpc.Upa.Impl.Uql.CompiledExpressionFilter {

        private System.Type type;

        public TypeCompiledExpressionFilter(System.Type type) {
            this.type = type;
        }


        public virtual bool Accept(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e) {
            return e != null && type.IsInstanceOfType(e);
        }
    }
}
