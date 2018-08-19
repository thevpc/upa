package net.vpc.upa.impl.upql;

import net.vpc.upa.expressions.CompiledExpression;

import java.util.Map;

/**
 * Created by vpc on 6/25/17.
 */
public interface CompiledExpressionFilteredReplacer{
    boolean isTopDown();
    ReplaceResult update(CompiledExpression e, Map<String, Object> updateContext);
}
