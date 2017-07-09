package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.expressions.BinaryOperator;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;

public final class CompiledLessEqualThan extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledLessEqualThan(CompiledExpressionExt left, Object right) {
        super(BinaryOperator.LE, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }

    public CompiledLessEqualThan(CompiledExpressionExt left, CompiledExpressionExt right) {
        super(BinaryOperator.LE, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }
}
