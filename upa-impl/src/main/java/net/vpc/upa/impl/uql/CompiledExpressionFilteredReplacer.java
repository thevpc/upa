package net.vpc.upa.impl.uql;

import net.vpc.upa.expressions.CompiledExpression;

/**
 * Created by vpc on 6/25/17.
 */
public interface CompiledExpressionFilteredReplacer{
    boolean isTopDown();
    ReplaceResult update(CompiledExpression e);
}
