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


    public sealed class CompiledAvg : Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledFunction {



        public CompiledAvg(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression)  : base("Avg"){

            ProtectedAddArgument(expression);
        }


        public override Net.Vpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression = GetExpression();
            Net.Vpc.Upa.Types.DataTypeTransform dd = expression.GetEffectiveDataType();
            if (dd != null) {
                System.Type c = dd.GetTargetType().GetPlatformType();
                if (c.Equals(typeof(int?)) || c.Equals(typeof(byte?)) || c.Equals(typeof(short?))) {
                    c = typeof(double?);
                } else if (c.Equals(typeof(int?)) || c.Equals(typeof(byte)) || c.Equals(typeof(short))) {
                    c = typeof(double);
                }
                return (Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.ForNativeType(c));
            } else {
                return Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.DOUBLE;
            }
        }

        public Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetExpression() {
            return GetArgument(0);
        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledAvg o = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledAvg(GetExpression().Copy());
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }
    }
}
