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


    public sealed class Avg : Net.Vpc.Upa.Expressions.FunctionExpression {



        private Net.Vpc.Upa.Expressions.Expression expression;

        public Avg(Net.Vpc.Upa.Expressions.Expression[] expressions) {
            CheckArgCount(GetName(), expressions, 1);
            this.expression = expressions[0];
        }

        public Avg(Net.Vpc.Upa.Expressions.Expression expression) {
            this.expression = expression;
        }


        public override void SetArgument(int index, Net.Vpc.Upa.Expressions.Expression e) {
            if (index == 0) {
                this.expression = e;
            } else {
                throw new Net.Vpc.Upa.Exceptions.UPAIllegalArgumentException();
            }
        }

        public int Size() {
            return 1;
        }


        public override bool IsValid() {
            return expression.IsValid();
        }

        public Net.Vpc.Upa.Expressions.Expression GetExpression() {
            return expression;
        }


        public override string GetName() {
            return "Avg";
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
            Net.Vpc.Upa.Expressions.Avg o = new Net.Vpc.Upa.Expressions.Avg(expression.Copy());
            return o;
        }
    }
}
