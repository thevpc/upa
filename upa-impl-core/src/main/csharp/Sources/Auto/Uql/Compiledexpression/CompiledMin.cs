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


    public sealed class CompiledMin : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledFunction {



        public CompiledMin(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression)  : base("Min"){

            ProtectedAddArgument(expression);
        }

        public Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetExpression() {
            return GetArgument(0);
        }


        public override Net.TheVpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return GetExpression().GetEffectiveDataType();
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledMin o = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledMin(GetExpression().Copy());
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }
    }
}
