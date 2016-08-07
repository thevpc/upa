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


    public sealed class CompiledMax : Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledFunction {



        public CompiledMax(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression)  : base("Max"){

            ProtectedAddArgument(expression);
        }

        public Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetExpression() {
            return GetArgument(0);
        }


        public override Net.Vpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return GetExpression().GetEffectiveDataType();
        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledMax o = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledMax(GetExpression().Copy());
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }
    }
}
