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


    public sealed class CompiledMinus : Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledBinaryOperatorExpression {



        public CompiledMinus(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left, object right)  : base(Net.Vpc.Upa.Expressions.BinaryOperator.MINUS, left, right){

            System.Type t = left.GetTypeTransform().GetTargetType().GetPlatformType();
            System.Type r = left.GetTypeTransform().GetTargetType().GetPlatformType();
            if (typeof(System.Numerics.BigInteger?).Equals(t) || typeof(System.Numerics.BigInteger?).Equals(r)) {
                if (typeof(double?).Equals(t) || typeof(double?).Equals(r)) {
                    SetTypeTransform(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.DOUBLE);
                } else if (typeof(float?).Equals(t) || typeof(float?).Equals(r)) {
                    SetTypeTransform(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.DOUBLE);
                } else {
                    SetTypeTransform(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.BIGINT);
                }
            } else if (typeof(double?).Equals(t) || typeof(double?).Equals(r)) {
                SetTypeTransform(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.DOUBLE);
            } else if (typeof(float?).Equals(t) || typeof(float?).Equals(r)) {
                SetTypeTransform(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.FLOAT);
            } else if (typeof(long?).Equals(t) || typeof(long?).Equals(r)) {
                SetTypeTransform(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.LONG);
            } else if (typeof(int?).Equals(t) || typeof(int?).Equals(r)) {
                SetTypeTransform(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.INT);
            } else {
                throw new System.ArgumentException ("Unsupported types");
            }
        }

        public CompiledMinus(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression right)  : base(Net.Vpc.Upa.Expressions.BinaryOperator.MINUS, left, right){

            System.Type t = left.GetTypeTransform().GetTargetType().GetPlatformType();
            System.Type r = left.GetTypeTransform().GetTargetType().GetPlatformType();
            if (typeof(System.Numerics.BigInteger?).Equals(t) || typeof(System.Numerics.BigInteger?).Equals(r)) {
                if (typeof(double?).Equals(t) || typeof(double?).Equals(r)) {
                    SetTypeTransform(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.DOUBLE);
                } else if (typeof(float?).Equals(t) || typeof(float?).Equals(r)) {
                    SetTypeTransform(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.DOUBLE);
                } else {
                    SetTypeTransform(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.BIGINT);
                }
            } else if (typeof(double?).Equals(t) || typeof(double?).Equals(r)) {
                SetTypeTransform(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.DOUBLE);
            } else if (typeof(float?).Equals(t) || typeof(float?).Equals(r)) {
                SetTypeTransform(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.FLOAT);
            } else if (typeof(long?).Equals(t) || typeof(long?).Equals(r)) {
                SetTypeTransform(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.LONG);
            } else if (typeof(int?).Equals(t) || typeof(int?).Equals(r)) {
                SetTypeTransform(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.INT);
            } else {
                throw new System.ArgumentException ("Unsupported types");
            }
        }
    }
}
