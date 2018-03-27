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



namespace Net.Vpc.Upa.Impl.Uql
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 12/14/12 12:00 AM
     */
    public class QLFunctionExpression : Net.Vpc.Upa.Expressions.FunctionExpression {

        private string name;

        private Net.Vpc.Upa.Expressions.Expression[] arguments;

        public QLFunctionExpression(string name, Net.Vpc.Upa.Expressions.Expression[] arguments) {
            this.name = name;
            this.arguments = arguments;
        }


        public override string GetName() {
            return name;
        }


        public override int GetArgumentsCount() {
            return arguments.Length;
        }


        public override Net.Vpc.Upa.Expressions.Expression GetArgument(int index) {
            return arguments[index];
        }


        public override void SetArgument(int index, Net.Vpc.Upa.Expressions.Expression e) {
            arguments[index] = e;
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            return new Net.Vpc.Upa.Impl.Uql.QLFunctionExpression(name, arguments);
        }
    }
}
