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


    public sealed class Avg : Net.TheVpc.Upa.Expressions.FunctionExpression {



        private Net.TheVpc.Upa.Expressions.Expression expression;

        public Avg(Net.TheVpc.Upa.Expressions.Expression[] expressions) {
            CheckArgCount(GetName(), expressions, 1);
            this.expression = expressions[0];
        }

        public Avg(Net.TheVpc.Upa.Expressions.Expression expression) {
            this.expression = expression;
        }


        public override void SetArgument(int index, Net.TheVpc.Upa.Expressions.Expression e) {
            if (index == 0) {
                this.expression = e;
            } else {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException();
            }
        }

        public int Size() {
            return 1;
        }


        public override bool IsValid() {
            return expression.IsValid();
        }

        public Net.TheVpc.Upa.Expressions.Expression GetExpression() {
            return expression;
        }


        public override string GetName() {
            return "Avg";
        }


        public override int GetArgumentsCount() {
            return 1;
        }


        public override Net.TheVpc.Upa.Expressions.Expression GetArgument(int index) {
            if (index != 0) {
                throw new System.IndexOutOfRangeException();
            }
            return expression;
        }


        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            Net.TheVpc.Upa.Expressions.Avg o = new Net.TheVpc.Upa.Expressions.Avg(expression.Copy());
            return o;
        }
    }
}
