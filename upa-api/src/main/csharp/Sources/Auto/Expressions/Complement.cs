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

    public sealed class Complement : Net.TheVpc.Upa.Expressions.UnaryOperatorExpression {



        public Complement(Net.TheVpc.Upa.Expressions.Expression expression)  : base(Net.TheVpc.Upa.Expressions.UnaryOperator.COMPLEMENT, "~", expression){

        }


        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            Net.TheVpc.Upa.Expressions.Complement o = new Net.TheVpc.Upa.Expressions.Complement(GetExpression().Copy());
            return o;
        }
    }
}
