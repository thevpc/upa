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
     *
     * @author taha.bensalah@gmail.com
     */
    public class CompiledExpressionFilterLeafVar : Net.TheVpc.Upa.Impl.Uql.CompiledExpressionFilter {

        public static readonly Net.TheVpc.Upa.Impl.Uql.CompiledExpressionFilter INSTANCE = new Net.TheVpc.Upa.Impl.Uql.Compiledfilters.CompiledExpressionFilterLeafVar();

        public virtual bool Accept(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e) {
            if (!(e != null && typeof(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar).IsInstanceOfType(e))) {
                return false;
            }
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar v = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) e;
            return v.GetChild() == null;
        }
    }
}
