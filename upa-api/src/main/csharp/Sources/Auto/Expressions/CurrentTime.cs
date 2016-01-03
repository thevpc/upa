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
    public class CurrentTime : Net.Vpc.Upa.Expressions.Function {



        public CurrentTime() {
        }


        public override string GetName() {
            return "CurrentTime";
        }


        public override int GetArgumentsCount() {
            return 0;
        }


        public override Net.Vpc.Upa.Expressions.Expression GetArgument(int index) {
            throw new System.IndexOutOfRangeException();
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.CurrentTime o = new Net.Vpc.Upa.Expressions.CurrentTime();
            return o;
        }
    }
}
