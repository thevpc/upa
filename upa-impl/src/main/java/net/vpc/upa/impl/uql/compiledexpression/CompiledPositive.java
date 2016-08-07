package net.vpc.upa.impl.uql.compiledexpression;

public final class CompiledPositive extends CompiledUnaryOperator
        implements Cloneable {
    private static final long serialVersionUID = 1L;

    public CompiledPositive(DefaultCompiledExpression expression) {
        super("+", expression);
    }

    @Override
    public DefaultCompiledExpression copy() {
        CompiledPositive o=new CompiledPositive(getExpression().copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

}
