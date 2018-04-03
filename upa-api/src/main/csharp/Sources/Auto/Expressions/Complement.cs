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

    public sealed class Complement : Net.Vpc.Upa.Expressions.UnaryOperatorExpression {



        public Complement(Net.Vpc.Upa.Expressions.Expression expression)  : base(Net.Vpc.Upa.Expressions.UnaryOperator.COMPLEMENT, "~", expression){

        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.Complement o = new Net.Vpc.Upa.Expressions.Complement(GetExpression().Copy());
            return o;
        }
    }
}
