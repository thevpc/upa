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


    public sealed class CompiledBitOr : Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledBinaryOperatorExpression {



        public CompiledBitOr(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left, object right)  : base(Net.Vpc.Upa.Expressions.BinaryOperator.BIT_OR, left, right){

            System.Type t = left.GetTypeTransform().GetTargetType().GetPlatformType();
            System.Type r = left.GetTypeTransform().GetTargetType().GetPlatformType();
            if (typeof(System.Numerics.BigInteger?).Equals(t) || typeof(System.Numerics.BigInteger?).Equals(r)) {
                SetDataType(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.BIGINT);
            } else if (typeof(long?).Equals(t) || typeof(long?).Equals(r)) {
                SetDataType(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.LONG);
            } else if (typeof(int?).Equals(t) || typeof(int?).Equals(r)) {
                SetDataType(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.INT);
            }
        }

        public CompiledBitOr(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression right)  : base(Net.Vpc.Upa.Expressions.BinaryOperator.BIT_OR, left, right){

            System.Type t = left.GetTypeTransform().GetTargetType().GetPlatformType();
            System.Type r = left.GetTypeTransform().GetTargetType().GetPlatformType();
            if (typeof(System.Numerics.BigInteger?).Equals(t) || typeof(System.Numerics.BigInteger?).Equals(r)) {
                SetDataType(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.BIGINT);
            } else if (typeof(long?).Equals(t) || typeof(long?).Equals(r)) {
                SetDataType(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.LONG);
            } else if (typeof(int?).Equals(t) || typeof(int?).Equals(r)) {
                SetDataType(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.INT);
            }
        }
    }
}
