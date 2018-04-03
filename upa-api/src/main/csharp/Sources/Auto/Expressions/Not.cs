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

    public sealed class Not : Net.Vpc.Upa.Expressions.UnaryOperatorExpression {



        public Not(Net.Vpc.Upa.Expressions.Expression expression)  : base(Net.Vpc.Upa.Expressions.UnaryOperator.NOT, "!", expression){

        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.Not o = new Net.Vpc.Upa.Expressions.Not(GetExpression().Copy());
            return o;
        }


        public override string ToString() {
            return "not(" + GetExpression() + ')';
        }
    }
}
