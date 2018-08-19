package net.vpc.upa.impl.upql.ext.expr;


import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;

public interface CompiledEntityStatement extends CompiledExpressionExt {
    String getEntityName();

    String getEntityAlias();

}
