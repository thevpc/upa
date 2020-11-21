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

    public sealed class Positive : Net.TheVpc.Upa.Expressions.UnaryOperatorExpression {



        public Positive(Net.TheVpc.Upa.Expressions.Expression expression)  : base(Net.TheVpc.Upa.Expressions.UnaryOperator.POSITIVE, "+", expression){

        }


        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            Net.TheVpc.Upa.Expressions.Positive o = new Net.TheVpc.Upa.Expressions.Positive(GetExpression().Copy());
            return o;
        }
    }
}
