package net.thevpc.upa.impl.upql.ext.expr;


import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;

public interface CompiledEntityStatement extends CompiledExpressionExt {
    String getEntityName();

    String getEntityAlias();

}
