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
    public class StrLen : Net.Vpc.Upa.Expressions.Function {



        private Net.Vpc.Upa.Expressions.Expression @value;

        public StrLen(Net.Vpc.Upa.Expressions.Expression @value) {
            this.@value = @value;
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.StrLen o = new Net.Vpc.Upa.Expressions.StrLen(@value.Copy());
            return o;
        }


        public override string GetName() {
            return "StrLen";
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
    }
}
