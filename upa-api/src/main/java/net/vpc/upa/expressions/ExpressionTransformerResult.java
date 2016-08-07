package net.vpc.upa.expressions;

/**
 * Result of transformation
 * Holds information about the transformed expression or the initial expression if not modified
 * reports about whether or not the expression has ben updated (content change) or replaced (reference change)
 * Created by vpc on 7/2/16.
 */
public class ExpressionTransformerResult {
    private Expression expression;
    private boolean replaced;
    private boolean updated;

    public ExpressionTransformerResult(Expression expression, boolean replaced, boolean updated) {
        this.expression = expression;
        this.replaced = replaced;
        this.updated = updated;
    }

    public Expression getExpression() {
        return expression;
    }

    public boolean isChanged() {
        return replaced || updated;
    }
    public boolean isReplaced() {
        return replaced;
    }

    public boolean isUpdated() {
        return updated;
    }
}
