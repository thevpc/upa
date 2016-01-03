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

    public sealed class Count : Net.Vpc.Upa.Expressions.Function {



        private Net.Vpc.Upa.Expressions.Expression @value;

        public Count(Net.Vpc.Upa.Expressions.Expression expression) {
            this.@value = expression;
        }

        public Net.Vpc.Upa.Expressions.Expression GetValue() {
            return @value;
        }

        public int Size() {
            return 1;
        }

        public override bool IsValid() {
            return @value.IsValid();
        }


        public override string GetName() {
            return "Count";
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
            Net.Vpc.Upa.Expressions.Count o = new Net.Vpc.Upa.Expressions.Count(@value.Copy());
            return o;
        }
    }
}
