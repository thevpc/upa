package net.vpc.upa.impl.extension;

import java.util.ArrayList;
import java.util.List;

import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.expressions.DefaultExpression;
import net.vpc.upa.expressions.DefaultTag;
import net.vpc.upa.expressions.EntityName;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.ExpressionTag;
import net.vpc.upa.expressions.TaggedExpression;
import net.vpc.upa.expressions.Var;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/7/13 2:03 AM
 */
class TreeEntityJoinCondition extends DefaultExpression {

    private static final DefaultTag EXPR = new DefaultTag("EXPR");
    private static final DefaultTag ENTITY = new DefaultTag("ENTITY");
    private static final DefaultTag VAR1 = new DefaultTag("VAR1");
    private static final DefaultTag VAR2 = new DefaultTag("VAR1");
    private String treeTable;
    private String var1;
    private String var2;
    private Expression expression;

    TreeEntityJoinCondition(String treeTable, String var1, String var2, Expression expression) {
        this.treeTable = treeTable;
        this.var1 = var1;
        this.var2 = var2;
        this.expression = expression;
    }

    @Override
    public List<TaggedExpression> getChildren() {
        List<TaggedExpression> list = new ArrayList<TaggedExpression>();
        list.add(new TaggedExpression(new EntityName(treeTable), ENTITY));
        list.add(new TaggedExpression(new Var(var1), VAR1));
        list.add(new TaggedExpression(new Var(var2), VAR2));
        list.add(new TaggedExpression(expression, EXPR));
        return list;
    }

    @Override
    public void setChild(Expression e, ExpressionTag tag) {
        if (tag.equals(ENTITY)) {
            treeTable = ((EntityName) e).getName();
        } else if (tag.equals(VAR1)) {
            var1 = ((Var) e).getName();
        } else if (tag.equals(VAR2)) {
            var2 = ((Var) e).getName();
        } else if (tag.equals(EXPR)) {
            expression = e;
        } else {
            throw new UPAIllegalArgumentException("Unsupported");
        }
    }

    @Override
    public Expression copy() {
        TreeEntityJoinCondition o = new TreeEntityJoinCondition(treeTable, var1, var2, expression.copy());
        return o;
    }
}
