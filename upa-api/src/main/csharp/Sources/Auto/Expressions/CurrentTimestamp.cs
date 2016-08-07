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
    public class CurrentTimestamp : Net.Vpc.Upa.Expressions.FunctionExpression {



        public CurrentTimestamp(Net.Vpc.Upa.Expressions.Expression[] expressions) {
            CheckArgCount(GetName(), expressions, 0);
        }

        public CurrentTimestamp() {
        }


        public override string GetName() {
            return "CurrentTimestamp";
        }


        public override void SetArgument(int index, Net.Vpc.Upa.Expressions.Expression e) {
            throw new System.Exception("Not supported yet.");
        }


        public override System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> GetChildren() {
            return new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.TaggedExpression>();
        }


        public override void SetChild(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.Expressions.ExpressionTag tag) {
            throw new System.Exception("Not supported yet.");
        }


        public override int GetArgumentsCount() {
            return 0;
        }


        public override Net.Vpc.Upa.Expressions.Expression GetArgument(int index) {
            throw new System.IndexOutOfRangeException();
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.CurrentTimestamp o = new Net.Vpc.Upa.Expressions.CurrentTimestamp();
            return o;
        }
    }
}
