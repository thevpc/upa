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


    public sealed class CompiledDifferent : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledBinaryOperatorExpression {



        public CompiledDifferent(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left, object right)  : base(Net.TheVpc.Upa.Expressions.BinaryOperator.DIFF, left, right){

            SetTypeTransform(Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform.BOOLEAN);
        }

        public CompiledDifferent(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression left, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression right)  : base(Net.TheVpc.Upa.Expressions.BinaryOperator.DIFF, left, right){

            SetTypeTransform(Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform.BOOLEAN);
        }
    }
}
