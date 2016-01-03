package net.vpc.upa.impl.uql.compiledexpression;

public final class CompiledNegative extends CompiledUnaryOperator
        implements Cloneable {
    private static final long serialVersionUID = 1L;

    public CompiledNegative(DefaultCompiledExpression expression) {
        super("-", expression);
    }
    @Override
    public DefaultCompiledExpression copy() {
        CompiledNegative o=new CompiledNegative(getExpression().copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

}
