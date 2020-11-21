/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.TheVpc.Upa.Expressions
{

    public sealed class Or : Net.TheVpc.Upa.Expressions.BinaryOperatorExpression {



        public Or(Net.TheVpc.Upa.Expressions.Expression left, object right)  : base(Net.TheVpc.Upa.Expressions.BinaryOperator.OR, left, right){

        }

        public Or(Net.TheVpc.Upa.Expressions.Expression left, Net.TheVpc.Upa.Expressions.Expression right)  : base(Net.TheVpc.Upa.Expressions.BinaryOperator.OR, left, right){

        }

        public static Net.TheVpc.Upa.Expressions.Expression Create(Net.TheVpc.Upa.Expressions.Expression left, Net.TheVpc.Upa.Expressions.Expression right) {
            if (left == null) {
                return right;
            }
            if (right == null) {
                return left;
            }
            return new Net.TheVpc.Upa.Expressions.Or(left, right);
        }
    }
}
