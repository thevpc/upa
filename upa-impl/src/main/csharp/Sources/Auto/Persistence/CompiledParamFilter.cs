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



namespace Net.Vpc.Upa.Impl.Persistence
{


    /**
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 1/10/13 11:22 PM*/
    internal class CompiledParamFilter : Net.Vpc.Upa.Impl.Uql.CompiledExpressionFilter {

        private readonly string name;

        public CompiledParamFilter(string name) {
            this.name = name;
        }


        public virtual bool Accept(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e) {
            return (e is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam) && name.Equals(((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam) e).GetName());
        }
    }
}
