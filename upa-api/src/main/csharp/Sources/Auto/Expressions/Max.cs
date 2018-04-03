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

    public sealed class Max : Net.Vpc.Upa.Expressions.FunctionExpression {



        private Net.Vpc.Upa.Expressions.Expression expression;

        public Max(Net.Vpc.Upa.Expressions.Expression[] expressions) {
            CheckArgCount(GetName(), expressions, 1);
            this.expression = expressions[0];
        }

        public Max(Net.Vpc.Upa.Expressions.Expression expression) {
            this.expression = expression;
        }


        public override void SetArgument(int index, Net.Vpc.Upa.Expressions.Expression e) {
            if (index == 0) {
                this.expression = e;
            } else {
                throw new System.IndexOutOfRangeException();
            }
        }

        public int Size() {
            return 1;
        }

        public override bool IsValid() {
            return expression.IsValid();
        }


        public override string GetName() {
            return "Max";
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
            Net.Vpc.Upa.Expressions.Max o = new Net.Vpc.Upa.Expressions.Max(expression.Copy());
            return o;
        }
    }
}
