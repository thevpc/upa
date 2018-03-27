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


    public sealed class CompiledXOr : Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledBinaryOperatorExpression {



        public CompiledXOr(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left, object right)  : base(Net.Vpc.Upa.Expressions.BinaryOperator.XOR, left, right){

            System.Type t = left.GetTypeTransform().GetTargetType().GetPlatformType();
            System.Type r = left.GetTypeTransform().GetTargetType().GetPlatformType();
            if (typeof(System.Numerics.BigInteger?).Equals(t) || typeof(System.Numerics.BigInteger?).Equals(r)) {
                SetTypeTransform(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.BIGINT);
            } else if (typeof(long?).Equals(t) || typeof(long?).Equals(r)) {
                SetTypeTransform(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.LONG);
            } else if (typeof(int?).Equals(t) || typeof(int?).Equals(r)) {
                SetTypeTransform(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.INT);
            }
        }

        public CompiledXOr(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression right)  : base(Net.Vpc.Upa.Expressions.BinaryOperator.XOR, left, right){

            System.Type t = left.GetTypeTransform().GetTargetType().GetPlatformType();
            System.Type r = left.GetTypeTransform().GetTargetType().GetPlatformType();
            if (typeof(System.Numerics.BigInteger?).Equals(t) || typeof(System.Numerics.BigInteger?).Equals(r)) {
                SetTypeTransform(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.BIGINT);
            } else if (typeof(long?).Equals(t) || typeof(long?).Equals(r)) {
                SetTypeTransform(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.LONG);
            } else if (typeof(int?).Equals(t) || typeof(int?).Equals(r)) {
                SetTypeTransform(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.INT);
            }
        }
    }
}
