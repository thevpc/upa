package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.types.DataTypeTransform;

/**
 * Created by IntelliJ IDEA.
 * User: root
 * Date: 22 mai 2003
 * Time: 12:21:56
 * To change this template use Options | File Templates.
 */
public class CompiledSign extends CompiledFunction {
    private static final long serialVersionUID = 1L;

    
    public CompiledSign(CompiledExpressionExt value) {
        super("Sign");
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
        CompiledSign o=new CompiledSign(getExpression().copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }
}
