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


    public sealed class CompiledConcat : Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledFunction {



        public CompiledConcat()  : base("Concat"){

        }


        public override Net.Vpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.STRING;
        }

        public CompiledConcat(params Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression [] expressions)  : this(){

            foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression in expressions) {
                Add(expression);
            }
        }

        public Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledConcat Clear() {
            ProtectedClear();
            return this;
        }

        public Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledConcat AddAll(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledConcat other) {
            for (int i = 0; i < other.GetArgumentsCount(); i++) {
                Add((Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) other.GetArgument(i));
            }
            return this;
        }

        public Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledConcat Add(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            if (expression == this) {
                throw new System.Exception("WOOOOOOOODOOOOOOO");
            } else {
                if (expression.GetTypeTransform() != null) {
                    System.Type platformType = expression.GetTypeTransform().GetTargetType().GetPlatformType();
                    if (platformType.Equals(typeof(int?)) || platformType.Equals(typeof(int)) || platformType.Equals(typeof(System.Numerics.BigInteger?))) {
                        expression = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledI2V(expression);
                    } else if (platformType.Equals(typeof(double?)) || platformType.Equals(typeof(double)) || platformType.Equals(typeof(System.Decimal))) {
                        expression = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledD2V(expression);
                    }
                }
                ProtectedAddArgument(expression);
                return this;
            }
        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledConcat o = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledConcat();
            ProtectedCopyTo(o);
            return o;
        }
    }
}
