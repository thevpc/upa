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

    public sealed class StrFormat : Net.TheVpc.Upa.Expressions.FunctionExpression {



        private Net.TheVpc.Upa.Expressions.Expression[] expressions;

        private Net.TheVpc.Upa.Expressions.Literal pattern;

        public StrFormat(Net.TheVpc.Upa.Expressions.Expression[] expressions) {
            if (expressions.Length < 1) {
                CheckArgCount(GetName(), expressions, 1);
            }
            this.pattern = (Net.TheVpc.Upa.Expressions.Literal) expressions[0];
            this.expressions = new Net.TheVpc.Upa.Expressions.Expression[expressions.Length - 1];
            System.Array.Copy(this.expressions, 1, this.expressions, 0, expressions.Length - 1);
        }

        public StrFormat(string pattern, params Net.TheVpc.Upa.Expressions.Expression [] expressions) {
            this.expressions = expressions;
            this.pattern = new Net.TheVpc.Upa.Expressions.Literal(pattern);
        }


        public override string GetName() {
            return "strformat";
        }


        public override int GetArgumentsCount() {
            return expressions.Length + 1;
        }


        public override Net.TheVpc.Upa.Expressions.Expression GetArgument(int index) {
            return index == 0 ? ((Net.TheVpc.Upa.Expressions.Expression)(pattern)) : expressions[index - 1];
        }


        public override void SetArgument(int index, Net.TheVpc.Upa.Expressions.Expression e) {
            if (index == 0) {
                this.pattern = (Net.TheVpc.Upa.Expressions.Literal) e;
            } else {
                expressions[index - 1] = e;
            }
        }


        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            Net.TheVpc.Upa.Expressions.StrFormat o = new Net.TheVpc.Upa.Expressions.StrFormat((string) (pattern.GetValue()));
            o.expressions = new Net.TheVpc.Upa.Expressions.Expression[expressions.Length];
            for (int i = 0; i < expressions.Length; i++) {
                o.expressions[i] = expressions[i].Copy();
            }
            return o;
        }
    }
}
