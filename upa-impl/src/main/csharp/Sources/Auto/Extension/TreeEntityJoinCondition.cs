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



namespace Net.Vpc.Upa.Impl.Extension
{


    /**
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 1/7/13 2:03 AM*/
    internal class TreeEntityJoinCondition : Net.Vpc.Upa.Expressions.DefaultExpression {

        private string treeTable;

        private string var1;

        private string var2;

        private Net.Vpc.Upa.Expressions.Expression expression;

        internal TreeEntityJoinCondition(string treeTable, string var1, string var2, Net.Vpc.Upa.Expressions.Expression expression) {
            this.treeTable = treeTable;
            this.var1 = var1;
            this.var2 = var2;
            this.expression = expression;
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Impl.Extension.TreeEntityJoinCondition o = new Net.Vpc.Upa.Impl.Extension.TreeEntityJoinCondition(treeTable, var1, var2, expression.Copy());
            return o;
        }
    }
}
