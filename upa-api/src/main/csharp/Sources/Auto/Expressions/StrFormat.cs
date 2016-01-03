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

    public sealed class StrFormat : Net.Vpc.Upa.Expressions.Function {



        private Net.Vpc.Upa.Expressions.Expression[] expressions;

        private Net.Vpc.Upa.Expressions.Literal pattern;

        public StrFormat(string pattern, params Net.Vpc.Upa.Expressions.Expression [] expressions) {
            this.expressions = expressions;
            this.pattern = new Net.Vpc.Upa.Expressions.Literal(pattern);
        }


        public override string GetName() {
            return "strformat";
        }


        public override int GetArgumentsCount() {
            return expressions.Length + 1;
        }


        public override Net.Vpc.Upa.Expressions.Expression GetArgument(int index) {
            return index == 0 ? ((Net.Vpc.Upa.Expressions.Expression)(pattern)) : expressions[index - 1];
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.StrFormat o = new Net.Vpc.Upa.Expressions.StrFormat((string) (pattern.GetValue()));
            o.expressions = new Net.Vpc.Upa.Expressions.Expression[expressions.Length];
            for (int i = 0; i < expressions.Length; i++) {
                o.expressions[i] = expressions[i].Copy();
            }
            return o;
        }
    }
}
