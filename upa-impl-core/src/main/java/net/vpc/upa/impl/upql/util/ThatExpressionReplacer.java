package net.vpc.upa.impl.upql.util;

import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.ExpressionTag;
import net.vpc.upa.expressions.ExpressionVisitor;
import net.vpc.upa.expressions.Var;

/**
 * Created by vpc on 7/3/16.
 */
public class ThatExpressionReplacer implements ExpressionVisitor {
    private final String alias2;

    public ThatExpressionReplacer(String alias2) {
        this.alias2 = alias2;
    }

    @Override
    public boolean visit(Expression expression, ExpressionTag tag) {
        if (expression instanceof Var) {
            Expression v = expression;
            while (v instanceof Var && ((Var) v).getApplier() != null) {
                v = ((Var) v).getApplier();
            }
            if (v instanceof Var && ((Var) v).getName().equals("that")) {
                ((Var) v).setName(alias2);
            }
        }
        return true;
    }
}
