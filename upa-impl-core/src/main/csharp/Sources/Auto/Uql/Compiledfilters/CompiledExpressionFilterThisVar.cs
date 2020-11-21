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
    public class CompiledExpressionFilterThisVar : Net.TheVpc.Upa.Impl.Uql.CompiledExpressionFilter {

        public CompiledExpressionFilterThisVar() {
        }

        public virtual bool Accept(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e) {
            if (e is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) {
                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar c = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) e;
                if (c.GetName().Equals("this")) {
                    return true;
                }
            }
            return false;
        }
    }
}
