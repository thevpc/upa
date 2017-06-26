package net.vpc.upa.impl.uql;

import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/17/12
 * Time: 4:08 PM
 * To change this template use File | Settings | File Templates.
 */
public interface CompiledExpressionFilter {
    boolean accept(DefaultCompiledExpression e);
}
