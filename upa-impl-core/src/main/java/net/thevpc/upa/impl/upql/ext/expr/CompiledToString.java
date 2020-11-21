package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.impl.transform.IdentityDataTypeTransform;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.types.DataTypeTransform;

public class CompiledToString extends CompiledFunction {

    private static final long serialVersionUID = 1L;

    public CompiledToString(CompiledExpressionExt expression) {
        super("tostring");
        protectedAddArgument(expression);
    }

    public CompiledExpressionExt getExpression() {
        return getArgument(0);
    }

    @Override
    public DataTypeTransform getTypeTransform() {
        //TODO should evaluate string length!!
        return IdentityDataTypeTransform.STRING;
    }

    @Override
    public CompiledExpressionExt copy() {
        CompiledToString o = new CompiledToString(getExpression().copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }
}
