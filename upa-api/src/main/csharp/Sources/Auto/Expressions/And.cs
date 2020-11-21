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

    public sealed class And : Net.TheVpc.Upa.Expressions.BinaryOperatorExpression {



        public And(Net.TheVpc.Upa.Expressions.Expression left, object right)  : base(Net.TheVpc.Upa.Expressions.BinaryOperator.AND, left, right){

        }

        public And(Net.TheVpc.Upa.Expressions.Expression left, Net.TheVpc.Upa.Expressions.Expression right)  : base(Net.TheVpc.Upa.Expressions.BinaryOperator.AND, left, right){

        }

        public static Net.TheVpc.Upa.Expressions.Expression Create(Net.TheVpc.Upa.Expressions.Expression left, Net.TheVpc.Upa.Expressions.Expression right) {
            if (left == null) {
                return right;
            }
            if (right == null) {
                return left;
            }
            return new Net.TheVpc.Upa.Expressions.And(left, right);
        }
    }
}
