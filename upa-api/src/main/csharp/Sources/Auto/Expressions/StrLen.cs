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

    /**
     * Created by IntelliJ IDEA.
     * User: root
     * Date: 22 mai 2003
     * Time: 12:21:56
     * To change this template use Options | File Templates.
     */
    public class StrLen : Net.TheVpc.Upa.Expressions.FunctionExpression {



        private Net.TheVpc.Upa.Expressions.Expression expression;

        public StrLen(Net.TheVpc.Upa.Expressions.Expression[] expressions) {
            CheckArgCount(GetName(), expressions, 1);
            this.expression = expressions[0];
        }

        public StrLen(Net.TheVpc.Upa.Expressions.Expression expression) {
            this.expression = expression;
        }


        public override void SetArgument(int index, Net.TheVpc.Upa.Expressions.Expression e) {
            if (index == 0) {
                this.expression = e;
            } else {
                throw new System.IndexOutOfRangeException();
            }
        }


        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            Net.TheVpc.Upa.Expressions.StrLen o = new Net.TheVpc.Upa.Expressions.StrLen(expression.Copy());
            return o;
        }


        public override string GetName() {
            return "StrLen";
        }


        public override int GetArgumentsCount() {
            return 1;
        }


        public override Net.TheVpc.Upa.Expressions.Expression GetArgument(int index) {
            switch(index) {
                case 0:
                    return expression;
            }
            throw new System.IndexOutOfRangeException();
        }
    }
}
