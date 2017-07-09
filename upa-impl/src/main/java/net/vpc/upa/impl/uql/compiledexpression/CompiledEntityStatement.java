package net.vpc.upa.impl.uql.compiledexpression;


import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;

public interface CompiledEntityStatement extends CompiledExpressionExt {
    String getEntityName();

    String getEntityAlias();

}
