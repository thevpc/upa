package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.expressions.BinaryOperator;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;

public final class CompiledLessThan extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledLessThan(CompiledExpressionExt left, Object right) {
        super(BinaryOperator.LT, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }

    public CompiledLessThan(CompiledExpressionExt left, CompiledExpressionExt right) {
        super(BinaryOperator.LT, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }
}
