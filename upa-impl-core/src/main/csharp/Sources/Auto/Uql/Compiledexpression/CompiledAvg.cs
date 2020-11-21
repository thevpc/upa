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


    public sealed class CompiledAvg : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledFunction {



        public CompiledAvg(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression)  : base("Avg"){

            ProtectedAddArgument(expression);
        }


        public override Net.TheVpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression = GetExpression();
            Net.TheVpc.Upa.Types.DataTypeTransform dd = expression.GetEffectiveDataType();
            if (dd != null) {
                System.Type c = dd.GetTargetType().GetPlatformType();
                if (c.Equals(typeof(int?)) || c.Equals(typeof(byte?)) || c.Equals(typeof(short?))) {
                    c = typeof(double?);
                } else if (c.Equals(typeof(int?)) || c.Equals(typeof(byte)) || c.Equals(typeof(short))) {
                    c = typeof(double);
                }
                return (Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform.ForNativeType(c));
            } else {
                return Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform.DOUBLE;
            }
        }

        public Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetExpression() {
            return GetArgument(0);
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledAvg o = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledAvg(GetExpression().Copy());
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }
    }
}
