package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.types.DataTypeTransform;

public final class CompiledDistinct extends CompiledFunction
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledDistinct(CompiledExpressionExt[] expressions) {
        super("Distinct");
        for (int i = 0; i < expressions.length; i++) {
            CompiledExpressionExt expression = expressions[i];
            protectedAddArgument(expression);
        }
    }

    @Override
    public DataTypeTransform getTypeTransform() {
        return getArgument(0).getEffectiveDataType();
    }

    @Override
    public CompiledExpressionExt copy() {
        final CompiledExpressionExt[] old = getArguments();
        CompiledExpressionExt[] expressions2 = new CompiledExpressionExt[old.length];
        for (int i = 0; i < expressions2.length; i++) {
            expressions2[i] = old[i].copy();
        }
        CompiledDistinct o = new CompiledDistinct(expressions2);
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

}
