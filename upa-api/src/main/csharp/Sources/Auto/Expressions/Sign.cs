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

    /**
     * Created by IntelliJ IDEA.
     * User: root
     * Date: 22 mai 2003
     * Time: 12:21:56
     * To change this template use Options | File Templates.
     */
    public class Sign : Net.Vpc.Upa.Expressions.Function {



        private Net.Vpc.Upa.Expressions.Expression @value;

        public Sign(Net.Vpc.Upa.Expressions.Expression @value) {
            this.@value = @value;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetValue() {
            return @value;
        }


        public override string GetName() {
            return "Sign";
        }


        public override int GetArgumentsCount() {
            return 1;
        }


        public override Net.Vpc.Upa.Expressions.Expression GetArgument(int index) {
            switch(index) {
                case 0:
                    return @value;
            }
            throw new System.IndexOutOfRangeException();
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.Sign o = new Net.Vpc.Upa.Expressions.Sign(@value.Copy());
            return o;
        }
    }
}
