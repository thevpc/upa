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


    public sealed class CompiledAnd : Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledBinaryOperatorExpression {



        public static Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TryAddCopies(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression right) {
            if (left != null) {
                left = left.Copy();
            }
            if (right != null) {
                right = right.Copy();
            }
            return TryAdd(left, right);
        }

        public static Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TryAdd(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression right) {
            if (left == null) {
                return right;
            }
            if (right == null) {
                return left;
            }
            return new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledAnd(right, left);
        }

        public CompiledAnd(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left, object right)  : base(Net.Vpc.Upa.Expressions.BinaryOperator.AND, left, right){

            System.Type t = left.GetTypeTransform().GetSourceType().GetPlatformType();
            System.Type r = left.GetTypeTransform().GetSourceType().GetPlatformType();
        }

        public CompiledAnd(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression right)  : base(Net.Vpc.Upa.Expressions.BinaryOperator.AND, left, right){

        }

        public override Net.Vpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.BOOLEAN;
        }


        public override bool IsValid() {
            return (GetLeft() == null || GetLeft().IsValid()) || (GetRight() == null || GetRight().IsValid());
        }
    }
}
