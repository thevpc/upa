package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.expressions.BinaryOperator;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;

public final class CompiledGreaterThan extends CompiledBinaryOperatorExpression
        implements Cloneable {
    private static final long serialVersionUID = 1L;

    public CompiledGreaterThan(CompiledExpressionExt left, Object right) {
        super(BinaryOperator.GT, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }

    public CompiledGreaterThan(CompiledExpressionExt left, CompiledExpressionExt right) {
        super(BinaryOperator.GT, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }

}
