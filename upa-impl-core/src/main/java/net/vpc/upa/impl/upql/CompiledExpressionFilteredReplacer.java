package net.vpc.upa.impl.upql;

import net.vpc.upa.expressions.CompiledExpression;


/**
 * Created by vpc on 6/25/17.
 */
public interface CompiledExpressionFilteredReplacer{
    boolean isTopDown();
    ReplaceResult update(CompiledExpression e, UpdateExpressionContext updateContext);
}
