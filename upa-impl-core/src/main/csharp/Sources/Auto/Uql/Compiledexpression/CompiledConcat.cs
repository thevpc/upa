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


    public sealed class CompiledConcat : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledFunction {



        public CompiledConcat()  : base("Concat"){

        }


        public override Net.TheVpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform.STRING;
        }

        public CompiledConcat(params Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression [] expressions)  : this(){

            foreach (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression in expressions) {
                Add(expression);
            }
        }

        public Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledConcat Clear() {
            ProtectedClear();
            return this;
        }

        public Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledConcat AddAll(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledConcat other) {
            for (int i = 0; i < other.GetArgumentsCount(); i++) {
                Add((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) other.GetArgument(i));
            }
            return this;
        }

        public Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledConcat Add(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            if (expression == this) {
                throw new System.Exception("WOOOOOOOODOOOOOOO");
            } else {
                if (expression.GetTypeTransform() != null) {
                    System.Type platformType = expression.GetTypeTransform().GetTargetType().GetPlatformType();
                    if (platformType.Equals(typeof(int?)) || platformType.Equals(typeof(int)) || platformType.Equals(typeof(System.Numerics.BigInteger?))) {
                        expression = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledI2V(expression);
                    } else if (platformType.Equals(typeof(double?)) || platformType.Equals(typeof(double)) || platformType.Equals(typeof(System.Decimal?))) {
                        expression = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledD2V(expression);
                    }
                }
                ProtectedAddArgument(expression);
                return this;
            }
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledConcat o = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledConcat();
            ProtectedCopyTo(o);
            return o;
        }
    }
}
