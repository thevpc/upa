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

    public class D2V : Net.Vpc.Upa.Expressions.Function {



        private Net.Vpc.Upa.Expressions.Expression @value;

        public D2V(Net.Vpc.Upa.Expressions.Expression expression) {
            this.@value = expression;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetValue() {
            return @value;
        }


        public override string GetName() {
            return "d2v";
        }


        public override int GetArgumentsCount() {
            return 1;
        }


        public override Net.Vpc.Upa.Expressions.Expression GetArgument(int index) {
            if (index != 0) {
                throw new System.IndexOutOfRangeException();
            }
            return @value;
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.D2V o = new Net.Vpc.Upa.Expressions.D2V(@value.Copy());
            return o;
        }
    }
}
