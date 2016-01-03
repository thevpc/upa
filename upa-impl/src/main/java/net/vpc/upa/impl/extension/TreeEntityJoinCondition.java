package net.vpc.upa.impl.extension;

import net.vpc.upa.expressions.DefaultExpression;
import net.vpc.upa.expressions.Expression;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/7/13 2:03 AM
*/
class TreeEntityJoinCondition extends DefaultExpression {
    private String treeTable;
    private String var1;
    private String var2;
    private Expression expression;

    TreeEntityJoinCondition(String treeTable, String var1, String var2, Expression expression) {
        this.treeTable = treeTable;
        this.var1 = var1;
        this.var2 = var2;
        this.expression=expression;
    }

    @Override
    public Expression copy() {
        TreeEntityJoinCondition o=new TreeEntityJoinCondition(treeTable,var1,var2,expression.copy());
        return o;
    }
}
