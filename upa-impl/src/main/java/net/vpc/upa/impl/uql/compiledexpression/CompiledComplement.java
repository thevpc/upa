package net.vpc.upa.impl.uql.compiledexpression;

public final class CompiledComplement extends CompiledUnaryOperator
        implements Cloneable {
    private static final long serialVersionUID = 1L;

    public CompiledComplement(DefaultCompiledExpression expression) {
        super("~", expression);
    }
    @Override
    public DefaultCompiledExpression copy() {
        CompiledComplement o=new CompiledComplement(getExpression().copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

}
