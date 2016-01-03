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

    public sealed class CompiledComplement : Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUnaryOperator {



        public CompiledComplement(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression)  : base("~", expression){

        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledComplement o = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledComplement(GetExpression().Copy());
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }
    }
}
