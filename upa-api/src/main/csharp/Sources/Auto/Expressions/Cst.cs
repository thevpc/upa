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


    public sealed class Cst : Net.TheVpc.Upa.Expressions.DefaultExpression {



        private object @value;

        public Cst(object @value) {
            this.@value = @value;
        }


        public override System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> GetChildren() {
            return new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.TaggedExpression>();
        }


        public override void SetChild(Net.TheVpc.Upa.Expressions.Expression e, Net.TheVpc.Upa.Expressions.ExpressionTag tag) {
            throw new System.Exception("Not supported yet.");
        }

        public override bool IsValid() {
            return true;
        }

        public object GetValue() {
            return @value;
        }


        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            return new Net.TheVpc.Upa.Expressions.Cst(@value);
        }
    }
}
