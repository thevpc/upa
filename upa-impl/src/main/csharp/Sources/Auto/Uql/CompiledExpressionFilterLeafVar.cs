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



namespace Net.Vpc.Upa.Impl.Uql
{


    /**
     *
     * @author vpc
     */
    public class CompiledExpressionFilterLeafVar : Net.Vpc.Upa.Impl.Uql.CompiledExpressionFilter {

        public static readonly Net.Vpc.Upa.Impl.Uql.CompiledExpressionFilter INSTANCE = new Net.Vpc.Upa.Impl.Uql.CompiledExpressionFilterLeafVar();

        public virtual bool Accept(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e) {
            if (!(e != null && typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar).IsInstanceOfType(e))) {
                return false;
            }
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar v = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) e;
            return v.GetChild() == null;
        }
    }
}
