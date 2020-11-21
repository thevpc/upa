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

    public sealed class Negative : Net.TheVpc.Upa.Expressions.UnaryOperatorExpression {



        public Negative(Net.TheVpc.Upa.Expressions.Expression expression)  : base(Net.TheVpc.Upa.Expressions.UnaryOperator.NEGATIVE, "-", expression){

        }


        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            Net.TheVpc.Upa.Expressions.Negative o = new Net.TheVpc.Upa.Expressions.Negative(GetExpression().Copy());
            return o;
        }
    }
}
