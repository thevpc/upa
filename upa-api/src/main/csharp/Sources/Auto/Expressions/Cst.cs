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

    public sealed class Cst : Net.Vpc.Upa.Expressions.DefaultExpression {



        private object @value;

        public Cst(object @value) {
            this.@value = @value;
        }

        public override bool IsValid() {
            return true;
        }

        public object GetValue() {
            return @value;
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            return new Net.Vpc.Upa.Expressions.Cst(@value);
        }
    }
}
