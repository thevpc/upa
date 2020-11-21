package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.impl.transform.IdentityDataTypeTransform;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.types.DataTypeTransform;


public final class CompiledExists extends CompiledFunction
        implements Cloneable {
    private static final long serialVersionUID = 1L;

    public CompiledExists() {
        super("Exists");
    }

    public CompiledExists(CompiledQueryStatement query) {
        this();
        setQuery(query);
    }

    @Override
    public DataTypeTransform getTypeTransform() {
        return IdentityDataTypeTransform.BOOLEAN;
    }

    public void setQuery(CompiledQueryStatement query) {
        if(getArgumentsCount()==0){
            protectedAddArgument(query);
        }else{
            protectedSetArgument(0, query);
        }
    }

    public CompiledQueryStatement getQuery() {
        return getArgumentsCount()==0?null:(CompiledQueryStatement)getArgument(0);
    }

    @Override
    public boolean isValid() {
        return getArgumentsCount()>0 && super.isValid();
    }

    @Override
    public CompiledExpressionExt copy() {
        CompiledQueryStatement qq = getQuery();
        CompiledExists o = qq==null?new CompiledExists():new CompiledExists((CompiledQueryStatement) qq.copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }


}
