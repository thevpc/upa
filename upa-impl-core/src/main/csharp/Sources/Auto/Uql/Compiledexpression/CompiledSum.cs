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



namespace Net.TheVpc.Upa.Impl.Uql.Compiledexpression
{


    public sealed class CompiledSum : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledFunction {



        public CompiledSum(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression)  : base("Sum"){

            ProtectedAddArgument(expression);
        }

        public Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetExpression() {
            return GetArgument(0);
        }

        public override Net.TheVpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return GetExpression().GetEffectiveDataType();
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSum o = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSum(GetExpression().Copy());
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }
    }
}
