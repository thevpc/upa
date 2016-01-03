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


    public sealed class CompiledLessEqualThan : Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledBinaryOperatorExpression {



        public CompiledLessEqualThan(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left, object right)  : base(Net.Vpc.Upa.Expressions.BinaryOperator.LE, left, right){

            SetDataType(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.BOOLEAN);
        }

        public CompiledLessEqualThan(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression right)  : base(Net.Vpc.Upa.Expressions.BinaryOperator.LE, left, right){

            SetDataType(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.BOOLEAN);
        }
    }
}
