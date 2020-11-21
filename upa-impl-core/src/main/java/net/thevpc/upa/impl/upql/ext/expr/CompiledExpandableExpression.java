package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/16/12
 * Time: 11:47 PM
 * To change this template use File | Settings | File Templates.
 */
public interface CompiledExpandableExpression extends CompiledExpressionExt {
    CompiledExpressionExt expand(PersistenceUnit persistenceUnit);
}
