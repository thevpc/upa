package net.vpc.upa.impl.uql.compiledexpression;


public interface CompiledEntityStatement extends DefaultCompiledExpression {
    String getEntityName();

    String getEntityAlias();

}
