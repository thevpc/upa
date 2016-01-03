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


    public sealed class CompiledDifferent : Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledBinaryOperatorExpression {



        public CompiledDifferent(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left, object right)  : base(Net.Vpc.Upa.Expressions.BinaryOperator.DIFF, left, right){

            SetDataType(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.BOOLEAN);
        }

        public CompiledDifferent(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression right)  : base(Net.Vpc.Upa.Expressions.BinaryOperator.DIFF, left, right){

            SetDataType(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.BOOLEAN);
        }
    }
}
