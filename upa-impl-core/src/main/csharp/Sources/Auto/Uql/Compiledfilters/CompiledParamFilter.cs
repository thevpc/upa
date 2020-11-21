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
    * @creationdate 1/10/13 11:22 PM*/
    public class CompiledParamFilter : Net.TheVpc.Upa.Impl.Uql.CompiledExpressionFilter {

        private readonly string name;

        public CompiledParamFilter(string name) {
            this.name = name;
        }


        public virtual bool Accept(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e) {
            return (e is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledParam) && name.Equals(((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledParam) e).GetName());
        }
    }
}
