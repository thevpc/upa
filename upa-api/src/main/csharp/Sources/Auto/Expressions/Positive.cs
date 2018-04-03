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



namespace Net.Vpc.Upa.Expressions
{

    public sealed class Positive : Net.Vpc.Upa.Expressions.UnaryOperatorExpression {



        public Positive(Net.Vpc.Upa.Expressions.Expression expression)  : base(Net.Vpc.Upa.Expressions.UnaryOperator.POSITIVE, "+", expression){

        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.Positive o = new Net.Vpc.Upa.Expressions.Positive(GetExpression().Copy());
            return o;
        }
    }
}
