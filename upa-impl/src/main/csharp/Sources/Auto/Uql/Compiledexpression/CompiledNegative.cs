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



namespace Net.Vpc.Upa.Impl.Uql.Compiledexpression
{

    public sealed class CompiledNegative : Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUnaryOperator {



        public CompiledNegative(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression)  : base("-", expression){

        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNegative o = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNegative(GetExpression().Copy());
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }
    }
}
