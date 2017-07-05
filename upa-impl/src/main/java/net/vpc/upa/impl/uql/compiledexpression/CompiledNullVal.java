package net.vpc.upa.impl.uql.compiledexpression;


import net.vpc.upa.types.DataTypeTransform;

public final class CompiledNullVal extends CompiledFunction
        implements Cloneable {
    private static final long serialVersionUID = 1L;

    
    public CompiledNullVal(DataTypeTransform type) {
        super("NullVal");
        protectedAddArgument(new CompiledTypeName(type));
        bindChildren(this);
    }

    public CompiledTypeName getNullTypeExpression(){
        return (CompiledTypeName)getArgument(0);
    }
    
    @Override
    public DataTypeTransform getTypeTransform() {
        return getNullTypeExpression().getTypeTransform();
    }

    @Override
    public Object clone() {
        return new CompiledNullVal(getTypeTransform());
    }

    @Override
    public String getDescription() {
        return "NULL";
    }

    @Override
    public DefaultCompiledExpression copy() {
        CompiledNullVal o = new CompiledNullVal(getNullTypeExpression().getTypeTransform());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

}
