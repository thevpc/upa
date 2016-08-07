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

    public sealed class Or : Net.Vpc.Upa.Expressions.BinaryOperatorExpression {



        public Or(Net.Vpc.Upa.Expressions.Expression left, object right)  : base(Net.Vpc.Upa.Expressions.BinaryOperator.OR, left, right){

        }

        public Or(Net.Vpc.Upa.Expressions.Expression left, Net.Vpc.Upa.Expressions.Expression right)  : base(Net.Vpc.Upa.Expressions.BinaryOperator.OR, left, right){

        }

        public static Net.Vpc.Upa.Expressions.Expression Create(Net.Vpc.Upa.Expressions.Expression left, Net.Vpc.Upa.Expressions.Expression right) {
            if (left == null) {
                return right;
            }
            if (right == null) {
                return left;
            }
            return new Net.Vpc.Upa.Expressions.Or(left, right);
        }
    }
}
