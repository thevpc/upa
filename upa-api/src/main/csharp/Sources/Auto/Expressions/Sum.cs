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

    public sealed class Sum : Net.Vpc.Upa.Expressions.Function {



        private Net.Vpc.Upa.Expressions.Expression expression;

        public Sum(Net.Vpc.Upa.Expressions.Expression expression) {
            this.expression = null;
            this.expression = expression;
        }

        public int Size() {
            return 1;
        }

        public override bool IsValid() {
            return expression.IsValid();
        }


        public override string GetName() {
            return "Sum";
        }


        public override int GetArgumentsCount() {
            return 1;
        }


        public override Net.Vpc.Upa.Expressions.Expression GetArgument(int index) {
            if (index != 0) {
                throw new System.IndexOutOfRangeException();
            }
            return expression;
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.Sum o = new Net.Vpc.Upa.Expressions.Sum(expression.Copy());
            return o;
        }
    }
}
