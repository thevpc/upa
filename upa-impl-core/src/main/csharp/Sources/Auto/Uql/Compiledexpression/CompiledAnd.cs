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


    public sealed class CompiledAnd : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledBinaryOperatorExpression {



        public static Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TryAddCopies(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression right) {
            if (left != null) {
                left = left.Copy();
            }
            if (right != null) {
                right = right.Copy();
            }
            return TryAdd(left, right);
        }

        public static Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TryAdd(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression right) {
            if (left == null) {
                return right;
            }
            if (right == null) {
                return left;
            }
            return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledAnd(right, left);
        }

        public CompiledAnd(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left, object right)  : base(Net.TheVpc.Upa.Expressions.BinaryOperator.AND, left, right){

            System.Type t = left.GetTypeTransform().GetSourceType().GetPlatformType();
            System.Type r = left.GetTypeTransform().GetSourceType().GetPlatformType();
        }

        public CompiledAnd(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression right)  : base(Net.TheVpc.Upa.Expressions.BinaryOperator.AND, left, right){

        }

        public override Net.TheVpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform.BOOLEAN;
        }


        public override bool IsValid() {
            return (GetLeft() == null || GetLeft().IsValid()) || (GetRight() == null || GetRight().IsValid());
        }
    }
}
