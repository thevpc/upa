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
     * @creationdate 1/7/13 2:03 AM
     */
    internal class TreeEntityJoinCondition : Net.Vpc.Upa.Expressions.DefaultExpression {

        private static readonly Net.Vpc.Upa.Expressions.DefaultTag EXPR = new Net.Vpc.Upa.Expressions.DefaultTag("EXPR");

        private static readonly Net.Vpc.Upa.Expressions.DefaultTag ENTITY = new Net.Vpc.Upa.Expressions.DefaultTag("ENTITY");

        private static readonly Net.Vpc.Upa.Expressions.DefaultTag VAR1 = new Net.Vpc.Upa.Expressions.DefaultTag("VAR1");

        private static readonly Net.Vpc.Upa.Expressions.DefaultTag VAR2 = new Net.Vpc.Upa.Expressions.DefaultTag("VAR1");

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


        public override System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> GetChildren() {
            System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> list = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.TaggedExpression>();
            list.Add(new Net.Vpc.Upa.Expressions.TaggedExpression(new Net.Vpc.Upa.Expressions.EntityName(treeTable), ENTITY));
            list.Add(new Net.Vpc.Upa.Expressions.TaggedExpression(new Net.Vpc.Upa.Expressions.Var(var1), VAR1));
            list.Add(new Net.Vpc.Upa.Expressions.TaggedExpression(new Net.Vpc.Upa.Expressions.Var(var2), VAR2));
            list.Add(new Net.Vpc.Upa.Expressions.TaggedExpression(expression, EXPR));
            return list;
        }


        public override void SetChild(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.Expressions.ExpressionTag tag) {
            if (tag.Equals(ENTITY)) {
                treeTable = ((Net.Vpc.Upa.Expressions.EntityName) e).GetName();
            } else if (tag.Equals(VAR1)) {
                var1 = ((Net.Vpc.Upa.Expressions.Var) e).GetName();
            } else if (tag.Equals(VAR2)) {
                var2 = ((Net.Vpc.Upa.Expressions.Var) e).GetName();
            } else if (tag.Equals(EXPR)) {
                expression = e;
            } else {
                throw new System.ArgumentException ("Unsupported");
            }
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Impl.Extension.TreeEntityJoinCondition o = new Net.Vpc.Upa.Impl.Extension.TreeEntityJoinCondition(treeTable, var1, var2, expression.Copy());
            return o;
        }
    }
}
