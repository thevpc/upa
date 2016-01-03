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
    public class CompiledExpressionFilterThisVar : Net.Vpc.Upa.Impl.Uql.CompiledExpressionFilter {

        public CompiledExpressionFilterThisVar() {
        }

        public virtual bool Accept(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e) {
            if (e is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar c = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) e;
                if (c.GetName().Equals("this")) {
                    return true;
                }
            }
            return false;
        }
    }
}
