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
     * Time: 17:00:10
     * To change this template use Options | File Templates.
     */
    public class CurrentDate : Net.Vpc.Upa.Expressions.Function {



        public CurrentDate() {
        }


        public override string GetName() {
            return "CurrentDate";
        }


        public override int GetArgumentsCount() {
            return 0;
        }


        public override Net.Vpc.Upa.Expressions.Expression GetArgument(int index) {
            throw new System.IndexOutOfRangeException();
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.CurrentDate o = new Net.Vpc.Upa.Expressions.CurrentDate();
            return o;
        }
    }
}
