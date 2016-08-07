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



namespace Net.Vpc.Upa.Expressions
{

    public sealed class And : Net.Vpc.Upa.Expressions.BinaryOperatorExpression {



        public And(Net.Vpc.Upa.Expressions.Expression left, object right)  : base(Net.Vpc.Upa.Expressions.BinaryOperator.AND, left, right){

        }

        public And(Net.Vpc.Upa.Expressions.Expression left, Net.Vpc.Upa.Expressions.Expression right)  : base(Net.Vpc.Upa.Expressions.BinaryOperator.AND, left, right){

        }

        public static Net.Vpc.Upa.Expressions.Expression Create(Net.Vpc.Upa.Expressions.Expression left, Net.Vpc.Upa.Expressions.Expression right) {
            if (left == null) {
                return right;
            }
            if (right == null) {
                return left;
            }
            return new Net.Vpc.Upa.Expressions.And(left, right);
        }
    }
}
