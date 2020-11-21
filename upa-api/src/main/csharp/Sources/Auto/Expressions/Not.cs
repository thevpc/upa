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

    public sealed class Not : Net.TheVpc.Upa.Expressions.UnaryOperatorExpression {



        public Not(Net.TheVpc.Upa.Expressions.Expression expression)  : base(Net.TheVpc.Upa.Expressions.UnaryOperator.NOT, "!", expression){

        }


        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            Net.TheVpc.Upa.Expressions.Not o = new Net.TheVpc.Upa.Expressions.Not(GetExpression().Copy());
            return o;
        }


        public override string ToString() {
            return "not(" + GetExpression() + ')';
        }
    }
}
