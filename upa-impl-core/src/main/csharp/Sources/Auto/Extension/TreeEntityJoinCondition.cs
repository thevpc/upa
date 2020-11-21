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



namespace Net.TheVpc.Upa.Impl.Extension
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 1/7/13 2:03 AM
     */
    internal class TreeEntityJoinCondition : Net.TheVpc.Upa.Expressions.DefaultExpression {

        private static readonly Net.TheVpc.Upa.Expressions.DefaultTag EXPR = new Net.TheVpc.Upa.Expressions.DefaultTag("EXPR");

        private static readonly Net.TheVpc.Upa.Expressions.DefaultTag ENTITY = new Net.TheVpc.Upa.Expressions.DefaultTag("ENTITY");

        private static readonly Net.TheVpc.Upa.Expressions.DefaultTag VAR1 = new Net.TheVpc.Upa.Expressions.DefaultTag("VAR1");

        private static readonly Net.TheVpc.Upa.Expressions.DefaultTag VAR2 = new Net.TheVpc.Upa.Expressions.DefaultTag("VAR1");

        private string treeTable;

        private string var1;

        private string var2;

        private Net.TheVpc.Upa.Expressions.Expression expression;

        internal TreeEntityJoinCondition(string treeTable, string var1, string var2, Net.TheVpc.Upa.Expressions.Expression expression) {
            this.treeTable = treeTable;
            this.var1 = var1;
            this.var2 = var2;
            this.expression = expression;
        }


        public override System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> GetChildren() {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> list = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.TaggedExpression>();
            list.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(new Net.TheVpc.Upa.Expressions.EntityName(treeTable), ENTITY));
            list.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(new Net.TheVpc.Upa.Expressions.Var(var1), VAR1));
            list.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(new Net.TheVpc.Upa.Expressions.Var(var2), VAR2));
            list.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(expression, EXPR));
            return list;
        }


        public override void SetChild(Net.TheVpc.Upa.Expressions.Expression e, Net.TheVpc.Upa.Expressions.ExpressionTag tag) {
            if (tag.Equals(ENTITY)) {
                treeTable = ((Net.TheVpc.Upa.Expressions.EntityName) e).GetName();
            } else if (tag.Equals(VAR1)) {
                var1 = ((Net.TheVpc.Upa.Expressions.Var) e).GetName();
            } else if (tag.Equals(VAR2)) {
                var2 = ((Net.TheVpc.Upa.Expressions.Var) e).GetName();
            } else if (tag.Equals(EXPR)) {
                expression = e;
            } else {
                throw new System.ArgumentException ("Unsupported");
            }
        }


        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            Net.TheVpc.Upa.Impl.Extension.TreeEntityJoinCondition o = new Net.TheVpc.Upa.Impl.Extension.TreeEntityJoinCondition(treeTable, var1, var2, expression.Copy());
            return o;
        }
    }
}
