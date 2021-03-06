package net.thevpc.upa.impl.upql.ext.expr;


import net.thevpc.upa.impl.transform.IdentityDataTypeTransform;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.types.DataTypeTransform;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 17:00:10
 * 
 */
public class CompiledCurrentDate extends CompiledFunction {
    private static final long serialVersionUID = 1L;

    public CompiledCurrentDate() {
        super("CurrentDate");
    }

    @Override
    public DataTypeTransform getTypeTransform() {
        return IdentityDataTypeTransform.DATE;
    }

    @Override
    public CompiledExpressionExt copy() {
        CompiledCurrentDate o = new CompiledCurrentDate();
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

}
