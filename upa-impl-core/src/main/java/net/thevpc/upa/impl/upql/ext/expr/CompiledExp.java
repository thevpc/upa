package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.impl.transform.IdentityDataTypeTransform;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.types.DataTypeTransform;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 12:21:56
 * 
 */
public class CompiledExp extends CompiledFunction {
    private static final long serialVersionUID = 1L;


    public CompiledExp(CompiledExpressionExt value) {
        super("Exp");
        protectedAddArgument(value);
    }
    public CompiledExpressionExt getExpression(){
        return getArgument(0);
    }


    @Override
    public DataTypeTransform getTypeTransform() {
        return IdentityDataTypeTransform.INT;
    }


    @Override
    public CompiledExpressionExt copy() {
        CompiledExp o=new CompiledExp(getExpression().copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }
}
