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

    public sealed class Negative : Net.Vpc.Upa.Expressions.UnaryOperatorExpression {



        public Negative(Net.Vpc.Upa.Expressions.Expression expression)  : base(Net.Vpc.Upa.Expressions.UnaryOperator.NEGATIVE, "-", expression){

        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.Negative o = new Net.Vpc.Upa.Expressions.Negative(GetExpression().Copy());
            return o;
        }
    }
}
