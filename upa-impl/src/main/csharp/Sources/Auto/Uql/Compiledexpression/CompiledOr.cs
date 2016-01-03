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


    public sealed class CompiledOr : Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledBinaryOperatorExpression {



        public CompiledOr(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left, object right)  : base(Net.Vpc.Upa.Expressions.BinaryOperator.OR, left, right){

            SetDataType(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.BOOLEAN);
        }

        public CompiledOr(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression right)  : base(Net.Vpc.Upa.Expressions.BinaryOperator.OR, left, right){

            SetDataType(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.BOOLEAN);
        }


        public override bool IsValid() {
            return (GetLeft() == null || GetLeft().IsValid()) || (GetRight() == null || GetRight().IsValid());
        }
    }
}
